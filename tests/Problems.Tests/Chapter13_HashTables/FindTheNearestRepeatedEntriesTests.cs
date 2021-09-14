using Problems.Chapter13_HashTables;
using Xunit;

namespace Problems.Tests.Chapter13_HashTables
{
    public class FindTheNearestRepeatedEntriesTests
    {
        private FindTheNearestRepeatedEntries finder = new();
        
        [Theory]
        [InlineData("All work and no play makes for no work no fun and no results", "no", 1)]
        public void FindTest(string input, string word, int minDistance)
        {
            var splitInput = input.Split(' ');
            var repetition = finder.Find(splitInput);
            Assert.Equal(word, repetition.Word);
            Assert.Equal(minDistance, repetition.MinimumDistance);
        }
    }
}