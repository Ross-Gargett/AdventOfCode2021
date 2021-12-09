namespace AdventOfCode2021.Models;

internal class Diagram
{
    private readonly Dictionary<Coordinate, int> _diagram;
    private readonly bool _includeDiagonal;

    public Diagram(bool includeDiagonal = true)
    {
        _diagram = new Dictionary<Coordinate, int>();
        _includeDiagonal = includeDiagonal;
    }

    public void AddLine(Line line)
    {
        if (!_includeDiagonal && line.Type == LineType.Diagonal)
            return;

        foreach (var coordinate in line.GetAllCoordinates())
        {
            if (_diagram.ContainsKey(coordinate))
            {
                _diagram.TryGetValue(coordinate, out var currentCount);
                _diagram[coordinate] = currentCount + 1;
            }
            else
                _diagram.Add(coordinate, 1);
        }
    }

    public int CountPointsWithIntersections(int threshold)
    {
        return _diagram.Count(p => p.Value >= threshold);
    }
}
