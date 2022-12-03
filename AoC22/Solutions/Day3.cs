namespace Solutions;

public static class Day3
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var ruckSackGroups = LoadRuckSacks(inputFilePath);

        var part1 = ruckSackGroups.Sum(g => g.SharedPriorityTotal);
        var part2 = ruckSackGroups.Sum(g => g.BadgePriority);

        return (part1.ToString(), part2.ToString());
    }

    private static IEnumerable<RuckSackGroup> LoadRuckSacks(string filePath)
    {
        var groups = new List<RuckSackGroup>();
        var currentGroup = new RuckSackGroup();
        groups.Add(currentGroup);

        foreach (var line in System.IO.File.ReadLines(filePath))
        {
            if (currentGroup.isFull)
            {
                currentGroup = new RuckSackGroup();
                groups.Add(currentGroup);
            }

            currentGroup.Add(new RuckSack(line));
        }

        return groups;
    }

    private class RuckSack
    {
        private IEnumerable<char> _leftCompartiment;
        private IEnumerable<char> _rightCompartiment;
        public RuckSack(string content)
        {
            (_leftCompartiment, _rightCompartiment) = SplitContent(content);
            Content = content.ToCharArray();
        }

        public IEnumerable<char> Content { get; private set; }
        public char Badge { get; set; }
        public int SharedPriority => GetPriority(GetCompartimentIntersection().First());
        public int BadgePriority => GetPriority(Badge);

        private int GetPriority(char itemType)
        {
            var charCode = (int)itemType;
            var firstLower = (int)'a';
            var firstUpper = (int)'A';

            return charCode >= firstLower ? charCode - firstLower + 1 : charCode - firstUpper + 27;
        }

        private IEnumerable<char> GetCompartimentIntersection()
        {
            return _leftCompartiment.Intersect(_rightCompartiment);
        }

        private (IEnumerable<char>, IEnumerable<char>) SplitContent(string content)
        {
            var half = content.Length / 2;
            var left = content.Substring(0, half);
            var right = content.Substring(half, half);

            return (left.ToCharArray(), right.ToCharArray());
        }
    }

    private class RuckSackGroup
    {
        private IList<RuckSack> ruckSacks = new List<RuckSack>();
        public bool isFull => ruckSacks.Count == 3;
        public int SharedPriorityTotal => ruckSacks.Sum(r => r.SharedPriority);
        public int BadgePriority => ruckSacks.First().BadgePriority;

        public void Add(RuckSack ruckSack)
        {
            ruckSacks.Add(ruckSack);
            UpdateBadges();
        }

        private void UpdateBadges()
        {
            var allContents = ruckSacks.Select(r => r.Content).ToList();
            HashSet<char> uniqueItemTypes = new HashSet<char>(allContents.First());

            foreach (var content in allContents.Skip(1))
            {
                uniqueItemTypes.IntersectWith(content);
            }

            var badge = uniqueItemTypes.First();

            foreach (var ruckSack in ruckSacks)
            {
                ruckSack.Badge = badge;
            }
        }
    }
}