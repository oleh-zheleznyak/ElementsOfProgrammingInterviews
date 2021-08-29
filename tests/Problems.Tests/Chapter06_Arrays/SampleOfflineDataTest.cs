using Problems.Chapter06_Arrays;
using System.Linq;
using Xunit;

namespace Problems.Tests.Chapter06_Arrays
{
    public class SampleOfflineDataTest
    {
        SampleOfflineData<int> sampleOfflineData = new SampleOfflineData<int>();

        [Theory]
        [InlineData(new int[] { 1, 2 }, 0, new int[] { })]
        [InlineData(new int[] { 1, 2 }, 2, new int[] { 2, 1 })]
        [InlineData(new int[] { 1, 1, 1 }, 1, new int[] { 1 })]
        public void SampleTest(int[] data, int sampleSize, int[] expected)
        {
            sampleOfflineData.Sample(data, sampleSize);
            var actual = data.Take(sampleSize).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}
