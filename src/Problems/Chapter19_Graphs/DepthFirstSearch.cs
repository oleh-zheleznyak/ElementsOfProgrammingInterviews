using System;

namespace Problems.Chapter19_Graphs
{
    public class DepthFirstSearch<T>
        where T : IEquatable<T>
    {
        public void Process(UndirectedGraph<T> graph)
        {
            if (graph is null) throw new ArgumentNullException(nameof(graph));

            graph.ResetStateForSearch();

            foreach (var vertex in graph.Vertices)
                if (vertex.Color == Color.White)
                {
                    vertex.Distance = 0;
                    Process(graph, vertex);
                }
        }

        public void Process(UndirectedGraph<T> graph, Vertice<T> startVertex)
        {
            if (graph is null) throw new ArgumentNullException(nameof(graph));
            if (startVertex is null) throw new ArgumentNullException(nameof(startVertex));

            startVertex.Color = Color.Gray;
            foreach (var adjacentVertex in graph.GetAdjacentVertices(startVertex))
            {
                if (adjacentVertex.Color == Color.White)
                {
                    adjacentVertex.Predescessor = startVertex;
                    adjacentVertex.Distance = startVertex.Distance + 1;
                    Process(graph, adjacentVertex);
                }
            }

            startVertex.Color = Color.Black;
        }
    }
}