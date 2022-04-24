using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;
using Xunit;
namespace Chapter17_DynamicProgramming;

public class KnapsackTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void MatrixContainsSequenceTests(Clock[] clocks, int weigth, int expectedValue)
    {
        var sut = new Knapsack();
        var actual = sut.MaxValueWithinWeight(clocks, weigth);
        Assert.Equal(expectedValue, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return NoClocksNoValue();
        yield return SingleClockWithAllowedWeight();
        yield return SingleClockThatIsTooHeavy();
    }
    public static object[] NoClocksNoValue() => new object[] { new Clock[0], 42, 0 };
    public static object[] SingleClockWithAllowedWeight() => new object[] { new Clock[] { new Clock(100, 42) }, 42 + 1, 100 };

    public static object[] SingleClockThatIsTooHeavy() => new object[] { new Clock[] { new Clock(100, 42) }, 42 - 1, 0 };
}
