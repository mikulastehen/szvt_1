using System.Collections.Generic;

namespace Gyak_Kiterjeszthetoseg.Writers;

interface IResultWriter
{
    void Write(List<Person> people);
}