using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gyak_Kiterjeszthetoseg;

class CsvProcessor : FileProcessorBase
{
    public CsvProcessor()
        : base("us-500.csv") // A fajl nevet nem tudhatja az ososztaly, azt innen adjuk
    {
    }
    protected override Person readPerson(StreamReader reader)
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
