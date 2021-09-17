using System;
using System.Collections.Generic;

namespace Problems.Chapter19_Graphs
{
    public class Vertice<T>
        where T : IEquatable<T>
    {
        public Vertice(T value) => Value = value;

        public T Value { get; }
        public Color Color { get; set; }
        public uint Distance { get; set; }
        public List<Vertice<T>> AdjacentVertices { get; set; }
    }
}