namespace Problems.Chapter06_Arrays
{
    public interface IPermuteTheElementsOfAnArray<T>
    {
        void ApplyPermutation(T[] array, int[] permutation);
        T[] ApplyPermutationToNewArray(T[] array, int[] permutation);
    }
}