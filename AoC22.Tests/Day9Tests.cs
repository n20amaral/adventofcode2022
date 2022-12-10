using FluentAssertions;
using Solutions;
using Xunit;

namespace Tests;

public class Day9Tests
{
    [Theory]
    [InlineData("InputMocks/9.txt")]
    public void Part1Test(string inputFilePath)
    {
        var (part1, part2) = Day9.GetAnswers(inputFilePath);

        part1.Should().Be("13");
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

}