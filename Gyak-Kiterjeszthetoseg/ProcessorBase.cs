using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Gyak_Kiterjeszthetoseg.PeopleProcessors;
using Gyak_Kiterjeszthetoseg.Writers;

namespace Gyak_Kiterjeszthetoseg;

abstract class ProcessorBase
{
    public void Run()
    {
        List<Person> input = Read();
        List<Person> processed = Processor.Transform(input);
        Writer.Write(processed);
    }

    public ProcessorBase(IResultWriter writer, IPeopleProcessor processor)
    {
        this.Writer = writer;
        this.Processor = processor;
    }

    protected IResultWriter Writer;
    protected IPeopleProcessor Processor;
    protected abstract List<Person> Read();
}