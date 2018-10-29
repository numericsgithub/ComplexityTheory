using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCover
{
    public class SetCover : IGraphNode
    {
        public List<Item> Items
        {
            get
            {
                List<Item> items = new List<Item>();
                Sets.ForEach(n => items.AddRange(n.Items));
                return items;
            }
        }

        public List<SubSet> Sets;
        public string NodeName
        {
            get
            {
                string s = "SC";
                foreach (var item in Sets)
                {
                    s += "(" + item.NodeName + "),";
                }
                return s;
            }
            set { }
        }

        public IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> cons = new List<NodeConnection>();
                foreach (var item in Sets)
                {
                    cons.Add(new NodeConnection(item.NodeName));
                }
                return cons;
            }
            set { }
        }
        public Color NodeColor { get; set; }

        public SetCover()
        {
            this.Sets = new List<SubSet>();
            this.NodeColor = Color.White;
        }
    }
}
