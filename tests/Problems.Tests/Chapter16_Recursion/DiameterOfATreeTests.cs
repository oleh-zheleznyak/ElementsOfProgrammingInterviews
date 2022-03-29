using Problems.Chapter16_Recursion;

namespace Problems.Tests.Chapter16_Recursion
{
    public class DiameterOfATreeTests : DiameterOfATreeTestsBase
    {
        protected override Node node(params Edge[] children) => new MyNode(children);
    }
}