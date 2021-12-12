namespace AdventOfCode2021.Models;

internal class SmallSchool
{
    private readonly List<LanternFish> _fish;

    public SmallSchool(IEnumerable<LanternFish> fish)
    {
        _fish = fish.ToList();
    }

    public void SimulateSchool(int days)
    {
        for (var i = 0; i < days; i++)
        {
            //Console.WriteLine($"Day {i}: {string.Join(',', _fish)}");
            var newSpawn = (from fish in _fish where fish.AgeUp() select new LanternFish()).ToList();
            _fish.AddRange(newSpawn);
        }
    }

    public int CountFish()
    {
        return _fish.Count;
    }
}
