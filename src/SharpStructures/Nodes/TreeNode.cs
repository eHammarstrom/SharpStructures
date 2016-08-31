using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Nodes
{
    public class TreeNode<E> {
        public E data;
        public TreeNode<E> Parent { get; set; }
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

        public TreeNode(TreeNode<E> parent, E data) {
            this.data = data;
            Parent = parent;
            Left = null;
            Right = null;
            Balance = 0;
        }
    }
}
