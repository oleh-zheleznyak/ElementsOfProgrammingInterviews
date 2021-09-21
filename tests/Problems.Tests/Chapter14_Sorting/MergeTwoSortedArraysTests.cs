using Problems.Chapter14_Sorting;
using System.Linq;
using Xunit;

namespace Problems.Tests.Chapter14_Sorting
{
    public class MergeTwoSortedArraysTests
    {
        private readonly MergeTwoSortedArrays<int> mergeTwoSortedArrays = new();
        [Theory]
        [InlineData(new int[] { 5, 13, 17, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, }, 3, new int[] { 3, 7, 11, 19 }, 4, new int[] { 3, 5, 7, 11, 13, 17, 19 })]
        public void MergeSecondIntoFirstTests(int[] first, int firstLength, int[] second, int secondLength, int[] expectedResult)
        {
            mergeTwoSortedArrays.MergeSecondIntoFirst(first, firstLength, second, secondLength);
            Assert.Equal(expectedResult, first.Take(firstLength + secondLength));
        }
    }
}
