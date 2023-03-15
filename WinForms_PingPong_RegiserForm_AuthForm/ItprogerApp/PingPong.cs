using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItprogerApp
{
    public partial class PingPong : Form
    {

        private int _speedVer = 5, _speedHor = 5, _platformSpeed = 15; // характеристики мяча и платформы

        private int _score = 0; // Общий счет игры

        public PingPong()
        {
            InitializeComponent();
            // Cursor.Hide(); // Скрываем курсор
        }

        // При нажатии
        private void PingPong_KeyDown(object sender, KeyEventArgs e)
        {
            // Отслеживаем что нажали
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && Platform.Left > GamePanel.Left)
                Platform.Left -= _platformSpeed; // Меняем позицию платформы влево
            else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && Platform.Right < GamePanel.Right)
                Platform.Left += _platformSpeed; // Меняем позицию платформы вправо

            // Перезапуск игры
            else if(e.KeyCode == Keys.R && !timer.Enabled) // Только если таймер отключен
            {
                Random random = new Random(); // Случайное число
                GameBall.Top = random.Next(20, 300); // Координата мяча
                GameBall.Left = random.Next(20, 500); // Координата мяча
                _score = 0; // Счет
                LoseLabel.Visible = false; // Видимость надписи
                ResultLabel.Text = "Результат: 0"; // Окно результата
                timer.Enabled = true; // Запускаем игру
            }
        }

        // Мяч
        private void timer_Tick(object sender, EventArgs e)
        {
            GameBall.Left -= _speedHor;
            GameBall.Top -= _speedVer;

            // Проверка верхняя граница
            if (GameBall.Top <= GamePanel.Top)
                _speedVer *= -1; // Отбивается
            // Проверка нижняя граница
            if (GameBall.Bottom >= GamePanel.Bottom)
            {
                timer.Enabled = false; // Игра остановлена
                LoseLabel.Visible = true; // Видимость подписи проигрыша
            }
            // Проверка правая граница
            if (GameBall.Right >= GamePanel.Right)
                _speedHor *= -1; // Отбивается
            // Проверка левая граница
            if (GameBall.Left <= GamePanel.Left)
                _speedHor *= -1; // Отбивается

            // Отбитие от платформы
            if (GameBall.Bottom >= Platform.Top && 
                GameBall.Left >= Platform.Left && GameBall.Right <= Platform.Right)
            {
                _speedVer *= -1;
                _score++; // Счёт
                ResultLabel.Text = "Результат: " + _score; // Строка результат отбития
                Random random = new Random(); // Случайное число 
                // Меняем задний фон после отбития
                GamePanel.BackColor = Color.FromArgb(random.Next(150, 255), random.Next(150, 255), random.Next(150, 255));
            }
        }

    }
}
