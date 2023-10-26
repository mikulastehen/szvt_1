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

    public FileProcessor(string path, PersonReaders.IPersonReader personReader,
        IProcessProgress processProgress)
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
    
    
    protected override List<Person> Transform(List<Person> people)
    {
        return people.OrderBy(p => p.State).ToList();
    }
    // Az implementációt a CsvProcessor-ból mozgassuk ide
    protected override void Write(List<Person> people)
    {
        using (StreamWriter writer = new StreamWriter(@"emberek.txt"))
        {
            foreach (Person p in people)
                writer.WriteLine($"{p.FirstName} {p.LastName}, {p.State}");
        }
    }
}
