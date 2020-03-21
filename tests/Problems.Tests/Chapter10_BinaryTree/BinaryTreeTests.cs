using Problems.Chapter_10_BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Problems.Tests.Chapter10_BinaryTree
{
    public class BinaryTreeTests
    {
        BinaryTree<char> binaryTree;

        public BinaryTreeTests()
        {
            binaryTree = new BinaryTree<char>()
            {
                 Value = 'A',
                 Left = new BinaryTree<char>()
                 {
                     Value = 'B',
                     Left = new BinaryTree<char>()
                     {
                         Value = 'C',
                         Left = new BinaryTree<char>('D'),
                         Right = new BinaryTree<char>('E')
                     },
                     Right = new BinaryTree<char>()
                     {
                         Value = 'F',
                         Right = new BinaryTree<char>()
                         {
                             Value = 'G',
                             Left = new BinaryTree<char>('H')
                         }
                     }
                 },
                 Right = new BinaryTree<char>()
                 {
                     Value = 'I',
                     Left = new BinaryTree<char>()
                     {
                         Value = 'J',
                         Right = new BinaryTree<char>()
                         {
                             Value = 'K',
                             Left = new BinaryTree<char>()
                             {
                                 Value = 'L',
                                 Right = new BinaryTree<char>('M')
                             },
                             Right = new BinaryTree<char>('N')
                         }
                     },
                     Right = new BinaryTree<char>()
                     {
                         Value = 'O',
                         Right = new BinaryTree<char>('P')
                     }
                 }
            };
        }

        [Fact]
        public void PreorderTest()
        {
            var preorder = binaryTree.Preorder().ToArray();

            var actual = new string(preorder);

            var expected = "ABCDEFGHIJKLMNOP";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InorderTest()
        {
            var preorder = binaryTree.Inorder().ToArray();

            var actual = new string(preorder);

            var expected = "DCEBFHGAJLMKNIOP";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PostorderTest()
        {
            var preorder = binaryTree.Postorder().ToArray();

            var actual = new string(preorder);

            var expected = "DECHGFBMLNKJPOIA";

            Assert.Equal(expected, actual);
        }
    }
}
