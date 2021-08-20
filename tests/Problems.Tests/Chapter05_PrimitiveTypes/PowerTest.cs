using Problems.Chapter05_PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter05_PrimitiveTypes
{
    public class PowerTest
    {
        private readonly Power power = new Power();

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(2, 0, 1)]
        [InlineData(2, -1, 0.5)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 4)]
        [InlineData(2, 3, 8)]
        [InlineData(2, 4, 16)]
        [InlineData(2, 8, 256)]
        [InlineData(3, 3, 27)]
        public void Test_WithPreComputed(double x, int y, double expected)
        {
            Assert.Equal(expected, power.Compute(x, y));
        }
    }
}
