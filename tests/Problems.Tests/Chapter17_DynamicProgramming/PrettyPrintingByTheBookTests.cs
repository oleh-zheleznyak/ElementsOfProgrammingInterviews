using Problems.Chapter17_DynamicProgramming;
using System.Collections.Generic;
using Xunit;
using static Problems.Chapter17_DynamicProgramming.PrettyPrinting;

namespace Problems.Tests.Chapter17_DynamicProgramming
{
    public class PrettyPrintingByTheBookTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void CalculateMessinessTest(string text, int lineWidth, int expected)
        {
            var sut = new PrettyPrintingByTheBook();
            var words = text.Split(' ');
            var actual = sut.CalculateMessiness(words, lineWidth);
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData()
        {
           yield return BookExample();
        }

        public static object[] BookExample() => new object[]
        {
          "aaa bbb c d ee ff ggggggg",
          11,
          20
        };
    }
}