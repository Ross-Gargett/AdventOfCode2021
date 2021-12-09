namespace AdventOfCode2021.Models;

public class Coordinate
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        var coord = obj as Coordinate;
        return coord.X == X && coord.Y == Y;
    }

    public override int GetHashCode()
    {
        var hash = 13;
        hash = (hash * 13) + X.GetHashCode();
        hash = (hash * 13) + Y.GetHashCode();
        return hash;
    }
}
