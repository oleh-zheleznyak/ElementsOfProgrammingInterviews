using Problems.Chapter18_GreedyAlgorithms;
using Xunit;

namespace Chapter18_GreedyAlgorithms.Tests;

public class ScheduleToMinimizeWaitingTimeTests
{
    [Theory]
    [InlineData(new int[] { 2,5,1,3 }, 10)]
    public void FindMinimumWeightPathTest(int[] array, int expectedWaitTime)
    {
        var sut = new ScheduleToMinimizeWaitingTime();
        var actual = sut.OrderOfMinWaitTime(array);
        Assert.Equal(expectedWaitTime, actual.waitTime);
    }
}