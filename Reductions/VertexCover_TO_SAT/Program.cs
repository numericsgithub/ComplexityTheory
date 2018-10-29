
using SATSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VertexCover;

namespace VertexCover_TO_SAT
{
    class Program
    {
        static List<Node> nodes = new List<Node>();

        static void Main(string[] args)
        {
            nodes = new List<Node>();
            for (int i = 1; i <= 12; i++)
                nodes.Add(i);
            nodes.Add(1, 2);
            nodes.Add(1, 7);
            nodes.Add(1, 11);
            nodes.Add(2, 3);
            nodes.Add(2, 11);
            nodes.Add(3, 4);
            nodes.Add(3, 10);
            nodes.Add(4,5);
            nodes.Add(4,9);
            nodes.Add(5,6);
            nodes.Add(5,9);
            nodes.Add(6,7);
            nodes.Add(6,8);
            nodes.Add(7,8);
            nodes.Add(8,12);
            nodes.Add(9,12);
            nodes.Add(10,12);
            nodes.Add(10,11);
            #region Random Graph
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
            #endregion

            CurVariables = new List<Variable>();
            AndOperator and = null;
            foreach (var first in nodes)
            {
                foreach (var secound in first.NeighboursFromOneSide)
                {
                    OrOperator or = new OrOperator(Vari(first), Vari(secound));
                    if (and == null)
                        and = new AndOperator(or, null);
                    else if (and.Right == null)
                        and.Right = or;
                    else and = new AndOperator(and, or);
                }
            }
            SATSolver.Program.OnFound += Program_OnFound;
            string str = and.ToString();
            SATSolver.Program.Solve(and);
            Console.WriteLine();
            foreach (var item in best)
            {
                Console.Write(item+ ", ");
                nodes.FirstOrDefault(n => n.NodeName == item).NodeColor = Microsoft.Glee.Drawing.Color.Red;
            }
            GraphPlotter.GraphPlott.PlottToFile(nodes, "asd.jpg", 1000, true);
            Console.ReadLine();
        }

        static List<string> best = null;

        private static void Program_OnFound(Variable[] variables)
        {
            nodes.ForEach(n => n.NodeColor = Microsoft.Glee.Drawing.Color.White);
            List<string> current = new List<string>();
            foreach (var item in variables)
            {
                if (item.Value)
                {
                    current.Add(item.Name);
                    Console.Write(item.Name + ", ");
                    //nodes.First(n => n.NodeName == item.Name).NodeColor = Microsoft.Glee.Drawing.Color.Red;
                }
            }
            if (best == null || best.Count > current.Count)
                best = current;
            Console.WriteLine();
            //GraphPlotter.GraphPlott.PlottToFile(nodes, "asd.jpg", 1000, true);
            //Console.ReadLine();
        }

        static List<Variable> CurVariables;

        static Variable Vari(Node node)
        {
            string name = node.NodeName.ToString();
            if (CurVariables.FirstOrDefault(v => v.Name == name) == null)
            {
                Variable variable = new Variable(name);
                CurVariables.Add(variable);
            }
            return CurVariables.Find(v => v.Name == name);
        }
    }
}
