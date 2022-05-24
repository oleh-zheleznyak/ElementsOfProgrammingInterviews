using Problems.Chapter18_GreedyAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter18_GreedyAlgorithms;

public class MaxWaterTrappedByVerticalLinesTest
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindPairThatTrapsMaxWaterTest(int[] array, (int,int) expectedPair)
    {
        var sut = new MaxWaterTrappedByVerticalLines();
        var actualPair = sut.FindPairThatTrapsMaxWater(array);
        Assert.Equal(expectedPair, actualPair);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new int[] { 1, 2, 1, 3, 4, 4, 5, 6, 2, 1, 3, 1, 3, 2, 1, 2, 4, 1 }, (4, 16) };
    }
}
