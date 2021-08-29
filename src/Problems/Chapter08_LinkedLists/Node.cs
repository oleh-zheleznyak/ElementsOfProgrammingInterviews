using System.Collections;
using System.Collections.Generic;

namespace Problems.Chapter08_LinkedLists
{
    /// <summary>
    /// Singly linked list node
    /// </summary>
    /// <remarks>
    /// For real life projects, opt for ISinglyLinkedList implementation, that offers proper encapsulation and immutability
    /// For the sake of excersises, however, using Node is better because
    /// - the excersises are about being fluent with raw data structure, not using a library
    /// - during interview, there will be no time to write a well encapsulated linked list, before doing a task / algorithm
    /// </remarks>
    /// <typeparam name="T">type of data</typeparam>
    public class Node<T> : IEnumerable<T>, ISinglyLinkedListNode<T>
    {
        public Node(T value, Node<T>? next = null)
        {
            Value = value;
            Next = next;
        }

        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        ISinglyLinkedListNode<T>? ISinglyLinkedListNode<T>.Next => Next;

        public override string ToString()
        {
            return Value + (Next == null ? "-x" : "->");
        }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            var node = Next;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
