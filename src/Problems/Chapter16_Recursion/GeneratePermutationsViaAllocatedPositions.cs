using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    /// <assumptions>
    /// There are no duplicates in the array
    /// </assumptions>
    public class GeneratePermutationsViaAllocatedPositions<T> : IGeneratePermutations<T>
    {
        public IEnumerable<T[]> AllPermutationsOf(T[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return Enumerable.Empty<T[]>();
            if (array.Length == 1) return Enumerable.Repeat(array, 1);

            var result = new List<T[]>();
            AllPermutationsViaAllocatedPositions(array, 0, result);
            return result;
        }


        /// <summary>
        /// Complexity
        /// - Number of calls:     Recurrence: C(n) = n*C(n-1) ~ O(n!)
        /// - Time: O(n*n!) = number of recursive calls * loop in each call
        /// - Space:    n*(n-1)*(n-2)*...1 = n!
        /// </summary>
        private void AllPermutationsViaAllocatedPositions(T[] input, int size, ICollection<T[]> results)
        {
            if (size == input.Length)
            {
                results.Add(input.ToArray());
                return;
            }

            for (int i = size; i < input.Length; i++)
            {
                input.Swap(size, i);
                AllPermutationsViaAllocatedPositions(input, size + 1, results);
                input.Swap(size, i);
            }
        }
    }
}
