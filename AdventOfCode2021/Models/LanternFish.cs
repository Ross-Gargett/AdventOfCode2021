namespace AdventOfCode2021.Models;

internal class LanternFish
{
    private const int DaysUntilMaturity = 2;
    private const int DaysToSpawn = 6;
    private int _daysUntilSpawn;

    public LanternFish()
    {
        _daysUntilSpawn = DaysToSpawn + DaysUntilMaturity;
    }

    public LanternFish(int age)
    {
        _daysUntilSpawn = age;
    }

    /// <summary>
    /// Increases thr age of the lantern fish
    /// </summary>
    /// <returns>True if they spawned a new lantern fish</returns>
    public bool AgeUp()
    {
        if (_daysUntilSpawn == 0)
        {
            _daysUntilSpawn = DaysToSpawn;
            return true;
        }

        _daysUntilSpawn--;
        return false;
    }

    public override string ToString()
    {
        return $"{_daysUntilSpawn}";
    }
}
