// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay4Part1 : IProblemSolver
{
    private const int BINGO_DIMENSIONS = 5;
    private readonly List<int> _bingoInput = new List<int>();
    private readonly List<BingoBoard> _bingoBoards = new List<BingoBoard>();

    public ProblemSolverDay4Part1(IEnumerable<string> input)
    {
        _bingoInput = input.First().Split(',').Select(int.Parse).ToList();

        var boards = input.Skip(2);

        for (var i = 0; i < boards.Count(); i+=6)
        {
            _bingoBoards.Add(new BingoBoard(boards.Skip(i).Take(BINGO_DIMENSIONS), BINGO_DIMENSIONS));
        }
    }

    public string Solve()
    {
        return $"{CalculateFinalScore()}";
    }

    private int CalculateFinalScore()
    {
        var unmarkedNums = new int[0];
        var lastNum = int.MinValue;

        foreach (var number in _bingoInput)
        {
            foreach (var board in _bingoBoards)
            {
                board.PickNumber(number);

                if (!board.HasBingo) continue;

                unmarkedNums = board.GetUnmarkedNumbers();
                lastNum = number;

                break;
            }

            if (lastNum != int.MinValue)
                break;
        }

        return lastNum * unmarkedNums.Sum();
    }
}