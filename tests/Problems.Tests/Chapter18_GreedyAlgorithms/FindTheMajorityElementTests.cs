using Problems.Chapter18_GreedyAlgorithms;
using Xunit;

namespace Problems.Tests.Chapter18_GreedyAlgorithms;

public class FindTheMajorityElementTests
{
    [Theory]
    [InlineData(new string[] { "b", "a", "c", "a", "a", "b", "a", "a", "c", "a" }, "a")]
    [InlineData(new string[] { "1", "2", "1" }, "1")]
    [InlineData(new string[] { "1", "2", "1", "2", "1", "1" }, "1")]
    public void FindInArrayTest(string[] array, string expected)
    {
        var sut = new FindTheMajorityElement();
        var actual = sut.FindInArray(array);
        Assert.Equal(expected, actual);
    }
}
