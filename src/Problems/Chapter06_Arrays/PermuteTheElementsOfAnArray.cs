using System;

namespace Problems.Chapter06_Arrays
{
    /// <summary>
    /// 6.9 Permute the elements of an array
    /// </summary>
    /// <remarks>
    /// "Immutable permutation", that returns a new array is more elegant and maintainable.
    /// This is the direction that most programming language libraries go ( LINQ in C#, lodash in js, etc)
    /// </remarks>
    /// <complexity>
    /// This implementation will shuffle array in place, to use O(1) space instead of O(N)
    /// Returning a new array is also trivial, and pointless as a programming excersise
    /// Time: O(N)
    /// Space: O(1) - however, it marks elements in permutation array
    /// </complexity>
    public class PermuteTheElementsOfAnArray<T>
    {
        public void ApplyPermutation(T[] array, int[] permutation)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (permutation is null) throw new ArgumentNullException(nameof(permutation));
            if (array.Length != permutation.Length)
                throw new ArgumentException($"{nameof(array)} should have the same number of elements as {nameof(permutation)}");

            if (array.Length <= 1) return;

            ApplyPermutationToArray(array, permutation);
        }

        private void ApplyPermutationToArray(T[] array, int[] permutation)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var current = i;
                while (permutation[current]>=0)
                {
                    array.Swap(i, permutation[current]);
                    var next = permutation[current];
                    permutation[current] -= permutation.Length;
                    current=next;
                }
            }

            for (var i = 0; i < permutation.Length; i++)
                permutation[i]+=permutation.Length; 
        }
    }
}
