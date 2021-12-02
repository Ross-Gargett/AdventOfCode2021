// See https://aka.ms/new-console-template for more information

using AdventOfCode2021.Services;
using Spectre.Console;

internal class AdventOfCodeMenu
{
    private readonly ProblemSolverBuilder _builder;
    private readonly string[] _days;

    public AdventOfCodeMenu()
    {
        _builder = new ProblemSolverBuilder();

        _days = new string[24];

        for (var i = 0; i < 24; i++)
        {
            _days[i] = $"Day {i + 1}";
        }
    }

    internal void Run()
    {
        do
        {
            Console.Clear();

            // Ask what day to solve
            var day = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What day would you like the solution for?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more days)[/]")
                    .AddChoices(_days));

            // Ask what part to solve
            var part = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What part of the problem would you like to solve?")
                    .AddChoices(new[] { "1", "2" }));

            var solver = _builder
                .ForDay(int.Parse(day.Split(' ')[1]))
                .ForPart(int.Parse(part))
                .Build();

            AnsiConsole.Markup($"And the answer is... [underline red]{solver.Solve()}[/]!\n\n"); 

        } while (AnsiConsole.Confirm("Solve another?"));
    }
}