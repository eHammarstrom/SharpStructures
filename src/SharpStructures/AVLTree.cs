using System;

using SharpStructures.Interfaces;
using SharpStructures.Nodes;
using SharpStructures.Helpers;

namespace SharpStructures {
    public class AVLTree<E> : ISearchTree<E> where E : IComparable {
        private TreeNode<E> _root;
        private bool _added;

        public AVLTree() {
            _root = null;
        }

        public bool Add(E element) {
            _added = false;

            if (_root == null) {
                _root = new TreeNode<E>(element);
                return true;
            }
            else if (element.CompareTo(_root.data) == 0) {
                return false;
            }
            else if (element.CompareTo(_root.data) < 0) {
                _root.Left = Add(_root.Left, element);
                return _added;
            }
            else {
                _root.Right = Add(_root.Right, element);
                return _added;
            }
        }

        private TreeNode<E> Add(TreeNode<E> node, E element) {
            if (node == null) {
                node = new TreeNode<E>(element);
                _added = true;
                return node;
            }
            else if (element.CompareTo(node.data) < 0) {
                node.Left = Add(node.Left, element);
            }
            else if (element.CompareTo(node.data) > 0) {
                node.Right = Add(node.Right, element);
            }

            return node;
        }

        public bool Contains(E element) {
            return Contains(_root, element);
        }

        private bool Contains(TreeNode<E> node, E element) {
            if (node == null)
                return false;
            else if (element.CompareTo(node.data) == 0)
                return true;
            else if (element.CompareTo(node.data) < 0)
                return Contains(node.Left, element);
            else
                return Contains(node.Right, element);
        }

        public E Delete(E element) {
            return Delete(null, _root, element);
        }

        private E Delete(TreeNode<E> parent, TreeNode<E> node, E element) {
            if (node == null)
                return default(E);
            else if (element.CompareTo(node.data) < 0)
                return Delete(node, node.Left, element);
            else if (element.CompareTo(node.data) > 0)
                return Delete(node, node.Right, element);
            else { // We found it
                E deleteReturn = node.data;
                bool isLeft = (parent.Left.data.Equals(node.data)) ? true : false;

                if (node.Children.Count == 0) {
                    if (isLeft) parent.Left = null;
                    else parent.Right = null;
                }
                else if (node.Children.Count == 1) {
                    if (isLeft) parent.Left = node.Children[0];
                    else parent.Right = node.Children[0];
                }
                else {
                    if (node.Left.Right == null) {
                        node.Left.Right = node.Right;
                        if (isLeft) parent.Left = node.Left;
                        else parent.Right = node.Left;
                    }
                    else {
                        TreeNode<E> tempSearch = node.Left;
                        TreeNode<E> tempSearchParent = null;

                        while (tempSearch.Right != null) {
                            tempSearchParent = tempSearch;
                            tempSearch = tempSearch.Right;
                        }

                        if (isLeft) parent.Left = tempSearch;
                        else parent.Right = tempSearch;

                        tempSearchParent.Right = tempSearch.Left;
                    }
                }

                return deleteReturn;
            }
        }

        public E Find(E element) {
            return Find(_root, element);
        }
        
        private E Find(TreeNode<E> node, E element) {
            if (node == null)
                return default(E);
            else if (element.CompareTo(node.data) == 0)
                return node.data;
            else if (element.CompareTo(node.data) < 0)
                return Find(node.Left, element);
            else if (element.CompareTo(node.data) > 0)
                return Find(node.Right, element);

            throw new TreeException("AVLTree.Find(TreeNode, E): undefined case");
        }

        public bool Remove(E element) {
            throw new NotImplementedException();
        }

        public void Print() {
            Tree<E>.Print(_root);
        }

        public void Clear() {
            _root = null;
        }

        private int GetBalanceFactor(TreeNode<E> node) {
            if (node == null)
                return 0;

            if (node.Left != null && node.Right != null)
                return Height(node.Left) - Height(node.Right);
            else
                return 0;
        }

        public int Height() => Height(_root) + 1;

        private int Height(TreeNode<E> node) {
            if (node == null)
                return 0;
            else if (node.Left != null || node.Right != null)
                return 1 + Height(node.Left) + Height(node.Right);
            else
                return 0;
        }
    }
}
