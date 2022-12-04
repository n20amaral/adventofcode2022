namespace Solutions;

public static class Day4
{
    public static (string, string) GetAnswers(string inputFilePath)
    {
        var assignmentPairs = LoadAssignments(inputFilePath);

        var part1 = assignmentPairs.Where(a => a.IsFullyContained).Count();

        return (part1.ToString(), String.Empty);
    }

    private static List<AssignmentPair> LoadAssignments(string filePath)
    {
        var assignmentPairs = new List<AssignmentPair>();

        foreach (var line in File.ReadLines(filePath))
        {
            var assignments = line.Split(',');
            assignmentPairs.Add(new AssignmentPair(assignments[0], assignments[1]));
        }

        return assignmentPairs;
    }

    private class AssignmentPair
    {
        private int assignmentOneStart;
        private int assignmentOneEnd;
        private int assignmentTwoStart;
        private int assignmentTwoEnd;
        public AssignmentPair(string pairOneRange, string pairTwoRange)
        {
            (assignmentOneStart, assignmentOneEnd) = parseRange(pairOneRange);
            (assignmentTwoStart, assignmentTwoEnd) = parseRange(pairTwoRange);
        }

        public (int, int) AssignmentOne => (assignmentOneStart, assignmentOneEnd);
        public (int, int) AssignmentTwo => (assignmentTwoStart, assignmentTwoEnd);
        public bool IsFullyContained =>
        (assignmentOneStart >= assignmentTwoStart && assignmentOneEnd <= assignmentTwoEnd) ||
        (assignmentTwoStart >= assignmentOneStart && assignmentTwoEnd <= assignmentOneEnd);

        private (int, int) parseRange(string rangeText)
        {
            var range = rangeText.Split('-');
            var min = int.Parse(range[0]);
            var max = int.Parse(range[1]);

            return (min, max);
        }
    }
}