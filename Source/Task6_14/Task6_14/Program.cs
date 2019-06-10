using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUpgraded;

namespace Task6_14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> a = new List<double>();    //Последовательность a
            int n;  //Количество элементов последовательности, которые необходимо добавить

            Console.WriteLine("Введите a1");
            a.Add(UpgradedConsole.GetDouble());
            Console.WriteLine("Введите a2");
            a.Add(UpgradedConsole.GetDouble());
            Console.WriteLine("Введите a3");
            a.Add(UpgradedConsole.GetDouble());
            Console.WriteLine("Введите N");
            n = UpgradedConsole.GetInt(1);
            n += a.Count; //ставим номер элемента, по который необходимо найти последовательсть
            Console.WriteLine();  //Разделяем для красоты:)

            Console.Write($"Последовательность:\n{a[0]}; {a[1]}; {a[2]}");

            for (int i = 3; i < n; i++)
            {
                a.Add((a[i - 1] + a[i - 2]) / 2 - a[i - 3]);
                Console.Write($"; {a[i]}");
            }

            Console.WriteLine(); Console.WriteLine();  //Разделяем для красоты:)

            List<double> res = MaxIncrementingSubsequence(a);   //Получаем максимальную подпоследовательность

            Console.WriteLine("Длина максимальной подпоследовательности: " + res.Count +"\n");

            Console.WriteLine("Последний элемент подпоследовательности: " + res[res.Count - 1]+"\n");

            Console.WriteLine("Максимальная подпоследовательность:");
            Console.Write(res[0]);
            for (int i = 1; i < res.Count; i++)
                Console.Write("; " + res[i]);
            
            Console.ReadKey();
        }

        static List<double> MaxIncrementingSubsequence(List<double> sequence)
        {
            List<double> res=new List<double>();
            for(int i=0; i<sequence.Count; i++)
            {
                List<double> subSequence = MaxIncrementingSubsequence(sequence, i);
                subSequence.Add(sequence[i]);
                if (subSequence.Count > res.Count)
                    res = subSequence;
            }
            res.Reverse();
            return res;
        }
        static List<double> MaxIncrementingSubsequence(List<double> sequence, int startIndex)
        {
            List<double> res = new List<double>();
            for(int i=startIndex+1; i<sequence.Count; i++)
            {
                if (sequence[i] > sequence[startIndex])
                {
                    List<double> subSequence = MaxIncrementingSubsequence(sequence, i);
                    subSequence.Add(sequence[i]);
                    if (subSequence.Count > res.Count)
                        res = subSequence;
                }
            }

            if (res.Count != 0)
                return res;
            else return new List<double>();
        }
    }
}
