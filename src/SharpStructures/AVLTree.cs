using System;

using SharpStructures.Interfaces;
using SharpStructures.Nodes;
using SharpStructures.Helpers;

namespace SharpStructures {
    public class AVLTree<E> : ISearchTree<E> where E : IComparable {
        private TreeNode<E> _root;
        private bool _isBalanceOff;
        private bool _wasAdded;

        public AVLTree() {
            _root = null;
            _isBalanceOff = false;
            _wasAdded = false;
        }

        #region Public

        public bool Add(E element) {
            _isBalanceOff = false;
            _root = Add(_root, element);
            return _wasAdded;
        }

        public void Clear() => _root = null;

        public bool Contains(E element) => Contains(_root, element);

        public E Remove(E element) {
            throw new NotImplementedException();
        }

        public E Get(E element) => Get(_root, element);

        public int Height() => Height(_root);

        public void Print() => Tree<E>.Print(_root);

        #endregion

        #region Private

        private E Get(TreeNode<E> node, E element) {
            if (element.CompareTo(node.data) == 0)
                return node.data;
            else if (node.Left != null && element.CompareTo(node.data) < 0)
                return Get(node.Left, element);
            else if (node.Right != null && element.CompareTo(node.data) > 0)
                return Get(node.Right, element);
            else
                return default(E);
        }

        private bool Contains(TreeNode<E> node, E element) {
            if (element.CompareTo(node.data) == 0)
                return true;
            else if (node.Left != null && element.CompareTo(node.data) < 0)
                return Contains(node.Left, element);
            else if (node.Right != null && element.CompareTo(node.data) > 0)
                return Contains(node.Right, element);
            else
                return false;
        }

        private int Height(TreeNode<E> node) {
            if (node == null)
                return 0;
            else
                return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private TreeNode<E> Add(TreeNode<E> node, E element) {
            if (node == null) {
                _isBalanceOff = true;
                _wasAdded = true;
                return new TreeNode<E>(element);
            }
            else if (element.CompareTo(node.data) == 0) {
                _wasAdded = false;
                return node;
            }
            else if (element.CompareTo(node.data) < 0) {
                node.Left = Add(node.Left, element);

                if (_isBalanceOff) {
                    node.Balance--;

                    if (node.Balance == TreeNode<E>.BALANCED) _isBalanceOff = false;
                    if (node.Balance < TreeNode<E>.LEFT_HEAVY) node = RebalanceLeft(node);
                }

                return node;
            }
            else if (element.CompareTo(node.data) > 0) {
                node.Right = Add(node.Right, element);

                if (_isBalanceOff) {
                    node.Balance++;

                    if (node.Balance == TreeNode<E>.BALANCED) _isBalanceOff = false;
                    if (node.Balance > TreeNode<E>.RIGHT_HEAVY) node = RebalanceRight(node);
                }

                return node;
            }

            throw new TreeException("AVLTree.Add(TreeNode, E): undefined case");
        }

        private TreeNode<E> RebalanceLeft(TreeNode<E> node) {
            if (node.Left.Balance >= TreeNode<E>.RIGHT_HEAVY) {
                if (node.Left.Left != null && node.Left.Left.Balance <= TreeNode<E>.LEFT_HEAVY) {
                    Console.WriteLine("Left-Right-Left Heavy");
                    node.Left.Balance = TreeNode<E>.BALANCED;
                    node.Left.Left.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.LEFT_HEAVY;
                }
                else if (node.Left.Left != null && node.Left.Left.Balance >= TreeNode<E>.RIGHT_HEAVY) {
                    Console.WriteLine("Left-Right-Right Heavy");
                    node.Left.Balance = TreeNode<E>.LEFT_HEAVY;
                    node.Left.Left.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.BALANCED;
                }
                else {
                    node.Left.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.BALANCED;
                }

                Console.WriteLine("{0} Left-Right Heavy", node.data);
                node.Left = RotateLeft(node.Left);
            }
            else {
                node.Left.Balance = TreeNode<E>.BALANCED;
                node.Balance = TreeNode<E>.BALANCED;
            }

            Console.WriteLine("{0} Left Heavy", node.data);
            node = RotateRight(node);

            return node;
        }

        private TreeNode<E> RebalanceRight(TreeNode<E> node) {
            if (node.Right.Balance <= TreeNode<E>.LEFT_HEAVY) {
                if (node.Right.Right != null && node.Right.Right.Balance >= TreeNode<E>.RIGHT_HEAVY) {
                    Console.WriteLine("Right-Left-Right Heavy");
                    node.Right.Balance = TreeNode<E>.BALANCED;
                    node.Right.Right.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.RIGHT_HEAVY;
                }
                else if (node.Right.Right != null && node.Right.Right.Balance <= TreeNode<E>.LEFT_HEAVY) {
                    Console.WriteLine("Right-Left-Left Heavy");
                    node.Right.Balance = TreeNode<E>.RIGHT_HEAVY;
                    node.Right.Right.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.BALANCED;
                }
                else {
                    node.Right.Balance = TreeNode<E>.BALANCED;
                    node.Balance = TreeNode<E>.BALANCED;
                }

                Console.WriteLine("{0} Right-Left Heavy", node.data);
                node.Right = RotateRight(node.Right);
            }
            else {
                node.Right.Balance = TreeNode<E>.BALANCED;
                node.Balance = TreeNode<E>.BALANCED;
            }

            Console.WriteLine("{0} Right Heavy", node.data);
            node = RotateLeft(node);

            return node;
        }

        private TreeNode<E> RotateRight(TreeNode<E> node) {
            TreeNode<E> tempNode = node.Left;
            node.Left = tempNode.Right;
            tempNode.Right = node;

            return tempNode;
        }

        private TreeNode<E> RotateLeft(TreeNode<E> node) {
            TreeNode<E> tempNode = node.Right;
            node.Right = tempNode.Left;
            tempNode.Left = node;

            return tempNode;
        }

        #endregion
    }
}
