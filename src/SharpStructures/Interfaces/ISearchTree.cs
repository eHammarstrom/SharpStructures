using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Interfaces
{
    interface ISearchTree<E>
    {
        bool Add(E element);
        bool Contains(E element);
        E Get(E element);
        E Remove(E element);
        int Height();
        void Clear();
    }
}
