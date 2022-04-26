using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;
using Xunit;
namespace Chapter17_DynamicProgramming;

public class BedBathAndBeyondTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void FindAnyDecompositionTest(string name, ISet<string> dictionary, string[] expectedResult)
    {
        var sut = new BedBathAndBeyond();
        var actual = sut.FindAnyDecomposition(name, dictionary);
        Assert.Equal(expectedResult, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return BedBathAndBeyondBookExample();
        yield return AManAPlanACanal();
    }
    public static object[] BedBathAndBeyondBookExample() =>
        new object[] { "BedBathAndBeyond", new HashSet<string>() { "Bed", "Bath", "And", "Beyond" }, new string[] { "Bed", "Bath", "And", "Beyond" } };

    public static object[] AManAPlanACanal() =>
new object[] { "AManAPlanACanal", new HashSet<string>() { "A", "Man", "Plan", "Canal" }, new string[] { "A", "Man", "A", "Plan", "A", "Canal" } };

}
