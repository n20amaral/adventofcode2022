using FluentAssertions;
using Xunit;
using Solutions;


namespace Tests;

public class Day8Tests
{
    [Theory]
    [InlineData("InputMocks/8.txt")]
    public void Part1(string filePath)
    {
        var (part1, part2) = Day8.GetAnswers(filePath);

        part1.Should().Be("21");
    }

    [Theory]
    [InlineData("InputMocks/8.txt")]
    public void Part2(string filePath)
    {
        var (part1, part2) = Day8.GetAnswers(filePath);

        part2.Should().Be("8");
    }
}