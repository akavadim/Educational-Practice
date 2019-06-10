using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUpgraded;

namespace Task11_14_533B
{
    class Program
    {
        static void Main(string[] args)
        {
            const string info = "Программа вычисляет (X1+X2+2Xn)(X2+X3+2*X(n-1))...(X(n-1)+Xn+2*X2)";
            Console.WriteLine(info);
            int n;
            List<double> x = new List<double>();

            Console.WriteLine("Введите N, то есть сколько будет элементов в Xn");
            n = UpgradedConsole.GetInt(2);

            Console.WriteLine("Вводите элементы, ввод закоончится, как только вы введете все элементы");
            for(int i=0; i < n; i++)
            {
                x.Add(UpgradedConsole.GetDouble());
            }

            Console.WriteLine("Результат: " + GetResSequence(x.ToArray()));
            Console.ReadKey();

        }

        static double GetResSequence(double[] sequence)
        {
            int indexOne = 0;
            int indexTwo = 1;
            int indexN = sequence.Length-1;
            double res = sequence[indexOne] + sequence[indexTwo] + 2 * sequence[indexN];

            while (indexTwo!=sequence.Length-1)
            {
                indexOne++;
                indexTwo++;
                indexN--;
                res *= (sequence[indexOne] + sequence[indexTwo] + 2 * sequence[indexN]);
            }
            return res;
        }
    }
}
