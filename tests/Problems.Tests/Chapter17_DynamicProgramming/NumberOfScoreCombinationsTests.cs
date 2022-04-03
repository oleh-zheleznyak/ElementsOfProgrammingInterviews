using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;
using Xunit;
namespace Chapter17_DynamicProgramming
{
    public class NumberOfScoreCombinationsTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void NumberOfCombinationsTests(uint finalScore, uint[] scores, uint[,] expectedResult)
        {
            var sut = new NumberOfScoreCombinations();
            var actual = sut.NumberOfCombinations(finalScore, scores);
            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 1, new uint[] { 1 }, new uint[,] { { 1, 1 } } };
            yield return new object[] { 3, new uint[] { 1, 2 }, new uint[,] 
            {
                 { 1, 1, 1, 1 },
                 { 1, 1, 2, 2 } 
            }};
        }
    }
}