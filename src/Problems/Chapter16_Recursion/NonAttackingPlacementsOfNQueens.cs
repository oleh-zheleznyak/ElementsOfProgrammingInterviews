using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class NonAttackingPlacementsOfNQueens
    {
        public IReadOnlyCollection<IEnumerable<ushort>> CalculatePlacementsFor(ushort n)
        {
            var result = new List<IEnumerable<ushort>>();

            PlacementForRow(n, 0, new List<ushort>(), result);

            return result;
        }

        private void PlacementForRow(ushort n, ushort row, IList<ushort> currentPlacement, ICollection<IEnumerable<ushort>> result)
        {
            if (row == n)
            {
                result.Add(currentPlacement.ToArray());
                return;
            }
            for (ushort col = 0; col < n; col++)
            {
                currentPlacement.Add(col);
                if (IsValid(currentPlacement)) PlacementForRow(n, (ushort)(row + 1), currentPlacement, result);
                currentPlacement.RemoveAt(currentPlacement.Count - 1);
            }
        }

        private bool IsValid(IList<ushort> placement)
        {
            var rowIndex = placement.Count - 1;
            for (int i = 0; i < rowIndex; ++i)
            {
                var diff = Math.Abs(placement[i] - placement[rowIndex]);
                if (diff == 0 || diff == rowIndex - i) return false;
            }
            return true;
        }
    }
}