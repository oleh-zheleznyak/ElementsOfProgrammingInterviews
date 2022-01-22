using System.Collections.Generic;
using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class SubsetsOfFixedSizeTests
    {
        private SubsetsOfFixedSize<int> sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void AllSubsetsOfSizeTest(int[] set, uint size, IReadOnlyCollection<int[]> expected)
        {
            var actual = sut.AllSubsetsOfSize(new HashSet<int>(set), size);
            TestUtils.AssertEquivalent(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new[] {1, 2, 3, 4, 5}, 2, new[]
                {
                    new[] {1, 2}, new[] {1, 3}, new[] {1, 4}, new[] {1, 5},
                    new[] {2, 3}, new[] {2, 4}, new[] {2, 5},
                    new[] {3, 4}, new[] {3, 5},
                    new[] {4, 5}
                },
            };
        }
    }
}