using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUpgraded
{
    public static class UpgradedConsole
    {
        #region Для ввода

        public static bool GetYesOrNo()
        {
            System.Console.WriteLine("1. Да\n2. Нет");
            int input = GetInt(1, 2);
            if (input == 1)
                return true;
            else
                return false;
        }

        #region GetDouble

        public static double GetDouble()
        {
            double res;
            while (true)
            {
                if (double.TryParse(System.Console.ReadLine().Replace('.',','), out res))
                    return res;
                else System.Console.WriteLine("Введите число");
            }
        }

        public static double GetDouble(double leftLimit)
        {
            while (true)
            {
                double res = GetDouble();
                if (res >= leftLimit)
                    return res;
                else System.Console.WriteLine($"Значение не может быть меньше {leftLimit}");
            }
        }

        public static double GetDouble(double numberStart, double numberEnd)
        {
            if (numberEnd < numberStart)
                throw new ArgumentException("Число для начала отсчета не может быть больше числа конца отсчета");
            while (true)
            {
                double res = GetDouble();
                if (res >= numberStart && res <= numberEnd)
                    return res;
                else System.Console.WriteLine($"Значение не может быть меньше {numberStart} и больше {numberEnd}");
            }
        }

        #endregion

        #region GetInt

        public static int GetInt()
        {
            int res;
            while (true)
            {
                if (int.TryParse(System.Console.ReadLine(), out res))
                    return res;
                else System.Console.WriteLine("Введите целое число");
            }
        }

        public static int GetInt(int leftLimit)
        {
            while (true)
            {
                int res = GetInt();
                if (res >= leftLimit)
                    return res;
                else System.Console.WriteLine($"Значение не может быть меньше {leftLimit}");
            }
        }

        public static int GetInt(int numberStart, int numberEnd)
        {
            if (numberEnd < numberStart)
                throw new ArgumentException("Число для начала отсчета не может быть больше числа конца отсчета");
            while (true)
            {
                int res = GetInt();
                if (res >= numberStart && res <= numberEnd)
                    return res;
                else System.Console.WriteLine($"Значение не может быть меньше {numberStart} и больше {numberEnd}");
            }
        }

        #endregion

        public static string GetStringNotEmpty()
        {
            string res;
            while (string.IsNullOrWhiteSpace(res = System.Console.ReadLine()))
            {
                System.Console.WriteLine("Введите что-нибудь");
            }
            return res;
        }

        #endregion
    }
}
