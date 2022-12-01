namespace Solutions;

public static class Day1
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var elves = LoadElvesFromFile(inputFilePath);

        var mostCaloriesElf = elves.Max(e => e.CaloriesTotal);
        var top3ElfCaloriesSum = elves.OrderByDescending(e => e.CaloriesTotal).Take(3).Sum(e => e.CaloriesTotal);

        return (mostCaloriesElf.ToString(), top3ElfCaloriesSum.ToString());
    }

    private static IEnumerable<Elf> LoadElvesFromFile(string filePath)
    {
        var elves = new List<Elf>();
        var currentElf = new Elf();
        elves.Add(currentElf);

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

        return elves;
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