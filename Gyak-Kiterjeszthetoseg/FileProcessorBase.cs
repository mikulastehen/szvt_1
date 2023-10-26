using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyak_Kiterjeszthetoseg;

abstract class FileProcessorBase : ProcessorBase
{
    private string path;
    public FileProcessorBase(string path)
    {
        this.path = path;
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
                people.Add(readPerson(reader));
                printProgress(personCount);
            }
        }
        return people;
    }

    protected virtual void printProgress(int personCount)
    {
        Console.WriteLine($"{personCount}. ember beolvasva");
    }

    protected abstract Person readPerson(StreamReader reader);
    // Az implementációt a CsvProcessor-ból mozgassuk ide
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
