using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures {
    public class LinkedList<T> : IEnumerable<T>, ICollection<T> where T : class {
        int count;
        SingleLinkedListNode<T> root;
        SingleLinkedListNode<T> last;

        public LinkedList() {
            root = null;
            last = null;
            count = 0;
        }

        /// <summary>
        /// Returns amount of elements
        /// </summary>
        public int Count {
            get { return count; }
        }

        public bool IsReadOnly {
            get {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Removes object from list
        /// </summary>
        /// <param name="obj">Object to be removed</param>
        /// <returns>True if identified and removed</returns>
        public bool Remove(T obj) {
            SingleLinkedListNode<T> last = root;
            SingleLinkedListNode<T> current = root;

            while (current != null) {
                if (current.data.Equals(obj)) {
                    last.next = current.next;
                    count--;
                    return true;
                }

                last = current;
                current = current.next;
            }

            return false;
        }

        /// <summary>
        /// Adds element to end of list
        /// </summary>
        /// <param name="data">Element to add</param>
        public void Add(T data) {
            if (root == null) {
                root = new SingleLinkedListNode<T>(data);
                last = root;
            } else {
                last.next = new SingleLinkedListNode<T>(data);
                last = last.next;
            }

            count++;
        }

        /// <summary>
        /// List object enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator() {
            SingleLinkedListNode<T> current = root;

            if (current == null) yield break;

            while (current != null) {
                yield return current.data;
                current = current.next;
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return (IEnumerator) GetEnumerator();
        }

        /// <summary>
        /// List in string format
        /// </summary>
        /// <returns>List as string</returns>
        override public String ToString() {
            string str = "";

            foreach (T t in this) {
                str += t.ToString() + " ";
            }

            return str;
        }

        public void Clear() {
            root = null;
        }

        public bool Contains(T item) {
            foreach (T t in this) {
                if (t.Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex) {
            int i = 0;
            foreach (T item in this) {
                if (i >= arrayIndex) array[i] = item;
                i++;
            }
        }
    }

    public class SingleLinkedListNode<E> where E : class {
        public SingleLinkedListNode<E> next;
        public E data;

        public SingleLinkedListNode(E data) {
            this.data = data;
        }
    }
}
