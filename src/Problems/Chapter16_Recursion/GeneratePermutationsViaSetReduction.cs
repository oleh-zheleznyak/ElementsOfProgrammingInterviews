using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class GeneratePermutationsViaSetReduction<T>: IGeneratePermutations<T>
    {
        public IEnumerable<T[]> AllPermutationsOf(T[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return Enumerable.Empty<T[]>();
            if (array.Length == 1) return Enumerable.Repeat(array, 1);

            var result = new List<T[]>();
            var set = new HashSet<T>(array);
            AllPermutationsViaSetReduction(set, new T[array.Length], 0, result);
            return result;
        }

        private void AllPermutationsViaSetReduction(ISet<T> set, T[] permutation, int size, ICollection<T[]> results)
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
    }
}