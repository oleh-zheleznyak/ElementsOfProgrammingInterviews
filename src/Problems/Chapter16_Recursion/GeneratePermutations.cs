using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class GeneratePermutations<T>
    {
        public IEnumerable<T[]> AllPermutationsOf(ISet<T> array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Count == 0) return Enumerable.Empty<T[]>();
            if (array.Count == 1) return Enumerable.Repeat(array.ToArray(), 1);

            var result = new List<T[]>();
            AllPermutationsOf(array, new T[array.Count], 0, result);
            return result;
        }

        private void AllPermutationsOf(ISet<T> set, T[] permutation, int size, ICollection<T[]> results)
        {
            if (set.Count == 0)
            {
                results.Add(permutation);
                return;
            }

            foreach (var item in set)
            {
                permutation[size] = item;
                var newSet = new HashSet<T>(set);
                newSet.Remove(item);
                AllPermutationsOf(newSet, permutation.ToArray(), size + 1, results);
            }
        }
    }
}
