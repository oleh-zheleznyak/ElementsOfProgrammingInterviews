using System.Collections.Generic;

namespace Problems.Chapter16_Recursion
{
    public interface IGeneratePermutations<T>
    {
        IEnumerable<T[]> AllPermutationsOf(T[] array);
    }
}
