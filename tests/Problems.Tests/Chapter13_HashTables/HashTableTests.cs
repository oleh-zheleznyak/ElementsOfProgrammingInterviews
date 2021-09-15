using System.Linq;
using Problems.Chapter13_HashTables;
using Xunit;

namespace Problems.Tests.Chapter13_HashTables
{
    public class HashTableTests
    {
        [Fact]
        public void AddedRecordCanBeFound()
        {
            var hashTable = new HashTable<string, int>();
            var key = "key";
            var value = 1;
            hashTable.Add(key, value);
            
            Assert.True(hashTable.TryGetValue(key, out var foundValue));
            Assert.Equal(value,foundValue);
        }
        
        [Fact]
        public void DeletedRecordCannotBeFound()
        {
            var hashTable = new HashTable<string, int>();
            var key = "key";
            var value = 1;
            hashTable.Add(key, value);
            
            Assert.True(hashTable.Remove(key));
            Assert.False(hashTable.TryGetValue(key, out var _));
        }
        
        [Fact]
        public void CanGrow()
        {
            var hashTable = new HashTable<string, int>();
            var sequence = Enumerable.Range(0, 100);
            foreach (var element in sequence)
            {
                hashTable.Add(element.ToString(),element);
            }
            
            Assert.All(sequence, i => Assert.True(hashTable.TryGetValue(i.ToString(), out var _)));
        }
    }
}