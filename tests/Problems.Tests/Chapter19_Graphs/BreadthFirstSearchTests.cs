using System;
using System.Linq;
using Problems.Chapter19_Graphs;
using Xunit;

namespace Problems.Tests.Chapter19_Graphs
{
    public class BreadthFirstSearchTests
    {
        private BreadthFirstSearch<string> bfs = new();

        [Fact]
        public void SearchLinkedListShapedGraphTest()
        {
            var graph = LinkedListShapedGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            bfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal((uint) 2, c.Distance);
        }

        [Fact]
        public void SearchTreeShapedGraphTest()
        {
            var graph = TreeShapedGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            bfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal((uint) 1, c.Distance);
        }

        [Fact]
        public void SearchCircularGraphTest()
        {
            var graph = CircularGraph();
            var (a, b, c) = FindByValue(("a", "b", "c"), graph);
            bfs.Process(graph, a);

            Assert.All(graph.Vertices, v => Assert.Equal(Color.Black, v.Color));
            Assert.Equal((uint) 1, b.Distance);
            Assert.Equal((uint) 1, c.Distance);
        }

        private static UndirectedGraph<string> LinkedListShapedGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (1, 2)});

        private static UndirectedGraph<string> TreeShapedGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (0, 2)});

        private static UndirectedGraph<string> CircularGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (1, 2), (2, 0)});

        private Vertice<T> SingleByValue<T>(T value, UndirectedGraph<T> graph)
            where T : IEquatable<T> =>
            graph.Vertices.Single(x => Equals(value, x.Value));

        private (Vertice<T>, Vertice<T>, Vertice<T>) FindByValue<T>((T value1, T value2, T value3) values,
            UndirectedGraph<T> graph)
            where T : IEquatable<T>
        {
            var vertice1 = SingleByValue(values.value1, graph);
            var vertice2 = SingleByValue(values.value2, graph);
            var vertice3 = SingleByValue(values.value3, graph);

            return (vertice1, vertice2, vertice3);
        }
    }
}