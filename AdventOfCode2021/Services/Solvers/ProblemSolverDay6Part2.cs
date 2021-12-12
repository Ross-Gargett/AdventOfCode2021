// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Contracts.Services;
using AdventOfCode2021.Models;

namespace AdventOfCode2021.Services.Solvers;

internal class ProblemSolverDay6Part2 : IProblemSolver
{
    private readonly LargeSchool _school;

    public ProblemSolverDay6Part2(IEnumerable<string> input)
    {
        var ages = input.First().Split(',').Select(age => int.Parse(age)).ToList();
        _school = new LargeSchool(ages);
    }

    public string Solve()
    {
        return $"{SimulateSchoolGrowth(days: 256)}";
    }

    private long SimulateSchoolGrowth(int days)
    {
        _school.SimulateSchool(days);
        return _school.CountFish();
    }
}