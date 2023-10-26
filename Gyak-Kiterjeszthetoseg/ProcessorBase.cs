using System.Collections.Generic;

namespace Gyak_Kiterjeszthetoseg;

abstract class ProcessorBase
{
    public void Run()
    {
        List<Person> input = Read();
        List<Person> processed = Transform(input);
        Write(processed);
    }
    protected abstract List<Person> Read();
    protected abstract List<Person> Transform(List<Person> people);
    protected abstract void Write(List<Person> people);
}