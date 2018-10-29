using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCover
{
    public class Item : IGraphNode
    {
        public int Name;
        public string NodeName { get => Name+""; set
            { } }
        public IEnumerable<NodeConnection> NodeConnectedTo { get; set; }
        public Color NodeColor { get; set; }

        public Item(int name)
        {
            this.Name = name;
            NodeColor = Color.White;
            NodeConnectedTo = new List<NodeConnection>();
        }
    }
}
