// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Services.Solvers;

namespace AdventOfCode2021.Services;

internal class ProblemSolverBuilder : IProblemSolverBuilder
{
    private int _day;
    private int _part;

    public IProblemSolver Build()
    {
        var input = ReadInput();

        return (_day, _part) switch
        {
            (1, 1) => new ProblemSolverDay1Part1(input),
            (1, 2) => new ProblemSolverDay1Part2(input),
            _ => throw new ArgumentOutOfRangeException("")
        };
    }

    private string[] ReadInput()
    {
        var path = Path.Combine("Input", $"Day{_day}", $"{_part}.txt");
        return File.ReadAllLines(path);
    }

    public IProblemSolverBuilder ForDay(int day)
    {
        _day = day;
        return this;
    }

    public IProblemSolverBuilder ForPart(int part)
    {
        _part = part;
        return this;
    }
}