using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Gyak_Kiterjeszthetoseg.Writers;

namespace Gyak_Kiterjeszthetoseg;

abstract class ProcessorBase
{
    public void Run()
    {
        List<Person> input = Read();
        List<Person> processed = Transform(input);
        Writer.Write(processed);
    }

    public ProcessorBase(IResultWriter writer)
    {
        this.Writer = writer;
    }

    protected IResultWriter Writer;
    protected abstract List<Person> Read();
    protected abstract List<Person> Transform(List<Person> people);
}