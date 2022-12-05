using FluentAssertions;
using Xunit;
using Solutions;

namespace Tests;

public class Day5Tests
{
    [Theory]
    [InlineData("InputMocks/5.txt")]
    public void Part1(string input)
    {
        var (part1, part2) = Day5.GetAnswers(input);

        part1.Should().Be("CMZ");
    }
}