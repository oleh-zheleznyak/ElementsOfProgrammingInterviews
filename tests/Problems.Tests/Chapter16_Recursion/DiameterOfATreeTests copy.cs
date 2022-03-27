using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion.BookSolution
{
    public class DiameterOfATreeTests
    {
        [Fact]
        public void DiameterOfTwoNodesIsTheCostOfEdgeBetweenThem()
        {
            var edgeCost = 42;
            var tree = new Node(new Edge(edgeCost, new Node()));
            var diameter = tree.Diameter();
            Assert.Equal(edgeCost, diameter);
        }

        [Fact]
        public void DiameterOfThreeNodesIsTheSumOfCostOfEdgesBetweenThem()
        {
            var edgeCost = 42;
            var tree = new Node(new Edge(edgeCost, new Node()), new Edge(edgeCost, new Node()));
            var diameter = tree.Diameter();
            Assert.Equal(edgeCost * 2, diameter);
        }

        [Fact]
        public void DiameterGoesViaParent()
        {
            var tree = new Node(
                new Edge(1, new Node(
                    new Edge(2, new Node()), new Edge(3, new Node())
                )),
                new Edge(4, new Node()),
                new Edge(5, new Node(
                    new Edge(6, new Node()), new Edge(7, new Node())
                ))
                );
            var diameter = tree.Diameter();
            Assert.Equal(1 + 3 + 5 + 7, diameter);
        }

        [Fact]
        public void DiameterGoesViaIsolatedSubTree()
        {
            var tree = new Node(
                new Edge(1, new Node(
                    new Edge(2, new Node()), new Edge(3, new Node())
                )),
                new Edge(4, new Node(
                    new Edge(5, new Node()), new Edge(6, new Node())
                )),
                new Edge(7, new Node(
                    new Edge(20, new Node()), new Edge(30, new Node())
                ))
                );
            var diameter = tree.Diameter();
            Assert.Equal(20 + 30, diameter);
        }
    }
}