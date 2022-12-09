namespace Solutions;

public static class Day8
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var forest = LoadForestFromFile(inputFilePath);

        UpdateForest(forest);

        var part1 = forest.SelectMany(r => r).Count(t => t.IsVisible);
        var part2 = forest.SelectMany(r => r).Max(t => t.ScenicScore);

        return (part1.ToString(), part2.ToString());
    }

    private static void UpdateForest(IEnumerable<IEnumerable<Tree>> forest)
    {
        var rowCount = forest.Count();
        var columnCount = forest.First().Count();

        for (int i = 0; i < rowCount; i++)
        {
            if (i == 0 || i == rowCount - 1)
            {
                foreach (var tree in forest.ElementAt(i))
                {
                    tree.IsVisible = true;
                }

                continue;
            }

            forest.ElementAt(i).First().IsVisible = true;
            forest.ElementAt(i).Last().IsVisible = true;

            for (int j = 1; j < columnCount - 1; j++)
            {
                var currentTree = forest.ElementAt(i).ElementAt(j);

                var leftTrees = forest.ElementAt(i).SkipLast(columnCount - j);
                var rightTrees = forest.ElementAt(i).TakeLast(columnCount - j - 1);
                var upperTrees = forest.SkipLast(rowCount - i).Select(row => row.ElementAt(j));
                var bottomTrees = forest.TakeLast(rowCount - i - 1).Select(row => row.ElementAt(j));   //down

                if (
                    currentTree.Height > leftTrees.Max(t => t.Height) ||
                    currentTree.Height > rightTrees.Max(t => t.Height) ||
                    currentTree.Height > upperTrees.Max(t => t.Height) ||
                    currentTree.Height > bottomTrees.Max(t => t.Height)
                )
                {
                    currentTree.IsVisible = true;
                }

                currentTree.ScenicScore = CountSmallerTrees(currentTree.Height, leftTrees.Reverse()) *
                    CountSmallerTrees(currentTree.Height, rightTrees) *
                    CountSmallerTrees(currentTree.Height, upperTrees.Reverse()) *
                    CountSmallerTrees(currentTree.Height, bottomTrees);
            }
        }
    }

    private static int CountSmallerTrees(int height, IEnumerable<Tree> trees)
    {
        var treeCount = 0;
        foreach (var tree in trees)
        {
            treeCount++;

            if (height <= tree.Height)
            {
                break;
            }
        }

        return treeCount;
    }

    private static IEnumerable<IEnumerable<Tree>> LoadForestFromFile(string filePath)
    {
        var forest = new List<IEnumerable<Tree>>();

        foreach (var line in File.ReadLines(filePath))
        {
            forest.Add(line.ToCharArray().Select(c => new Tree() { Height = int.Parse(c.ToString()) }).ToArray());
        }

        return forest;
    }

    private class Tree
    {
        public int Height { get; set; }
        public bool IsVisible { get; set; }
        public int ScenicScore { get; set; }
    }

}