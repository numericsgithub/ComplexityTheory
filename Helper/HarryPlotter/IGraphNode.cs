using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphPlotter
{
    public interface IGraphNode
    {
        string NodeName { get; set; }
        IEnumerable<NodeConnection> NodeConnectedTo { get; set; }
        Color NodeColor { get; set; }

    }

    public class NodeConnection
    {
        public string TargetNode;
        public string Text;
        public Color Color;
        public EdgeAttr CustomEdgeAttr;

        public NodeConnection(string targetNode, string text = "", EdgeAttr customEdgeAttr = null)
        {
            this.TargetNode = targetNode;
            this.Text = text;
            this.CustomEdgeAttr = customEdgeAttr;
        }
    }
}
