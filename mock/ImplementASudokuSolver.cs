// implement a sudoku solver
// 9x9 int grid, where each row and each col and each 3x3 grid have unique numbers 1..9
// ~ 40 min

namespace Recursion 
{
public class Sudoku
{
	public const byte MinValue = 1;
	public const byte MaxValue = 9;

	// solves the puzzle in place, if there are several solutions, picks arbitrary one
	public void Solve(byte[,] sudoku)
	{
		if (sudoku is null) throw new ArgumentNullException(nameof(sudoku));
		if (HasProperSize(sudoku)) throw new ArgumentException(nameof(sudoku));
		if (HasInvalidNumbers(sudoku)) throw new ArgumentException(nameof(sudoku));
		if (IsValid(sudoku)) throw new ArgumentException(nameof(sudoku));

		// what if there is no solution?
		EnumeratePossibleValues(sudoku, new Point(0,0));
		if (IsValid(sudoku)) throw new Exception("solution not found");				
	}

	private void EnumeratePossibleValues(byte[,] sudoku, Point currentIndex)
	{
		if (currentIndex.IsEndOfLine()) return;
		if (IsFilled(sudoku, currentIndex)) currentIndex = currentIndex.Next();

		for (var value = MinValue; value<=MaxValue; value++)
		{
			sudoku[currentIndex.row, currentIndex.column] = value;
			EnumeratePossibleValues(sudoku, currentIndex.Next());
		}		
	}

	private bool IsFilled(byte[,] sudoku, Point currentIndex)
	{
		return sudoku[currentIndex.row, currentIndex.column] > 0;
	}

	private bool HasInvalidNumbers(byte[,] sudoku)
	{
		// TODO: check all integers < 9
		return true;
	}

	private bool IsValid(byte[,] sudoku)
	{
		// TODO: check uniqueness
		return true;
	}

	private bool HasProperSize(byte[,] sudoku)
	{
		return 
			sudoku.GetLength(0) == 9 &&
			sudoku.GetLength(1) == 9;
	}


}

public struct Point
{
	public Point(byte row, byte column)
	{
		this.row = row;
		this.column = column;
	}	

	private readonly byte row;
	private readonly byte column;

	public byte Row => this.row;
	public byte Column => this.column;

	public Point Next()
	{
		if (column<8) return new Point(row,column+1);
		if (row<8) return new Point(row+1,0);
		return End;
	}

	public bool IsEndOfLine() => this == End;
	
	public Point End => new Point(byte.MaxValue,byte.MaxValue);
}

}