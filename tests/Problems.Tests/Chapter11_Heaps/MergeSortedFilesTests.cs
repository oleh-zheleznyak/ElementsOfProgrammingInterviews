using Problems.Chapter11_Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter11_Heaps
{
    public class MergeSortedFilesTests
    {
        private MergeSortedFiles<int> mergeSortedFiles = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void MergeTest(int[][] input, int[] expectedOutput)
        {
            var actual = mergeSortedFiles.MergeSortedSequences(input).ToArray();
            Assert.Equal(expectedOutput, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new int[][] { new int[] { 4,3,2,1 } },
                new int[] { 4,3,2,1 }
            };
            yield return new object[]
            {
                new int[][] { new int[] { 3,1 }, new int[] { 4,2 } },
                new int[] { 4,3,2,1 }
            };
            yield return new object[]
            {
                new int[][] { new int[] { 1 }, new int[] { 2 }, new int[] { 3 } },
                new int[] { 3,2,1 }
            };
        }
    }
}
