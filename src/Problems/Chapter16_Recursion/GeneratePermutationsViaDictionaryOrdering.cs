using Problems.Chapter06_Arrays;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter16_Recursion
{
    public class GeneratePermutationsViaDictionaryOrdering<T> : IGeneratePermutations<T>
    {
        private readonly IComputeTheNextPermutation computeTheNextPermutation;
        private readonly IPermuteTheElementsOfAnArray<T> permuteTheElementsOfAnArray;

        public GeneratePermutationsViaDictionaryOrdering(
            IComputeTheNextPermutation computeTheNextPermutation,
            IPermuteTheElementsOfAnArray<T> permuteTheElementsOfAnArray)
        {
            this.computeTheNextPermutation = computeTheNextPermutation;
            this.permuteTheElementsOfAnArray = permuteTheElementsOfAnArray;
        }

        public IEnumerable<T[]> AllPermutationsOf(T[] array)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) yield break;
            if (array.Length == 1)
            {
                yield return array;
                yield break;
            }

            var nextPermutation = Enumerable.Range(0, array.Length).ToArray();
            do
            {
                var permuttedArray = permuteTheElementsOfAnArray.ApplyPermutationToNewArray(array, nextPermutation);
                yield return permuttedArray;
                nextPermutation = computeTheNextPermutation.NextPermutationUnderDictionaryOrdering(nextPermutation);

            } while (nextPermutation.Any());
         }
    }
}
