using System.Reflection;

for (int i = 1; i <= 25; i++)
{
    MethodInfo? getAnswersMethod = Type.GetType($"Solutions.Day{i}")?.GetMethod("GetAnswers");
    object? result = getAnswersMethod?.Invoke(null, new object[] { $"inputs/{i}.txt" });

    Console.Write($"*** Day {(i < 10 ? " " : "")}{i} ***\t");

    if (result == null)
    {
        Console.WriteLine("N/A");
        continue;
    }

    var (part1, part2) = ((string, string))result;
    Console.WriteLine($"Part1: {part1} | Part2: {part2}");
}