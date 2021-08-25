using Problems.Chapter07_Strings;
using Xunit;

namespace Problems.Tests.Chapter07_Strings
{
    public class BaseConversionTests
    {
        BaseConversion baseConversion = new BaseConversion();

        [Theory]
        [InlineData("0", 2, 10, "0")]
        [InlineData("1", 2, 10, "1")]
        [InlineData("10", 2, 10, "2")]
        [InlineData("11", 2, 10, "3")]
        [InlineData("100", 2, 10, "4")]
        [InlineData("101", 2, 10, "5")]
        [InlineData("A", 11, 10, "10")]
        [InlineData("10", 11, 10, "11")]
        [InlineData("A0", 11, 10, "110")]
        [InlineData("B", 12, 10, "11")]
        [InlineData("B0", 12, 10, "132")]
        [InlineData("C", 13, 10, "12")]
        [InlineData("D", 14, 10, "13")]
        [InlineData("E", 15, 10, "14")]
        [InlineData("F", 16, 10, "15")]
        [InlineData("FF", 16, 10, "255")]
        public void ConvertBaseTest(string numberInBaseFrom, byte baseFrom, byte baseTo, string expectedNumberBaseTo)
        {
            Assert.Equal(expectedNumberBaseTo, baseConversion.ConvertBase(numberInBaseFrom, baseFrom, baseTo));
        }

        [Theory]
        [InlineData(1,2,"1")]
        [InlineData(2, 2, "10")]
        [InlineData(3, 2, "11")]
        [InlineData(4, 2, "100")]
        [InlineData(1, 3, "1")]
        [InlineData(2, 3, "2")]
        [InlineData(3, 3, "10")]
        [InlineData(9, 16, "9")]
        [InlineData(10, 16, "A")]
        [InlineData(15, 16, "F")]
        [InlineData(16, 16, "10")]
        public void FormatInBaseFromLeastSignificantTest(int number, byte baseTo, string expectedFormattedValue)
        {
            Assert.Equal(expectedFormattedValue, baseConversion.FormatInBaseFromLeastSignificant(number, baseTo));
        }
    }
}
