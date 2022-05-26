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
        yield return BookExample();
        yield return StartEnd();
        yield return HiTower();
        yield return LowTower();
    }
    
    private static object[] BookExample()=>
        new object[] { new int[] { 1, 2, 1, 3, 4, 4, 5, 6, 2, 1, 3, 1, 3, 2, 1, 2, 4, 1 }, (4, 16) };
    
    private static object[] StartEnd()=>
        new object[] { new int[] { 3, 2, 1, 2, 3 }, (0, 4) };
    
    private static object[] HiTower()=>
        new object[] { new int[] { 1, 2, 11, 11, 1, 2 }, (2, 3) };
    
    private static object[] LowTower()=>
        new object[] { new int[] { 1, 2, 5, 5, 1, 2 }, (1, 5) };
}
