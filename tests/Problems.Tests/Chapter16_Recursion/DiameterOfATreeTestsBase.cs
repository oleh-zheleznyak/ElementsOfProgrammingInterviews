using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
{
    public abstract class DiameterOfATreeTestsBase
    {
        [Fact]
        public void DiameterGoesViaIsolatedSubTree()
        {
            var tree = node(
                new Edge(1, node(
                    new Edge(2, node()), new Edge(3, node())
                )),
                new Edge(4, node(
                    new Edge(5, node()), new Edge(6, node())
                )),
                new Edge(7, node(
                    new Edge(20, node()), new Edge(30, node())
                ))
                );
            var diameter = tree.Diameter();
            Assert.Equal(20 + 30, diameter);
        }

        [Fact]
        public void DiameterGoesViaParent()
        {
            var tree = node(
                new Edge(1, node(
                    new Edge(2, node()), new Edge(3, node())
                )),
                new Edge(4, node()),
                new Edge(5, node(
                    new Edge(6, node()), new Edge(7, node())
                ))
                );
            var diameter = tree.Diameter();
            Assert.Equal(1 + 3 + 5 + 7, diameter);
        }

        [Fact]
        public void DiameterOfThreeNodesIsTheSumOfCostOfEdgesBetweenThem()
        {
            var edgeCost = 42;
            var tree = node(new Edge(edgeCost, node()), new Edge(edgeCost, node()));
            var diameter = tree.Diameter();
            Assert.Equal(edgeCost * 2, diameter);
        }
        [Fact]
        public void DiameterOfTwoNodesIsTheCostOfEdgeBetweenThem()
        {
            var edgeCost = 42;
            var tree = node(new Edge(edgeCost, node()));
            var diameter = tree.Diameter();
            Assert.Equal(edgeCost, diameter);
        }

        protected abstract Node node(params Edge[] children);
    }
}