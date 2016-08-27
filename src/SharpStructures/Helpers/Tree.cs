using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SharpStructures.Nodes;

namespace SharpStructures.Helpers {
    public static class Tree<E> {
        /// <summary>
        /// http://stackoverflow.com/a/8567550/6162189
        /// Kudos to Joshua Stachowski
        /// </summary>
        /// <param name="tree"></param>
        public static void Print(TreeNode<E> tree) {
            List<TreeNode<E>> firstStack = new List<TreeNode<E>>();
            firstStack.Add(tree);

            List<List<TreeNode<E>>> childListStack = new List<List<TreeNode<E>>>();
            childListStack.Add(firstStack);

            while (childListStack.Count > 0) {
                List<TreeNode<E>> childStack = childListStack[childListStack.Count - 1];

                if (childStack.Count == 0) {
                    childListStack.RemoveAt(childListStack.Count - 1);
                }
                else {
                    tree = childStack[0];
                    childStack.RemoveAt(0);

                    string indent = "";
                    for (int i = 0; i < childListStack.Count - 1; i++) {
                        indent += (childListStack[i].Count > 0) ? "|  " : "   ";
                    }

                    Console.WriteLine(indent + "+- " + tree.data.ToString());

                    if (tree.Children.Count > 0) {
                        childListStack.Add(new List<TreeNode<E>>(tree.Children));
                    }
                }
            }
        }
    }
}
