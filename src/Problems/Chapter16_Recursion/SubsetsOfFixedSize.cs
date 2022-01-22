using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class SubsetsOfFixedSize<T> where T : IEquatable<T>
    {
        public IReadOnlyCollection<T[]> AllSubsetsOfSize(ISet<T> set, uint size)
        {
            if (set is null) throw new ArgumentNullException(nameof(set));
            if (set.Count == 0) return Array.Empty<T[]>();
            if (size == 0) return new[] {Array.Empty<T>()};

            var result = new List<T[]>();
            AllSubsetsOfSize(set.ToArray(), size, 0, new List<T>(), result);

            return result;
        }

        private void AllSubsetsOfSize(T[] set, uint size, uint currentPosition, List<T> currentSubset,
            ICollection<T[]> results)
        {
            if (currentSubset.Count == size)
            {
                results.Add(currentSubset.ToArray());
                return;
            }

            if (currentPosition == set.Length) return; // sub-optimal

            // one set will have the element
            currentSubset.Add(set[currentPosition]);
            AllSubsetsOfSize(set, size, currentPosition + 1, currentSubset, results);
            currentSubset.RemoveAt(currentSubset.Count - 1);

            // another will not
            AllSubsetsOfSize(set, size, currentPosition + 1, currentSubset, results);
        }
    }
}