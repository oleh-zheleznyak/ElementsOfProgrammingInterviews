using Problems.Chapter18_GreedyAlgorithms;
using Xunit;

namespace Chapter18_GreedyAlgorithms.Tests;

public class OptimumAssignmentOfTasksTests
{
    [Theory]
    [InlineData(new uint[] { 1 }, 1)]
    [InlineData(new uint[] { 1,2 }, 3)]
    [InlineData(new uint[] { 1,8,9,10 }, 17)]
    [InlineData(new uint[] { 5,2,1,6,4,4 }, 8)]
    public void FindMinimumWeightPathTest(uint[] array, uint expectedMaxLength)
    {
        var sut = new OptimumAssignmentOfTasks();
        var actual = sut.FindOptimumAssignment(array);
        Assert.Equal(expectedMaxLength, actual);
    }
}