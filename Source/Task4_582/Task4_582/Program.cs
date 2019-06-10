using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_582
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Найти последовательность десятичных чисел числа 2^(-200)");

            int[] bit = MinusPow(2, 200);

           foreach(int b in bit)
            {
                Console.Write(b);
            }

            Console.ReadKey();
        }
        
        static int[] MinusPow(int x, int y)
        {
            List<int> byts = new List<int>();

            byts.Add(1);

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < byts.Count; j++)
                {
                    if (byts[j] % x != 0)
                    {
                        try
                        {
                            byts[j + 1] += ((byts[j] % x) * 10);
                        }
                        catch
                        {
                            byts.Add(((byts[j] % x) * 10));

                        }
                    }
                    byts[j] = (byts[j] / x);
                }
            }

            return byts.ToArray();
        }
    }
}
