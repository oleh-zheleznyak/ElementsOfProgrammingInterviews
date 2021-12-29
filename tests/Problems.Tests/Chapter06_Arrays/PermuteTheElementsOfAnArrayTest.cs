using Problems.Chapter06_Arrays;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class PermuteTheElementsOfAnArrayTest
    {
        private PermuteTheElementsOfAnArray<char> permutator = new();

        [Theory]
        [InlineData(new char[] { 'a', 'b', 'c' }, new int[] { 0, 1, 2 }, new char[] { 'a', 'b', 'c' })]
        [InlineData(new char[] { 'a', 'b', 'c' }, new int[] { 0, 2, 1 }, new char[] { 'a', 'c', 'b' })]
        [InlineData(new char[] { 'a', 'b', 'c' }, new int[] { 1, 0, 2 }, new char[] { 'b', 'a', 'c' })]
        [InlineData(new char[] { 'a', 'b', 'c', 'd' }, new int[] { 2, 0, 1, 3 }, new char[] { 'b', 'c', 'a', 'd' })]
        public void ApplyPermutationTest(char[] input, int[] permutation, char[] expected)
        {
            permutator.ApplyPermutation(input, permutation);
            Assert.Equal(expected, input);
        }
    }
}
