using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphPlotter;
using Microsoft.Glee.Drawing;

namespace _3COL
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = CreateRandomMesh2(3, 18, 0.79f);
            //GraphPlott.PlottToFile(nodes, "lol.png", 1000, true);
            COLIT(nodes);
            GraphPlott.PlottToFile(nodes, "lol2.png", 1000, true);
        }

        static void COLIT(List<Node> nodes)
        {
            Color[] colors = new Color[] { Color.Red, Color.Violet, Color.Green };
            foreach (Node n in nodes)
            {
                foreach (var color in colors)
                {
                    if (n.Neighbours.Count(x => x.NodeColor == color) != 0)
                        continue;
                    n.NodeColor = color;
                }
            }
        }

        static List<Node> CreateRandomMesh(int maxNeighbours, int nodeCount, int maxEdgeCount)
        {
            List<Node> nodes = new List<Node>();
            Random rand = new Random();
            for (int i = 0; i < nodeCount; i++)
                nodes.Add(new Node((i+1)+""));
            for (int i = 0; i < maxEdgeCount; i++)
            {
                Node fromNode = nodes[rand.Next(0, nodes.Count)];
                Node toNode = nodes[rand.Next(0, nodes.Count)];
                if (fromNode.Neighbours.Count >= maxNeighbours || toNode.Neighbours.Count >= maxNeighbours)
                    continue;
                if (fromNode == toNode || fromNode.Neighbours.Contains(toNode))
                    continue;
                fromNode.Neighbours.Add(toNode);
                toNode.Neighbours.Add(fromNode);
            }
            return nodes;
        }

        static List<Node> CreateRandomMesh2(int maxNeighbours, int nodeCount, float edgeFactor)
        {
            List<Node> nodes = new List<Node>();
            Random rand = new Random();
            for (int i = 0; i < nodeCount; i++)
                nodes.Add(new Node((i + 1) + ""));
            if (edgeFactor > 1f)
                edgeFactor = 1f;
            if (edgeFactor < 0f)
                edgeFactor = 0f;
            int egdeCount = (int)(((maxNeighbours * nodeCount) / 2) * edgeFactor);
            int currentEdgeCount = 0;
            while (currentEdgeCount < egdeCount)
            {
                foreach (var fromNode in nodes)
                {
                    if (currentEdgeCount >= egdeCount)
                        break;
                    int tries = rand.Next(1, maxNeighbours - 1);
                    for (int i = 0; i < tries; i++)
                    {
                        if (fromNode.Neighbours.Count >= maxNeighbours)
                            continue;
                        List<Node> toNodes = nodes
                            .Where(n => n != fromNode)
                            .Where(n => n.Neighbours.Count < maxNeighbours)
                            .Where(n => !n.Neighbours.Contains(fromNode)).ToList();
                        if (toNodes.Count == 0)
                            break;
                        Node toNode = toNodes[rand.Next(0, toNodes.Count)];
                        fromNode.Neighbours.Add(toNode);
                        toNode.Neighbours.Add(fromNode);
                        currentEdgeCount++;
                        if (currentEdgeCount >= egdeCount)
                            break;
                    }
                }
            }
            return nodes;
        }
    }
}
