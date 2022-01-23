using System.Collections.Generic;

namespace Problems.Tests.Chapter16_Recursion
{
    public class SubsetsOfFixedSizeTestsBase
    {
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
            yield return new object[]
            {
                new[] {1, 2, 3, 4}, 1, new[]
                {
                    new[] {1}, new[] {2}, new[] {3}, new[] {4},
                },
            };
        }
    }
}