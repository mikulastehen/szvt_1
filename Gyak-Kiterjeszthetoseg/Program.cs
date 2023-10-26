using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gyak_Kiterjeszthetoseg.Progress;
using Gyak_Kiterjeszthetoseg.Writers;
using TextWriter = System.IO.TextWriter;

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
            /*var p = new FileProcessor("us-500-text.txt",
                new PersonReaders.MultilineTxtPersonReader(),
                new PercentageProgress());
            */
            /*var p = new FileProcessor("us-500-text.txt", new PersonReaders.MultilineTxtPersonReader(),
                new PercentageProgress(), new Writers.TextWriter());
            */
            var p = new FileProcessor("us-500-text.txt", new PersonReaders.MultilineTxtPersonReader(),
                new PercentageProgress(), new Writers.TextWriter(), new PeopleProcessors.SortProcessor(x => x.State));
            p.Run();
        }
    }
}
