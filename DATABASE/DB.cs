using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;


namespace database;

class DB{
    private const string HOST = "localhost";
    private const string PORT = "3306";
    private const string DATABASE = "zhenya";
    private const string USER = "root";
    private const string PASS = "";
    private string connect;

    //Значения подключения
    public DB(){
        connect = $"Server={HOST};User={USER};Password={PASS};Database={DATABASE};Port={PORT};";
    }

    //Создаем таблицу
    public async Task CreateTable(){
        string sql = "CREATE TABLE IF NOT EXISTS `users` (" +
            "id  INT(11) AUTO_INCREMENT PRIMARY KEY," +
            "login VARCHAR(50)," +
            "password VARCHAR(50)" +
            ") ENGINE=MYISAM";
        await ExecuteQuery(sql); // дожидаемся пока метод выполниться (подключение)
    }

    //Добавление записей
    public async Task InsertData(string? title, string? text, string? date, string? avtor){

        string sql = "INSERT INTO `articles` (title, text, date, avtor) VALUES (@title, @text, @date, @avtor)";
        Dictionary<string, string?> parametrs = new Dictionary<string, string?>(); // словарь из наших значений
        parametrs.Add("title", title);
        parametrs.Add("text", text);
        parametrs.Add("date", date);
        parametrs.Add("avtor", avtor);
        await ExecuteQuery(sql, parametrs); // дожидаемся пока метод выполниться (подключение)
    }

    //Соединение с БД и подключение
    private async Task ExecuteQuery(string sql, Dictionary<string, string?>? parametrs = null){
        using(MySqlConnection conn = new MySqlConnection(connect)){ // подключение к БД

            await conn.OpenAsync(); // открываем соединение
            MySqlCommand command = new MySqlCommand(sql, conn); // подготавливаем команду

            // проверяем написано ли что-то в словаре
            if(parametrs != null){
                foreach(var el in parametrs){
                    MySqlParameter param = new MySqlParameter($"@{el.Key}", el.Value); // перебираем 
                    command.Parameters.Add(param); // подставляем
                }
            }
            await command.ExecuteNonQueryAsync(); // выполняем комманду и дожидаемся
        }
    }

    // Получение записей из таблицы
    public async Task GetData(int number){
        using(MySqlConnection conn = new MySqlConnection(connect)){ // подключение к БД

            await conn.OpenAsync(); // открываем соединение

            MySqlCommand command = new MySqlCommand("SELECT * FROM `articles` WHERE title LIKE '%oo%' OR id >= @number  ORDER BY id DESK LIMIT 2 OFFSET 1", conn); // подготавливаем команду

            // получение от пользователя
            MySqlParameter param = new MySqlParameter($"@number", number); // перебираем 
            command.Parameters.Add(param); // подставляем

            MySqlDataReader reader = (MySqlDataReader) await command.ExecuteReaderAsync(); // выполняет команду и возвращает и далее перебираем

            if(reader.HasRows){ // HasRows - возвращает true
                while(await reader.ReadAsync()){ // ReadAsync - прочитать таблицу построчно 
                    object id = reader["id"]; // получение поля
                    object title = reader["title"];
                    object text = reader["text"];
                    object date = reader["date"];
                    object avtor = reader["avtor"];
                    
                    System.Console.WriteLine($"{id}. {title} - {avtor}");
                } 
            }
           await reader.CloseAsync(); // закрытие считывания
        }
    }

    // Обновление
    public async Task UpdateData(string? title, string? text, string? date, string? avtor){

        string sql = "UPDATE `articles` SET title = @title, text = @text, date = @date, avtor = @avtor WHERE id = 2";
        Dictionary<string, string?> parametrs = new Dictionary<string, string?>(); // словарь из наших значений
        parametrs.Add("title", title);
        parametrs.Add("text", text);
        parametrs.Add("date", date);
        parametrs.Add("avtor", avtor);
        await ExecuteQuery(sql, parametrs); // дожидаемся пока метод выполниться (подключение)
    }

    // Удаление
    public async Task DeleteData(){
        string sql = "DELETE FROM `articles` WHERE title = 'Tesla'"; // DROP TABLE articles - полностью удалить
        await ExecuteQuery(sql); // дожидаемся пока метод выполниться (подключение)
    }

    // Подсчет кол-во записей
    public async Task CountData(){
        string sql = "SELECT COUNT(id) FROM `articles`";

         using(MySqlConnection conn = new MySqlConnection(connect)){ // подключение к БД

            await conn.OpenAsync(); // открываем соединение

            MySqlCommand command = new MySqlCommand(sql, conn); // подготавливаем команду
            object? num = await command.ExecuteScalarAsync(); // возвращает точное значение
            System.Console.WriteLine(num);
         }
    }
}