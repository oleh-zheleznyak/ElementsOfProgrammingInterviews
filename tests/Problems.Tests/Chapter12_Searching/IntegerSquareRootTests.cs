using Problems.Chapter12_Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter12_Searching
{
    public class IntegerSquareRootTests
    {
        IntegerSquareRoot integerSquareRoot = new();

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(6, 2)]
        [InlineData(7, 2)]
        [InlineData(8, 2)]
        [InlineData(9, 3)]
        [InlineData(10, 3)]
        [InlineData(11, 3)]
        [InlineData(12, 3)]
        [InlineData(13, 3)]
        [InlineData(14, 3)]
        [InlineData(15, 3)]
        [InlineData(16, 4)]
        public void SqrtTests(int value, int expectedSqrt)
        {
            var actualSqrt = integerSquareRoot.Sqrt(value);
            Assert.Equal(expectedSqrt, actualSqrt);
        }
    }
}
