using System;
using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class TheTowersOfHanoiTextBookSolutionTests
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ShouldMoveRingsToAnotherPeg(int numberOfRings)
        {
            Action<string> log = s => Console.WriteLine(s);
            var theTowersOfHanoi = new TheTowersOfHanoiTextbookSolution(numberOfRings, log);
            theTowersOfHanoi.MoveAllRingsToSecondPeg();

            Assert.Empty(theTowersOfHanoi.GetPeg(0));
            Assert.Empty(theTowersOfHanoi.GetPeg(2));
            Assert.Equal(numberOfRings, theTowersOfHanoi.GetPeg(1).Count);
        }
    }
}
