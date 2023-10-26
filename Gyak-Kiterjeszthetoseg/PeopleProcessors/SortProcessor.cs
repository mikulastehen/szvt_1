using System;
using System.Collections.Generic;
using System.Linq;

namespace Gyak_Kiterjeszthetoseg.PeopleProcessors;

class SortProcessor : IPeopleProcessor
{
    public List<Person> Transform(List<Person> people)
    {
        return people.OrderBy(this.SortSelector).ToList();
    }

    public SortProcessor(Func<Person, string> sortSelector)
    {
        this.SortSelector = sortSelector;
    }

    Func<Person, string> SortSelector;
}