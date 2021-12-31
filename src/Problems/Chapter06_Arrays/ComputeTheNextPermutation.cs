using System;
using System.Linq;

namespace Problems.Chapter06_Arrays
{
    public class ComputeTheNextPermutation
    {
        public int[] NextPermutationUnderDictionaryOrdering(int[] permutation)
        {
            if (permutation is null) throw new ArgumentNullException(nameof(permutation));
            if (permutation.Length <= 1) return permutation;

            var endOfSequenceIndex = FindDecreasingSequenceEnd(permutation);
            if (endOfSequenceIndex < 0) return Array.Empty<int>();

            var minimumIndex = FindMinLargerThan(permutation[endOfSequenceIndex], permutation, endOfSequenceIndex + 1);
            var nextPermutation = permutation.ToArray();

            nextPermutation.Swap(endOfSequenceIndex, minimumIndex);

            ReverseStartingAtIndex(endOfSequenceIndex + 1, nextPermutation);

            return nextPermutation;
        }

        private void ReverseStartingAtIndex(int v, int[] nextPermutation)
        {
            var count = (nextPermutation.Length - v + 1) / 2;
            for (int i = 0; i < count; i++)
                nextPermutation.Swap(v + i, nextPermutation.Length - 1 - i);
        }

        private int FindDecreasingSequenceEnd(int[] permutation)
        {
            var prev = permutation[permutation.Length - 1];

            for (int i = permutation.Length - 2; i >= 0; i--)
            {
                var current = permutation[i];

                if (current < prev) return i;

                prev = current;
            }
            return -1;
        }

        /// <summary>
        /// here, such minimum always exists, otherwise the whole permutation is a monotonously decreasing seqence
        /// </summary>
        private int FindMinLargerThan(int value, int[] permutation, int startIndex)
        {
            var minIndex = startIndex;
            var min = permutation[minIndex];

            for (int i = startIndex; i < permutation.Length; i++)
            {
                var current = permutation[i];

                if (current < min && current > value)
                {
                    min = current;
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}
