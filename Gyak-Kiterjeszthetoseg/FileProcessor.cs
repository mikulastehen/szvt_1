using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gyak_Kiterjeszthetoseg.Progress;

namespace Gyak_Kiterjeszthetoseg;

class FileProcessor : ProcessorBase
{
    private string path;
    private readonly PersonReaders.IPersonReader personReader;
    private readonly IProcessProgress processProgress;

    public FileProcessor(string path,
        PersonReaders.IPersonReader personReader,
        IProcessProgress processProgress,
        Writers.IResultWriter writer, PeopleProcessors.IPeopleProcessor processor)
        : base(writer, processor)
    {
        this.path = path;
        this.personReader = personReader;
        this.processProgress = processProgress;
    }
    protected override List<Person> Read()
    {
        // A lista osszeallitasa es a fajlkezeles kozos resze marad itt
        List<Person> people = new List<Person>();
        using (StreamReader reader = new StreamReader(path))
        {
            Console.WriteLine("Fajl megnyitva");
            int personCount = 0;
            while (!reader.EndOfStream)
            {
                ++personCount;
                people.Add(personReader.Read(reader));
                processProgress.PrintProgress(personCount);
            }
        }
        return people;
    }
    
}
