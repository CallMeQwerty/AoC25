using AoC25.Core;

namespace AoC25.Solutions;

public class Day04 : ISolution
{
    public string Title => "Day 4: Printing Department";

    // Implementation for Part 1
    public long SolvePart1(string input)
    {
        var grid = InputToGrid(input);
        var largeGrid = EncapsulateWithDots(grid);
        
        return FindIsolatedPositions(largeGrid, 4).Count();
    }

    // Implementation for Part 2
    public long SolvePart2(string input)
    {
        var grid = InputToGrid(input);
        var largeGrid = EncapsulateWithDots(grid);
        
        long result = 0;
        List<(int y, int x)> coordsToRemove;

        do
        {
            coordsToRemove = [.. FindIsolatedPositions(largeGrid, 4)];
            result += coordsToRemove.Count;

            foreach (var (y, x) in coordsToRemove)
            {
                largeGrid[y][x] = '.';
            }

        } while (coordsToRemove.Count > 0);
        
        return result;
    }

    private List<List<char>> InputToGrid(string input)
    {
        return [.. input.Split('\n').Select(row => row.Trim().ToList())];
    }

    private List<List<char>> EncapsulateWithDots(List<List<char>> grid)
    {
        List<char> border = [.. Enumerable.Repeat('.', grid[0].Count + 2)];

        return 
        [
            border,
            .. grid.Select(row => 
            {
                List<char> newRow = ['.', .. row, '.'];
                return newRow;
            }),
            border
        ];
    }

    private static readonly List<(int y, int x)> AdjacentOffsets = 
    [
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1),           (0, 1),
        (1, -1),  (1, 0),  (1, 1)
    ];

    private IEnumerable<(int y, int x)> FindIsolatedPositions(List<List<char>> grid, int requiredNeighbours)
    {
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[i].Count; j++)
            {
                if (grid[i][j] == '@' && !HasNeighbours(i, j, grid, requiredNeighbours))
                {
                    yield return (i, j);
                }
            }
        }
    }

    private bool HasNeighbours(int y, int x, List<List<char>> grid, int requiredCount)
    {
        return AdjacentOffsets.Count(offset => grid[y + offset.y][x + offset.x] == '@') >= requiredCount;
    }
}
