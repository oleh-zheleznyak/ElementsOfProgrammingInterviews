using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GrayCodeTests
    {
        GrayCode grayCode = new();

        [Theory]
        [InlineData(3, new int[] { 0, 4, 5, 7, 6, 2, 3, 1 })]
        [InlineData(3, new int[] { 0, 1, 3, 2, 6, 7, 5, 4 })]
        public void ComputeTests(byte n, int[] someGrayCode)
        {
            var allCodes = grayCode.Compute(n);
            Assert.Contains(someGrayCode, allCodes);
        }
    }
}
