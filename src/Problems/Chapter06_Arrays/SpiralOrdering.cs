using System;
using System.Collections.Generic;

namespace Problems.Chapter06_Arrays
{
    /// <summary>
    /// 6.17 Compute spiral ordering of a 2D array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SpiralOrdering<T>
    {
        public IEnumerable<T> EnumerateInSpiralOrder(T[,] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) yield break;

            // TODO: sanitize input more dillignetly
            var length = array.Length;

            var minRow = -1;
            var maxRow = array.GetLength(0); 
            var minColumn = -1;
            var maxColumn = array.GetLength(1); 

            var row = 0;
            var column = 0;
            var counter = 0;
            var direction = Direction.Right;

            while (counter < length)
            {
                yield return array[row, column];
                counter++;

                switch (direction)
                {
                    case Direction.Right:
                        column++;
                        if (column == maxColumn)
                        {
                            column--;
                            row++;
                            minRow++;
                            direction = Direction.Down;
                        }
                        break;
                    case Direction.Down:
                        row++;
                        if (row == maxRow)
                        {
                            row--;
                            column--;
                            maxColumn--;
                            direction = Direction.Left;
                        }
                        break;
                    case Direction.Left:
                        column--;
                        if (column == minColumn)
                        {
                            column++;
                            row--;
                            maxRow--;
                            direction = Direction.Up;
                        }
                        break;
                    case Direction.Up:
                        row--;
                        if (row == minRow)
                        {
                            row++;
                            column++;
                            minColumn++;
                            direction = Direction.Right;
                        }
                        break;
                }
            }
            yield break;
        }

        private enum Direction : byte
        {
            Right = 1,
            Down = 2,
            Left = 3,
            Up = 4,
        }
    }
}
