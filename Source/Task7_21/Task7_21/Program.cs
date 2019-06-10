using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUpgraded;

namespace Task7_21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arange
            List<double> frequencies = new List<double>();
            SortedDictionary<string, double> keyBinaryValue;

            //Ввод данных
            Console.WriteLine("Вводите частоты символов для построения суффиксного кода " +
    "через Enter, ввод закончится, когда сумма частот будет равна 1");

            do
            {
                double inputFrequnce = UpgradedConsole.GetDouble(0, 1);
                if (Math.Round(inputFrequnce, 15) == 0)
                    Console.WriteLine("Частота не может равняться 0");
                else if (Math.Round(frequencies.Sum() + inputFrequnce, 15) > 1)
                    Console.WriteLine($"Сумма не может быть больше 1. " +
                        $"Максимальное для ввода число : {Math.Round(1 - frequencies.Sum(), 15)}");
                else frequencies.Add(inputFrequnce);
            } while (Math.Round(frequencies.Sum(), 15)!=1);

            //Строим префисный код Хаффмана
            keyBinaryValue= HuffmansAlgorithm(frequencies);

            Console.WriteLine("Cуффиксный код:\tЗначение:");
            while (keyBinaryValue.Count != 0)
            {
                int minElem = 0;
                for (int i = 0; i < keyBinaryValue.Count; i++)
                {
                    if (keyBinaryValue.Keys.ToArray()[i].Length < keyBinaryValue.Keys.ToArray()[minElem].Length)
                        minElem = i;
                }
                string key = keyBinaryValue.Keys.ToArray()[minElem];
                Console.WriteLine(key + "\t\t" + keyBinaryValue[key]);
                keyBinaryValue.Remove(key);
            }
            Console.ReadKey();
        }

        static SortedDictionary<string, double> HuffmansAlgorithm(List<double> frequence)
        {
            if (Math.Round(frequence.Sum(),15) != 1)
                throw new ArgumentException("Сумма частот должна в сумме давать 1");
            if (frequence.Count == 1)
            {
                var sd = new SortedDictionary<string, double>();
                sd.Add("0", 1);
                return sd;
            }

            List<BinaryTree> binaryTrees = new List<BinaryTree>();  //Бинарное дерево
            SortedDictionary<string, double> res = new SortedDictionary<string, double>();  //Словарь для результата

            frequence.Sort();

            foreach (double f in frequence) 
                binaryTrees.Add(new BinaryTree() { elem = f });
            BinaryTree[] copyBinaryTree = binaryTrees.ToArray();

            while (binaryTrees.Count!=1)
            {
                BinaryTree newTree = new BinaryTree();

                newTree.Left = BinaryTreeMinimum(binaryTrees.ToArray());
                binaryTrees.Remove(newTree.Left);
                newTree.Left.UpTree = newTree;

                newTree.Right = BinaryTreeMinimum(binaryTrees.ToArray());
                binaryTrees.Remove(newTree.Right);
                newTree.elem = Math.Abs(newTree.Left.elem + newTree.Right.elem);
                newTree.Right.UpTree = newTree;

                binaryTrees.Add(newTree);
            }

            for(int i=0; i<copyBinaryTree.Length; i++)
            {
                double value = copyBinaryTree[i].elem;
                string key = "";
                do
                {
                    BinaryTree upTree = copyBinaryTree[i].UpTree;
                    if (upTree.Left == copyBinaryTree[i])
                        key += "1";
                    else if (upTree.Right == copyBinaryTree[i])
                        key += "0";
                    else throw new Exception("Я ошибся где то в коде, это не пофиксить");
                    copyBinaryTree[i] = copyBinaryTree[i].UpTree;
                } while (copyBinaryTree[i].elem != 1);
                res.Add(key, value);
            }
            return res;
        }

        static BinaryTree BinaryTreeMinimum(BinaryTree[] trees)
        {
            BinaryTree min = trees[0];
            foreach (BinaryTree tree in trees)
                if (tree.elem < min.elem)
                    min = tree;
            return min;
        }
    }

    class BinaryTree
    {
        public BinaryTree Left;
        public BinaryTree Right;
        public BinaryTree UpTree;

        public double elem;
    }
}
 