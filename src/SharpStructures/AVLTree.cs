using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SharpStructures.Interfaces;
using SharpStructures.Nodes;
using SharpStructures.Helpers;

namespace SharpStructures {
    public class AVLTree<E> : ISearchTree<E> where E : IComparable {
        private TreeNode<E> _root;
        private int _leftHeight;
        private int _rightHeight;
        private bool _increase;

        public AVLTree() {
            _leftHeight = 0;
            _rightHeight = 0;
            _root = null;
            _increase = false;
        }

        public bool Add(E element) {
            _increase = false;

            if (_root == null) {
                _root = new TreeNode<E>(element);
                _leftHeight++;
                _rightHeight++;
                return true;
            }
            else if (element.CompareTo(_root.data) == 0) {
                return false;
            }
            else if (element.CompareTo(_root.data) < 0) {
                _root.Left = Add(_root.Left, element);

                if (_increase) _leftHeight++;

                return _increase;
            }
            else if (element.CompareTo(_root.data) > 0) {
                _root.Right = Add(_root.Right, element);

                if (_increase) _rightHeight++;

                return _increase;
            }
            throw new TreeException("AVLTree.Add(E): undefined case");
        }

        private TreeNode<E> Add(TreeNode<E> crawlNode, E element) {
            if (crawlNode == null) {
                crawlNode = new TreeNode<E>(element);
                _increase = true;
                return crawlNode;
            }
            else if (element.CompareTo(crawlNode.data) == 0) {
                return crawlNode;
            }
            else if (element.CompareTo(crawlNode.data) < 0) {
                crawlNode.Left = Add(crawlNode.Left, element);
            }
            else if (element.CompareTo(crawlNode.data) > 0) {
                crawlNode.Right = Add(crawlNode.Right, element);
            }
            return crawlNode;
        }

        public bool Contains(E element) {
            return Contains(_root, element);
        }

        private bool Contains(TreeNode<E> crawlNode, E element) {
            if (crawlNode == null)
                return false;
            else if (element.CompareTo(crawlNode.data) == 0)
                return true;
            else if (element.CompareTo(crawlNode.data) < 0)
                return Contains(crawlNode.Left, element);
            else if (element.CompareTo(crawlNode.data) > 0)
                return Contains(crawlNode.Right, element);

            throw new TreeException("AVLTree.Contains(TreeNode, E): undefined case");
        }

        public E Delete(E element) {
            return Delete(null, _root, element);
        }

        private E Delete(TreeNode<E> parent, TreeNode<E> crawlNode, E element) {
            if (crawlNode == null)
                return default(E);
            else if (element.CompareTo(crawlNode.data) < 0)
                return Delete(crawlNode, crawlNode.Left, element);
            else if (element.CompareTo(crawlNode.data) > 0)
                return Delete(crawlNode, crawlNode.Right, element);
            else { // We found it
                E deleteReturn = crawlNode.data;
                bool isLeft = (parent.Left.data.Equals(crawlNode.data)) ? true : false;

                if (crawlNode.Children.Count == 0) {
                    if (isLeft) parent.Left = null;
                    else parent.Right = null;
                }
                else if (crawlNode.Children.Count == 1) {
                    if (isLeft) parent.Left = crawlNode.Children[0];
                    else parent.Right = crawlNode.Children[0];
                }
                else {
                    if (crawlNode.Left.Right == null) {
                        crawlNode.Left.Right = crawlNode.Right;
                        if (isLeft) parent.Left = crawlNode.Left;
                        else parent.Right = crawlNode.Left;
                    }
                    else {
                        TreeNode<E> tempSearch = crawlNode.Left;
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

            throw new TreeException("AVLTree.Delete(TreeNode, E): undefined case");
        }

        public E Find(E element) {
            return Find(_root, element);
        }
        
        private E Find(TreeNode<E> crawlNode, E element) {
            if (crawlNode == null)
                return default(E);
            else if (element.CompareTo(crawlNode.data) == 0)
                return crawlNode.data;
            else if (element.CompareTo(crawlNode.data) < 0)
                return Find(crawlNode.Left, element);
            else if (element.CompareTo(crawlNode.data) > 0)
                return Find(crawlNode.Right, element);

            throw new NotImplementedException("AVLTree.Find(TreeNode, E): undefined case");
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

        private void RebalanceRight() {

        }

        private void RebalanceLeft() {

        }

        private void Rebalance() {
            if (GetBalance() < -1)
                RebalanceRight();
            else if (GetBalance() > 1)
                RebalanceLeft();
        }

        private int GetBalance() {
            return _leftHeight - _rightHeight;
        }

        public int Height() => Height(_root);

        private int Height(TreeNode<E> crawlNode) {
            throw new NotImplementedException();
        }
    }
}
