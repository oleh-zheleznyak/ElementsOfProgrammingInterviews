using System.Collections.Generic;
using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class SubsetsOfFixedSizeTests : SubsetsOfFixedSizeTestsBase
    {
        private SubsetsOfFixedSize<int> sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllSubsetsOfSizeTest(int[] set, uint size, IReadOnlyCollection<int[]> expected)
        {
            var actual = sut.AllSubsetsOfSize(new HashSet<int>(set), size);
            TestUtils.AssertEquivalent(expected, actual);
        }
    }
}