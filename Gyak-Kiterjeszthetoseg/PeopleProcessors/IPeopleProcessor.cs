using System.Collections.Generic;

namespace Gyak_Kiterjeszthetoseg.PeopleProcessors;

interface IPeopleProcessor
{
    List<Person> Transform(List<Person> people);
}