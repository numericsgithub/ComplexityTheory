
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VertexCover;

namespace VertexCover_TO_SAT
{
    public static class Extensions
    {
        public static void Add(this List<Node> nodes, int name)
        {
            nodes.Add(new Node(name+""));
        }

        public static void Add(this List<Node> nodes, int a, int b)
        {
            Node nodeA = nodes.First(n => n.NodeName == a + "");
            Node nodeB = nodes.First(n => n.NodeName == b + "");
            nodeA.AddNeighbour(nodeB);
        }
    }
}