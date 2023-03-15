using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ItprogerApp
{
    public partial class RegisterForm : Form
    {
        // К каким элементам обращаемся
        public RegisterForm()
        {
            InitializeComponent();

            UserLoginField.Text = "Введите имя";
            UserEmailField.Text = "Введите email";
            UserPasswordField.Text = "Введите пароль";
            this.Text = "Регистрация в программе"; // Название окна
        }

        // При нажатии на нужный бокс убираются подсказки, текст остается
        public void TextBox_Enter(object sender, EventArgs eventArgs)
        {
            if(((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "Введите имя")
            {
                UserLoginField.Text = "";
                UserLoginField.ForeColor = Color.White;
            }
            if (((TextBox)sender).Name == "UserEmailField" && UserEmailField.Text.Trim() == "Введите email")
            {
                UserEmailField.Text = "";
                UserEmailField.ForeColor = Color.White;
            }
            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "Введите пароль")
            {
                UserPasswordField.Text = "";
                UserPasswordField.UseSystemPasswordChar = true;
                UserPasswordField.ForeColor = Color.White;
            }
        }

        // Когда забрали курсор подсказки появляются
        public void TextBox_Leave(object sender, EventArgs eventArgs)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "")
            {
                UserLoginField.Text = "Введите имя";
                UserLoginField.ForeColor = Color.Gray;
            }
            if (((TextBox)sender).Name == "UserEmailField" && UserEmailField.Text.Trim() == "")
            {
                UserEmailField.Text = "Введите email";
                UserEmailField.ForeColor = Color.Gray;
            }
            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "")
            {
                UserPasswordField.Text = "Введите пароль";
                UserPasswordField.UseSystemPasswordChar = false;
                UserPasswordField.ForeColor = Color.Gray;
            }
        }

        // Регистрация при нажатии на кнопку
        private void RegBtn_Click(object sender, EventArgs e)
        {
            // Проверка на ввод
            if(UserLoginField.Text.Trim() == "" || UserLoginField.Text.Trim() == "Введите имя")
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }

            if (UserEmailField.Text.Trim() == "" || UserEmailField.Text.Trim() == "Введите email")
            {
                MessageBox.Show("Вы не ввели email");
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
                "INSERT INTO users (login, password, email) VALUES(@login, @password, @email)", 
                db.GetConnection()
            );
            // Подставляем данные которые ввел пользователь
            command.Parameters.AddWithValue("login", UserLoginField.Text);
            command.Parameters.AddWithValue("password", Hash(UserPasswordField.Text));
            command.Parameters.AddWithValue("email", UserEmailField.Text);

            db.OpenConnection(); // Открываем соединение

            // Проверка на существование пользователя
            try
            {
                if (command.ExecuteNonQuery() == 1) MessageBox.Show("Аккаунт создан");
                else MessageBox.Show("Ошибка при выполнения");
            } catch (MySqlException ex) {
                if (ex.Message.Contains("Duplicate entry")) MessageBox.Show("Видимо такой логин уже есть");
                else MessageBox.Show(ex.Message); 
            }

            db.CloseConnection(); // Закрываем соединение
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
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        // Переход на другую страницу
        private void LinkToAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();// Прячем
            AuthForm authForm = new AuthForm(); // Открываем другое окно
            authForm.ShowDialog(); // Появляется новое окно
            this.Close(); // Закрываем текущее окно
        }
    }
}
