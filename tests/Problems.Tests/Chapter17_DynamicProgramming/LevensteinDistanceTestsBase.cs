using System.Collections.Generic;
using Xunit;
namespace Chapter17_DynamicProgramming
{
    public abstract class LevensteinDistanceTestsBase
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "a", "a", 0 };
            yield return new object[] { "a", "b", 1 };
            yield return new object[] { "ab", "a", 1 };
            yield return new object[] { "a", "ab", 1 };
            yield return new object[] { "a", "ba", 1 };
            yield return new object[] { "ab", "cd", 2 };
            yield return new object[] { "abc", "bbc", 1 };
            yield return new object[] { "abc", "ac", 1 };
            yield return new object[] { "ac", "abc", 1 };
            yield return new object[] { "Saturday", "Sundays", 4 };
        }
        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeDistanceTest(string first, string second, int expectedResult)
        {
            var sut = CreateLevensteinDistance();
            var actual = sut.ComputeDistance(first, second);
            Assert.Equal(expectedResult, actual);
        }

        public abstract ILevensteinDistance CreateLevensteinDistance();
    }
}