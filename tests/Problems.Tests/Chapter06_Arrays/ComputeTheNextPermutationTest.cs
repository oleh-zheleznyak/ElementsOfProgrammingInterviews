using Problems.Chapter06_Arrays;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class ComputeTheNextPermutationTest
    {
        ComputeTheNextPermutation sut = new();

        [Theory]
        [InlineData(new int[] { 1, 0, 3, 2 }, new int[] { 1, 2, 0, 3 })]
        [InlineData(new int[] { 3, 0, 1, 2 }, new int[] { 3, 0, 2, 1 })]
        [InlineData(new int[] { 3, 0, 2, 1 }, new int[] { 3, 1, 0, 2 })]
        [InlineData(new int[] { 3, 1, 0, 2 }, new int[] { 3, 1, 2, 0 })]
        [InlineData(new int[] { 3, 2, 1, 0 }, new int[] { })]
        [InlineData(new int[] { 6, 2, 1, 5, 4, 3, 0 }, new int[] { 6, 2, 3, 0, 1, 4, 5 })]
        public void NextPermutationUnderDictionaryOrderingTest(int[] permutation, int[] nextPermutation)
        {
            var actual = sut.NextPermutationUnderDictionaryOrdering(permutation);
            Assert.Equal(nextPermutation, actual);
        }
    }
}
