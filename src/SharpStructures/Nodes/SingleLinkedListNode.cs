using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Nodes
{
    public class SingleLinkedListNode<E> where E : class {
        public SingleLinkedListNode<E> next;
        public E data;

        public SingleLinkedListNode(E data) {
            this.data = data;
        }
    }
}
