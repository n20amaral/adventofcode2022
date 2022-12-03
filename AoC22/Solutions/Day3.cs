namespace Solutions;

public static class Day3
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var rucksacks = LoadRuckSacks(inputFilePath);

        var part1 = rucksacks.Sum(r => r.SharedPriority);

        return (part1.ToString(), String.Empty);
    }

    private static IEnumerable<RuckSack> LoadRuckSacks(string filePath)
    {
        var rucksacks = new List<RuckSack>();

        foreach (var line in System.IO.File.ReadLines(filePath))
        {
            rucksacks.Add(new RuckSack(line));
        }

        return rucksacks;
    }

    private class RuckSack
    {
        private string _leftCompartiment;
        private string _rightCompartiment;
        public RuckSack(string content)
        {
            (_leftCompartiment, _rightCompartiment) = SplitContent(content);
        }

        public int SharedPriority => GetPriority(GetCompartimentIntersection().First());

        private int GetPriority(char itemType)
        {
            var charCode = (int)itemType;
            var firstLower = (int)'a';
            var firstUpper = (int)'A';

            return charCode >= firstLower ? charCode - firstLower + 1 : charCode - firstUpper + 27;
        }

        private IEnumerable<char> GetCompartimentIntersection()
        {
            return _leftCompartiment.ToCharArray().Intersect(_rightCompartiment.ToCharArray());
        }

        private (string, string) SplitContent(string content)
        {
            var half = content.Length / 2;
            var left = content.Substring(0, half);
            var right = content.Substring(half, half);

            return (left, right);
        }
    }
}