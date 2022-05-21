using System.Collections.Generic;
using Xunit;

namespace Problems.Chapter18_GreedyAlgorithms;
public class IntervalCoveringTests
{

    [Theory]
    [MemberData(nameof(TestData))]
    public void FindMinimalCoverageTests(Interval[] intervals, int[] expectedCoverage)
    {
        var sut = new IntervalCovering();
        var actual = sut.FindMinimalCoverage(intervals);
        Assert.Equal(expectedCoverage, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return ExampleFromTheBook();
        yield return ExampleFromTheBook2();
        yield return NonOverlapping();
        yield return Nested();
        yield return Chained();
    }
    public static object[] ExampleFromTheBook() => new object[]
    {
        new Interval[] { new Interval(0,3), new Interval(2,6), new Interval(3,4), new Interval(6,9) },
        new int[] { 3,9 }
    };

    public static object[] ExampleFromTheBook2() => new object[]
{
        new Interval[] { new Interval(1,2), new Interval(2,3), new Interval(3,4), new Interval(2,3),new Interval(3,4),new Interval(4,5) },
        new int[] { 2,4 }
};

    public static object[] NonOverlapping() => new object[]
    {
        new Interval[] { new Interval(0,1), new Interval(2,3), new Interval(4,5) },
        new int[] { 1,3,5 }
    };

    public static object[] Nested() => new object[]
    {
        new Interval[] { new Interval(0,10), new Interval(1,9), new Interval(2,8) },
        new int[] { 8 }
    };

    public static object[] Chained() => new object[]
    {
        new Interval[] { new Interval(0,3), new Interval(2,5), new Interval(4,7) },
        new int[] { 3,7 }
    };

}