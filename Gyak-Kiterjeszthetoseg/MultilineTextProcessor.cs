using System.IO;

namespace Gyak_Kiterjeszthetoseg;

class MultilineTxtProcessor : FileProcessorBase
{
    public MultilineTxtProcessor()
        : base("us-500-text.txt") // A fajl nevet nem tudhatja az ososztaly
    {
    }
    protected override Person readPerson(StreamReader reader)
    {
        // 13 egymas utani sort olvasunk be
        string[] columns = new string[13];
        for (int i = 0; i < 13; ++i)
            columns[i] = reader.ReadLine();
        // Minden sorbol egy ember adatot leiro osztaly peldanyt keszitunk
        return new Person(firstName: columns[0], lastName: columns[1], companyName:
            columns[2], address: columns[3], city: columns[4], state: columns[6]);
    }
}