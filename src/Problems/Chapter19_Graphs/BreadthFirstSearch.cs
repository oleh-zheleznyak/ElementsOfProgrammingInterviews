using System;
using System.Collections.Generic;

namespace Problems.Chapter19_Graphs
{
    public class BreadthFirstSearch<T>
        where T : IEquatable<T>
    {
        public void Process(UndirectedGraph<T> graph, Vertice<T> startVertice)
        {
            if (graph is null) throw new ArgumentNullException(nameof(graph));
            if (startVertice is null) throw new ArgumentNullException(nameof(startVertice));

            Initialize(graph);

            var queue = new Queue<Vertice<T>>();
            queue.Enqueue(startVertice);
            startVertice.Distance = 0;
            startVertice.Color = Color.Gray;

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var adjacentVertex in graph.GetAdjacentVertices(vertex))
                {
                    if (adjacentVertex.Color == Color.White)
                    {
                        adjacentVertex.Distance = vertex.Distance + 1;
                        adjacentVertex.Color = Color.Gray;
                        queue.Enqueue(adjacentVertex);
                    }
                }

                vertex.Color = Color.Black;
            }
        }

        private void Initialize(UndirectedGraph<T> graph)
        {
            foreach (var vertice in graph.Vertices)
            {
                vertice.Color = Color.White;
                vertice.Distance = uint.MaxValue;
            }
        }
    }
}