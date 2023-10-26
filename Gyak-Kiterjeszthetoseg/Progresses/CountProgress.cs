using System;

namespace Gyak_Kiterjeszthetoseg.Progress;

class CountProgress : IProcessProgress
{
    public void PrintProgress(int personCount)
    {
        Console.WriteLine($"{personCount}. ember beolvasva");
    }
}
