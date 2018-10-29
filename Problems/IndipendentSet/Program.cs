using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndipendentSet
{
    class Program
    {
        static List<Node> AllNodes = new List<Node>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                AllNodes.Add(new Node((i + 1).ToString(), AllNodes));
            }
            Random rand = new Random();
            for (int i = 0; i < 90; i++)
            {
                Node from = AllNodes[rand.Next(0, AllNodes.Count)];
                IEnumerable<Node> restNodes = AllNodes.Where(n => n != from);
                Node to = restNodes.ToList()[rand.Next(0, restNodes.Count())];
                from.AddNeighbour(to);
            }
            //Node a = new Node("a", AllNodes);
            //Node b = new Node("b", AllNodes);
            //Node c = new Node("c", AllNodes);
            //Node d = new Node("d", AllNodes);
            //Node e = new Node("e", AllNodes);
            //AllNodes.Add(a);
            //AllNodes.Add(b);
            //AllNodes.Add(c);
            //AllNodes.Add(d);
            //AllNodes.Add(e);
            //b.AddNeighbour(c);
            //b.AddNeighbour(d);
            //b.AddNeighbour(e);
            //c.AddNeighbour(d);
            //c.AddNeighbour(e);
            //d.AddNeighbour(e);
            //a.AddNeighbour(b);
            //a.AddNeighbour(e);

            //GraphPlotter.GraphPlott.PlottToFile(AllNodes, "asd.jpg", 1000, true);
            //Console.ReadLine();

            //GraphPlotter.GraphPlott.PlottToFile(AllNodes, "asd2.jpg", 1000, true);

            List<Node> founded = FindNext(new List<Node>(), AllNodes, 5);
            foreach (var item in founded)
            {
                item.NodeColor = Microsoft.Glee.Drawing.Color.Red;
            }
            GraphPlotter.GraphPlott.PlottToFile(AllNodes, "a2sd2.jpg", 1000, true);
        }

        static List<Node> FindNext(List<Node> found, List<Node> all, int till)
        {
            if (found.Count >= till)
                return found;
            List<Node> diff = all.Where(n => !found.Contains(n)).ToList();
            foreach (var item in diff)
            {
                if (CheckIndipendence(found, item)) // Check if it also part of the indipendent set
                {
                    List<Node> tryfounds = new List<Node>();
                    foreach (var curFound in found)
                        tryfounds.Add(curFound);
                    tryfounds.Add(item);
                    List<Node> result = FindNext(tryfounds, all, till);
                    if (result.Count >= till)
                        return result;
                }
            }
            return found; // Nothing found
        }

        static bool CheckIndipendence(List<Node> nodes, Node element)
        {
            foreach (var item in nodes)
            {
                if (item.Neighbours.Contains(element))
                    return false;
            }
            return true;
        }

        static void Clique(int k)
        {
            List<Node> copy = new List<Node>();
            foreach (var item in AllNodes)
                copy.Add(item);
            while (AllNodes.Count(node => node.Neighbours.Count < (k - 1)) > 0)
                AllNodes = AllNodes.Where(node => node.Neighbours.Count >= (k - 1)).ToList();
            GraphPlotter.GraphPlott.PlottToFile(AllNodes, "asd.jpg", 1000, true);
            foreach (var item in AllNodes)
            {
                //List<Node> 
            }
        }

        //static bool CheckNeighbours(List<Node> nodes)
        //{

        //}
    }
}
