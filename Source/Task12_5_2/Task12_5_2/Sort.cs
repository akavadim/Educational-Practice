using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_5_2
{
    public struct SortRes
    {
        public double[] arraySorted;
        public int numberOfMove;
        public int numberOfCompare;

        public override string ToString()
        {
            string res = "Результат: " + Menu.ArrayToString(arraySorted) +
                "\nКоличество перемещений: " + numberOfMove +
                "\nКоличество сравнений: " + numberOfCompare;

            return res;
        }
    }
    class BinaryTree
    {
        public BinaryTree() { }
        public BinaryTree(double Item)
        {
            this.Item = Item;
        }

        public BinaryTree Left, Right;
        public double Item;
    }
    class Sort
    {
        #region Сортировка бинарным деревом

        public static SortRes SortOfBinarryTree(double[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Массив не может быть пустым");

            (BinaryTree, SortRes) dopPer= CreateTreeForSort(array);
            BinaryTree binaryTree = dopPer.Item1;
            SortRes sortRes = dopPer.Item2;

            List<double> sortArray = new List<double>();
            BinaryTreeToSortArray(binaryTree, sortArray, sortRes);

            sortRes.arraySorted = sortArray.ToArray();

            return sortRes;
        }

        private static (BinaryTree, SortRes) CreateTreeForSort(double[] array)
        {
            SortRes sortRes = new SortRes();


            BinaryTree treeStart = new BinaryTree(array[0]);
            sortRes.numberOfMove++; //Перемещение элемента в предыдущей строке

            BinaryTree forCycle = treeStart;

            //Цикл сортировки по дереву
            for (int i = 1; i < array.Length; i++)
            {
                sortRes.numberOfCompare++;  //Сравнение в следующей строке
                if (array[i] < forCycle.Item)
                {
                    sortRes.numberOfCompare++;  //Сравнение в следующей строке
                    if (forCycle.Left == null)
                    {
                        forCycle.Left = new BinaryTree(array[i]);
                        sortRes.numberOfMove++; //Перемещение элемента в предыдущей строке
                        forCycle = treeStart;
                    }
                    else
                    {
                        forCycle = forCycle.Left;
                        i--;
                    }
                }
                else
                {
                    sortRes.numberOfCompare++;  //Сравнение в следующей строке
                    if (forCycle.Right == null)
                    {
                        forCycle.Right = new BinaryTree(array[i]);
                        sortRes.numberOfMove++; //Перемещение элемента в предыдущей строке
                        forCycle = treeStart;
                    }
                    else
                    {
                        forCycle = forCycle.Right;
                        i--;
                    }
                }

            }

            return (treeStart, sortRes);
        }

        /// <summary>
        /// Превращает бинарное дерево сортировки в отсорттированный массив
        /// </summary>
        /// <param name="tree">Дерево сортировки</param>
        /// <param name="array">В начале необходимо подать пустой лист, который и будет результатом</param>
        ///  /// <param name="sortRes">Сюда будут записываться количество перемещений</param>
        /// <returns></returns>
        private static void BinaryTreeToSortArray(BinaryTree tree, List<double> array, SortRes sortRes)
        {
            if (tree != null)
            {
                BinaryTreeToSortArray(tree.Left, array, sortRes);
                array.Add(tree.Item);
                sortRes.numberOfMove++; //Перемещение элемента в предыдущей строке
                BinaryTreeToSortArray(tree.Right, array, sortRes);
            }
        }

        #endregion

        #region Сортировка перемешивание

        public static SortRes SortOfMixing(double[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Массив не может быть пустым");

            int left = 0,
                right = array.Length - 1;
            SortRes sortRes = new SortRes();

            while (left < right)
            {
                for(int i=left; i<right; i++)
                {
                    sortRes.numberOfCompare++;
                    if (array[i] > array[i + 1])
                    {
                        sortRes.numberOfMove++;
                        double dop = array[i];
                        sortRes.numberOfMove++;
                        array[i] = array[i + 1];
                        sortRes.numberOfMove++;
                        array[i + 1] = dop;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    sortRes.numberOfCompare++;
                    if (array[i] < array[i - 1])
                    {
                        sortRes.numberOfMove++;
                        double dop = array[i];
                        sortRes.numberOfMove++;
                        array[i] = array[i - 1];
                        sortRes.numberOfMove++;
                        array[i - 1] = dop;
                    }
                }
                left++;
            }

            sortRes.arraySorted = array;

            return sortRes;
        }

        #endregion
    }
}
