using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clique
{
    public class Node : IGraphNode
    {
        private List<string> refs = new List<string>();
        public List<Node> AllNodes;
        public List<Node> Neighbours
        {
            get
            {
                List<Node> neighs = new List<Node>();
                foreach (var item in refs)
                {
                    Node node = AllNodes.FirstOrDefault(n => n.NodeName == item);
                    if (node != null)
                        neighs.Add(node);
                }
                return neighs;
            }
        }
        public string NodeName { get; set; }
        //public List<Node> NeighboursFromOneSide;
        public IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> cons = new List<NodeConnection>();
                List<Node> neighs = Neighbours;
                for (int i = 0; i < neighs.Count; i++)
                {
                    NodeConnection connection = new NodeConnection(neighs[i].NodeName);
                    connection.CustomEdgeAttr = new EdgeAttr();
                    connection.CustomEdgeAttr.ArrowHeadAtSource = ArrowStyle.None;
                    connection.CustomEdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;
                    if (NodeColor == Color.Red)
                        connection.CustomEdgeAttr.Color = NodeColor;
                    else connection.CustomEdgeAttr.Color = new Color(200, 200, 200);
                    if(this.NodeName.CompareTo(neighs[i].NodeName)<=0)
                        cons.Add(connection);
                }
                return cons;
            }
            set { }
        }
        public Color NodeColor { get; set; }

        public void AddNeighbour(Node node)
        {
            refs.Add(node.NodeName);
            node.refs.Add(this.NodeName);
        }

        public Node(string name, List<Node> allNodes)
        {
            this.AllNodes = allNodes;
            NodeName = name;
            NodeColor = Color.White;
            refs = new List<string>();
        }

        public void Inverse()
        {
            List<Node> notNeighbours = this.AllNodes.Where(n => !Neighbours.Contains(n)).ToList();
            refs.Clear();
            foreach (var nei in notNeighbours)
            {
                if (nei != this)
                    refs.Add(nei.NodeName);
            }
        }

        public override string ToString()
        {
            return NodeName;
        }
    }
}
