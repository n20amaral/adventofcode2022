namespace Solutions;

public static class Day1
{
    public static (int, int) GetAnswers(string inputFilePath)
    {
        var elves = new List<Elf>();
        LoadElvesFromFile(inputFilePath, elves);

        elves.Sort((a, b) => b.CaloriesTotal - a.CaloriesTotal);

        var mostCaloriesElf = elves.Max(e => e.CaloriesTotal);
        var top3ElfCaloriesSum = elves.Take(3).Sum(e => e.CaloriesTotal);

        return (mostCaloriesElf, top3ElfCaloriesSum);
    }

    private static void LoadElvesFromFile(string filePath, IList<Elf> elves)
    {
        var currentElf = new Elf();

        foreach (string line in System.IO.File.ReadLines(filePath))
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                currentElf = new Elf();
                elves.Add(currentElf);
                continue;
            }

            currentElf.ConsumeCalories(line);
        }
    }
    private class Elf
    {
        private List<int> _calories = new List<int>();
        public int CaloriesTotal => _calories.Sum();
        public void ConsumeCalories(string calories)
        {
            var value = 0;
            Int32.TryParse(calories, out value);
            _calories.Add(value);
        }
    }
}