using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUpgraded;
using Menu;

namespace Task8
{
    class Program
    {
        static int head;
        static List<(int start, int end)> Ribs;

        static bool contain(int start, int end)
        {
            if (start == end)
                return true;
            foreach(var rib in Ribs)
            {
                if (rib.end == end && rib.start == start)
                    return true;
            }
            return false;
        }
        static void Initialize()
        {
            head = 0;
            Ribs = new List<(int start, int end)>();
        }

        static void keybooarGraph()
        {
            Console.WriteLine("Введите количество вершин");
            Ribs = new List<(int start, int end)>();

            head = UpgradedConsole.GetInt(1);
            
            for(int i=0; i<head; i++)
            {
                int res;
                Console.WriteLine("Введите с какими ребрами соеденина вершина {0}, для завершшения нажмите N", i+1);
                string inputStr;
                while ((inputStr = UpgradedConsole.GetStringNotEmpty())[0] != 'n')
                {
                    try
                    {
                        res = int.Parse(inputStr);
                    }
                    catch
                    {
                        Console.WriteLine("Не число");
                        continue;
                    }
                    if (res < 1 || res > head)
                    {
                        Console.WriteLine("Значение не может быть больше 1 и меньше {0}", head);
                        continue;
                    }
                    if (contain(i + 1, res))
                        continue;
                    Ribs.Add((i + 1, res));
                    Ribs.Add((res, i + 1));
                }
            }
            Console.WriteLine("Готово!");
            Console.ReadKey();
        }
        static void autoGraph()
        {
            Random rand = new Random();
            Ribs = new List<(int start, int end)>();

            head = rand.Next(10,30);

            for (int i = 0; i < head; i++)
            {
                for(int j=0; j< head; j++)
                {
                    if (j == i)
                        continue;
                    if (rand.Next(0, 2) != 1)
                        continue;
                    if (contain(i + 1, j+1))
                        continue;
                    Ribs.Add((i + 1, j + 1));
                    Ribs.Add((j + 1, i + 1));
                }
            }
            Console.WriteLine("Сгенерирован случайный граф");
            Console.ReadKey();
        }

        static void SearchClickMenu()
        {
            if (Ribs.Count == 0)
            {
                Console.WriteLine("Нет графа");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Введите размер клики");
            int size = UpgradedConsole.GetInt(1);
            if (size == 1)
            {
                Console.WriteLine("Вершина: " + 1);
                Console.ReadKey();
                return;
            }

            if (size > head) {
                Console.WriteLine("Размер клики не может превышать количество вершин");
                Console.ReadKey();
                return;
                    } 

            int[] res = SearchClick(new List<int>(), size, size);
            if (res.Length != 0)
            {
                Console.WriteLine("Вершины:");
                foreach(int r in res)
                {
                    Console.Write(r + " ");
                }
            }
            else
            {
                Console.WriteLine("Такой клики нет");
            }
            Console.ReadKey();

        }

        static int[] SearchClick(List<int> Heads, int startSize ,int size)
        {
            if (Heads.Count == 0)
            {
                for(int i=1; i<= head; i++)
                {
                    List<int> newL = new List<int>();
                    newL.Add(i);
                    int[] res = SearchClick(newL, startSize, size);
                    if (res.Length == startSize)
                        return res;
                }
                return new int[0];
            }
            int currentHead = Heads.Last();
            var gran = from r in Ribs
                       where r.start == currentHead
                       select r.end;
            foreach(int h in Heads)
            {
                if (!gran.Contains(h) && h!=currentHead)
                {
                    return new int[0];
                }
            }

            if (size == 1)
                return Heads.ToArray();
            foreach(int g in gran)
            {
                if (!Heads.Contains(g))
                    {
                    List<int> headsNew = Heads.ToList();
                    headsNew.Add(g);
                    int[] res = SearchClick(headsNew, startSize, size - 1);

                    if (res.Length == startSize)
                        return res;
                }
            }

            return new int[0];
        }

        static void ShowItem()
        {
            if(Ribs.Count==0)
            {
                Console.WriteLine("Нет графа");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Количество вершин: " + head);
            Console.WriteLine("Соединенные вершины");
            foreach(var item in Ribs)
            {
                Console.WriteLine(item.start + " " + item.end);
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Initialize();

            string[] items = { "Задать граф с кллавиатуры", "Задать граф генератором", "Найти клику", "Вывести вершины", "Выход" };
            bool end = false;

            while (!end)
            {
                int choice = ConsoleMenu.Show(items);
                switch (choice)
                {
                    case 0: keybooarGraph(); break;
                    case 1: autoGraph(); break;
                    case 2: SearchClickMenu(); break;
                    case 3: ShowItem(); break;
                    case 4: end = true; break;
                }
            }
        }
    }
}
