using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    public class Node : IGraphNode
    {
        public int Name { get; set; }
        public List<int> Neighbours { get; set; }
        public string NodeName { get => Name + ""; set { } }
        public IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                foreach (var item in Neighbours)
                {
                    NodeConnection connection = new NodeConnection(item+"");
                    nodes.Add(connection);
                }
                return nodes;
            }
            set
            {
            }
        }
        public Color NodeColor { get; set; }

        public Node()
        {
            Neighbours = new List<int>();
        }

        public Node(int name)
        {
            Neighbours = new List<int>();
            this.Name = name;
        }

        public bool GGSolve(List<Node> nodes)
        {
            if (Neighbours.Count == 0)
                return false;
            List<Node> nodesStrich =
                nodes.Clone();
            this.Neighbours.ForEach(n => nodesStrich.GetNeighbour(n).NodeColor = Color.Red);
            nodesStrich.GetNeighbour(Name).NodeColor = Color.Violet;
            nodesStrich.ForEach(n => n.Neighbours.Remove(Name));
            //GraphPlott.PlottToFile(nodesStrich, "asd.jpg", 500, true);
            //Console.ReadLine();
            nodesStrich = nodesStrich.Where(n => n.Name != this.Name).ToList();
            List<bool> result = new List<bool>();
            foreach (var name in Neighbours)
            {
                Node neighbour = nodesStrich.GetNeighbour(name);
                result.Add(neighbour.GGSolve(nodesStrich.Clone()));
            }
            if (result.Where(r => !r).Count() == 0) // If all accept
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj is Node)
                return ((Node)(obj)).Name == Name;
            return base.Equals(Name);
        }

        public static bool operator ==(Node obj1, Node obj2)
        {
            if ((Object)obj1 == null && (Object)obj2 == null)
                return true;
            if ((Object)obj1 == null || (Object)obj2 == null)
                return false;
            return obj1.Name == obj2.Name;
        }

        public static bool operator !=(Node obj1, Node obj2)
        {
            return !(obj1 == obj2);
        }

        public Node Clone()
        {
            Node clone = new Node();
            clone.Name = Name;
            foreach (int item in Neighbours)
            {
                clone.Neighbours.Add(item);
            }
            return clone;
        }

        public override int GetHashCode()
        {
            var hashCode = -516892826;
            hashCode = hashCode * -1521134295 + Name.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Neighbours);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NodeName);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<NodeConnection>>.Default.GetHashCode(NodeConnectedTo);
            hashCode = hashCode * -1521134295 + EqualityComparer<Color>.Default.GetHashCode(NodeColor);
            return hashCode;
        }
    }
}
