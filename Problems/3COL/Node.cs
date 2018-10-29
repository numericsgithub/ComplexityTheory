﻿using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3COL
{
    public class Node : IGraphNode
    {
        public List<Node> Neighbours { get; set; }
        public string NodeName { get; set; }
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
            if (this.NodeName == node.NodeName)
                return;
            if (node.Neighbours.Select(n => n.NodeName).Contains(this.NodeName))
                return;
            node.Neighbours.Add(this);
            this.Neighbours.Add(node);
        }

        public Node(string name)
        {
            Neighbours = new List<Node>();
            NodeName = name;
            NodeColor = Color.White;
        }
    }
}
