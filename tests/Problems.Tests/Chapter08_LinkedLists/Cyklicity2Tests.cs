using Problems.Chapter08_LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Problems.Tests.Chapter08_LinkedLists
{
    public class Cyklicity2Tests
    {
        Cyklicity2 cyklicity = new Cyklicity2();

        [Theory]
        [MemberData(nameof(TestData))]
        public void FindCycleStartTest(Node<int> list, Node<int> expectedCycleStart)
        {
            var actualCycleStart = cyklicity.FindCycleStart(list);
            Assert.Same(expectedCycleStart, actualCycleStart);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return TwoElementCycle();
            yield return NoCycle();
            yield return TwoElementCycleAtSecondNode();
        }

        private static object[] TwoElementCycle()
        {
            var first = new Node<int>(1);
            var second = new Node<int>(2);
            first.Next = second;
            second.Next = first;

            return new object[]
            {
                first,
                first
            };
        }

        private static object[] NoCycle()
        {
            var list = TestHelpers.ToSinglyLinkedList(1, 2, 3);

            return new object[]
{
                list,
                null
};
        }

        private static object[] TwoElementCycleAtSecondNode()
        {
            var first = new Node<int>(1);
            var second = new Node<int>(2);
            var third = new Node<int>(3);
            first.Next = second;
            second.Next = third;
            third.Next = second;

            return new object[]
            {
                first,
                second
            };
        }
    }
}
