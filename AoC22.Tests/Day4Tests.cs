using Xunit;
using Solutions;
using FluentAssertions;

namespace Tests;

public class Day4Tests
{
    [Theory]
    [InlineData("InputMocks/4.txt")]
    public void Part1(string input)
    {
        var (part1, part2) = Day4.GetAnswers(input);

        part1.Should().Be("2");
    }

    [Theory]
    [InlineData("InputMocks/4.txt")]
    public void Part2(string input)
    {
        var (part1, part2) = Day4.GetAnswers(input);

        part2.Should().Be("4");
    }
}