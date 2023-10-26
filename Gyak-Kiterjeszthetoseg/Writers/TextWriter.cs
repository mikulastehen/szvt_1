using System.Collections.Generic;
using System.IO;

namespace Gyak_Kiterjeszthetoseg.Writers;

class TextWriter : IResultWriter
{
    public void Write(List<Person> people)
    {
        using (StreamWriter writer = new StreamWriter(@"emberek.txt"))
        {
            foreach (Person p in people)
                writer.WriteLine($"{p.FirstName} {p.LastName}, {p.State}");
        }
    }
}