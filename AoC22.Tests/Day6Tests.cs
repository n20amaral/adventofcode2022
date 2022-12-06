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
}