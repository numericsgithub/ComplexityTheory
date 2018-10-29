using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSetSum
{
    public class NumberNode : IGraphNode
    {
        public NumberNode Smaller, Bigger;
        public int Value;

        public int SumToMax(int current, int max)
        {
            if (Bigger != null)
                current += Bigger.SumToMax(0, max - current);
            if (Value <= max - current)
            {
                current += Value;
                NodeColor = Microsoft.Glee.Drawing.Color.Red;
            }
            if (Smaller != null)
                current += Smaller.SumToMax(0, max - current);
            return current;
        }

        //public int SumToMaxInTree(int current, int max)
        //{
        //}


        public List<NumberNode> GetAll()
        {
            List<NumberNode> nodes = new List<NumberNode>();
            nodes.Add(this);
            if (Smaller != null)
                nodes.AddRange(Smaller.GetAll());
            if (Bigger != null)
                nodes.AddRange(Bigger.GetAll());
            return nodes;
        }

        public NumberNode(int value)
        {
            Value = value;
            NodeColor = Microsoft.Glee.Drawing.Color.White;
        }

        public NumberNode(int value, int smaller, int bigger)
            : this(value)
        {
            if (smaller < bigger)
            {
                Smaller = new NumberNode(smaller);
                Bigger = new NumberNode(bigger);
            }
            else
            {
                Smaller = new NumberNode(bigger);
                Bigger = new NumberNode(smaller);
            }
        }

        public string NodeName { get => Value + ""; set { } }
        public IEnumerable<NodeConnection> NodeConnectedTo { get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                if(Smaller != null)
                    nodes.Add( new NodeConnection(Smaller.Value+"", "SMALLER"));
                if (Bigger != null)
                    nodes.Add(new NodeConnection(Bigger.Value+"", "BIGGER"));
                return nodes;
            }
            set { } }
        public Microsoft.Glee.Drawing.Color NodeColor { get; set; }

        public void Insert(int value)
        {
            if(value < Value)
            {
                if (Smaller == null)
                    Smaller = new NumberNode(value);
                else Smaller.Insert(value);
            }
            else
            {
                if (Bigger == null)
                    Bigger = new NumberNode(value);
                else Bigger.Insert(value);
            }
        }
    }
}
