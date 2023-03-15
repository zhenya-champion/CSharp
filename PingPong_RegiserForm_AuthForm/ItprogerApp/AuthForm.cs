using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace ItprogerApp
{
    public partial class AuthForm : Form
    {
        // К каким элементам обращаемся
        public AuthForm()
        {
            InitializeComponent();
            UserLoginField.Text = "Введите имя";
            UserPasswordField.Text = "Введите пароль";
        }

        public void TextBox_Enter(object sender, EventArgs eventArgs)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "Введите имя")
            {
                UserLoginField.Text = "";
                UserLoginField.ForeColor = Color.White;
            }
            
            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "Введите пароль")
            {
                UserPasswordField.Text = "";
                UserPasswordField.UseSystemPasswordChar = true;
                UserPasswordField.ForeColor = Color.White;
            }
        }

        public void TextBox_Leave(object sender, EventArgs eventArgs)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "")
            {
                UserLoginField.Text = "Введите имя";
                UserLoginField.ForeColor = Color.Gray;
            }
           
            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "")
            {
                UserPasswordField.Text = "Введите пароль";
                UserPasswordField.UseSystemPasswordChar = false;
                UserPasswordField.ForeColor = Color.Gray;
            }
        }

        // Метод авторизации
        private void AuthBtn_Click(object sender, EventArgs e)
        {
            //Проверяем что введено
            if (UserLoginField.Text.Trim() == "" || UserLoginField.Text.Trim() == "Введите имя")
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (UserPasswordField.Text.Trim() == "" || UserPasswordField.Text.Trim() == "Введите пароль")
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }

            // Создаем объект и выполняем проверку
            DB db = new DB();
            MySqlCommand command = new MySqlCommand(
                //Подсчитываем поля
                "SELECT COUNT(id) FROM users WHERE login = @login AND password = @password",
                db.GetConnection()
            );
            // Подставляем данные которые ввел пользователь
            command.Parameters.AddWithValue("login", UserLoginField.Text);
            command.Parameters.AddWithValue("password", Hash(UserPasswordField.Text));

            db.OpenConnection(); // Подключение

            int countUser = Convert.ToInt32(command.ExecuteScalar());

            // Проверка на существование
            if (countUser > 0)
            {
                this.Hide(); // Прячем
                PingPong pingPong = new PingPong(); // Открываем другое окно
                pingPong.ShowDialog(); // Появляется новое окно
                this.Close(); // Закрываем текущее окно
            }
            else MessageBox.Show("User not exists");

            db.CloseConnection(); // Отключение
        }

        // Хеш пароля
        private string Hash(string input)
        {
            byte[] temp = Encoding.UTF8.GetBytes(input);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(temp);
                return Convert.ToBase64String(hash);
            }
        }

        // При загрузке формочки
        private void AuthForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        // Переход на другую страницу
        private void LinkToReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Прячем
            RegisterForm registerForm = new RegisterForm(); // Открываем другое окно
            registerForm.ShowDialog(); // Появляется новое окно
            this.Close(); // Закрываем текущее окно
        }
    }
}
