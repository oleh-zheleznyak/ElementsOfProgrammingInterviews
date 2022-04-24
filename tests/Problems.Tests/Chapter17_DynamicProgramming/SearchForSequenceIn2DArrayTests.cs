using System.Collections.Generic;
using Problems.Chapter17_DynamicProgramming;
using Xunit;
namespace Chapter17_DynamicProgramming;

public class SearchForSequenceIn2DArrayTests
{
    [Theory]
    [MemberData(nameof(TestData))]
    public void MatrixContainsSequenceTests(int[,] matrix, int[] sequence, bool expectedResult)
    {
        var sut = new SearchForSequenceIn2DArray();
        var actual = sut.MatrixContainsSequence(matrix, sequence);
        Assert.Equal(expectedResult, actual);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return EmptyMatrixDoesNotContainEmptyPath();
        yield return EmptyMatrixDoesNotContainNonEmptyPath();
        yield return SingleElementMatrixContainsSingleElement();
        yield return SingleElementMatrixDoesNotContainAnotherElement();
        yield return SampleMatrixContainsRow() ;
        yield return SampleMatrixContainsColumn();
        yield return SampleMatrixContainsTurn();
        yield return SampleMatrixContainsLoops();
        yield return SampleMatrixDoesNotContainNonAdjacentElements();
    }
    public static object[] EmptyMatrixDoesNotContainEmptyPath() => new object[] { new int[0, 0], new int[0], false };
    public static object[] EmptyMatrixDoesNotContainNonEmptyPath() => new object[] { new int[0, 0], new int[] { 1, 2, 3 }, false };

    public static object[] SingleElementMatrixContainsSingleElement() => new object[] { new int[1, 1] { { 1 } }, new int[] { 1 }, true };

    public static object[] SingleElementMatrixDoesNotContainAnotherElement() => new object[] { new int[1, 1] { { 1 } }, new int[] { 2 }, false };

    public static object[] SampleMatrixContainsRow() => new object[] { SampleMatrix(), new int[] { 4, 5, 6 }, true };

    public static object[] SampleMatrixContainsColumn() => new object[] { SampleMatrix(), new int[] { 2, 5, 8 }, true };

    public static object[] SampleMatrixContainsTurn() => new object[] { SampleMatrix(), new int[] { 1,2, 5, 8,9 }, true };

public static object[] SampleMatrixContainsLoops() => new object[] { SampleMatrix(), new int[] { 1,2,5,4,1,2 }, true };
    public static object[] SampleMatrixDoesNotContainNonAdjacentElements() => new object[] { SampleMatrix(), new int[] { 4,6 }, false };
    private static int[,] SampleMatrix() => new int[3, 3]
    {
        {1,2,3},
        {4,5,6},
        {7,8,9}
    };

}
