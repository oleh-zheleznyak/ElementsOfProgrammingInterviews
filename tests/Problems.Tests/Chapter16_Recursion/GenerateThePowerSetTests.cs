using Problems.Chapter16_Recursion;
using System;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateThePowerSetTests
    {
        GenerateThePowerSet<int> sut = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculatePlacementsForTest(int[] data, int[][] expected)
        {
            var set = new HashSet<int>(data);
            var actual = sut.PowerSetOf(set);
            TestUtils.AssertEquivalent(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new int[] { 0,1,2 },
                new int[][]
                {
                    Array.Empty<int>(),
                    new int[] { 0 } , new int[] { 1 }, new int[] { 2 },
                    new int[] { 0, 1 } , new int[] { 0, 2 }, new int[] { 1, 2 },
                    new int[] { 0, 1, 2 }
                }
            };
        }
    }
}
