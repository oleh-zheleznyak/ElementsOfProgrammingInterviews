using System;

namespace Problems.Chapter16_Recursion
{
    public class SudokuSolver
    {
        private const int Size = 9;
        private const int StartIndex = 0;
        private const int EndIndex = Size - 1;
        private const int EmptyValue = 0;
        private const byte MinValue = 1;
        private const byte MaxValue = 9;
        private const byte RegionSize = 3;

        // returns true if at least one solution for a partially filled sudoku is found
        public bool HasSolution(byte[,] sudoku)
        {
            if (sudoku is null) throw new ArgumentNullException(nameof(sudoku));
            Validate(sudoku);

            return HasSolution(sudoku, StartIndex, StartIndex);
        }

        private bool HasSolution(byte[,] sudoku, int row, int column)
        {
            // handle indexes - TODO: extract a separate index struct / class
            if (row > EndIndex)
            {
                row = StartIndex;
                column = column + 1;
            }

            // when to stop - sudoku is filled entirely
            if (column == EndIndex + 1)
                return true;

            // respect for filled in values: assume empty - means zero
            if (sudoku[row, column] != EmptyValue)
                return HasSolution(sudoku, row + 1, column);

            // How to iterate
            for (var value = MinValue; value <= MaxValue; value++)
            {
                // constraint validation
                if (IsValid(sudoku, row, column, value))
                {
                    sudoku[row, column] = value;
                    if (HasSolution(sudoku, row + 1, column))
                        return true;
                }
            }

            // unset value
            sudoku[row, column] = 0;

            return false;

        }

        private bool IsValid(byte[,] sudoku, int row, int column, byte value)
        {
            return
                IsRowContstraintValid(sudoku, row, value) &&
                IsColumnContstraintValid(sudoku, column, value) &&
                IsSubSectionConstraintValid(sudoku, row, column, value);

        }

        private bool IsRowContstraintValid(byte[,] sudoku, int row, byte value)
        {
            for (var i = StartIndex; i <= EndIndex; i++)
                if (sudoku[row, i] == value)
                    return false;
            return true;
        }

        private bool IsColumnContstraintValid(byte[,] sudoku, int column, byte value)
        {
            for (var i = StartIndex; i <= EndIndex; i++)
                if (sudoku[i, column] == value)
                    return false;
            return true;
        }

        private bool IsSubSectionConstraintValid(byte[,] sudoku, int row, int column, byte value)
        {
            // verify that in 3x3 grid none of the numbers matches the one in row/column
            // which grid we are in?
            var rowSection = row  / RegionSize;
            var columnSection = column / RegionSize;

            for (var i = 0; i < RegionSize; i++)
            {
                var rowIndex = rowSection * RegionSize + i;
                for (var j = 0; j < RegionSize; j++)
                {
                    var columnIndex = columnSection * RegionSize + j;
                    var v = sudoku[rowIndex, columnIndex];
                    if (v == value && rowIndex != row && columnIndex != column)
                        return false;
                }
            }
            return true;
        }

        private void Validate(byte[,] sudoku)
        {
            ValidateSize(sudoku);
            ValidateFilledNumbers(sudoku);
            ValidateConstraints(sudoku);
        }

        private void ValidateConstraints(byte[,] sudoku)
        {
            // todo
        }

        private void ValidateFilledNumbers(byte[,] sudoku)
        {
            for (var i = StartIndex; i <= EndIndex; i++)
            {
                for (var j = StartIndex; j <= EndIndex; j++)
                {
                    var value = sudoku[i, j];
                    if (value != 0 && (value < MinValue || value > MaxValue))
                        throw new ArgumentException(
                            $"Value {value} at index (row;col)=({i};{j}) is outside of the range of allowed values of {MinValue}..{MaxValue}");
                }
            }
        }

        private void ValidateSize(byte[,] sudoku)
        {
            if (sudoku.GetLength(0) != Size || sudoku.GetLength(1) != Size)
                throw new ArgumentException("Wrong size of input array");
        }

    }
}