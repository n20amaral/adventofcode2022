using Xunit;
using Solutions;
using FluentAssertions;

namespace Tests;

public class Day2Tests
{
    [Theory]
    [InlineData("InputMocks/2a.txt")]
    [InlineData("InputMocks/2b.txt")]
    [InlineData("InputMocks/2c.txt")]
    [InlineData("InputMocks/2d.txt")]
    [InlineData("InputMocks/2e.txt")]
    [InlineData("InputMocks/2f.txt")]
    public void Part1(string input)
    {
        var (part1, part2) = Day2.GetAnswers(input);

        part1.Should().Be("15");
    }

    [Theory]
    [InlineData("InputMocks/2a.txt")]
    [InlineData("InputMocks/2b.txt")]
    [InlineData("InputMocks/2c.txt")]
    [InlineData("InputMocks/2d.txt")]
    [InlineData("InputMocks/2e.txt")]
    [InlineData("InputMocks/2f.txt")]
    public void Part2(string input)
    {
        var (part1, part2) = Day2.GetAnswers(input);

        part2.Should().Be("12");
    }
}