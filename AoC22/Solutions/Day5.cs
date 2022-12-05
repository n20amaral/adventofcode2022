namespace Solutions;

public static class Day5
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var ship = LoadShipFromFile(inputFilePath);

        var part1 = ship.TopContainers();

        return (string.Concat(part1), String.Empty);
    }

    private static Ship LoadShipFromFile(string filePath)
    {
        var containersInfo = new List<string>();
        Ship ship = null;
        foreach (var line in File.ReadLines(filePath))
        {
            if (ship == null)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    int numberOfStacks = containersInfo.Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).Count();
                    var containers = ExtractContainers(numberOfStacks, containersInfo.SkipLast(1));

                    ship = new Ship(numberOfStacks, containers);
                    continue;
                }

                containersInfo.Add(line);
                continue;
            }

            var instructions = new string[] { "move", "from", "to" };
            var instructionValues = line.Split(instructions, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(v => int.Parse(v)).ToArray();

            ship.RunInstruction(instructionValues[0], instructionValues[1], instructionValues[2]);
        }

        return ship ?? new Ship(0);
    }

    private static IEnumerable<char[]> ExtractContainers(int numberOfStacks, IEnumerable<string> containerInfo)
    {
        var containers = new List<char[]>();

        foreach (var line in containerInfo)
        {
            var containersRow = line.Chunk(4).Select(c => c[1]).ToArray();
            containers.Add(containersRow);
        }

        containers.Reverse();

        return containers;
    }

    private class Ship
    {
        private Stack<char>[] _containerStacks;

        public Ship(int numberOfStacks)
        {
            _containerStacks = new Stack<char>[numberOfStacks];

            for (int i = 0; i < numberOfStacks; i++)
            {
                _containerStacks[i] = (new Stack<char>());
            }
        }
        public Ship(int numberOfStacks, IEnumerable<char[]> containers) : this(numberOfStacks)
        {
            foreach (var containerRow in containers)
            {
                for (int i = 0; i < numberOfStacks; i++)
                {
                    if (containerRow[i] == ' ')
                    {
                        continue;
                    }
                    _containerStacks[i].Push(containerRow[i]);
                }
            }
        }

        public IEnumerable<char> TopContainers()
        {
            return _containerStacks.Select(s => s.Peek()).ToArray();
        }

        public void RunInstruction(int quantity, int from, int to)
        {
            var fromContainer = _containerStacks.ElementAt(from - 1);
            var toContainer = _containerStacks.ElementAt(to - 1);

            for (int i = 0; i < quantity; i++)
            {
                toContainer.Push(fromContainer.Pop());
            }
        }
    }
}