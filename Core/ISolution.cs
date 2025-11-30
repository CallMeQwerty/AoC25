namespace AoC25.Core;

/// <summary>
/// Interface for Advent of Code solution implementations.
/// </summary>
public interface ISolution
{
    /// <summary>
    /// Title of the Advent of Code challenge.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// Solves Part 1 of the puzzle using the input data.
    /// </summary>
    /// <param name="input">The input string containing the puzzle data to be processed. Cannot be null.</param>
    /// <returns>The result of Part 1 as a long value.</returns>
    long SolvePart1(string input);

    /// <summary>
    /// Solves Part 2 of the puzzle using the input data.
    /// </summary>
    /// <param name="input">The input string containing the puzzle data to be processed. Cannot be null.</param>
    /// <returns>The result of Part 2 as a long value.</returns>
    long SolvePart2(string input);
}
