using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Chapter06_Arrays
{
    /// <summary>
    /// 6.9 Permute the elements of an array
    /// </summary>
    /// <remarks>
    /// "Immutable permutation", that returns a new array is more elegant and maintainable.
    /// This is the direction that most programming language libraries go ( LINQ in C#, lodash in js, etc)
    /// This implementation will shuffle array in place, to use O(1) space instead of O(N)
    /// Returning a new array is also trivial, and pointless as a programming excersise
    /// </remarks>
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
            var counter = 0;
            while (counter < array.Length)
            {
                var currentIndex = counter;
                var newIndex = permutation[currentIndex];
                var previousValue = array[currentIndex];
                while (newIndex != currentIndex && newIndex >= 0)
                {
                    var tmp = array[newIndex];
                    array[newIndex] = previousValue;
                    previousValue = tmp;
                    permutation[currentIndex] = int.MinValue;
                    currentIndex = newIndex;
                    newIndex = permutation[newIndex];
                }
                counter++;
            }
        }
    }
}
