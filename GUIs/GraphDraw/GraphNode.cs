using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDraw
{
    public class GraphNode : IGraphNode
    {
        public string NodeName { get; set; }
        public List<NodeConnection> Connections { get; set; }
        public Microsoft.Glee.Drawing.Color NodeColor { get; set; }
        public IEnumerable<NodeConnection> NodeConnectedTo { get => Connections; set { } }

        public GraphNode(string name)
        {
            NodeName = name;
            if (String.IsNullOrEmpty(name))
                throw new Exception("Empty Name for Node");
            Connections = new List<NodeConnection>();
        }
    }
}
