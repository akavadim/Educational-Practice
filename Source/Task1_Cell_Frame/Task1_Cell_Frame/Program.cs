using System.IO;

namespace Task1_Cell_Frame
{
    class Program
    {
        static void Main()
        {
            StreamReader r = new StreamReader("input.txt");
            StreamWriter w = new StreamWriter("output.txt");
            int t = int.Parse(r.ReadLine());
            for(int i = 0; i <t; i++)
            {
                string[] l = r.ReadLine().Split(' ');
                w.Write(GetResult(int.Parse(l[0]), int.Parse(l[1]), int.Parse(l[2])));
            }
            r.Close(); w.Close();
        }
        static public int GetResult(int x, int y, int a)
        {
            if (CheckFrame(x, y, a) == 1)
                return 1;
            else if (CheckFrame(y, x, a) == 1)
                return 1;
            return 0;
        }
        public static int CheckFrame(int x, int y, int a)
        {
            int oct = x % a;
            if (oct > 1)
                return 0;
            oct = (y - 1 + oct) % a;
            if (oct > 1)
                return 0;
            oct = (x - 1 + oct) % a;
            if (oct > 1)
                return 0;
            oct = (y - 2 + oct) % a;
            if (oct == 0)
                return 1;
            else return 0;
        }
    }
}
