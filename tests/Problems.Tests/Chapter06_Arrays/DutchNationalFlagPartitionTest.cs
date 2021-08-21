using Problems.Chapter06_Arrays;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class DutchNationalFlagPartitionTest
    {
        DutchNationalFlagPartition partition = new DutchNationalFlagPartition();

        [Theory]
        [InlineData(new int[] { 3, 2, 1 }, 1, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 3, 1, 2, 3, 1 }, 2, new int[] { 1, 1, 2, 3, 3 })]
        [InlineData(new int[] { 2,2,2 }, 1, new int[] { 2, 2, 2 })]
        [InlineData(new int[] { 1 }, 0, new int[] { 1 })]
        [InlineData(new int[] { }, 0, new int[] { })]
        public void PartitionTest(int[] input, int index, int[] expected)
        {
            partition.Partition<int>(input, index);
            Assert.Equal(expected, input);
        }
    }
}
