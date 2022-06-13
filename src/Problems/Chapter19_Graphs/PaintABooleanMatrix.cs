using System.Collections.Generic;
using System.Linq;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Chapter19_Graphs;

public class PaintABooleanMatrix
{
    public void Paint(bool[,] matrix, Point point)
    {
        // convert matrix to graph - adjacent vertices of the same color are connected
        var graph = BuildGraph(matrix);

        // do a BFS or DFS starting at point
        var visited = DepthFirstSearch(graph, point);

        // invert the color of all entries found
        InvertColors(matrix, visited);
    }

    private void InvertColors(bool[,] matrix, ISet<Point> visited)
    {
        foreach (var point in visited)
            matrix[point.row, point.col] = !matrix[point.row, point.col];
    }
    private ISet<Point> DepthFirstSearch(IDictionary<Point, List<Point>> graph, Point start)
    {
        var visited = new HashSet<Point>();
        DepthFirstSearch(graph, start, visited);
        return visited;
    }

    private void DepthFirstSearch(IDictionary<Point, List<Point>> graph, Point start, ISet<Point> visited)
    {
        if (visited.Contains(start)) return;
        visited.Add(start);        
        if (!graph.TryGetValue(start, out var neighbours)) return;
        foreach (var neighbour in neighbours)
        {
            if (!visited.Contains(neighbour))
                DepthFirstSearch(graph, neighbour, visited);
        }
    }

    private IDictionary<Point, List<Point>> BuildGraph(bool[,] matrix)=>
        Point.GetAllPointsInMatrix(matrix).ToDictionary(
            x=>x,
            p=> p.GetNeighboursInMatrix(matrix).Where(x => matrix[x.row, x.col] == matrix[p.row, p.col]).ToList());
}