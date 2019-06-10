using System;
using System.IO;


namespace Task2_Fast_Train
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int number = int.Parse(reader.ReadLine());
            string[] line, dop;
            string max="";
            TimeSpan ts, ts1, res;
            res = new TimeSpan(1,0,0,1);
            for (int i=0;i<number;i++)
            {
                line = reader.ReadLine().Split('"');
                dop = line[2].Split(' ');
                line = new string[] { line[1], dop[1], dop[2] };
                ts = TimeSpan.Parse(line[1]);
                ts1 = TimeSpan.Parse(line[2]);
                if (ts >= ts1)
                    ts1=ts1.Add(new TimeSpan(1,0,0,0));
                ts = ts1 - ts;
                if (ts<res)
                {
                    res = ts;
                    max = line[0];
                }
            }
            reader.Close();
            writer.Write($"The fastest train is \"{max}\".\r\nIts speed is {(Math.Round(650 / res.TotalMinutes * 60))} km/h, approximately.");
            writer.Close();
        }
    }
}