namespace AoC25.Core;

/// <summary>
/// Provides helper methods for reading Advent of Code input files.
/// </summary>
public class InputHelper
{
    /// <summary>
    /// Reads the input file for the specified Advent of Code day and returns its contents as a string.
    /// </summary>
    /// <param name="day">The day number for which to read the input file. Must be a positive integer corresponding to an existing input file (e.g., 1 for day01.txt).</param>
    /// <returns>A string containing the contents of the input file for the specified day.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the input file for the specified day does not exist.</exception>
    public static string ReadInput(int day)
    {
        var path = $"Inputs/day{day:D2}.txt";

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Input file not found: {path}\n" +
                $"Please create the file at: {Path.GetFullPath(path)}\n" +
                $"Get your input from: https://adventofcode.com/2025/day/{day}/input");
        }

        return File.ReadAllText(path);
    }
}
