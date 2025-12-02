# 🎄 Advent of Code 2025

A C# console application for solving [Advent of Code 2025](https://adventofcode.com/2025) puzzles with a beautiful CLI interface powered by [Spectre.Console](https://spectreconsole.net/).

## ✨ Features

- 🎨 **Beautiful CLI Interface** - Interactive menu with styled panels and spinners
- ⚡ **Performance Tracking** - Measures and displays execution time for each solution
- 🎯 **Modular Architecture** - Easy to add new solutions with automatic discovery
- 📊 **Results Table** - Clean display of answers and timing information
- 🎄 **Festive Theming** - Christmas-themed UI elements and animations

## 🚀 Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later

### Installation

1. Clone the repository:
```bash
git clone https://github.com/CallMeQwerty/AoC25.git
cd AoC25
```

2. Build the project:
```bash
dotnet build
```

3. Run the application:
```bash
dotnet run --project AdventOfCode2025
```

## 📁 Project Structure

```
AoC25/
├── AdventOfCode2025/          # Main console application
│   ├── Program.cs             # Entry point with UI logic
│   └── Inputs/                # Puzzle input files (day01.txt, day02.txt, etc.)
├── AdventOfCode2025.Core/     # Core library
│   ├── ISolution.cs           # Solution interface
│   ├── SolutionRunner.cs      # Solution discovery and execution
│   └── InputHelper.cs         # Input file management
└── AdventOfCode2025.Solutions/ # Daily puzzle solutions
    ├── Day01.cs               # Day 1 solution
    ├── Day02.cs               # Day 2 solution
    └── ...                    # More solutions
```

## 🎮 Usage

### Running the Application

1. Launch the application using `dotnet run`
2. Select a day from the interactive menu
3. View the results with timing information
4. Press any key to return to the menu
5. Press `Ctrl+C` to exit

### Adding Puzzle Inputs

Create input files in the `AdventOfCode2025/Inputs/` directory:

```
Inputs/
├── day01.txt
├── day02.txt
└── ...
```

The application will automatically look for `dayXX.txt` where `XX` is the day number (zero-padded).

## 🧩 Adding New Solutions

### Step 1: Create a Solution Class

Create a new file in `AdventOfCode2025.Solutions/` (e.g., `Day03.cs`):

```csharp
using AdventOfCode2025.Core;

namespace AdventOfCode2025.Solutions;

public class Day03 : ISolution
{
    public string Title => "Day 3: Mull It Over";

    public long SolvePart1(string input)
    {
        // Your Part 1 solution here
        return 0;
    }

    public long SolvePart2(string input)
    {
        // Your Part 2 solution here
        return 0;
    }
}
```

### Step 2: Add Your Input File

Create `Inputs/day03.txt` with your puzzle input.

### Step 3: Run!

The solution will be automatically discovered and appear in the menu. No registration required! ✨

## 📊 Progress

| Day | Part 1 | Part 2 | Title |
|-----|--------|--------|-------|
| 1   | ⭐     | ⭐     | Secret Entrance |
| 2   | ⭐     | ⭐     | Gift Shop |

## 🛠️ Technologies Used

- **C# / .NET 10.0** - Core language and runtime
- **Spectre.Console** - Beautiful CLI interfaces and formatting
- **Reflection** - Automatic solution discovery

## 📝 Solution Interface

All solutions implement the `ISolution` interface:

```csharp
public interface ISolution
{
    string Title { get; }
    long SolvePart1(string input);
    long SolvePart2(string input);
}
```

## 🎨 Features Showcase

### Interactive Menu
- Centered, styled panel with Advent of Code branding
- Green-highlighted selection
- Automatic solution discovery

### Execution Display
- Yellow-bordered header with puzzle title
- Green animated spinner during computation
- Performance timing in milliseconds/seconds
- Results table showing both parts with execution times

### Error Handling
- Friendly error messages for missing input files
- Direct links to puzzle input URLs
- Exception details for debugging

## 📜 License

This project is open source and available for personal use.

## 🎄 Happy Coding!

Good luck with Advent of Code 2025! May your code be bug-free and your stars be plentiful! ⭐⭐

---

*Created with ❤️ for Advent of Code 2025*