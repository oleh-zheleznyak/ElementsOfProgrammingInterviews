using Problems.Chapter17_DynamicProgramming;
using Xunit;

namespace Chapter17_DynamicProgramming.Tests;

public class LongestNonDecreasingSubSequenceByTheBookTests
{
    [Theory]
    [InlineData(new int[] {1}, 1)]
    [InlineData(new int[] {1,2}, 2)]
    [InlineData(new int[] {2,1}, 1)]
    [InlineData(new int[] {1,2,3}, 3)]
    [InlineData(new int[] {2,1,3}, 2)]
    [InlineData(new int[] {1,3,2}, 2)]
    [InlineData(new int[] {0,8,4,12,2,10,6,14,1,9}, 4)]
    public void FindMinimumWeightPathTest(int[] array, int expectedMaxLength)
    {
        var sut = new LongestNonDecreasingSubSequenceByTheBook();
        var actual = sut.Length(array);
        Assert.Equal(expectedMaxLength, actual);
    }
}