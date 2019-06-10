using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    /// <summary>
    /// Меню для коносли
    /// </summary>
    public class ConsoleMenu
    {
        /// <summary>
        /// Выбор происходит стрелками
        /// </summary>
        /// <param name="items">Пункт меню</param>
        /// <returns>Индекс выбранного элемента</returns>
        public static int Show(string[] items)
        {
            return Show("", items);
        }

        /// <summary>
        /// Выбор происходит стрелками
        /// </summary>
        /// <param name="items">Пункт меню</param>
        /// <param name="headline">Заголовок меню</param>
        /// <returns>Индекс выбранного элемента</returns>
        public static int Show(string headline, string[] items)
        {
            int CurrentItem = 0;
            if (items.Length == 0)
                throw new ArgumentException("В меню должен быть хотя бы один пункт");

            ConsoleKeyInfo keyInfo=new ConsoleKeyInfo();
            do
            {
                Console.Clear();

                if (headline.Length != 0)
                    Console.WriteLine(headline+'\n');

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (CurrentItem == 0)
                        CurrentItem = items.Length-1;
                    else CurrentItem--;
                }
                else if(keyInfo.Key==ConsoleKey.DownArrow)
                {
                    if (CurrentItem == items.Length-1)
                        CurrentItem = 0;
                    else
                        CurrentItem++;
                }

                for (int i = 0; i < items.Length; i++)
                {
                    if (i == CurrentItem)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(items[i]);
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine(items[i]);
                }
            } while ((keyInfo = Console.ReadKey()).Key != (ConsoleKey.Enter));
            return CurrentItem;
        }
    }
}
