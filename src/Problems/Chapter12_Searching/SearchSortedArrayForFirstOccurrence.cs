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

            var index = Array.BinarySearch<T>(sortedArray, valueToFind, comparer);

            var previous = index;
            var firstIndex = index;
            while (firstIndex >= 0)
            {
                previous = firstIndex;
                firstIndex = Array.BinarySearch<T>(sortedArray, 0, firstIndex, valueToFind, comparer);
            }
            return previous;
        }
    }
}
