// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay1Part2 : IProblemSolver
{
    private readonly List<int> _input;

    public ProblemSolverDay1Part2(IEnumerable<string> input)
    {
        _input = input.Select(int.Parse).ToList();
    }

    public string Solve()
    {
        return $"{CountIncreases()}";
    }

    private int CountIncreases()
    {
        int previousSum = int.MaxValue,
            count = 0;

        for (var winStartIndex = 0; winStartIndex < _input.Count - 2;)
        {
            for (var winEndIndex = 2; winEndIndex < _input.Count; winStartIndex++, winEndIndex++)
            {
                var currentSum = _input[winStartIndex]
                                 + _input[winStartIndex + 1]
                                 + _input[winEndIndex];

                if (previousSum < currentSum)
                    count++;

                previousSum = currentSum;
            }
        }

        return count;
    }
}