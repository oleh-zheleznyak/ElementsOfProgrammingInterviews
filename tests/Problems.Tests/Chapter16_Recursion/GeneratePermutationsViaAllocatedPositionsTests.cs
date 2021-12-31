using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GeneratePermutationsViaAllocatedPositionsTests : GeneratePermutationsTestsBase
    {
        GeneratePermutationsViaAllocatedPositions<int> sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllPermutationsOfTests(int[] input, IEnumerable<int[]> expected)
        {
            var actual = sut.AllPermutationsOf(input);
            TestUtils.AssertEquivalent(expected, actual);
        }
    }
}
