using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITest
{
    public class Node
    {
        private double weight = 1;
        private double val = 1;
        public double Weight { get { return weight; } set { weight = value; } }
        public double Value { get { return val; } }
        public Node[] Next;

        public Node(double v, Node[]? next = null)
        {
            weight = v;
            Next = next == null ? Array.Empty<Node>() : next;
        }

        public void Process(double inp)
        {
            val = inp * weight;
            foreach (var node in Next)
            {
                node.Process(val);
            }
        }
    }
}
