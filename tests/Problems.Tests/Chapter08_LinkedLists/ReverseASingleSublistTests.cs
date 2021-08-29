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
            var actual = reverse.ReverseSublistBetweenIndices<int>(input, start, end);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(11,3,5,7,2),
                2,
                4,
                TestHelpers.ToSinglyLinkedList(11,7,5,3,2),
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,2,3,4,5),
                2,
                4,
                TestHelpers.ToSinglyLinkedList(1,4,3,2,5),
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,2,3,4),
                1,
                3,
                TestHelpers.ToSinglyLinkedList(3,2,1,4),
            };
            yield return new object[]
            {
                TestHelpers.ToSinglyLinkedList(1,2,3,4),
                2,
                4,
                TestHelpers.ToSinglyLinkedList(1,4,3,2),
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
