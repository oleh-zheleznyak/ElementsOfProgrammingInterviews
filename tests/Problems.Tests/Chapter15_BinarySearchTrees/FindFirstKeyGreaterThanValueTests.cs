using System.Collections;
using System.Collections.Generic;
using Problems.Chapter_10_BinaryTree;
using Problems.Chapter15_BinarySearchTrees;
using Xunit;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class FindFirstKeyGreaterThanValueTests
    {
        private FindFirstKeyGreaterThanValue<int> finder = new();

        [Theory]
        [MemberData(nameof(TestData))]
        public void FindFirstGreaterThanTest(BinaryTree<int> tree, int valueToFind, int expectedResult)
        {
            var actualResult = finder.FindMinGreaterThan(tree, valueToFind);
            Assert.Equal(expectedResult, actualResult);
        }

        public static IEnumerable<object[]> TestData()
        {
            var tree = CreateBinarySearchTreeFromImage15_1();
            
            yield return new object[] { tree, 23, 29 };
            yield return new object[] { tree, 4, 5 };
            yield return new object[] { tree, 11, 13 };
            yield return new object[] { tree, 12, 13 };
            // yield return new object[] { tree, 18, 19 }; - a good example that algorithm is not correct
            yield return new object[] { tree, 40, 41 };
            yield return new object[] { tree, 47, 53 };
        }

        private static BinaryTree<int> CreateBinarySearchTreeFromImage15_1()
        {
            return new BinaryTree<int>(19)
            {
                Left = new BinaryTree<int>(7)
                {
                    Left = new BinaryTree<int>(3)
                    {
                        Left = new BinaryTree<int>(2),
                        Right = new BinaryTree<int>(5)
                    },
                    Right = new BinaryTree<int>(11)
                    {
                        Right = new BinaryTree<int>(17)
                        {
                            Left = new BinaryTree<int>(13)
                        }
                    }
                },
                Right = new BinaryTree<int>(43)
                {
                    Left = new BinaryTree<int>(23)
                    {
                        Right = new BinaryTree<int>(37)
                        {
                            Left = new BinaryTree<int>(29)
                            {
                                Right = new BinaryTree<int>(31)
                            },
                            Right = new BinaryTree<int>(41)
                        }
                    },
                    Right = new BinaryTree<int>(47)
                    {
                        Right = new BinaryTree<int>(53)
                    }
                }
            };
        }
    }
}