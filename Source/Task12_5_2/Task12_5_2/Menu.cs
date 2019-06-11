using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;
using ConsoleUpgraded;

namespace Task12_5_2
{
    class Menu
    {
        public void MainMenu()
        {
            string[] itemsMenu = { "Сгенерировать массив", "Ввести массив", "Отсортировать", "Выход" };

            bool end = false;
            while (!end)
            {
                string headline = $"Массив: {ArrayToString(Program.Array)}\n" +
                    $"Упорядоченный по возрастанию массив: {ArrayToString(Program.SortArray)}\n" +
                    $"Упорядоченный по убыванию массив: {ArrayToString(Program.ReversSortArray)}";
                int choice = ConsoleMenu.Show(headline, itemsMenu);

                try
                {
                    switch (choice)
                    {
                        case 0: RandomArray(); break;
                        case 1: KeyboardArray(); break;
                        case 2: SortArray(); break;
                        case 3: end = true; break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }

        private void RandomArray()
        {
            Console.WriteLine("Введите размер массива");
            int size = UpgradedConsole.GetInt(1);

            Program.RandomArray(size);

            Console.WriteLine("Готово!");
            Console.ReadKey();
        }

        private void KeyboardArray()
        {
            Console.WriteLine("Введите размер массива");
            int size = UpgradedConsole.GetInt(1);
            double[] array = new double[size];

            Console.WriteLine("Вводите элементы массива");
            for(int i=0; i<size; i++)
            {
                array[i] = UpgradedConsole.GetDouble();
            }

            Program.SetArray(array);

            Console.WriteLine("Готово");
            Console.ReadKey();
        }

        private void SortArray()
        {
            Program.InfoSort infoSort = Program.ArrayInfoSort;
            Console.WriteLine($"Массив\nСортировка с помощью двоичного кода:\n{infoSort.SortOfBinaryTree.ToString()}" +
                $"\nСортировка перемешиванием:\n{infoSort.SortOfMixing.ToString()}");

            infoSort = Program.SortArrayInfoSort;
            Console.WriteLine();
            Console.WriteLine($"Упорядоченный по возрастанию массив:\nСортировка с помощью двоичного кода:\n{infoSort.SortOfBinaryTree.ToString()}" +
                $"\nСортировка перемешиванием:\n{infoSort.SortOfMixing.ToString()}");

            infoSort = Program.ReversSortArrayInfoSort;
            Console.WriteLine();
            Console.WriteLine($"Упорядоченный по убыванию массив:\nСортировка с помощью двоичного кода:\n{infoSort.SortOfBinaryTree.ToString()}" +
                $"\nСортировка перемешиванием:\n{infoSort.SortOfMixing.ToString()}");

            Console.ReadKey();
        }

        public static string ArrayToString(double[] array)
        {
            if (array.Length == 0)
                return "Массив пуст";

            string res = array[0].ToString(); ;
            for (int i = 1; i < array.Length; i++)
            {
                res += "; " + array[i].ToString();
            }

            return res;
        }
    }
}
