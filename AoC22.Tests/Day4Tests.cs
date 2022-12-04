using Xunit;
using Solutions;
using FluentAssertions;

namespace Tests;

public class Day3Tests
{
    [Theory]
    [InlineData("InputMocks/3.txt")]
    public void Part1(string input)
    {
        var (part1, part2) = Day3.GetAnswers(input);

        part1.Should().Be("157");
    }

    [Theory]
    [InlineData("InputMocks/3.txt")]
    public void Part2(string input)
    {
        var (part1, part2) = Day3.GetAnswers(input);

        part2.Should().Be("70");
    }
}