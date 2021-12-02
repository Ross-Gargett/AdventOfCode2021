namespace AdventOfCode2021.Contracts.Services;

public interface IProblemSolverBuilder
{
    IProblemSolverBuilder ForDay(int day);
    IProblemSolverBuilder ForPart(int part);
    IProblemSolver Build();
}
