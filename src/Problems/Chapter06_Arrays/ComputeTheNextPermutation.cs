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

            var result = permutation.ToArray();
            var max = permutation.Length - 1;
            if (permutation[max] == max)
            {
                result.Swap(max, max - 1);
                return result;
            }
            var index = max;
            while (permutation[index] >= result[index] && index >= 1)
            {
                result.Swap(index, index - 1);
                index--;
            }

            return result;
        }
    }
}
