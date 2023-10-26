using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gyak_Kiterjeszthetoseg.Progress;

namespace Gyak_Kiterjeszthetoseg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program indul");
            //CsvProcessor p = new CsvProcessor();
            //p.Run();
            //MultilineTxtProcessor p = new MultilineTxtProcessor();
            //MultilineTxtProcessorWithPercentageProgress p = new MultilineTxtProcessorWithPercentageProgress();
            var p = new FileProcessor("us-500-text.txt",
                new PersonReaders.MultilineTxtPersonReader(),
                new PercentageProgress());
            p.Run();
        }
    }
}
