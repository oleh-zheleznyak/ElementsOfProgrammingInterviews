using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Chapter19_Graphs;

public interface ISearchAMaze
{
    IReadOnlyList<Point> FindPath(bool[,] maze, Point start, Point end);
}