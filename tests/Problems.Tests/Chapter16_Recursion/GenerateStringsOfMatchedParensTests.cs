using Problems.Chapter16_Recursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateStringsOfMatchedParensTests
    {
        GenerateStringsOfMatchedParens sut = new();

        [Theory]
        [InlineData(0, new[] { "" })]
        [InlineData(1, new[] { "()" })]
        [InlineData(2, new[] { "()()", "(())" })]
        [InlineData(3, new[] { "()()()", "()(())", "(())()", "((()))", "(()())" })]
        public void AllStringsWithMachedNumberOfParensTest(uint numberOfParensPairs, string[] expectedResult)
        {
            var actual = sut.AllStringsWithMachedNumberOfParens(numberOfParensPairs);
            TestUtils.AssertEquivalent(expectedResult, actual);
        }
    }
}
