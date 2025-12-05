using AoC25.Core;

namespace AoC25.Solutions;

public class Day05 : ISolution
{
    public string Title => "Day 5: Cafeteria";

    /// <summary>
    /// Ranges of fresh ingredients.
    /// </summary>
    private IEnumerable<(long start, long end)> Ranges = [];

    /// <summary>
    /// Ids of ingredients to check.
    /// </summary>
    private IEnumerable<long> Ingredients = [];

    // Implementation for Part 1
    public long SolvePart1(string input)
    {
        long result = 0;
        LoadData(input);

        foreach (var ingredient in Ingredients)
        {
            if (Ranges.Any(range => ingredient >= range.start && ingredient <= range.end)) result++;
        }

        return result;
    }

    // Implementation for Part 2
    public long SolvePart2(string input)
    {
        long result = 0;
        LoadData(input);

        List<(long start, long end)> groupedRanges = [];
        Ranges = Ranges.OrderBy(r => r.start);
        
        var current = Ranges.ElementAt(0);
        var totalRanges = Ranges.Count();

        for (int i = 1; i < totalRanges; i++)
        {
            var next = Ranges.ElementAt(i);

            // Overlap
            if (next.start <= current.end + 1)
            {
                // Extend current range
                current.end = Math.Max(current.end, next.end);
                continue;
            }

            // Current range ended
            groupedRanges.Add(current);
            current = next;
        }

        groupedRanges.Add(current);

        foreach (var range in groupedRanges)
        {
            result += (range.end - range.start + 1);
        }

        return result;
    }

    private void LoadData(string input)
    {
        var lines = input.Split(["\r\n", "\n"], StringSplitOptions.None);
        int emptyLineIndex = Array.FindIndex(lines, string.IsNullOrWhiteSpace);

        IEnumerable<string> ranges = lines.Take(emptyLineIndex);
        IEnumerable<string> ingredients = lines.Skip(emptyLineIndex + 1);

        Ranges = ranges.Select(line =>
        {
            var parts = line.Split('-');
            return (long.Parse(parts[0]), long.Parse(parts[1]));
        });

        Ingredients = ingredients.Select(long.Parse);
    }
}
