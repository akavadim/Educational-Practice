using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr11_835
{
    class Program
    {
        public static int Shift;

        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.HeadMenu();
        }

        public static string Encrypt(string line)
        {
            return Cryptographer.Encrypt(line, Shift);
        }

        public static string Decrypt(string line)
        {
            return Cryptographer.Decrypt(line, Shift);
        }
    }
}
