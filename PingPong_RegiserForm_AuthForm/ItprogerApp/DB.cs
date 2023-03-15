using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ItprogerApp
{
    internal class DB
    {
        // Подключение
        MySqlConnection db = new MySqlConnection("server=localhost;" +
            "port=3306;username=root;password=;database=winforms");

        // Открываем если закрыто
        public void OpenConnection()
        {
            if(db.State == System.Data.ConnectionState.Closed)
                db.Open();
        }

        // Закрываем если открыто
        public void CloseConnection()
        {
            if (db.State == System.Data.ConnectionState.Open)
                db.Close();
        }

        // Возвращаем подключение
        public MySqlConnection GetConnection()
        {
            return db;
        }
    }
}
