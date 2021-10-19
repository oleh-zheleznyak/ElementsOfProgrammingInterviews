using Problems.Chapter_10_BinaryTree;

namespace Problems.Tests.Chapter15_BinarySearchTrees
{
    public class TestDataHelper
    {
        public static BinaryTree<int> CreateBinarySearchTreeFromImage15_1()
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