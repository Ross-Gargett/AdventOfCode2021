// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay2Part2 : IProblemSolver
{
    private readonly List<DirectionInput> _input;

    public ProblemSolverDay2Part2(IEnumerable<string> input)
    {
        _input = input.Select(x => new DirectionInput(x)).ToList();
    }

    public string Solve()
    {
        return $"{CalculatePosition()}";
    }

    private int CalculatePosition()
    {
        int aim = 0,
            horizontal = 0,
            vertical = 0;

        foreach (var direction in _input)
        {
            switch (direction.Direction)
            {
                case Direction.Down:
                    aim += direction.Distance;
                    break;
                case Direction.Up:
                    aim -= direction.Distance;
                    break;
                case Direction.Forward:
                    horizontal += direction.Distance;
                    vertical += aim * direction.Distance;
                    break;
                default:
                    break;
            }
        }

        return horizontal * vertical;
    }
}