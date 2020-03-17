using Problems.Chapter09_Stacks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter09_Stacks
{
    public class ReversePolishNotationCalculatorTests
    {
        ReversePolishNotationCalculator calc = new ReversePolishNotationCalculator(';');

        [Theory]
        [InlineData("1;1;+", 2)]
        [InlineData("3;2;-", 1)]
        [InlineData("2;3;*", 6)]
        [InlineData("6;2;/", 3)]
        [InlineData("1;2;+;5;*", 15)]
        [InlineData("9;3;/;1;+", 4)]
        public void Add(string input, int result)
        {
            Assert.Equal(result, calc.Calculate(input));
        }
    }
}
