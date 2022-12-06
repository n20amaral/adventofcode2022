using FluentAssertions;
using Xunit;
using Solutions;

namespace Tests;

public class Day6Tests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", "7")]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", "5")]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", "6")]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", "10")]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", "11")]

    public void Part1(string input, string expectedOutput)
    {
        var (part1, part2) = Day6.GetAnswers(input);

        part1.Should().Be(expectedOutput);
    }
}