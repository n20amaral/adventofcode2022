using FluentAssertions;
using Xunit;
using Solutions;


namespace Tests;

public class Day7Tests
{
    [Theory]
    [InlineData("InputMocks/7.txt")]
    public void Part1(string filePath)
    {
        var (part1, part2) = Day7.GetAnswers(filePath);

        part1.Should().Be("95437");
    }


    [Theory]
    [InlineData("InputMocks/7.txt")]
    public void Part2(string filePath)
    {
        var (part1, part2) = Day7.GetAnswers(filePath);

        part2.Should().Be("24933642");
    }
}