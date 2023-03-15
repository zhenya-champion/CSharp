using System;

namespace database;

class Program{
    public static async Task Main(){
        DB db = new DB();
        // System.Console.WriteLine("Enter title:");
        // string? title = Console.ReadLine();
        // System.Console.WriteLine("Enter text:");
        // string? text = Console.ReadLine();
        // System.Console.WriteLine("Enter date:");
        // string? date = Console.ReadLine();
        // System.Console.WriteLine("Enter avtor:");
        // string? avtor = Console.ReadLine();
        // await db.UpdateData(title, text, date, avtor); // дожидаемся подключения к БД
        // await db.DeleteData();
        await db.CountData();
    }
}