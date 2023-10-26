using System.IO;

namespace Gyak_Kiterjeszthetoseg.PersonReaders;

interface IPersonReader
{
    Person Read(StreamReader reader);
}
