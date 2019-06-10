using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Cell_Frame
{
    class Test
    {
        public void start()
        {
            for(int i=3;i<30;i++)
                for(int j=3;j<30;j++)
                    for(int k=1;k<30;k++)
                    {
                        if (Program.res(i, j, k) != res(i, j, k))
                            Console.WriteLine(i + ", " + j + ", " + k);
                    }
            Console.ReadKey();
        }
        
        public int res(int x, int y, int a)
        {
            if (a > x || a > y)
                return 0;
            if (rr(x, y, a) == 1)
                return 1;
            else if (rr(y, x, a) == 1)
                return 1;
            return 0;
        }
        public int rr(int x, int y, int a)
        {
            int oct = x % a;
            if (oct > 1)
                return 0;
            oct = (y-1 + oct) % a;
            if (oct > 1)
                return 0;
            oct = (x-1 + oct) % a;
            if (oct > 1)
                return 0;
            oct = (y-2 + oct) % a;
            if (oct == 0)
                return 1;
            else return 0;
        }
    }
}
