using System;
using System.Collections.Generic;

namespace Problems.Chapter14_Sorting
{
    /// <summary>
    /// 14.1 Compute the intersection of two sorted arrays
    /// </summary>
    public class IntersectionOfSortedArrays<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> comparer;

        public IntersectionOfSortedArrays(IComparer<T>? comparer = null)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public IReadOnlyCollection<T> Intersection(T[] firstSortedArray, T[] secondSortedArray)
        {
            if (firstSortedArray is null) throw new ArgumentNullException(nameof(firstSortedArray));
            if (secondSortedArray is null) throw new ArgumentNullException(nameof(secondSortedArray));
            if (ReferenceEquals(firstSortedArray, secondSortedArray)) return firstSortedArray;
            if (firstSortedArray.Length == 0 || secondSortedArray.Length == 0) return Array.Empty<T>();

            return IntersectTwoDifferentNonEmptySortedArrays(firstSortedArray, secondSortedArray);
        }

        private IReadOnlyCollection<T> IntersectTwoDifferentNonEmptySortedArrays(T[] firstSortedArray, T[] secondSortedArray)
        {
            var first = 0;
            var second = 0;
            var intersection = new List<T>(); // TODO: make this more elegant, by implementing IEnumerable and avoiding helper collection

            do
            {
                var comparison = comparer.Compare(firstSortedArray[first], secondSortedArray[second]);
                if (comparison == 0)
                {
                    if (intersection.Count > 0)
                    {
                        var lastAdded = intersection[intersection.Count - 1];
                        if (comparer.Compare(lastAdded, firstSortedArray[first]) != 0)
                            intersection.Add(firstSortedArray[first]);
                    }
                    else intersection.Add(firstSortedArray[first]);

                    first++;
                    second++;
                }
                else if (comparison < 0) first++;
                else second++;


            } while (first < firstSortedArray.Length && second < secondSortedArray.Length);

            return intersection;
        }
    }
}
