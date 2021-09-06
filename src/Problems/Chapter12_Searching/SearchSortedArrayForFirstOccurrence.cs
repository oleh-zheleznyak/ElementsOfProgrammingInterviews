using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var firstOccurrence = index - 1;
            while (
                firstOccurrence >= 0 &&
                comparer.Compare(sortedArray[firstOccurrence], sortedArray[index]) == 0)
            {
                firstOccurrence--;
            }
            return firstOccurrence + 1;
        }
    }
}
