// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay1Part1 : IProblemSolver
{
    private readonly List<int> _input;

    public ProblemSolverDay1Part1(IEnumerable<string> input)
    {
        _input = input.Select(int.Parse).ToList();
    }

    public string Solve()
    {
        return $"{CountIncreases()}";
    }

    private int CountIncreases()
    {
        int previousNum = int.MaxValue,
            count = 0;

        foreach (var currentNum in _input)
        {
            if(currentNum > previousNum)
                count++;

            previousNum = currentNum;
        }

        return count;
    }
}