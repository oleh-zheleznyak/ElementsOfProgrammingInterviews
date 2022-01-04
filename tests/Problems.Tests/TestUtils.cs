using System.Collections.Generic;
using Xunit;

namespace Problems.Tests
{
    public class TestUtils
    {
        public static void AssertEquivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.All(expected, e => Assert.Contains(e, actual));
            Assert.All(actual, a => Assert.Contains(a, expected));
        }

        public static void AssertEquivalent<T>(IEnumerable<IEnumerable<T>> expected, IEnumerable<IEnumerable<T>> actual)
        {
            Assert.All(expected, e => Assert.Contains(e, actual));
            Assert.All(actual, a => Assert.Contains(a, expected));
        }
    }
}
