// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay7Part2 : IProblemSolver
{
    private readonly List<int> _crabs;

    public ProblemSolverDay7Part2(IEnumerable<string> input)
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
        return Enumerable.Range(_crabs.Min(), _crabs.Max() - _crabs.Min())
            .Select(crab => _crabs.Sum(x => Enumerable.Range(1, Math.Abs(crab - x)).Sum()))
            .Min();
    }
}