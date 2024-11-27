using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsoleApp
{
    public class SimpleBinarySearch : LeetCodeRunner
    {
        public override void Run()
        {
            int searchValue = 12;
            var root = GetRootWithInitialData();

            var foundNode = Search(root,12);
            Console.WriteLine( $"Searched {searchValue} and found {foundNode.Key}");
        }

        private TreeNode Search(TreeNode node, int value)
        {
            Console.WriteLine($"searching {value} in {node.Key}");
            if (node.Key == value)
            {
                return node;
            }

            if (value > node.Key)
            {
                return Search(node.Right, value);
            }
            return Search(node.Left, value);
        }

        private TreeNode GetRootWithInitialData()
        {
            /*
                   10
                  /  \
                 5    15
                / \   / \
               2   7 12  17
            */
            var root = new TreeNode(10);
            root.Left = new TreeNode(5);
            root.Right = new TreeNode(15);

            root.Left.Left = new TreeNode(2);
            root.Left.Right = new TreeNode(7);

            root.Right.Left = new TreeNode(12);
            root.Right.Right = new TreeNode(17);
            return root;
        }
    }

    public class TreeNode
    {
        public int Key { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int key)
        {
            Key = key;
        }
    }
}
