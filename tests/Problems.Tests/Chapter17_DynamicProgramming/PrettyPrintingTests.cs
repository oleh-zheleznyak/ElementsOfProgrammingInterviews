using Problems.Chapter17_DynamicProgramming;
using System.Collections.Generic;
using Xunit;
using static Problems.Chapter17_DynamicProgramming.PrettyPrinting;

namespace Problems.Tests.Chapter17_DynamicProgramming
{
    public class PrettyPrintingTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void DecomposeIntoLinesTest(string text, uint lineWidth, PrettyPrinting.Decomposition expected)
        {
            var sut = new PrettyPrinting();
            var actual = sut.DecomposeIntoLines(text, lineWidth);
            
            Assert.Equal(expected.Messiness, actual.Messiness);
            Assert.Equal(expected.Lines.Length, actual.Lines.Length);

            // TODO: record implements equals - and it is shallow
            // naturally, string arrays with same elements are not equal
            // that is why we cannot compare whole objects
            // workaround - compare line as a string
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return Trivial();
            yield return TrivialThreeSymbolsPerLine();
            // yield return BookExample();
        }
        public static object[] Trivial() => new object[]
        {
          "a b",
          1,
          new Decomposition(new Line[] {
            new Line(new [] {"b"},0,1 ), 
            new Line(new [] {"a"},0,0 )},0 )
        };

        public static object[] TrivialThreeSymbolsPerLine() => new object[]
        {
          "a b c",
          3,
          new Decomposition(new Line[] {
            new Line(new [] {"a", "b"},0,1 ), 
            new Line(new [] {"c"},4,2 )}
            ,4 )
        };

        public static object[] BookExample() => new object[]
        {
          "I have inserted a large number of new examples from the papers for the Mathematical Tripos during the last twenty years, which should be useful to Cambridge students.",
          36,
          82
        };
    }
}