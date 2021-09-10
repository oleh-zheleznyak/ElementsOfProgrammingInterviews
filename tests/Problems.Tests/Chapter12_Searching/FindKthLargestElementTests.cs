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
        [InlineData(3, new int[] {3,2,1,5,4},3)]
        public void FindKthLargestElementTest(int k, int[] dataset, int expectedMax)
        {
            var actualMax = findKthLargestElement.findKthLargestElement(k, dataset);
            Assert.Equal(expectedMax, actualMax);
        }
    }
}