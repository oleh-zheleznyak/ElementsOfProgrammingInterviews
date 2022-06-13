using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;
using Problems.Chapter19_Graphs;
using Xunit;

namespace Problems.Tests.Chapter19_Graphs;

public class PaintABooleanMatrixTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void PaintTests(bool[,] matrix, Point start, bool[,] expected)
    {
        var sut = new PaintABooleanMatrix();
        sut.Paint(matrix, start);
        Assert.Equal(expected,matrix);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return TwoByTwoSingleColor();
        yield return TwoByTwoCross();
        yield return TwoByTwoCorner();
    }

    private static object[] TwoByTwoSingleColor() =>
        new object[]
        {
            new bool[,] { {false,false}, {false,false}},
            new Point(0,0),
            new bool[,] {{true,true}, {true,true}}
        };
    
    private static object[] TwoByTwoCross() =>
        new object[]
        {
            new bool[,] { {false,true}, {true,false}},
            new Point(1,1),
            new bool[,] {{false,true}, {true,true}}
        };
    
    private static object[] TwoByTwoCorner() =>
        new object[]
        {
            new bool[,] { {false,false}, {false,true}},
            new Point(0,0),
            new bool[,] {{true,true}, {true,true}}
        };
}