using System.IO;

namespace Gyak_Kiterjeszthetoseg.PersonReaders;

class CsvPersonReader : IPersonReader
{
    public Person Read(StreamReader reader)
    {
        var line = reader.ReadLine();
        System.Text.RegularExpressions.MatchCollection columns
            = new System.Text.RegularExpressions.Regex(
                "((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))"
            ).Matches(line);
        return new Person(firstName: columns[0].Value, lastName: columns[1].Value,
            companyName: columns[2].Value, address: columns[3].Value,
            city: columns[4].Value, state: columns[6].Value);
    }
}
