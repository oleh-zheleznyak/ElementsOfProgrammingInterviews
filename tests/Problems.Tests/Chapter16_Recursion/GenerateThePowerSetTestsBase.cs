using System;
using System.Collections.Generic;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateThePowerSetTestsBase
    {
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
