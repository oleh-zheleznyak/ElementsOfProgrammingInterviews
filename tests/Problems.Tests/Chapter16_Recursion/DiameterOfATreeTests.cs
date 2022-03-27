using System;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion
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
    }
}