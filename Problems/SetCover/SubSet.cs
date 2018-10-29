using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCover
{
    public class SubSet : IGraphNode
    {
        public List<Item> Items;
        public string NodeName
        {
            get
            {
                string s = "";
                foreach (var item in Items)
                {
                    s += "N" + item.NodeName + ",";
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
                foreach (var item in Items)
                {
                    cons.Add(new NodeConnection(item.NodeName));
                }
                return cons;
            }
            set { }
        }
        public Color NodeColor { get; set; }

        public SubSet()
        {
            this.Items = new List<Item>();
            this.NodeColor = Color.White;
        }

        public SubSet(List<Item> items)
        {
            this.Items = items;
            this.NodeColor = Color.White;
        }
    }
}
