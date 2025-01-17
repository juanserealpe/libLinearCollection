using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearCollection.Nodes
{
    public class LinkedNode<T> where T : IComparable<T>
    {
        public T attItem { get; set; }
        public LinkedNode<T> attNextNode { get; set; }

        public LinkedNode(T value)
        {
            attItem = value;
            attNextNode = null;
        }
        public LinkedNode(){}
    }
}
