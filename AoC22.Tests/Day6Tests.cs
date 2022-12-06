using FluentAssertions;
using Xunit;
using Solutions;

namespace Tests;

public class Day6Tests
{
    [Theory]
    [InlineData("InputMocks/6a.txt", "7")]
    [InlineData("InputMocks/6b.txt", "5")]
    [InlineData("InputMocks/6c.txt", "6")]
    [InlineData("InputMocks/6d.txt", "10")]
    [InlineData("InputMocks/6e.txt", "11")]

    public void Part1(string input, string expectedOutput)
    {
        var (part1, part2) = Day6.GetAnswers(input);

        part1.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData("InputMocks/6a.txt", "19")]
    [InlineData("InputMocks/6b.txt", "23")]
    [InlineData("InputMocks/6c.txt", "23")]
    [InlineData("InputMocks/6d.txt", "29")]
    [InlineData("InputMocks/6e.txt", "26")]

    public void Part2(string input, string expectedOutput)
    {
        var (part1, part2) = Day6.GetAnswers(input);

        part2.Should().Be(expectedOutput);
    }
}