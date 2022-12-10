using FluentAssertions;
using Solutions;
using Xunit;

namespace Tests;

public class Day10Tests
{
    [Theory]
    [InlineData("InputMocks/10.txt")]
    public void Part1Test(string inputFilePath)
    {
        var (part1, part2) = Day10.GetAnswers(inputFilePath);

        part1.Should().Be("13140");
    }

    [Theory]
    [InlineData("InputMocks/10.txt")]
    public void Part2Test(string inputFilePath)
    {
        var (part1, part2) = Day10.GetAnswers(inputFilePath);

        part2.Should().Be("\n##..##..##..##..##..##..##..##..##..##..\n###...###...###...###...###...###...###.\n####....####....####....####....####....\n#####.....#####.....#####.....#####.....\n######......######......######......####\n#######.......#######.......#######.....");
    }
}