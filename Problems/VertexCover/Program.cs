using Microsoft.Glee.Drawing;
using SATSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexCover
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node d = new Node("d");
            nodes.Add(a);
            nodes.Add(b);
            nodes.Add(c);
            //nodes.Add(d);

            a.AddNeighbour(b);
            a.AddNeighbour(c);


            //c.AddNeighbour(d);
            //Random rand = new Random();
            //for (int i = 0; i < 12; i++)
            //{
            //    nodes.Add(new Node((i + 1) + ""));
            //}
            //for (int i = 0; i < 20; i++)
            //{
            //    List<Node> forcon = nodes.Where(n => n.Neighbours.Count < 11).ToList();
            //    if (forcon.Count < 2)
            //        break;
            //    Node a = forcon[rand.Next(0, forcon.Count)];
            //    forcon = forcon.Where(n => n != a).ToList();
            //    Node b = forcon[rand.Next(0, forcon.Count)];
            //    a.AddNeighbour(b);
            //}
            //GraphPlotter.GraphPlott.PlottToFile(nodes, "asd.jpg", 1000, true);
            List<Node> choosen = new List<Node>();
            while(true)
            {
                Node newnode = PickVertex(nodes, choosen);
                if (newnode == null)
                    break;
            }
            foreach (var item in choosen)
            {
                item.NodeColor = Color.Red;
            }

            GraphPlotter.GraphPlott.PlottToFile(nodes, "asd.jpg", 1000, true);
        }

        static Node PickVertex(List<Node> nodes, List<Node> choosen)
        {
            List<Node> allchoosenNeighbours = new List<Node>();
            foreach (var item in choosen)
            {
                allchoosenNeighbours.Add(item);
                allchoosenNeighbours.AddRange(item.Neighbours);
            }
            List<Node> uncovered = nodes.Where(n => !allchoosenNeighbours.Contains(n)).ToList();
            if (uncovered.Count == 0)
                return null;
            // Pick a Vertex
            int maxNeighbours = 0;
            Node current = nodes.First();
            foreach (var item in uncovered)
            {
                if(item.Neighbours.Count > maxNeighbours)
                {
                    current = item;
                    maxNeighbours = item.Neighbours.Count;
                }
            }

            choosen.Add(current);
            return current;
        }
    }
}
