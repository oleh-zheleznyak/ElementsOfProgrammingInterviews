using Problems.Chapter06_Arrays;
using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GeneratePermutationsViaDictionaryOrderingTests : GeneratePermutationsTestsBase
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void AllPermutationsOfTests(int[] input, IEnumerable<int[]> expected)
        {
            var computeNextPermutation = new ComputeTheNextPermutation();
            var permuteTheElementsOfArray = new PermuteTheElementsOfAnArray<int>();
            var sut = new GeneratePermutationsViaDictionaryOrdering<int>(computeNextPermutation, permuteTheElementsOfArray);
            
            var actual = sut.AllPermutationsOf(input);
            TestUtils.AssertEquivalent(expected, actual);
        }
    }
}
