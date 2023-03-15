using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItprogerApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // Стили
            Application.SetCompatibleTextRenderingDefault(false); // Значение поумолчанию
            Application.Run(new PingPong()); // Что запускаем
        }
    }
}
