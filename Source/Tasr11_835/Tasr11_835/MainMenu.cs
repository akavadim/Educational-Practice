using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;
using ConsoleUpgraded;

namespace Tasr11_835
{
    class MainMenu
    {
        public void HeadMenu()
        {
            string[] itemsMenu = { "Изменить сдвиг", "Зашифровать", "Расшифровать", "Выход" };
            bool end = false;

            while (!end)
            {
                string headLine = "Установленный сдвиг: " + Program.Shift;

                int choice = ConsoleMenu.Show(headLine, itemsMenu);
                switch (choice)
                {
                    case 0: ChangeShift(); break;
                    case 1: Encrypt(); break;
                    case 2: Decrypt(); break;
                    case 3: end = true; break;
                }
            }
        }

        public void ChangeShift()
        {
            Console.WriteLine("Введите новый сдвиг");
            Program.Shift = UpgradedConsole.GetInt();
        }

        public void Encrypt()
        {
            Console.WriteLine("Введите строку, куоторую необходимо зашифровать");
            string line = UpgradedConsole.GetStringNotEmpty();
            Console.WriteLine("Зашифрованная строка:");
            Console.WriteLine(Program.Encrypt(line));
            Console.ReadKey();
        }

        public void Decrypt()
        {
            Console.WriteLine("Введите строку, куоторую необходимо расшифровать");
            string line = UpgradedConsole.GetStringNotEmpty();
            Console.WriteLine("Расшифрованная строка:");
            Console.WriteLine(Program.Decrypt(line));
            Console.ReadKey();
        }
    }
}
