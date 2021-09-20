using Problems.Chapter14_Sorting;
using Xunit;

namespace Problems.Tests.Chapter14_Sorting
{
    public class IntersectionOfSortedArraysTests
    {
        private readonly IntersectionOfSortedArrays<int> intersectionOfSortedArrays = new();

        [Theory]
        [InlineData(new int[] { 2, 3, 3, 5, 5, 6, 7, 7, 8, 12 }, new int[] { 5, 5, 6, 8, 8, 9, 10, 10 }, new int[] { 5, 6, 8 })]
        public void IntersectTest(int[] firstSortedArray, int[] secondSortedArray, int[] expectedResult)
        {
            var actual = intersectionOfSortedArrays.Intersection(firstSortedArray, secondSortedArray);
            Assert.Equal(expectedResult, actual);
        }
    }
}
