using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpStructures.Interfaces
{
    public interface IBalancedTree
    {
        void Balance();
        int GetBalance();
    }
}
