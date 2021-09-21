using System;
using System.Collections.Generic;

namespace Problems.Chapter14_Sorting
{
    /// <summary>
    /// 14.2 Merge two sorted arrays (in place, no additional storage)
    /// </summary>
    public class MergeTwoSortedArrays<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public MergeTwoSortedArrays(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public void MergeSecondIntoFirst(T[] firstSortedArrayWithExtraSpace, int firstArrayLength, T[] secondSortedArray, int secondArrayLength)
        {
            if (firstSortedArrayWithExtraSpace is null) throw new ArgumentNullException(nameof(firstSortedArrayWithExtraSpace));
            if (secondSortedArray is null) throw new ArgumentNullException(nameof(secondSortedArray));
            if (firstArrayLength < 0 || firstArrayLength > firstSortedArrayWithExtraSpace.Length) throw new ArgumentException(nameof(firstArrayLength));
            if (secondArrayLength < 0 || secondArrayLength > secondSortedArray.Length) throw new ArgumentException(nameof(secondArrayLength));
            if (firstArrayLength + secondArrayLength > firstSortedArrayWithExtraSpace.Length) throw new ArgumentException("not enough space in first array");

            Merge(firstSortedArrayWithExtraSpace, firstArrayLength, secondSortedArray, secondArrayLength);
        }

        private void Merge(T[] firstSortedArrayWithExtraSpace, int firstArrayLength, T[] secondSortedArray, int secondArrayLength)
        {
            // relocate elements from first array from beginning of array to the end
            for (int i = firstArrayLength - 1; i >= 0; i--)
            {
                firstSortedArrayWithExtraSpace[i + secondArrayLength] = firstSortedArrayWithExtraSpace[i];
            }
            // now the first array has secondArrayLength "free space" at the beginning

            // merge the two using space at the beginning, advancing on both of the arrays
            var firstIndex = secondArrayLength;
            var secondIndex = 0;
            var insertSpot = 0;

            do
            {
                var comparison = comparer.Compare(firstSortedArrayWithExtraSpace[firstIndex], secondSortedArray[secondIndex]);
                if (comparison < 0) // first < second
                    firstSortedArrayWithExtraSpace[insertSpot++] = firstSortedArrayWithExtraSpace[firstIndex++];
                else if (comparison > 0) // first > second
                    firstSortedArrayWithExtraSpace[insertSpot++] = secondSortedArray[secondIndex++];
                else // first == second
                {
                    firstSortedArrayWithExtraSpace[insertSpot++] = firstSortedArrayWithExtraSpace[firstIndex++];
                    firstSortedArrayWithExtraSpace[insertSpot++] = secondSortedArray[secondIndex++];
                }
            }
            while (insertSpot < firstArrayLength + secondArrayLength);
        }
    }
}
