using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class ReverseASingleSublistTests
    {
        public ReverseASingleSublist reverse = new ReverseASingleSublist();

        [Theory]
        [MemberData(nameof(TestData))]
        public void ReverseSublistBetweenIndicesTest(Node<int> input, int start, int end, Node<int> expected)
        {
            reverse.ReverseSublistBetweenIndices<int>(input, start, end);
            Assert.Equal(expected, input);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,2,3,4),
                2,
                3,
                TestHelpers.ToSinglyLinkedList(1,3,2,4),
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,2,3),
                1,
                3,
                TestHelpers.ToSinglyLinkedList(3,2,1),
            };
        }
    }
}
