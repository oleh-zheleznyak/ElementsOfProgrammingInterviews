using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Tests.Chapter19_Graphs;

public class SearchAMazeBfsTestsBase
{
    public static IEnumerable<object[]> TestData()
    {
        yield return TwoByTwoWithSinglePath();
    }

    public static object[] TwoByTwoWithSinglePath()
    {
        return new object[]
        {
            new bool[,] { {true, true}, {false, true} },
            new Point(0,0),
            new Point(1,1),
            new List<Point>() {new Point(0,0), new Point(0,1), new Point(1,1)}
        };
    }
}