using Problems.Chapter07_Strings;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter07_Strings
{
    public class IntercovertStringsAndIntegersTests
    {
        IntercovertStringsAndIntegers convert = new IntercovertStringsAndIntegers();

        [Theory]
        [InlineData("0")]
        [InlineData("9")]
        [InlineData("12")]
        [InlineData("123")]
        [InlineData("-1")]
        [InlineData("-12")]
        [InlineData("-123")]
        public void StringToInteger(string input)
        {
            var actual = convert.StringToInteger(input);
            var expected = Convert.ToInt32(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(123)]
        [InlineData(-1)]
        [InlineData(-12)]
        [InlineData(-123)]
        public void IntegerToString(int input)
        {
            var actual = convert.IntegerToString(input);
            var expected = Convert.ToString(input);
            Assert.Equal(expected, actual);
        }
    }
}
