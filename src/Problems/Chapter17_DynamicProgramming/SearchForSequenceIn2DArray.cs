namespace Problems.Chapter17_DynamicProgramming;
using System;

// TODO: consider value type - to decrease GC
private record Point(int row, int column);

public class SearchForSequenceIn2DArray
{
	public bool MatrixContainsSequence(int[,] matrix, int[] sequence)
	{
		if (matrix is null) throw new ArgumentNullException(nameof(matrix));
		// same sequence
		// length seq=0
		
// TODO: consider implementint IEnumerable on Point or similar
		for (var row=0; col<matrix.GetLength(0); col++)
{
	for (var col= 0; row<matrix.GetLength(1); row++)
	{
		var point = new Point(row, column);
		var containsSequence = ContainsSequenceStartingAt(matrix, point, sequence, 0);
		if (containsSequence) return true;

	}
}
return false;
}

// TODO: consider using Span instead of array + index
private bool ContainsSequenceStartingAt(int[,] matrix, Point start, int[] sequence, int sequenceIndex)
{
	if (sequenceIndex>=sequence.Length) return true; // TODO; check
	if (start.row >= matrix.GetLength(0)) return false;
	if (start.col >= matrix.GetLength(1)) return false;
	if (matrix[start.row,start.column]!=sequence[sequenceIndex]) return false;

// TODO: have a method to return adjacent points
var adjacentCellsContainSeq = 
GetAdjacentPointsWithinMatrix(point,matrix)
.Aggregate( 
(bool contains, Point point)=>	contains | ContainsSequenceStartingAt(matrix,point, sequence, sequenceIndex+1), false)

return adjacentCellsContainSeq;

// same as 
 adjacentCellsContainSeq = false;
foreach (var point in GetAdjacentPointsWithinMatrix(point,matrix))
	adjacentCellsContainSeq |= ContainsSequenceStartingAt(matrix,point, sequence, sequenceIndex+1);
}

private IEnumerable<Point> GetAdjacentPointsWithinMatrix(Point point, int[,] matrix)
{
	return GetAdjacentPoints(point).Where(x=>x.row>=0 && x.row<matrix.GetLength(0) && x.col>=0 && x.col<matrix.GetLength(1);
}

private IEnumerable<Point> GetAdjacentPoints(Point point)
{
	yield return new Point(point.row-1,point.col);
yield return new Point(point.row+1,point.col);
yield return new Point(point.row,point.col-1);
yield return new Point(point.row,point.col+1);
}

}
