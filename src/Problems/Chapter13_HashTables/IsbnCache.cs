using System;
using System.Collections.Generic;

namespace Problems.Chapter13_HashTables
{
    public class IsbnCache
    {
        public IsbnCache(int capacity)
        {
            this.capacity = capacity;
        }

        private readonly Dictionary<string, LinkedListNode<IsbnRecord>> isbnPrices = new();
        private readonly LinkedList<IsbnRecord> linkedList = new();
        private readonly int capacity;

        public double? LookupPrice(string isbn)
        {
            if (!isbnPrices.TryGetValue(isbn, out var node)) return null;
            linkedList.Remove(node);
            linkedList.AddFirst(node);
            return node.Value.Price;
        }

        public void InsertPrice(IsbnRecord isbnRecord)
        {
            if (isbnRecord is null) throw new ArgumentNullException(nameof(isbnRecord));
            InsertPrice(isbnRecord.Isbn, isbnRecord.Price);
        }
        
        public void InsertPrice(string isbn, double price)
        {
            var isbnRecord = new IsbnRecord(isbn, price);
            
            if (isbnPrices.TryGetValue(isbn, out var node))
            {
                linkedList.Remove(node);
                linkedList.AddFirst(node);
                node.Value = isbnRecord;
            }
            else
            {
                var newNode = linkedList.AddFirst(isbnRecord);
                isbnPrices[isbn] = newNode;
            }

            if (linkedList.Count > capacity)
            {
                var nodeToRemove = linkedList.Last;
                isbnPrices.Remove(nodeToRemove.Value.Isbn);
                linkedList.RemoveLast();
            }
        }

        public void DeletePrice(string isbn)
        {
            if (!isbnPrices.TryGetValue(isbn, out var node)) return;
            linkedList.Remove(node);
            isbnPrices.Remove(isbn);
        }

        public record IsbnRecord(string Isbn, double Price);
    }
}