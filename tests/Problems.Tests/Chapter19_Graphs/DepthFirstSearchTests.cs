using System;
using System.Linq;
using Problems.Chapter19_Graphs;
using Xunit;

namespace Problems.Tests.Chapter19_Graphs
{
    public class DepthFirstSearchTests : GraphSearchTests
    {
        private DepthFirstSearch<string> dfs = new();

        [Fact]
        public void SearchLinkedListShapedGraphTest()
        {
            var graph = LinkedListShapedGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            dfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal(a, b.Predescessor);
            Assert.Equal((uint) 2, c.Distance);
            Assert.Equal(b, c.Predescessor);
        }

        [Fact]
        public void SearchTreeShapedGraphTest()
        {
            var graph = TreeShapedGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            dfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal(a,b.Predescessor);
            Assert.Equal((uint) 1, c.Distance);
            Assert.Equal(a,c.Predescessor);
        }

        [Fact]
        public void SearchCircularGraphTest()
        {
            var graph = CircularGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            dfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal(a,b.Predescessor);
            Assert.Equal((uint) 2, c.Distance);
            Assert.Equal(b,c.Predescessor);
        }

    }
}