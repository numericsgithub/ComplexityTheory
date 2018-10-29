using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    public static class Extensions
    {
        public static Node GetNeighbour(this List<Node> nodes, int name)
        {
            return nodes.First(n => n.Name == name);
        }

        public static List<Node> Clone(this List<Node> nodes)
        {
            List<Node> clone = new List<Node>();
            foreach (var item in nodes)
            {
                clone.Add(item.Clone());
            }
            return clone;
        }

        public static void Add(this List<Node> nodes, int from, int to)
        {
            nodes.GetNeighbour(from).Neighbours.Add(to);
        }
    }
}
