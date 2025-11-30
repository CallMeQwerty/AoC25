using System.Reflection;

namespace AoC25.Core;

/// <summary>
/// Provides functionality to discover and instantiate all solutions within the current assembly.
/// </summary>
public class SolutionRunner
{
    /// <summary>
    /// Discovers and instantiates all non-abstract implementations of the ISolution interface in the current assembly.
    /// </summary>
    /// <returns>A dictionary mapping day numbers to their corresponding ISolution instances. The dictionary will be empty if no solutions are found.</returns>
    public static Dictionary<int, ISolution> DiscoverSolutions()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(ISolution).IsAssignableFrom(t) &&
                       !t.IsInterface &&
                       !t.IsAbstract)
            .Select(t => (ISolution)Activator.CreateInstance(t)!)
            .ToDictionary(
                solution => ExtractDayNumber(solution.GetType().Name),
                solution => solution
            );
    }

    /// <summary>
    /// Extracts the first sequence of digits found in the specified class name and returns it as an integer.
    /// </summary>
    /// <param name="className">The class name string from which to extract the day number. Cannot be null.</param>
    /// <returns>An integer representing the first sequence of digits found in the class name. Returns 0 if no digits are present.</returns>
    private static int ExtractDayNumber(string className)
    {
        var match = System.Text.RegularExpressions.Regex.Match(className, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }
}
