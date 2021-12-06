using System;
using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public class NonAttackingPlacementsOfNQueens
    {
        private static bool[][,] empty = Array.Empty<bool[,]>();

        private static bool[][,] single = new[]
        {
            new bool[1, 1]
            {
                {true},
            }
        };

        public bool[][,] CalculatePlacementsFor(ushort n)
        {
            if (n == 0) return empty;
            if (n == 1) return single;

            var placementsForSmallerN = CalculatePlacementsFor((ushort) (n - 1));
            if (placementsForSmallerN.Length == 0) return empty; // is this possible?
            var placementsForN = new List<bool[,]>();
            
            foreach (var combination in placementsForSmallerN)
            {
                // TODO: refactor - do not mutate array, return arrays instead??
                DiagonalPlacements(combination, placementsForN);

                // TODO: Refactor - take n from combination?
                RowPlacements(n, combination, placementsForN);

                ColumnPlacements(n, combination, placementsForN);
            }

            return placementsForN.ToArray(); // todo: can we avoid copy?
        }

        private void RowPlacements(ushort n, bool[,] combination, List<bool[,]>? placementsForN)
        {
            for (int i = 0; i < n; i++)
            {
                if (!HasAQueenInRow(i, combination))
                {
                    var bigger = WrapInBiggerArray(combination);
                    bigger[1 + i, 0] = true;
                    placementsForN.Add(bigger);
                }
            }
        }

        private void ColumnPlacements(ushort n, bool[,] combination, List<bool[,]>? placementsForN)
        {
            // TODO: similar to row
        }

        private void DiagonalPlacements(bool[,] combination, List<bool[,]>? placementsForN)
        {
            if (!HasAQueenOnDiagonal(combination))
            {
                var bigger = WrapInBiggerArray(combination);
                bigger[0, 0] = true;
                placementsForN.Add(bigger);
            }
        }

        private bool[,] WrapInBiggerArray(bool[,] array)
        {
            return array; // resize to n+1 on both dimensions
        }

        private bool HasAQueenInRow(int rowIndex, bool[,] board)
        {
            for (int i = 0; i < board.GetLength(1); i++)
                if (board[rowIndex, i]) return true;
            return false;
        }
        
        private bool HasAQueenInColumn(int columnIndex, bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, columnIndex]) return true;
            return false;
        }
        
        private bool HasAQueenOnDiagonal(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                if (board[i, i]) return true;
            return false;
        }
    }
}