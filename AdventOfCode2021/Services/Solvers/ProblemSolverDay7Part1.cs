// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay7Part1 : IProblemSolver
{
    private readonly List<int> _crabs;

    public ProblemSolverDay7Part1(IEnumerable<string> input)
    {
        var crabStrs = input.First().Split(',');
        _crabs = crabStrs.Select(int.Parse).ToList();
    }

    public string Solve()
    {
        return $"{FindOptimalPosition()}";
    }

    private int FindOptimalPosition()
    {
        return _crabs.Select(crab => _crabs.Sum(x => Math.Abs(crab - x))).Min();
    }
}