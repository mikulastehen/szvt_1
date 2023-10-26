namespace Gyak_Kiterjeszthetoseg.Progress;

class PercentageProgress : IProcessProgress
{
    public void PrintProgress(int personCount)
    {
        float percentage = (float)personCount / 500 * 100;
        if (percentage % 10 == 0) // Csak 5 szazalekonkent irjuk ki
            System.Console.WriteLine($"Feldolgozas {percentage}%");
    }
}