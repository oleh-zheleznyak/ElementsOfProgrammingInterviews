using System;
using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public class SudokuSolver
    {
        public const byte MinValue = 1;
        public const byte MaxValue = 9;

        // solves the puzzle in place, if there are several solutions, picks arbitrary one
        public void Solve(byte[,] sudoku)
        {
            if (sudoku is null) throw new ArgumentNullException(nameof(sudoku));
            if (HasWrongSize(sudoku)) throw new ArgumentException(nameof(sudoku));
            if (HasInvalidNumbers(sudoku)) throw new ArgumentException(nameof(sudoku));
            if (IsInvalid(sudoku)) throw new ArgumentException(nameof(sudoku));

            // what if there is no solution?
            EnumeratePossibleValues(sudoku, new Point(0, 0));
            if (IsInvalid(sudoku)) throw new Exception("solution not found");
        }

        private void EnumeratePossibleValues(byte[,] sudoku, Point currentIndex)
        {
            if (currentIndex.IsEndOfLine()) return;
            if (IsFilled(sudoku, currentIndex)) currentIndex = currentIndex.Next();

            for (var value = MinValue; value <= MaxValue; value++)
            {
                sudoku[currentIndex.Row, currentIndex.Column] = value;
                EnumeratePossibleValues(sudoku, currentIndex.Next());
            }
        }

        private bool IsFilled(byte[,] sudoku, Point currentIndex)
        {
            return sudoku[currentIndex.Row, currentIndex.Column] > 0;
        }

        private bool HasInvalidNumbers(byte[,] sudoku)
        {
            foreach (var index in Point.AllPoints())
            {
                var value = sudoku[index.Row, index.Column];
                if (value < MinValue || value > MaxValue) return true;
            }

            return false;
        }

        private bool IsInvalid(byte[,] sudoku)
        {
            // TODO: check uniqueness
            return true;
        }

        private bool HasWrongSize(byte[,] sudoku)
        {
            return
                sudoku.GetLength(0) != MaxValue ||
                sudoku.GetLength(1) != MaxValue;
        }


    }

    public readonly struct Point : IEquatable<Point>
    {
        public bool Equals(Point other)
        {
            return row == other.row && column == other.column;
        }

        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(row, column);
        }

        public static bool operator ==(Point left, Point right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !left.Equals(right);
        }

        private static byte Increment = 1;
        private static byte StartIndex = 0;
        private static byte EndIndex = 8;
        
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
            if (column < EndIndex) return new Point(row, (byte) (column + Increment));
            if (row < EndIndex) return new Point((byte) (row + Increment), StartIndex);
            return End;
        }
        
        public bool IsEndOfLine() => this == End;

        public static Point End => new Point(byte.MaxValue, byte.MaxValue);

        public static Point Start => new Point(0, 0);

        public static IEnumerable<Point> AllPoints()
        {
            var index = Start;
            while (!index.IsEndOfLine())
            {
                yield return index;
                index = index.Next();
            }
        }

        public static IEnumerable<Point> RowPoints(byte rowIndex)
        {
            for (byte i = StartIndex; i <= EndIndex; i++)
            {
                yield return new Point(rowIndex, i);
            }
        }
    }
}