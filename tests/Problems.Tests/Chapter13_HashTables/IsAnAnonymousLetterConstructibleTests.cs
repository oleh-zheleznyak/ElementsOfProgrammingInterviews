using Problems.Chapter13_HashTables;
using Xunit;

namespace Problems.Tests.Chapter13_HashTables
{
    public class IsAnAnonymousLetterConstructibleTests
    {
        private readonly IsAnAnonymousLetterConstructible constructible = new();

        [Theory]
        [InlineData("same text", "same text", true)]
        [InlineData("abc", "def", false)]
        [InlineData("będę", "be definitely", false)]
        [InlineData("you will die", "word is - young specialists are struggling to find half-decent jobs", true)]
        public void IsConstructibleFromTextTests(string anonymousLetter, string magazine, bool expected)
        {
            var actual = constructible.IsConstructibleFromText(anonymousLetter, magazine);
            Assert.Equal(expected, actual);
        }
    }
}