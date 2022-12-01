using Xunit;
using Solutions;
using FluentAssertions;

namespace Tests;

public class Day1Tests
{
    [Theory]
    [InlineData("InputMocks/1a.txt")]
    [InlineData("InputMocks/1b.txt")]
    [InlineData("InputMocks/1c.txt")]
    public void Part1(string input)
    {
        var (part1, part2) = Day1.GetAnswers(input);

        part1.Should().Be("24000");
    }

    [Theory]
    [InlineData("InputMocks/1a.txt")]
    [InlineData("InputMocks/1b.txt")]
    [InlineData("InputMocks/1c.txt")]
    public void Part2(string input)
    {
        var (part1, part2) = Day1.GetAnswers(input);

        part2.Should().Be("45000");
    }
}