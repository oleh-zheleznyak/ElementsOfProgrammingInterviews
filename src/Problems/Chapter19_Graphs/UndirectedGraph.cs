using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Chapter19_Graphs
{
    public class UndirectedGraph<T>
        where T : IEquatable<T>
    {
        public UndirectedGraph(T[] vertices, (int, int)[] edges)
        {
            if (vertices is null) throw new ArgumentNullException(nameof(vertices));
            if (edges is null) throw new ArgumentNullException(nameof(edges));

            var vertexObjects = vertices.Select(x => new Vertice<T>(x)).ToArray(); // throw away array, to rewrite
            
            var adjacencyList = new List<Vertice<T>>[vertices.Length]; // throw away list, to rewrite
            foreach (var edge in edges)
            {
                RegisterAdjacent(edge.Item1, edge.Item2, adjacencyList, vertexObjects);
                RegisterAdjacent(edge.Item2, edge.Item1, adjacencyList, vertexObjects);
            }

            vertexToAdjacentVerticesMap = new();
            for (int i = 0; i < vertices.Length; i++)
            {
                vertexToAdjacentVerticesMap[vertexObjects[i]] = adjacencyList[i];
                vertexObjects[i].AdjacentVertices = adjacencyList[i];
            }
        }

        private static void RegisterAdjacent(int edgeIndex, int adjacentEdgeIndex, List<Vertice<T>>[] adjacencyList, Vertice<T>[] vertices)
        {
            if (edgeIndex < 0 || edgeIndex > vertices.Length - 1) throw new ArgumentOutOfRangeException(nameof(edgeIndex));
            if (adjacentEdgeIndex < 0 || adjacentEdgeIndex > vertices.Length - 1) throw new ArgumentOutOfRangeException(nameof(adjacentEdgeIndex));

            var edgeAdjacencyList = adjacencyList[edgeIndex];
            if (edgeAdjacencyList is null)
            {
                adjacencyList[edgeIndex] = new List<Vertice<T>>();
                edgeAdjacencyList = adjacencyList[edgeIndex];
            }
            edgeAdjacencyList.Add(vertices[adjacentEdgeIndex]);
        }

        public IReadOnlyCollection<Vertice<T>>? GetAdjacentVertices(Vertice<T> vertice)
        {
            if (vertice is null) throw new ArgumentNullException(nameof(vertice));
            vertexToAdjacentVerticesMap.TryGetValue(vertice, out var adjacencyList);
            return adjacencyList;
        }

        private readonly Dictionary<Vertice<T>, List<Vertice<T>>> vertexToAdjacentVerticesMap;

        public IReadOnlyCollection<Vertice<T>> Vertices => vertexToAdjacentVerticesMap.Keys;
    }
}