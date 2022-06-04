using System;
using System.Collections.Generic;
using System.Linq;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Chapter19_Graphs;

public class SearchAMazeBfs : ISearchAMaze
{
    public IReadOnlyList<Point> FindPath(bool[,] maze, Point start, Point end)
    {
        if (!start.BelongsToMatrix(maze))
            throw new ArgumentException($"point {start} is outside of maze", nameof(start));
        if (!end.BelongsToMatrix(maze)) throw new ArgumentException($"point {end} is outside of maze", nameof(end));

        var graph = BuildGraphFromMaze(maze);

        // depth first search
        var previous = DepthFirstSearch(start, end, graph);

        return ReconstructPath(end, previous);
    }

    private static List<Point> ReconstructPath(Point end, Dictionary<Point, Point> previous)
    {
        if (!previous.ContainsKey(end)) return new List<Point>();
        var path = new List<Point>();
        var last = end;
        while (previous.TryGetValue(last, out var from))
        {
            path.Add(last);
            last = from;
        }

        path.Reverse();
        return path;
    }

    private static Dictionary<Point, Point> DepthFirstSearch(Point start, Point end, Dictionary<Point, List<Point>> graph)
    {
        var queue = new Queue<Point>();
        queue.Enqueue(start);
        var previous = new Dictionary<Point, Point>();
        previous[start] = new Point(-1,-1);

        while (queue.Count > 0)
        {
            var point = queue.Dequeue();
            var adjacent = graph[point];
            foreach (var p in adjacent)
            {
                if (!previous.ContainsKey(p))
                {
                    queue.Enqueue(p);
                    previous[p] = point;
                }

                if (p == end) break;
            }
        }

        return previous;
    }

    private Dictionary<Point, List<Point>> BuildGraphFromMaze(bool[,] maze) =>
        GetAllPointsInMaze(maze).ToDictionary(x => x, y => GetNeighboursWithinMatrix(y, maze).ToList());

    private IEnumerable<Point> GetAllPointsInMaze(bool[,] maze)
    {
        for (int i = 0; i < maze.GetLength(0); i++)
            for (int j = 0; j < maze.GetLength(1); j++)
                if (maze[i, j])
                    yield return new Point(i, j);
    }

    private IEnumerable<Point> GetNeighboursWithinMatrix(Point point, bool[,] maze) =>
        point.GetNeighboursInMatrix(maze).Where(p => maze[p.row, p.col]);
}