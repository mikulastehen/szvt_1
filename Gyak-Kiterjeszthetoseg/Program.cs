using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyak_Kiterjeszthetoseg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul");
            //CsvProcessor p = new CsvProcessor();
            //p.Run();
            //MultilineTxtProcessor m = new MultilineTxtProcessor();
            //m.Run();
            MultilineTxtProcessorWithPercentageProgress n = new MultilineTxtProcessorWithPercentageProgress();
            n.Run();

        }
    }
}
