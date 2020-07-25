using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ANS
{
    static class Program
    {
        static public Form Shell; // Указатель на основную форму программы.
        static public Boolean UseShell; // Флаг, отвечающий за всплытие основного окна.

        /// <summary>
        /// Точка входа для приложения Artificial NS.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormANS());
        }
    }
}