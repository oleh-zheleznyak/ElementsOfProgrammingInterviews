using Problems.Chapter12_Searching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter12_Searching
{
    public class SearchSortedArrayForFirstOccurrenceTests
    {
        SearchSortedArrayForFirstOccurrence<int> searchSorted = new();

        [Theory]
        [InlineData(new int[] { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 }, 108, 3)]
        [InlineData(new int[] { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 }, 285, 6)]
        public void FindFirstOccurrence(int[] data, int valueToFind, int expectedIndex)
        {
            var actualIndex = searchSorted.FindFirstOccurrence(data, valueToFind);
            Assert.Equal(expectedIndex, actualIndex);
        }
    }
}
