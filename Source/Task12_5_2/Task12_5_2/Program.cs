using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_5_2
{
    class Program
    {
        public struct InfoSort
        {
            public SortRes SortOfBinaryTree;
            public SortRes SortOfMixing;

            public InfoSort(SortRes SortOfBinaryTree, SortRes SortOfMixing)
            {
                this.SortOfBinaryTree = SortOfBinaryTree;
                this.SortOfMixing = SortOfMixing;
            }
        }


        private static List<double> _array;

        public static double[] Array { get { return _array.ToArray(); } }
        public static InfoSort ArrayInfoSort
        {
            get { return new InfoSort(Sort.SortOfBinarryTree(Array), Sort.SortOfMixing(Array)); }
        }

        public static double[] SortArray
        {
            get
            {
                List<double> dopArray = new List<double>(_array.ToArray());
                dopArray.Sort();
                return dopArray.ToArray();
            }
        }
        public static InfoSort SortArrayInfoSort
        {
            get
            {
                return new InfoSort(Sort.SortOfBinarryTree(SortArray), Sort.SortOfMixing(SortArray));
            }
        }


        public static double[] ReversSortArray
        {
            get
            {

                List<double> dopArray = new List<double>(_array.ToArray());
                dopArray.Sort();
                dopArray.Reverse();
                return dopArray.ToArray();
            }
        }
        public static InfoSort ReversSortArrayInfoSort
        {
            get
            {
                return new InfoSort(Sort.SortOfBinarryTree(ReversSortArray), Sort.SortOfMixing(ReversSortArray));
            }
        }


        static void Main(string[] args)
        {
            Initialize();

            Menu menu = new Menu();
            menu.MainMenu();
        }

        static void Initialize()
        {
            _array = new List<double>();
        }

        public static void RandomArray(int size)
        {
            if (size < 0)
                throw new ArgumentException("Массив не может состоять из отрицательного количества элементов");

            _array = new List<double>();

            if (size == 0)
                return;

            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                _array.Add(rand.Next(1000));
            }
        } 

        public static void SetArray(double[] array)
        {
            _array = new List<double>(array);
        }

    }
}
