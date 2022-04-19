using Xunit;
namespace Chapter17_DynamicProgramming;

public abstract class BinomialCoefficientTests
{
    [Theory]
    [InlineData(1,1,1)]
    [InlineData(2,1,2)]
    [InlineData(2,2,1)]
    [InlineData(3,1,3)]
    [InlineData(3,2,3)]
    [InlineData(3,3,1)]
    public void ComputeDistanceTest(byte n, byte k, uint expectedResult)
    {
        var sut = new BinomialCoefficient();
        var actual = sut.Compute(n, k);
        Assert.Equal(expectedResult, actual);
    }
}