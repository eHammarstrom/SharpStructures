using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Helpers
{
    public class TreeException : Exception
    {
        public TreeException() : base() { }
        public TreeException(string msg) : base(msg) { }
    }
}
