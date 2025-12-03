using AoC25.Core;

namespace AoC25.Solutions;

public class Day03 : ISolution
{
    public string Title => "Day 3: Lobby";

    // Implementation for Part 1
    public long SolvePart1(string input)
    {
        long result = 0;
        var banks = input.Split('\n').ToList();
        
        foreach (var bank in banks)
        {
            var bankDigits = bank.Trim().Chunk(1).Select(chars => int.Parse(chars)).ToList();

            var batteryOne = bankDigits.SkipLast(1).Select((value, index) => (Value: value, Index: index)).MaxBy(x => x.Value);
            var batteryTwo = bankDigits.Skip(batteryOne.Index + 1).Select((value, index) => (Value: value, Index: index)).MaxBy(x => x.Value);

            result += long.Parse($"{batteryOne.Value}{batteryTwo.Value}");
        }

        return result;
    }

    // Implementation for Part 2
    public long SolvePart2(string input)
    {
        long result = 0;
        var banks = input.Split('\n').ToList();

        foreach (var bank in banks)
        {
            var bankDigits = bank.Trim().Chunk(1).Select(chars => int.Parse(chars)).ToList();

            string joltage = "";
            int totalBatteries = bankDigits.Count;

            int skip = 0;
            int skipLast = 11;

            for (int i = 0; i < 12; i++)
            {
                var battery = bankDigits.Skip(skip).SkipLast(skipLast).Select((value, index) => (Value: value, Index: index)).MaxBy(x => x.Value);
                
                joltage += battery.Value.ToString();
                skip = ++battery.Index + skip;

                if (totalBatteries - skip < skipLast) skipLast = totalBatteries - skip;
                skipLast--;
            }

            result += long.Parse(joltage);
        }

        return result;
    }
}
