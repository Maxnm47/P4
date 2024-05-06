using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public abstract class JAstLeafNode<T> : JAstNode
    {
        T Value { get; set; }

        public JAstLeafNode(T value)
        {
            Value = value;
        }
    }
}