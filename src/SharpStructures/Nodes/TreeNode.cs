using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Nodes
{
    public class TreeNode<E> {
        public const int BALANCED = 0;
        public const int LEFT_HEAVY = -1;
        public const int RIGHT_HEAVY = 1;

        public E data;
        public TreeNode<E> Left { get; set; }
        public TreeNode<E> Right { get; set; }
        public int Balance { get; set; }

        public List<TreeNode<E>> Children {
            get {
                List<TreeNode<E>> list = new List<TreeNode<E>>();
                if (Left != null) list.Add(Left);
                if (Right != null) list.Add(Right);
                return list;
            }
        }

        public TreeNode(E data) {
            this.data = data;
            Left = null;
            Right = null;
            Balance = 0;
        }
    }
}
