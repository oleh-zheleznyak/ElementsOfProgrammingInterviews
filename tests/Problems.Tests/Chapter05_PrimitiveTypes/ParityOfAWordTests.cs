using Problems.Chapter05_PrimitiveTypes;
using Xunit;

namespace Problems.Tests.Chapter05_PrimitiveTypes
{
    public class ParityOfAWordTests
    {
        ParityOfAWord parity = new ParityOfAWord();

        [Theory]
        [InlineData(0b_0000, 0)]
        [InlineData(0b_0001, 1)]
        [InlineData(0b_0011, 0)]
        [InlineData(0b_0111, 1)]
        public void ParityTest(ulong word, ulong expectedParity)
        {
            Assert.Equal(expectedParity, parity.CalculateParity_Linear(word));
            Assert.Equal(expectedParity, parity.CalculateParity_Efficient(word));
        }

        [Theory]
        [InlineData(new ulong[] { 0b_0000, 0b_0011 }, 0)]
        [InlineData(new ulong[] { 0b_0001, 0b_0111 }, 0)]
        [InlineData(new ulong[] { 0b_0011, 0b_0001 }, 1)]
        public void ParityTestForArray(ulong[] word, ulong expectedParity)
        {
            Assert.Equal(expectedParity, parity.CalculateParity_BruteForce(word));
        }

        [Theory]
        [InlineData(new ulong[] { 0b_0000, 0b_0011 }, 0)]
        [InlineData(new ulong[] { 0b_0001, 0b_0111 }, 0)]
        [InlineData(new ulong[] { 0b_0011, 0b_0001 }, 1)]
        [InlineData(new ulong[] { 0b_0000, 0b_0001 }, 1)]
        [InlineData(new ulong[] { 0b_0000, 0b_0000 }, 0)]
        [InlineData(new ulong[] { 0b_1111, 0b_1111 }, 0)]
        public void ParityTestCached(ulong[] word, ulong expectedParity)
        {
            Assert.Equal(expectedParity, parity.CalculateParity_Cached(word));
        }

    }
}
