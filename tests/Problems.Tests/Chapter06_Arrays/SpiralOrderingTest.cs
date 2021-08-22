using Problems.Chapter06_Arrays;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class SpiralOrderingTest
    {
        SpiralOrdering<int> spiralOrdering = new SpiralOrdering<int>();

        [Theory]
        [MemberData(nameof(TestData))]
        public void EnumerateInSpiralOrderTest(int[,] array, int[] expectedOrder)
        {
            var actualOrder = spiralOrdering.EnumerateInSpiralOrder(array);
            Assert.Equal(expectedOrder, actualOrder);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } },
                new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }
            };
            yield return new object[]
            {
                new int[,] { {1,2,3,4}, {5,6,7,8}, {9,10,11,12}, {13,14,15,16} },
                new int[] {1,2,3,4,8,12,16,15,14,13,9,5,6,7,11,10}
            };
        }
    }
}
