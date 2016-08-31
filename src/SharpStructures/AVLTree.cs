using System;

using SharpStructures.Interfaces;
using SharpStructures.Nodes;
using SharpStructures.Helpers;

namespace SharpStructures {
    public class AVLTree<E> : ISearchTree<E> where E : IComparable {
        private TreeNode<E> _root;

        public bool Add(E element) {
            throw new NotImplementedException();
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public bool Contains(E element) {
            throw new NotImplementedException();
        }

        public E Delete(E element) {
            throw new NotImplementedException();
        }

        public E Find(E element) {
            throw new NotImplementedException();
        }

        public int Height() {
            throw new NotImplementedException();
        }

        public bool Remove(E element) {
            throw new NotImplementedException();
        }

        public void Print() => Tree<E>.Print(_root);
    }
}
