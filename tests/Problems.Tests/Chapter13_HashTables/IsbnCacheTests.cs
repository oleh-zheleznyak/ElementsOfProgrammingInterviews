using Problems.Chapter13_HashTables;
using Xunit;

namespace Problems.Tests.Chapter13_HashTables
{
    public class IsbnCacheTests
    {
        private static int capacity = 2;
        private readonly IsbnCache cache = new IsbnCache(capacity);
        private readonly IsbnCache.IsbnRecord elementsOfProgrammingInterviews = new("1479274836", 19.94);
        
        [Fact]
        public void Insert_ShouldAddNew()
        {
            cache.InsertPrice(elementsOfProgrammingInterviews.Isbn, elementsOfProgrammingInterviews.Price);
            var priceInCache = cache.LookupPrice(elementsOfProgrammingInterviews.Isbn);
            Assert.Equal(elementsOfProgrammingInterviews.Price, priceInCache);
        }
        
        [Fact]
        public void Insert_ShouldOverwritePrice()
        {
            cache.InsertPrice(elementsOfProgrammingInterviews.Isbn, elementsOfProgrammingInterviews.Price);
            var newPrice = 100D;
            cache.InsertPrice(elementsOfProgrammingInterviews.Isbn, newPrice);
            var priceInCache = cache.LookupPrice(elementsOfProgrammingInterviews.Isbn);
            Assert.Equal(newPrice, priceInCache);
        }
        
        [Fact]
        public void Cache_ShouldEvictItems()
        {
            var first = new IsbnCache.IsbnRecord("A", 1);
            var second = new IsbnCache.IsbnRecord("B", 2);
            var third = new IsbnCache.IsbnRecord("C", 3);
            
            cache.InsertPrice(first);
            cache.InsertPrice(second);
            cache.InsertPrice(third);
            
            Assert.Null(cache.LookupPrice(first.Isbn));
            Assert.Equal(second.Price, cache.LookupPrice(second.Isbn));
            Assert.Equal(third.Price, cache.LookupPrice(third.Isbn));
        }
    }
}