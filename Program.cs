using System.Reflection;

for (int i = 1; i <= 25; i++)
{
    Type? type = Type.GetType($"Solutions.Day{i}");
    MethodInfo? method = type?.GetMethod("GetAnswers");
    object? result = method?.Invoke(null, new object[] { $"inputs/{i}.txt" });

    Console.Write($"*** Day {(i < 10 ? " " : "")}{i} ***\t");

    if (result == null)
    {
        Console.WriteLine("N/A");
        continue;
    }

    var (part1, part2) = ((int, int))result;
    Console.WriteLine($"Part1: {part1} | Part2: {part2}");
}