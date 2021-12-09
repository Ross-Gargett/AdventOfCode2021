// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay5Part1 : IProblemSolver
{
    private const string LINE_SEPARATOR = " -> ";
    private readonly Diagram _diagram;

    public ProblemSolverDay5Part1(IEnumerable<string> input)
    {
        _diagram = new Diagram(includeDiagonal: false);

        foreach (var inputLine in input)
        {
            var (x1, y1, x2, y2) = ParseCoordsFromLine(inputLine);
            var line = new Line(x1, y1, x2, y2);
            _diagram.AddLine(line);
        }
    }

    private (int, int, int, int) ParseCoordsFromLine(string inputLine)
    {
        var bothCoords = inputLine.Split(LINE_SEPARATOR, StringSplitOptions.RemoveEmptyEntries);
        var lineOne = bothCoords[0].Split(',');
        var lineTwo = bothCoords[1].Split(',');

        return (int.Parse(lineOne[0]), int.Parse(lineOne[1]),
                int.Parse(lineTwo[0]), int.Parse(lineTwo[1]));
    }

    public string Solve()
    {
        return $"{CountOverlappingPoints(threshold: 2)}";
    }

    private int CountOverlappingPoints(int threshold)
    {
        return _diagram.CountPointsWithIntersections(threshold);
    }
}