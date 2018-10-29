using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GG
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();
            //nodes.Add(new Node(1));
            //nodes.Add(new Node(2));
            //nodes.Add(new Node(3));
            //nodes.Add(new Node(4));
            //nodes.Add(new Node(5));
            //nodes.Add(new Node(6));
            //nodes.Add(new Node(7));

            //nodes.Add(1, 2);
            //nodes.Add(1, 3);
            //nodes.Add(2, 5);
            //nodes.Add(2, 4);
            //nodes.Add(3, 2);
            //nodes.Add(4, 3);
            //nodes.Add(4, 6);
            //nodes.Add(5, 4);
            //nodes.Add(6, 7);

            nodes.Add(new Node(1));
            nodes.Add(new Node(2));
            nodes.Add(new Node(3));
            nodes.Add(new Node(4));
            nodes.Add(new Node(5));
            nodes.Add(new Node(6));
            nodes.Add(new Node(7));

            nodes.Add(1, 2);
            nodes.Add(2, 3);
            nodes.Add(3, 4);
            nodes.Add(4, 5);
            nodes.Add(4, 6);
            nodes.Add(6, 7);

            //List<Node> nodes = new List<Node>();
            //nodes.Add(new Node(1));
            //nodes.Add(new Node(2));
            //nodes.Add(new Node(3));
            //nodes.Add(1, 2);
            //nodes.Add(1, 3);
            //nodes.Add(2, 1);

            //bool asd = nodes.GetNeighbour(1).GGSolve(nodes);
            //GraphPlott.PlottToFile(nodes, "asd.jpg", 500, true);
            foreach (var item in nodes)
            {
                bool asd = item.GGSolve(nodes);
                item.NodeColor = asd ? Color.Green : Color.Red;
            }
            GraphPlott.PlottToFile(nodes, "asd.jpg", 500, true);
        }
    }
}
