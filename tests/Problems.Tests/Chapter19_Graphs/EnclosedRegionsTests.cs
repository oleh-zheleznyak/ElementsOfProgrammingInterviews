using System.Collections.Generic;
using Problems.Chapter19_Graphs;
using Xunit;

namespace Problems.Tests.Chapter19_Graphs;

public class EnclosedRegionsTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void ReplaceAllWhitesThatCannotReachBoundaryTest(bool[,] matrix, bool[,] expected)
    {
        var sut = new EnclosedRegions();
        sut.ReplaceAllWhitesThatCannotReachBoundary(matrix);
        Assert.Equal(expected,matrix);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return AllAreEnclosedIn2X2Matrix();
        yield return SingleWhiteInside3X3();
        yield return ExampleFromBook();
    }

    private static object[] AllAreEnclosedIn2X2Matrix() => new object[]
    {
        new bool[,] { {true,false}, {false,true} },
        new bool[,] { {true,false}, {false,true} },
    };
    
    private static object[] SingleWhiteInside3X3() => new object[]
    {
        new bool[,] { {false,false,false}, {false,true,false},{false,false,false} },
        new bool[,] { {false,false,false}, {false,false,false},{false,false,false} },
    };
    
    private static object[] ExampleFromBook() => new object[]
    {
        new bool[,]
        {
            {false,false,false,false}, 
            {true,false,true,false},
            {false, true,true,false},
            {false,false,false,false},
        },
        new bool[,]
        {
            {false,false,false,false}, 
            {true,false,false,false},
            {false,false,false,false},
            {false,false,false,false},
        },
    };

}