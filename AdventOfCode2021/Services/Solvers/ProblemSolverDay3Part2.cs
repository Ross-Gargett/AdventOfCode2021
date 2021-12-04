// See https://aka.ms/new-console-template for more information

using System.Numerics;
using AdventOfCode2021.Contracts.Services;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay3Part2 : IProblemSolver
{
    private readonly int _positionLength;
    private readonly List<string> _oxygenCandidates;
    private readonly List<string> _c02Candidates;

    public ProblemSolverDay3Part2(IEnumerable<string> input)
    {
        _positionLength = input.First().Length;

        _oxygenCandidates = new List<string>(input.ToArray());
        _c02Candidates = new List<string>(input.ToArray());

    }

    public string Solve()
    {
        return $"{CalculatePowerConsumption()}";
    }

    private int CalculatePowerConsumption()
    {
        var oxygenRating = CalculateRatingForCandidates(_oxygenCandidates, RatingType.O2);
        var c02Rating = CalculateRatingForCandidates(_c02Candidates, RatingType.CO2);
        
        return oxygenRating * c02Rating;
    }

    private int CalculateRatingForCandidates(List<string> candidates, RatingType rating)
    {
        for (var i = 0; i < _positionLength; i++)
        {
            var onesInPosition = candidates.Count(x => x[i] == '1');

            var bitToRemove = GetBitToRemove(candidates.Count, onesInPosition, rating);
            RemoveFromListIfNotEmpty(candidates, i, bitToRemove);
        }

        return Convert.ToInt32(candidates[0], 2);
    }

    private static char GetBitToRemove(int collectionLength, int onesInPosition, RatingType rating)
    {
        return onesInPosition >= collectionLength / (double)2
            ? rating == RatingType.O2 ? '0' : '1'
            : rating == RatingType.O2 ? '1' : '0';
    }

    private static void RemoveFromListIfNotEmpty(List<string> candidates, int i, char bit)
    {
        if(candidates.Count > 1)
            candidates.RemoveAll(MatchBitPositionEquals(i, bit));
    }

    private static Predicate<string> MatchBitPositionEquals(int i, char bit)
    {
        return x => x[i] == bit;
    }
}

public enum RatingType
{
    O2,
    CO2
}