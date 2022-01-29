using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class GenerateBalancedParensTests
    {
        GenerateBalancedParens sut = new();

        [Theory]
        [InlineData(0, new[] { "" })]
        [InlineData(1, new[] { "()" })]
        [InlineData(2, new[] { "()()", "(())" })]
        [InlineData(3, new[] { "()()()", "()(())", "(())()", "((()))", "(()())" })]
        [InlineData(4, new[] { "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()", "()((()))", "()(()())", "()(())()", "()()(())", "()()()()" })]
        public void AllStringsWithMachedNumberOfParensTest(uint numberOfParensPairs, string[] expectedResult)
        {
            var actual = sut.AllStringsWithMachedNumberOfParens(numberOfParensPairs);
            TestUtils.AssertEquivalent(expectedResult, actual);
        }
    }
}
