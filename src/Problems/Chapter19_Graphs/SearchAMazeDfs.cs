using System;
using System.Collections.Generic;
using System.Linq;
using Problems.Chapter17_DynamicProgramming;

namespace Problems.Chapter19_Graphs;

public class SearchAMazeDfs : ISearchAMaze
{
    public IReadOnlyList<Point> FindPath(bool[,] maze, Point start, Point end)
    {
        if (!start.BelongsToMatrix(maze))
            throw new ArgumentException($"point {start} is outside of maze", nameof(start));
        if (!end.BelongsToMatrix(maze)) throw new ArgumentException($"point {end} is outside of maze", nameof(end));

        var path = new List<Point>();
        var visited = new HashSet<Point>();
        if (DepthFirstSearch(maze, start, end, path, visited)) return path;
        return new List<Point>();
    }

    private bool DepthFirstSearch(bool[,] maze, Point current, Point end, IList<Point> path, ISet<Point> visited)
    {
        path.Add(current);
        visited.Add(current);
        if (current == end) return true;

        var neighbours = GetNeighboursWithinMatrix(current, maze);
        foreach (var neighbour in neighbours)
        {
            if (!visited.Contains(neighbour) &&
                DepthFirstSearch(maze, neighbour, end, path, visited)) return true;
        }

        path.Remove(current);
        return false;
    }

    private IEnumerable<Point> GetNeighboursWithinMatrix(Point point, bool[,] maze) =>
        point.GetNeighboursInMatrix(maze).Where(p => maze[p.row, p.col]);
    
}