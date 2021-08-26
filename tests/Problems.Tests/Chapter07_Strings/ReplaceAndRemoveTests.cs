using Problems.Chapter07_Strings;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Problems.Tests.Chapter07_Strings
{
    public class ReplaceAndRemoveTests
    {
        readonly ReplaceAndRemove replacer = new();

        [Theory]
        [MemberData(nameof(TestData_ForLinearMemory))]
        public void Process_WithLinearMemoryTest(char[] inputArray, int elementsToProcess, char[] expectedResult)
        {
            var actual = replacer.Process_WithLinearMemory(inputArray, elementsToProcess);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [MemberData(nameof(TestData_ForConstantMemory))]
        public void Process_WithConstantMemoryTest(char[] inputArray, int elementsToProcess, char[] expectedResult)
        {
            var actual = replacer.Process_WithConstantMemory(inputArray, elementsToProcess);
            Assert.Equal(expectedResult, actual);
        }

        public static IEnumerable<object[]> TestData_ForConstantMemory() => TestData().Union(new object[][] { singleBChar_OneToProcess });

        public static IEnumerable<object[]> TestData_ForLinearMemory() => TestData().Union(new object[][] { singleBChar_OneToProcessLinear });

        public static IEnumerable<object[]> TestData()
        {
            yield return emptyArray_ZeroToProcess;
            yield return nonEmptyArray_ZeroToProcess;
            yield return singleA_OneToProcess;
            yield return arrayWithNoControlChars_EntirelyToProcess;
            yield return mixedCharsOfAlltypes_AllToProcess;
        }

        private static object[] mixedCharsOfAlltypes_AllToProcess = new object[]
        {
            new char[] { 'a', 'c', 'b', 'a', char.MinValue },
            4,
            new char[] { 'd', 'd', 'c', 'd', 'd' }
        };


        private static object[] singleBChar_OneToProcess = new object[]
        {
            new char[] { 'b' },
            1,
            new char[] { char.MinValue }
        };


        private static object[] singleBChar_OneToProcessLinear = new object[]
        {
            new char[] { 'b' },
            1,
            new char[] { }
        };

        private static object[] arrayWithNoControlChars_EntirelyToProcess = new object[]
        {
            new char[] { 'f','e','g' },
            3,
            new char[] { 'f', 'e', 'g' }
        };

        private static object[] singleA_OneToProcess = new object[]
        {
            new char[] { 'a', char.MinValue },
            1,
            new char[] { 'd','d' }
        };

        private static object[] emptyArray_ZeroToProcess = new object[]
        {
            new char[] { },
            0,
            new char[] { }
        };

        private static object[] nonEmptyArray_ZeroToProcess = new object[]
        {
            new char[] { 'z' },
            0,
            new char[] { }
        };
    }
}
