using System.Collections.Generic;
using System.ComponentModel;
using Problems.Chapter17_DynamicProgramming;
using Problems.Chapter19_Graphs;
using Xunit;

namespace Problems.Tests.Chapter19_Graphs;

public class SearchAMazeDfsTests : SearchAMazeBfsTestsBase
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindPathTests(bool[,] matrix, Point start, Point end, List<Point> expectedPath)
    {
        var mazeRunner = new SearchAMazeDfs();
        var actualPath = mazeRunner.FindPath(matrix, start, end);
        Assert.Equal(expectedPath,actualPath);
    }
}