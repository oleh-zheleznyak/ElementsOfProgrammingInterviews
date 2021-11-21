using Problems.Chapter16_Recursion;
using System.Collections.Generic;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public class TheTowersOfHanoiTests
    {

        [Theory]
        [MemberData(nameof(TestData))]

        public void ShouldMoveRingsToAnotherPeg(int[] ringsForFirstPeg)
        {
            var theTowersOfHanoi = new TheTowersOfHanoi(ringsForFirstPeg);
            theTowersOfHanoi.MoveRingsToAnotherPeg();

            Assert.Empty(theTowersOfHanoi.GetPeg(TheTowersOfHanoi.Peg.Source));
            Assert.Empty(theTowersOfHanoi.GetPeg(TheTowersOfHanoi.Peg.Helper));
            Assert.Equal(ringsForFirstPeg, theTowersOfHanoi.GetPeg(TheTowersOfHanoi.Peg.Destination));
        }



        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new int[] { 1 } };
            yield return new object[] { new int[] { 1, 2 } };
            yield return new object[] { new int[] { 1, 2, 3 } };
        }
    }
}
