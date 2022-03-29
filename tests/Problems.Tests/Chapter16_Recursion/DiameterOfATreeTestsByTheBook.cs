using Problems.Chapter16_Recursion;
using Xunit;

namespace Problems.Tests.Chapter16_Recursion.BookSolution
{
    public class DiameterOfATreeTestsByTheBook : DiameterOfATreeTestsBase
    {
        protected override Node node(params Edge[] children) => new Problems.Chapter16_Recursion.BookSolution.Node(children);
    }
}