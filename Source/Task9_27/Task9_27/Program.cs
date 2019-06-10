using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;
using ConsoleUpgraded;

namespace Task9_27
{
    class MyListItem<T>
    {
        public MyListItem<T> nextElem;
        public T elem;

        public MyListItem() { }
        public MyListItem(T elem)
        {
            this.elem = elem;
        }

    }

    class MyListInt
    {

        MyListItem<int> startElem;
        public int Count
        {
            get
            {
                if (startElem == null)
                    return 0;
                int sum = 1;
                MyListItem<int> item = startElem;
                while (item.nextElem != null)
                {
                    sum++;
                    item = item.nextElem;
                }
                return sum;
            }
        }
        public int this[int index]
        {
            get
            {
                return GetItem(index).elem;
            }
            set
            {
                GetItem(index).elem = value;
            }
        }

        public MyListItem<int> GetItem(int index)
        {
            if (Count == 0||index>=Count)
                throw new ArgumentOutOfRangeException();

            MyListItem<int> item = startElem;

            for (int i=0; i<index; i++)
            {
                item = item.nextElem;
            }

            return item;
        }

        public void Add(int elem)
        {
            MyListItem<int> newElem = new MyListItem<int>(elem);

            if (startElem == null)
                startElem = newElem;
            else
                GetItem(Count - 1).nextElem = newElem;
        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                if (startElem.nextElem == null)
                    startElem = null;
                else startElem = startElem.nextElem;
            }
            else if (index == Count - 1)
                GetItem(index - 1).nextElem = null;
            else GetItem(index - 1).nextElem = GetItem(index + 1);
        }

        public bool Remove(int elem)
        {
            if (Count == 0)
                return false;

            for(int i=0; i<Count; i++)
            {
                if(elem.Equals(this[i]))
                {
                    if (i == 0)
                    {
                        if (startElem.nextElem == null)
                            startElem = null;
                        else startElem = startElem.nextElem;
                    }
                    else if (i == Count - 1)
                        GetItem(i - 1).nextElem = null;
                    else GetItem(i - 1).nextElem = GetItem(i + 1);

                    return true;
                }
            }

            return false;
        }

        public int sumAllPlus()
        {
            int res = 0;
            for(int i=0; i<Count; i++)
            {
                if (this[i] > 0)
                    res += this[i];
            }
            return res;
        }
        public int sumAllMinus()
        {
            int res = 0;
            for (int i = 0; i < Count; i++)
            {
                if (this[i] < 0)
                    res += this[i];
            }
            return res;
        }

        public string[] Show()
        {
            string[] res = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                res[i] = this[i].ToString();
            }
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyListInt myListInt = new MyListInt();
            string[] itemsMenu = {"Добавить элемент", "Удалить элемент", "Показать",
                "Найти сумму всех положительных элементов", "Найти сумму всех отрицательных элементов", "Выход" };
            bool end = false;

            do
            {
                int choice = ConsoleMenu.Show(itemsMenu);

                switch (choice)
                {
                    case 0: AddItem(myListInt); break;
                    case 1: RemoveItem(myListInt); break;
                    case 2: ShowItems(myListInt); break;
                    case 3: SumAllPlus(myListInt); break;
                    case 4: SumAllMinus(myListInt); break;
                    case 5: end = true; break;
                }
            } while (!end);
        }

        static void AddItem(MyListInt myList)
        {
            Console.WriteLine("Введите число, которое необходимо добавить");
            myList.Add(UpgradedConsole.GetInt());
        }
        static void RemoveItem(MyListInt myList)
        {
            if (myList.Count == 0)
            {
                Console.WriteLine("Массив пуст");
                Console.ReadKey();
                return;
            }

            int choice = ConsoleMenu.Show(myList.Show());
            myList.RemoveAt(choice);
        }
        static void ShowItems(MyListInt myList)
        {
            if(myList.Count==0)
            {
                Console.WriteLine("Массив пуст");
                Console.ReadKey();
                return;
            }

            for(int i=0; i<myList.Count; i++)
            {
                Console.WriteLine($"{i+1}. " + myList[i]);
            }
            Console.ReadKey();
        }
        static void SumAllPlus(MyListInt myList)
        {
            if (myList.Count == 0)
            {
                Console.WriteLine("Массив пуст");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Сумма всех положительных элементов массива");
            Console.WriteLine(myList.sumAllPlus());
            Console.ReadKey();
        }
        static void SumAllMinus(MyListInt myList)
        {
            if (myList.Count == 0)
            {
                Console.WriteLine("Массив пуст");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Сумма всех отрицательных элементов массива");
            Console.WriteLine(myList.sumAllMinus());
            Console.ReadKey();
        }
    }
}
