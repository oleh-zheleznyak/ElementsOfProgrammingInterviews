using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class GeneratePermutations
    {
        public IEnumerable<T[]> AllPermutationsViaSetReduction<T>(ISet<T> array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Count == 0) return Enumerable.Empty<T[]>();
            if (array.Count == 1) return Enumerable.Repeat(array.ToArray(), 1);

            var result = new List<T[]>();
            AllPermutationsViaSetReduction(array, new T[array.Count], 0, result);
            return result;
        }

        public IEnumerable<T[]> AllPermutationsViaAllocatedPositions<T>(T[] array)
            where T : struct
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return Enumerable.Empty<T[]>();
            if (array.Length == 1) return Enumerable.Repeat(array.ToArray(), 1);

            var result = new List<T[]>();
            AllPermutationsViaAllocatedPositions(array, new T?[array.Length], 0, result);
            return result;
        }

        /// <summary>
        /// Complexity
        /// - Time:     n*(n-1)*(n-2)*...1 = n!
        /// - Space:    n*(n-1)*(n-2)*...1 = n!
        /// </summary>
        private void AllPermutationsViaSetReduction<T>(ISet<T> set, T[] permutation, int size, ICollection<T[]> results)
        {
            if (set.Count == 0)
            {
                results.Add(permutation);
                return;
            }

            foreach (var item in set)
            {
                permutation[size] = item;
                var newSet = new HashSet<T>(set); // inefficient - high number of allocations
                newSet.Remove(item);
                AllPermutationsViaSetReduction(newSet, permutation.ToArray(), size + 1, results);
            }
        }

        /// <summary>
        /// Complexity
        /// - Time:     n*n*...n = n^n
        /// - Space:    n*(n-1)*(n-2)*...1 = n!
        /// </summary>
        private void AllPermutationsViaAllocatedPositions<T>(T[] input, T?[] permutation, int size, ICollection<T[]> results)
            where T: struct
        {
            if (size == input.Length)
            {
                results.Add(permutation.Select(x => x!.Value).ToArray());
                return;
            }

            var element = input[size];
            for (int i = 0; i < permutation.Length; i++)
            {
                if (!permutation[i].HasValue)
                {
                    var newPermutation = permutation.ToArray(); // copy
                    newPermutation[i] = element;
                    AllPermutationsViaAllocatedPositions(input, newPermutation, size + 1, results);
                }
            }
        }
    }
}
