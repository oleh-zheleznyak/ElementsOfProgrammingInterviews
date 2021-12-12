using Problems.Chapter16_Recursion;
using System;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class NonAttackingPlacementsOfNQueensTests
    {
        NonAttackingPlacementsOfNQueens sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculatePlacementsForTest(ushort n, IReadOnlyCollection<IEnumerable<ushort>> expected)
        {
            var actual = sut.CalculatePlacementsFor(n);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1, new[] { new ushort[] { 0 } } };
            yield return new object[] { 2, empty };
            yield return new object[] { 3, empty };
            yield return new object[] { 4, new[] { new ushort[] { 1, 3, 0, 2 }, new ushort[] { 2, 0, 3, 1 } } };
        }

        private static ushort[][] empty = Array.Empty<ushort[]>();
    }
}
