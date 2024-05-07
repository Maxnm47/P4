using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public abstract class JAstLeafNode<T> : JAstNode
    {
        public T Value { get; set; }

        public JAstLeafNode(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return this.GetType().Name + ": " + Value;
        }

        public override string ToString(string indent)
        {
            return indent + ToString();
        }
    }
}