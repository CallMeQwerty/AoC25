using AoC25.Core;
using Spectre.Console;
using System.Diagnostics;
using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Get all available solutions
var solutions = SolutionRunner.DiscoverSolutions();

while (true)
{
    AnsiConsole.Clear();

    // Title
    var panel = new Panel(new Markup("[green bold]🎄 Advent of Code 2025 🎄[/]").Centered())
        .BorderColor(Color.Green)
        .Border(BoxBorder.Rounded)
        .Padding(2, 1);

    AnsiConsole.Write(panel);
    AnsiConsole.WriteLine();

    // Get choices
    var choices = solutions
        .OrderBy(x => x.Key)
        .Select(x => x.Value.Title)
        .Append("Exit")
        .ToList();

    // Menu
    var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[green]Select a day to run:[/]")
            .AddChoices(choices));

    // Exit condition
    if (selection == "Exit") break;

    // Extract day number
    var dayNum = int.Parse(selection.Split(':')[0].Replace("Day ", ""));

    // Run the selected solution
    if (solutions.TryGetValue(dayNum, out var solution))
    {
        RunSolution(dayNum, solution);
    }
}

void RunSolution(int day, ISolution solution)
{
    AnsiConsole.Clear();

    // Title
    var header = new Panel($"[yellow bold]{solution.Title}[/]")
        .BorderColor(Color.Yellow)
        .Border(BoxBorder.Rounded)
        .Padding(1, 0)
        .Expand();

    AnsiConsole.Write(header);
    AnsiConsole.WriteLine();

    try
    {
        // Get input for current day
        var input = InputHelper.ReadInput(day);

        // Part 1
        object? result1 = null;
        var sw1 = Stopwatch.StartNew();

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Star)
            .SpinnerStyle(Style.Parse("yellow bold"))
            .Start("[green]Solving Part 1...[/]", ctx =>
            {
                result1 = solution.SolvePart1(input);
            });

        sw1.Stop();
        AnsiConsole.MarkupLine("[green]✓ Completed Part 1[/]");

        // Part 2
        object? result2 = null;
        var sw2 = Stopwatch.StartNew();

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Star)
            .SpinnerStyle(Style.Parse("yellow bold"))
            .Start("[green]Solving Part 2...[/]", ctx =>
            {
                result2 = solution.SolvePart2(input);
            });

        sw2.Stop();
        AnsiConsole.MarkupLine("[green]✓ Completed Part 2[/]");

        // Result table
        AnsiConsole.WriteLine();

        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Green)
            .AddColumn(new TableColumn("[green bold]Part[/]").Centered())
            .AddColumn(new TableColumn("[green bold]Answer[/]").RightAligned())
            .AddColumn(new TableColumn("[green bold]Time[/]").RightAligned());

        table.AddRow("Part 1", $"[bold]{result1}[/]", $"[dim]{FormatTime(sw1.Elapsed)}[/]");
        table.AddRow("Part 2", $"[bold]{result2}[/]", $"[dim]{FormatTime(sw2.Elapsed)}[/]");
        table.AddRow("[dim]Total[/]", "", $"[bold]{FormatTime(sw1.Elapsed + sw2.Elapsed)}[/]");

        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }
    catch (FileNotFoundException ex)
    {
        AnsiConsole.MarkupLine($"[red]Error:[/] {Markup.Escape(ex.Message)}");
    }
    catch (Exception ex)
    {
        AnsiConsole.WriteException(ex);
    }

    AnsiConsole.MarkupLine("[dim]Press any key to continue...[/]");
    Console.ReadKey();
}

// Time format helper
string FormatTime(TimeSpan elapsed)
{
    if (elapsed.TotalSeconds >= 1) 
        return $"{elapsed.TotalSeconds.ToString("F2", CultureInfo.InvariantCulture)}s";    
    
    if (elapsed.TotalMilliseconds >= 1) 
        return $"{elapsed.TotalMilliseconds.ToString("F0", CultureInfo.InvariantCulture)}ms";    
    
    return $"{elapsed.TotalMicroseconds.ToString("F0", CultureInfo.InvariantCulture)}µs";
}