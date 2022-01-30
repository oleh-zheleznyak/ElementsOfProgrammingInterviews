using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class PalindromicDecompositionsTests
    {
        PalindromicDecompositions sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeAllPalindromicDecompositionsTest(string input, string[][] expected)
        {
            var actual = sut.ComputeAllPalindromicDecompositions(input);
            TestUtils.AssertEquivalent(expected, actual);
        }


        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "A", new[] { new[] { "A" } } };
            yield return new object[] { "AB", new[] { new[] { "A", "B" } } };
            yield return new object[] { "AA", new[] { new[] { "A", "A" }, new[] { "AA" } } };
            yield return new object[] { "ABB", new[] { new[] { "A", "BB" }, new[] { "A", "B", "B" } } };
            yield return new object[] { "ABBA", new[] { new[] { "A", "BB", "A" }, new[] { "A", "B", "B", "A" }, new[] { "ABBA" } } };
        }
    }
}
