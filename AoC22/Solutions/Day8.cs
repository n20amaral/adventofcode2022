namespace Solutions;

public static class Day8
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var forest = LoadForestFromFile(inputFilePath);

        var part1 = CountVisibleTrees(forest);

        return (part1.ToString(), String.Empty);
    }

    private static int CountVisibleTrees(IEnumerable<IEnumerable<int>> forest)
    {
        var rowCount = forest.Count();
        var columnCount = forest.First().Count();
        var visibleTrees = (columnCount * 2) + ((rowCount - 2) * 2);

        for (int i = 1; i < rowCount - 1; i++)
        {
            for (int j = 1; j < columnCount - 1; j++)
            {
                var currentTree = forest.ElementAt(i).ElementAt(j);

                if (currentTree > forest.ElementAt(i).SkipLast(columnCount - j).Max() ||                     //left
                    currentTree > forest.ElementAt(i).TakeLast(columnCount - j - 1).Max() ||                //right
                    currentTree > forest.SkipLast(rowCount - i).Select(row => row.ElementAt(j)).Max() ||    //up
                    currentTree > forest.TakeLast(rowCount - i - 1).Select(row => row.ElementAt(j)).Max()   //down
                )
                {
                    visibleTrees++;
                }
            }
        }

        return visibleTrees;
    }

    private static IEnumerable<IEnumerable<int>> LoadForestFromFile(string filePath)
    {
        var forest = new List<IEnumerable<int>>();

        foreach (var line in File.ReadLines(filePath))
        {
            forest.Add(line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray());
        }

        return forest;
    }

}