using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexCover
{
    public class Node : IGraphNode
    {
        public List<Node> Neighbours { get; set; }
        public string NodeName { get; set; }
        public List<Node> NeighboursFromOneSide;
        public IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> cons = new List<NodeConnection>();
                for (int i = 0; i < Neighbours.Count; i++)
                {
                    NodeConnection connection = new NodeConnection(Neighbours[i].NodeName);
                    connection.CustomEdgeAttr = new EdgeAttr();
                    connection.CustomEdgeAttr.ArrowHeadAtSource = ArrowStyle.None;
                    connection.CustomEdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;
                    if(this.NodeName.CompareTo(Neighbours[i].NodeName)>0)
                    cons.Add(connection);
                }
                return cons;
            }
            set { }
        }
        public Color NodeColor { get; set; }

        public void AddNeighbour(Node node)
        {
            node.Neighbours.Add(this);
            NeighboursFromOneSide.Add(node);
            this.Neighbours.Add(node);
        }

        public Node(string name)
        {
            Neighbours = new List<Node>();
            NodeName = name;
            NodeColor = Color.White;
            NeighboursFromOneSide = new List<Node>();
        }
    }
}
