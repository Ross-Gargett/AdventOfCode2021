namespace AdventOfCode2021.Models;

internal class LargeSchool
{
    private const int DaysUntilMaturity = 2;
    private const int DaysToSpawn = 6;
    private readonly Dictionary<int, long> _fishAges;

    public LargeSchool(IEnumerable<int> fishAges)
    {
        _fishAges = new Dictionary<int, long>();
        SetAgeKeys();
        PopulateFishAges(fishAges);
    }

    private void SetAgeKeys()
    {
        for (var i = 0; i <= (DaysToSpawn + DaysUntilMaturity); i++)
        {
            _fishAges.Add(i, 0);
        }
    }

    private void PopulateFishAges(IEnumerable<int> fishAges)
    {
        foreach (var age in fishAges)
        {
            if (!_fishAges.ContainsKey(age)) continue;

            _fishAges.TryGetValue(age, out var currentCount);
            _fishAges[age] = currentCount + 1;
        }
    }

    public void SimulateSchool(int days)
    {
        for (var i = 0; i < days; i++)
        {
            var newSpawn = DecrementAllAges();
            _fishAges[(DaysToSpawn + DaysUntilMaturity)] = newSpawn;
        }
    }

    private long DecrementAllAges()
    {
        var lastAgeCount = 0l;


        for (var age = (DaysToSpawn + DaysUntilMaturity); age >= 0; age--)
        {
            _fishAges.TryGetValue(age, out var currentCount);
            _fishAges[age] = lastAgeCount;
            lastAgeCount = currentCount;
        }

        _fishAges[DaysToSpawn] += lastAgeCount;

        return lastAgeCount;
    }

    public long CountFish()
    {
        return _fishAges.Sum(fa => fa.Value);
    }
}
