using Problems.Chapter06_Arrays;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class ComputeTheNextPermutationTest
    {
        ComputeTheNextPermutation sut = new();

        [Theory]
        [InlineData(new int[] { 1, 0, 3, 2 }, new int[] { 1, 2, 0, 3 })]
        public void NextPermutationUnderDictionaryOrderingTest(int[] permutation, int[] nextPermutation)
        {
            var actual = sut.NextPermutationUnderDictionaryOrdering(permutation);
            Assert.Equal(nextPermutation, actual);
        }
    }
}
