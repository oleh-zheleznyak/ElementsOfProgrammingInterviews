using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateThePowerSetNonRecursiveTests: GenerateThePowerSetTestsBase
    {
        GenerateThePowerSetNonRecursive<int> sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void PowerSetOfTest(int[] data, int[][] expected)
        {
            var set = new HashSet<int>(data);
            var actual = sut.PowerSetOf(set);
            TestUtils.AssertEquivalent(expected, actual);
        }
    }
}
