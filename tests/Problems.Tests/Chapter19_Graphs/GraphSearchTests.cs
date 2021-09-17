using System;
using System.Linq;
using Problems.Chapter19_Graphs;

namespace Problems.Tests.Chapter19_Graphs
{
    public abstract class GraphSearchTests
    {
        
        protected static UndirectedGraph<string> LinkedListShapedGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (1, 2)});

        protected static UndirectedGraph<string> TreeShapedGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (0, 2)});

        protected static UndirectedGraph<string> CircularGraph() =>
            new UndirectedGraph<string>(new string[] {"a", "b", "c"}, new (int, int)[] {(0, 1), (1, 2), (2, 0)});

        protected Vertice<T> SingleByValue<T>(T value, UndirectedGraph<T> graph)
            where T : IEquatable<T> =>
            graph.Vertices.Single(x => Equals(value, x.Value));

        protected (Vertice<T>, Vertice<T>, Vertice<T>) FindByValue<T>((T value1, T value2, T value3) values,
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