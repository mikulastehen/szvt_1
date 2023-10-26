using System.IO;

namespace Gyak_Kiterjeszthetoseg.PersonReaders;

class MultilineTxtPersonReader : IPersonReader
{
    public Person Read(StreamReader reader)
    {
        string[] columns = new string[13];
        for (int i = 0; i < 13; ++i)
            columns[i] = reader.ReadLine();
        return new Person(firstName: columns[0], lastName: columns[1],
            companyName: columns[2], address: columns[3],
            city: columns[4], state: columns[6]);
    }
}