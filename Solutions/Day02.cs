using AoC25.Core;

namespace AoC25.Solutions;

public class Day02 : ISolution
{
    public string Title => "Day 2: Gift Shop";

    // Implementation for Part 1
    public long SolvePart1(string input)
    {
        long result = 0;
        var values = input.Split(',');

        foreach (var value in values)
        {
            var bounds = value.Split('-').Select(long.Parse).ToList();

            for (long i = bounds[0]; i <= bounds[1]; i++)
            {
                string str = i.ToString();
                if (str.Length % 2 == 0 && (str[..(str.Length / 2)] == str[(str.Length / 2)..])) result += i;
            }
        }

        return result;
    }

    // Implementation for Part 2
    public long SolvePart2(string input)
    {
        long result = 0;
        var values = input.Split(',');

        foreach (var value in values)
        {
            var bounds = value.Split('-').Select(long.Parse).ToList();

            for (long i = bounds[0]; i <= bounds[1]; i++)
            {
                string str = i.ToString();
                for (int j = str.Length / 2; j >= 1; j--)
                {
                    if (str.Length % j != 0) continue;

                    var chunks = str.Chunk(j).Select(chars => new string(chars)).ToArray();
                    if (chunks.All(chunk => chunk == chunks[0]))
                    {
                        result += i;
                        break;
                    }
                }
            }
        }

        return result;
    }
}
