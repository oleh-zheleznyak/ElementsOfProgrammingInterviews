using System.Collections.Generic;
using System.Linq;
using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class SubsetsOfFixedSizeNonGenericTests : SubsetsOfFixedSizeTestsBase
    {
        private SubsetsOfFixedSize sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllSubsetsOfSizeTest(int[] set, uint size, IReadOnlyCollection<int[]> expected)
        {
            var actual = sut.AllSubsetsOfSize(set.Max(), (int)size);
            TestUtils.AssertEquivalent(expected, actual);
        }
    }
}