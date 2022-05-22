using Problems.Chapter18_GreedyAlgorithms;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter18_GreedyAlgorithms
{
    public class The3SumProblemTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void FindThreeEntriesThatSumUpToTests(int sum, int[] array, (int,int,int)? expected)
        {
            var sut = new The3SumProblem();
            var actual = sut.FindThreeEntriesThatSumUpTo(sum, array);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1, new int[] { 1 }, ((int,int,int)?)null };
            yield return new object[] { 3, new int[] { 1,2 }, (1,1,1) };
            yield return new object[] { 21, new int[] { 11, 2, 5, 7, 3 }, (3, 7, 11) };
        }
    }
}
