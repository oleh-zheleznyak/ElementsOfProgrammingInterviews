namespace Problems.Chapter17_DynamicProgramming;
using System;
using System.Collections.Generic;
using System.Linq;

public record struct Point(int row, int col)
{
    public bool BelongsToMatrix(int[,] matrix) =>
       row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
}

public class SearchForSequenceIn2DArray
{
    public bool MatrixContainsSequence(int[,] matrix, int[] sequence)
    {
        if (matrix is null) throw new ArgumentNullException(nameof(matrix));
        if (sequence is null) throw new ArgumentNullException(nameof(sequence));

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                var point = new Point(row, col);
                var span = new ReadOnlySpan<int>(sequence, 0, sequence.Length);
                var containsSequence = ContainsSequenceStartingAt(matrix, point, span);
                if (containsSequence) return true;
            }
        }
        return false;
    }

    // TODO: consider using Span instead of array + index
    private bool ContainsSequenceStartingAt(int[,] matrix, Point start, ReadOnlySpan<int> sequence)
    {
        if (sequence.IsEmpty) return true; // TODO; check - do we need this?
        if (start.row >= matrix.GetLength(0)) return false;
        if (start.col >= matrix.GetLength(1)) return false;
        if (matrix[start.row, start.col] != sequence[0]) return false;
        if (sequence.Length == 1) return true;

        // same as 
        var adjacentCellsContainSeq = false;
        var nextSequence = sequence.Slice(1);
        foreach (var point in GetAdjacentPointsWithinMatrix(start, matrix))
            adjacentCellsContainSeq = adjacentCellsContainSeq || ContainsSequenceStartingAt(matrix, point, nextSequence);
        return adjacentCellsContainSeq;
    }

    private IEnumerable<Point> GetAdjacentPointsWithinMatrix(Point point, int[,] matrix) =>
        GetAdjacentPoints(point)
        .Where(x => x.BelongsToMatrix(matrix));


    private IEnumerable<Point> GetAdjacentPoints(Point point)
    {
        yield return new Point(point.row - 1, point.col);
        yield return new Point(point.row + 1, point.col);
        yield return new Point(point.row, point.col - 1);
        yield return new Point(point.row, point.col + 1);
    }
}
