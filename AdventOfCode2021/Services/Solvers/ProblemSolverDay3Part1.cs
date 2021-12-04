// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay3Part1 : IProblemSolver
{
    private readonly int _positionLength = 5;
    private readonly List<string> _input;

    public ProblemSolverDay3Part1(IEnumerable<string> input)
    {
        _input = input.ToList();
        _positionLength = _input.First().Length;
    }

    public string Solve()
    {
        return $"{CalculatePowerConsumption()}";
    }

    private int CalculatePowerConsumption()
    {
        int gammaRate = 0,
            epsilonRate = 0;
        
        var mask = (int)Math.Pow(2, _positionLength) - 1;

        for (var i = 0; i < _positionLength; i++)
        {
            var onesInPosition = _input.Count(x => x[i] == '1');

            var gammaBit = onesInPosition >= _input.Count / (double)2
                ? 1
                : 0;

            gammaRate = SetBitToValue(gammaRate, gammaBit, position: (_positionLength - 1) - i);
        }

        epsilonRate = ~gammaRate & mask;

        return gammaRate * epsilonRate;
    }

    private static int SetBitToValue(int number, int bit, int position)
    {
        return number |= bit << position;
    }
}