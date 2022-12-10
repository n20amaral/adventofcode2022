using FluentAssertions;
using Solutions;
using Xunit;

namespace Tests;

public class Day9Tests
{
    [Theory]
    [InlineData("InputMocks/9a.txt")]
    public void Part1Test(string inputFilePath)
    {
        var (part1, part2) = Day9.GetAnswers(inputFilePath);

        part1.Should().Be("13");
    }

    [Theory]
    //[InlineData("InputMocks/9a.txt", "1")]
    [InlineData("InputMocks/9b.txt", "36")]
    public void Part2Test(string inputFilePath, string expectedOutput)
    {
        var (part1, part2) = Day9.GetAnswers(inputFilePath);

        part2.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData(new[] { "R 4" }, 4, 0, 3, 0, 4)]
    [InlineData(new[] { "R 4", "U 4" }, 4, 4, 4, 3, 7)]
    [InlineData(new[] { "R 4", "U 4", "L 3" }, 1, 4, 2, 4, 9)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1" }, 1, 3, 2, 4, 9)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4" }, 5, 3, 4, 3, 10)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1" }, 5, 2, 4, 3, 10)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5" }, 0, 2, 1, 2, 13)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" }, 2, 2, 1, 2, 13)]
    public void MoveTest(string[] moves, int headX, int headY, int tailX, int tailY, int tailVisited)
    {
        var rope = new Rope();

        foreach (var move in moves)
        {
            rope.Move(move);
        }

        rope.Head.Should().Be((headX, headY));
        rope.Tail.Should().Be((tailX, tailY));
        rope.TailVisitedNodes.Count.Should().Be(tailVisited);
    }

    [Theory]
    [InlineData(new[] { "R 4" }, 4, 0,
    new[] { 3, 2, 1, 0, 0, 0, 0, 0, 0 },
    new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4" }, 4, 4,
    new[] { 4, 4, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 3, 2, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3" }, 1, 4,
    new[] { 2, 3, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 4, 3, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1" }, 1, 3,
    new[] { 2, 3, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 4, 3, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4" }, 5, 3,
    new[] { 4, 3, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 3, 3, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1" }, 5, 2,
    new[] { 4, 3, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 3, 3, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5" }, 0, 2,
    new[] { 1, 2, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 2, 2, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 4", "U 4", "L 3", "D 1", "R 4", "D 1", "L 5", "R 2" }, 2, 2,
    new[] { 1, 2, 3, 2, 1, 0, 0, 0, 0 },
    new[] { 2, 2, 2, 2, 1, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 5" }, 5, 0,
    new[] { 4, 3, 2, 1, 0, 0, 0, 0, 0 },
    new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1)]
    [InlineData(new[] { "R 5", "U 8" }, 5, 8,
    new[] { 5, 5, 5, 5, 4, 3, 2, 1, 0 },
    new[] { 7, 6, 5, 4, 4, 3, 2, 1, 0 }, 1)]
    [InlineData(new[] { "R 5", "U 8", "L 8" }, -3, 8,
    new[] { -2, -1, 0, 1, 1, 1, 1, 1, 1 },
    new[] { 8, 8, 8, 8, 7, 6, 5, 4, 3 }, 4)]
    [InlineData(new[] { "R 5", "U 8", "L 8", "D 3" }, -3, 5,
    new[] { -3, -2, -1, 0, 1, 1, 1, 1, 1 },
    new[] { 6, 7, 7, 7, 7, 6, 5, 4, 3 }, 4)]
    [InlineData(new[] { "R 5", "U 8", "L 8", "D 3", "R 17" }, 14, 5,
    new[] { 13, 12, 11, 10, 9, 8, 7, 6, 5 },
    new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 8)]

    public void MoveKnotTest(string[] moves, int headX, int headY, int[] tailX, int[] tailY, int tailVisited)
    {
        var rope = new Rope();

        foreach (var move in moves)
        {
            rope.Move(move);
        }

        rope.Head.Should().Be((headX, headY));
        for (int i = 0; i < tailX.Length; i++)
        {
            rope.Knots[i].Should().Be((tailX[i], tailY[i]));
        }

        rope.KnotVisitedNodes.Count.Should().Be(tailVisited);
    }

}