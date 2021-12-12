// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay6Part1 : IProblemSolver
{
    private readonly SmallSchool _school;

    public ProblemSolverDay6Part1(IEnumerable<string> input)
    {
        var ages = input.First().Split(',');
        var lanternFish = ages.Select(age => new LanternFish(int.Parse(age))).ToList();
        _school = new SmallSchool(lanternFish);
    }

    public string Solve()
    {
        return $"{SimulateSchoolGrowth(days: 80)}";
    }

    private int SimulateSchoolGrowth(int days)
    {
        _school.SimulateSchool(days);
        return _school.CountFish();
    }
}