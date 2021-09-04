using Problems.Chapter11_Heaps;
using Xunit;

namespace Problems.Tests.Chapter11_Heaps
{
    public class MaxHeapTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 3, 2 }, 3)]
        [InlineData(new int[] { 1, 3, 4, 2 }, 4)]
        [InlineData(new int[] { 1, 3, 2, 5, 4 }, 5)]
        public void CreateAndPeekMaxTests(int[] inputArray, int expectedMax)
        {
            var maxHeap = new MaxHeap<int>(inputArray);
            var actualMax = maxHeap.Peek();
            Assert.Equal(expectedMax, actualMax);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, 1)]
        [InlineData(new int[] { 1, 3, 2 }, 2)]
        [InlineData(new int[] { 1, 3, 4, 2 }, 3)]
        [InlineData(new int[] { 1, 3, 2, 5, 4 }, 4)]
        public void CreateAndPopMaxTests(int[] inputArray, int expectedPoppedMax)
        {
            var maxHeap = new MaxHeap<int>(inputArray);
            maxHeap.Pop();
            var actualMax = maxHeap.Peek();
            Assert.Equal(expectedPoppedMax, actualMax);
        }

        [Theory]
        [InlineData(new int[] { 1, 2 }, 3, 3)]
        [InlineData(new int[] { 1, 3, 2 }, 4, 4)]
        [InlineData(new int[] { 1, 3, 4, 2 }, 3, 4)]
        [InlineData(new int[] { 1, 3, 2, 5, 4 }, 6, 6)]
        public void CreateAndPushTests(int[] initalArray, int pushElement, int expectedMax)
        {
            var maxHeap = new MaxHeap<int>(initalArray);
            maxHeap.Push(pushElement);
            var actualMax = maxHeap.Peek();
            Assert.Equal(expectedMax, actualMax);
        }
    }
}
