using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter17_DynamicProgramming;

public readonly record struct Point(int row, int col)
{
    public bool BelongsToMatrix<T>(T[,] matrix) =>
        row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    
    public IEnumerable<Point> GetNeighbours()
    {
        yield return new Point(row - 1, col);
        yield return new Point(row + 1, col);
        yield return new Point(row, col - 1);
        yield return new Point(row, col + 1);
    }

    public IEnumerable<Point> GetNeighboursInMatrix<T>(T[,] matrix) =>
        GetNeighbours().Where(x => x.BelongsToMatrix(matrix));
    
    public static IEnumerable<Point> GetAllPointsInMatrix<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
                yield return new Point(i, j);
    }
}