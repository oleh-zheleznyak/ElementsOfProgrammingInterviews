using Problems.Chapter12_Searching;
using Xunit;

namespace Problems.Tests.Chapter12_Searching
{
    public class FindKthLargestElementTests
    {
        private FindKthLargestElement<int> findKthLargestElement = new();

        [Theory]
        [InlineData(1, new int[] {3,2,1,5,4},5)]
        [InlineData(2, new int[] {3,2,1,5,4},4)]
        [InlineData(5, new int[] {3,2,1,5,4},1)]
        [InlineData(1, new int[] {1,2},2)]
        [InlineData(2, new int[] {1,2},1)]
        public void FindKthLargestElementTest(int k, int[] dataset, int expectedMax)
        {
            var actualMax = findKthLargestElement.findKthLargestElement(k, dataset);
            Assert.Equal(expectedMax, actualMax);
        }
    }
}