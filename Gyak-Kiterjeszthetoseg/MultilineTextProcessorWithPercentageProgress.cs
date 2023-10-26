namespace Gyak_Kiterjeszthetoseg;

class MultilineTxtProcessorWithPercentageProgress : MultilineTxtProcessor
{
    protected override void printProgress(int personCount)
    {
        float percentage = (float)personCount / 500 * 100;
        if (percentage % 5 == 0) // Csak 5 szazalekonkent irjuk ki
            System.Console.WriteLine($"Feldolgozas {percentage}%");
    }
}