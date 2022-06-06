using System.Collections.Generic;
using Problems.Chapter18_GreedyAlgorithms;
using Xunit;

namespace Problems.Tests.Chapter18_GreedyAlgorithms
{
    public class LargestRectangleUnderSkylineTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ComputeLargestTest(uint[] array, Rectangle expected)
        {
            var sut = new LargestRectangleUnderSkyline();
            var actualPair = sut.ComputeLargest(array);
            Assert.Equal(expected, actualPair);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return BookExample();
        }
    
        private static object[] BookExample()=>
            new object[] { new int[] { 1,4,2,5,6,3,2,6,6,5,2,1,3 }, new Rectangle(1,11,20) };
    }
}