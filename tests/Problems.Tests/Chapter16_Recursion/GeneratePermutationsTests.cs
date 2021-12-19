using Problems.Chapter16_Recursion;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GeneratePermutationsTests
    {
        GeneratePermutations sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllPermutationsViaSetReductionTest(int[] input, IEnumerable<int[]> expected)
        {
            var set = new HashSet<int>(input);
            var actual = sut.AllPermutationsViaSetReduction(set);
            AssertEquivalent(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllPermutationsViaAllocatedPositions(int[] input, IEnumerable<int[]> expected)
        {
            var actual = sut.AllPermutationsViaAllocatedPositions(input);
            AssertEquivalent(expected, actual);

        }

        private void AssertEquivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.All(expected, e => Assert.Contains(e, actual));
            Assert.All(actual, a => Assert.Contains(a, expected));
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { Array.Empty<int>(), Enumerable.Empty<int[]>() };
            yield return new object[] { new int[] { 1 }, new[] { new int[] { 1 } } };
            yield return new object[] { new int[] { 1, 2 }, new[] { new int[] { 1, 2 }, new int[] { 2, 1 } } };
            yield return new object[] { new int[] { 1, 2, 3 }, new[] { new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 }, new int[] { 2, 1, 3 }, new int[] { 2, 3, 1 }, new int[] { 3, 1, 2 }, new int[] { 3, 2, 1 } } };
        }

    }
}
