using AoC25.Core;

namespace AoC25.Solutions;

public class Day01 : ISolution
{
    public string Title => "Day 1: Secret Entrance";

    // Implementation for Part 1
    public long SolvePart1(string input)
    {
        var dial = 50;
        var result = 0;

        var values = input.Split('\n').ToList();
        foreach (var value in values)
        {
            RotateDial(ref dial, value[0], int.Parse(value.Substring(1)));
            if (dial == 0) result++;
        }

        return result;
    }

    // Implementation for Part 2
    public long SolvePart2(string input)
    {
        var dial = 50;
        var result = 0;

        var values = input.Split('\n').ToList();
        foreach (var value in values)
        {
            RotateDial(ref dial, ref result, value[0], int.Parse(value.Substring(1)));
            if (dial == 0) result++;
        }

        return result;
    }

    private void RotateDial(ref int dial, char direction, int amount)
    {
        // Shorten amount to within 0-99
        int shortenedAmount = amount % 100;

        // Rotate dial based on direction
        if (direction == 'L') dial -= shortenedAmount;
        if (direction == 'R') dial += shortenedAmount;

        // Wrap around the dial if necessary
        if (dial < 0) dial += 100;
        if (dial > 99) dial -= 100;
    }

    private void RotateDial(ref int dial, ref int result, char direction, int amount)
    {
        // Count full rotations
        if (amount > 100) result += amount / 100;

        // Shorten amount to within 0-99
        int shortenedAmount = amount % 100;

        // Check if dial starts at zero
        bool startsAtZero = dial == 0;

        // Rotate dial Left and track wrapping around
        if (direction == 'L')
        {
            dial -= shortenedAmount;

            if (dial < 0)
            {
                dial += 100;
                if (dial != 0 && !startsAtZero) result++;
            }
        }

        // Rotate dial Right and track wrapping around
        if (direction == 'R')
        {
            dial += shortenedAmount;

            if (dial > 99)
            {
                dial -= 100;
                if (dial != 0 && !startsAtZero) result++;
            }
        }
    }
}
