// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay2Part1 : IProblemSolver
{
    private readonly List<DirectionInput> _input;

    public ProblemSolverDay2Part1(IEnumerable<string> input)
    {
        _input = input.Select(x => new DirectionInput(x)).ToList();
    }

    public string Solve()
    {
        return $"{CalculatePosition()}";
    }

    private int CalculatePosition()
    {
        int horizontal = 0,
            vertical = 0;

        horizontal += _input.Where(d => d.Direction == Direction.Forward).Sum(input => input.Distance);
        vertical += _input.Where(d => d.Direction == Direction.Down).Sum(input => input.Distance);
        vertical -= _input.Where(d => d.Direction == Direction.Up).Sum(input => input.Distance);

        return horizontal * vertical;
    }
}