// See https://aka.ms/new-console-template for more information

namespace AdventOfCode2021.Models;

public class DirectionInput
{
    public Direction Direction { get; private set; }
    public int Distance { get; private set; }

    public DirectionInput(string inputRow)
    {
        var splitRow = inputRow.Split(' ');

        if (!Enum.TryParse(splitRow[0], true, out Direction tempDirection))
            throw new ArgumentOutOfRangeException($"{splitRow[0]} is not a valid Direction");

        if (!int.TryParse(splitRow[1], out int tempDistance))
            throw new ArgumentOutOfRangeException($"{splitRow[1]} is not a valid integer");

        Direction = tempDirection;
        Distance = tempDistance;
    }
}

public enum Direction
{
    Forward,
    Down,
    Up
}