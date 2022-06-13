using System.Collections.Generic;
using System.Linq;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Chapter19_Graphs;

public class EnclosedRegions
{
    public void ReplaceAllWhitesThatCannotReachBoundary(bool[,] matrix)
    {
        // TODO: arg check
        var graph = CreateGraph(matrix);
        var pointsOnOuterEdge = GetAllWhitePointsOnOuterEdge(matrix);

        var visited = new HashSet<Point>();
        foreach (var point in pointsOnOuterEdge) DepthFirstSearch(point, graph,visited);

        PaintAllNonVisitedWhites(matrix,visited);
    }

    private IDictionary<Point, List<Point>> CreateGraph(bool[,] matrix) =>
        Point.GetAllPointsInMatrix(matrix)
            .Where(x=>matrix[x.row,x.col])
            .ToDictionary(
                x => x,
                y => y.GetNeighboursInMatrix(matrix).Where(z => matrix[z.row, z.col]).ToList());

    private IEnumerable<Point> GetAllWhitePointsOnOuterEdge(bool[,] matrix) =>
        GetAllPointsOnOuterEdge(matrix).Where(x => matrix[x.row, x.col]);
    private IEnumerable<Point> GetAllPointsOnOuterEdge<T>(T[,] matrix)
    {
        var maxRow = matrix.GetLength(0);
        var maxCol = matrix.GetLength(1);
        // first row
        for (int col = 0; col < maxCol; col++) yield return new Point(0, col);
        // last col
        for (int row = 1; row < maxRow; row++) yield return new Point(row, maxCol-1);
        //last row
        for (int col = maxCol-2; col>=0; col--) yield return new Point(maxRow-1, col);
        // first col
        for (int row = maxRow-2; row >=1; row--) yield return new Point(row, 0);
    }

    private void DepthFirstSearch(Point start, IDictionary<Point, List<Point>> graph, ISet<Point> visited)
    {
        if (visited.Contains(start)) return;
        visited.Add(start);
        if (!graph.TryGetValue(start, out var adjacent)) return;

        foreach (var edge in adjacent)
            DepthFirstSearch(start,graph,visited);
    }

    private void PaintAllNonVisitedWhites(bool[,] matrix, ISet<Point> visited)
    {
        var pointsToPaint = Point.GetAllPointsInMatrix(matrix).Where(x => matrix[x.row, x.col] && !visited.Contains(x));
        foreach (var point in pointsToPaint)
            matrix[point.row, point.col] = false;
    }
}