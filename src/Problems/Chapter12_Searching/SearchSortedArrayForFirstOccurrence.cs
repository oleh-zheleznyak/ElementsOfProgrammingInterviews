using System;
using System.Collections.Generic;

namespace Problems.Chapter12_Searching
{
    public class SearchSortedArrayForFirstOccurrence<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public SearchSortedArrayForFirstOccurrence(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public int FindFirstOccurrence(T[] sortedArray, T valueToFind)
        {
            if (sortedArray == null) throw new ArgumentNullException(nameof(sortedArray));

            var low = 0;
            var high = sortedArray.Length - 1;
            var result = -1;

            while (low <= high)
            {
                var mid = low + (high - low) / 2;
                var comparison = comparer.Compare(sortedArray[mid], valueToFind);

                if (comparison < 0)
                {
                    low = mid + 1;
                }
                else if (comparison > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    high = mid - 1;
                    result = mid;
                }
            }
            return result;
        }
    }
}
