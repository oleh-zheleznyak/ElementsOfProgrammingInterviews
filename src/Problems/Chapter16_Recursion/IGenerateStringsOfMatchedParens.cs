using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public interface IGenerateStringsOfMatchedParens
    {
        IReadOnlyCollection<string> AllStringsWithMachedNumberOfParens(uint numberOfMatchedParensPairs);
    }
}