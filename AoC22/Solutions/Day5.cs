namespace Solutions;

public static class Day5
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var ship = LoadShipFromFile(inputFilePath);

        var part1 = ship.SimulateTopContainers(false);
        var part2 = ship.SimulateTopContainers(true);

        return (string.Concat(part1), string.Concat(part2));
    }

    private static Ship LoadShipFromFile(string filePath)
    {
        var containersInfo = new List<string>();
        Ship? ship = null;

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

            ship.AddInstruction(line);
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
        private List<(int, int, int)> _instructions = new List<(int, int, int)>();

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

        public IEnumerable<char> SimulateTopContainers(bool isCrane9001)
        {
            var containerStacksCopy = _containerStacks.Select(s =>
            {
                var copy = new char[s.Count];
                s.CopyTo(copy, 0);
                Array.Reverse(copy);
                return new Stack<char>(copy);
            }).ToArray();

            foreach (var instruction in _instructions)
            {
                RunInstruction(instruction, containerStacksCopy, isCrane9001);
            }

            return containerStacksCopy.Select(s => s.Peek()).ToArray();
        }

        public void AddInstruction(string instructionText)
        {
            var operations = new string[] { "move", "from", "to" };
            var values = instructionText
                .Split(operations, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(v => int.Parse(v))
                .ToArray();

            _instructions.Add((values[0], values[1], values[2]));
        }

        private void RunInstruction((int, int, int) instruction, IEnumerable<Stack<char>> stacks, bool isCrane9001)
        {
            var (quantity, from, to) = instruction;
            var fromContainer = stacks.ElementAt(from - 1);
            var toContainer = stacks.ElementAt(to - 1);

            if (isCrane9001)
            {
                HandleContainers9001(fromContainer, toContainer, quantity);
            }
            else
            {
                HandleContainers9000(fromContainer, toContainer, quantity);
            }
        }

        private void HandleContainers9000(Stack<char> fromContainer, Stack<char> toContainer, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                toContainer.Push(fromContainer.Pop());
            }
        }

        private void HandleContainers9001(Stack<char> fromContainer, Stack<char> toContainer, int quantity)
        {
            var bufferStack = new Stack<char>();

            for (int i = 0; i < quantity; i++)
            {
                bufferStack.Push(fromContainer.Pop());
            }

            for (int i = 0; i < quantity; i++)
            {
                toContainer.Push(bufferStack.Pop());
            }
        }
    }
}