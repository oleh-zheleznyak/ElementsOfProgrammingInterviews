using System;

namespace Interviews 
{
// time taken: 00:49:06

public class SudokuSolver
{
	private const int Size = 9;
	private const int StartIndex = 0;
	private const int EndIndex = Size - 1;
	private const int EmptyValue = 0;
	private const int MinValue =1;
	private const int MaxValue =9;

	// returns true if at least one solution for a partially filled sudoku is found
	public bool HasSolution(byte[,] sudoku)
	{
		if (sudoku is null) throw new ArgumentNullException(nameof(sudoku));
		Validate(sudoku);
		
		return HasSolution(sudoku, StartIndex ,StartIndex);			

	}

	private bool HasSolution(byte[,] sudoku, int row, int column)
	{
		// handle indexes - TODO: extract a separate index struct / class
		if (row>EndIndex)
		{
			row = StartIndex;
			column = column + 1;
		}

		// when to stop - sudoku is filled entirely
		if (column == EndIndex+1)
			return true;
		
		// respect for filled in values: assume empty - means zero
		if (sudoku[row, column] == EmptyValue) 
			return HasSolution(sudoku, row +1, column);

		// How to iterate
		// var hasAtLeastOneMatch = true; 
		for (int value = MinValue; value<=MaxValue; value++)
		{
			sudoku[row,column] = value;
			// constraint validation
			if (IsValid(sudoku, row, column))
				hasAtLeastOneMatch &= HasSolution(sudoku, row+1, column); // what to do with return value
		}
		
		// unset value
		sudoku[row,column] = 0;
		
		return hasAtLeastOneMatch;

	}

	private bool IsValid(sudoku, row, column)
	{
		return
			IsRowConstraintValid(sudoku, row, column) &&
			IsColumnContraintValid(sudoku, row, column) &&
			IsSubSectionConstraintValid(sudoku, row, column);
		
	}

	private bool IsRowContstraintValid(sudoku, row, column)
	{
		for (var i = StartIndex; i<=EndIndex; i++)
			if (i!=column && sudoku[row, i] == sudoku[row,column])		
				return false;
		return true;
	}

	private bool IsColumnContstraintValid(sudoku, row, column)
	{
		for (var i = StartIndex; i<=EndIndex; i++)
			if (i!=row && sudoku[i, column] == sudoku[row,column])		
				return false;
		return true;
	}

	private bool IsSubSectionConstraintValid(sudoku, row, column)
	{
		// verify that in 3x3 grid none of the numbers matches the one in row/column
		// which grid we are in?
		var rowSection = (row +1) / 3;
		var columnSection = (column +1)/3;
		
		var value = sudoku[row,column];
		for (var i=0; i<3; i++)
		{
			for (var j=0; j<3;j++)
			{
				var v = sudoku[rowSection + i, columnSection + j];
				if ( v == value && (rowSection+i!=row && columnSection+j!=column))
					return false;	
			}
		}
		return true;
	}

	private void Validate(byte[,] sudoku)
	{
		ValidateSize(sudoku);
		ValidateFilledNumbers(sudoku); // TODO
		ValidateConstraints(sudoku);	// TODO
	}

	private void ValidateSize(byte[,] sudoku)
	{
		if (sudoku.GetLength(0)!=Size || sudoku.GetLength(1)!=Size)
			throw new ArgumentException("Wrong size of input array");
	}

















}
}