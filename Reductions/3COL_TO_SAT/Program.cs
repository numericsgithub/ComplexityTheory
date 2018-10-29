using _3COL;
using Microsoft.Glee.Drawing;
using SATSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3COL_TO_SAT
{
    class Program
    {
        static List<Variable> curVariables;
        static readonly CColor[] colors = new CColor[] { new CColor("1",Color.Red), new CColor("2", Color.Blue), new CColor("3", Color.Violet), new CColor("4", Color.Yellow) };
        static List<Tuple<_3COL.Node, _3COL.Node>> connections = new List<Tuple<_3COL.Node, _3COL.Node>>();
        static List<_3COL.Node> nodes = new List<_3COL.Node>();
        static Random rand = new Random();

        class CColor
        {
            public Color Color;
            public string name;
            public CColor(string name, Color color)
            {
                this.name = name;
                this.Color = color;
            }

            public override string ToString()
            {
                return name;
            }
        }

        //static bool _1X0_0 = false; // FALSE
        static bool _2X0_0 = false;
        //static bool _3X0_0 = false; // FALSE
        //static bool _4X0_0 = false; // FALSE
        static bool _1X0_1 = true; // TRUE
        //static bool _2X0_1 = false; // FALSE
        //static bool _3X0_1 = false; // FALSE
        //static bool _4X0_1 = false; // FALSE
        //static bool _1X0_2 = false; // FALSE
        //static bool _2X0_2 = false; // FALSE
        static bool _3X0_2 = false;
        static bool _4X0_2 = false;
        //static bool _1X0_3 = false; // FALSE
        //static bool _2X0_3 = false; // FALSE
        static bool _3X0_3 = false;
        static bool _4X0_3 = false;
        static bool _1X1_0 = false;
        //static bool _2X1_0 = false; // FALSE
        static bool _3X1_0 = false;
        static bool _4X1_0 = false;
        //static bool _1X1_1 = false; // FALSE
        //static bool _2X1_1 = false; // FALSE
        static bool _3X1_1 = false;
        static bool _4X1_1 = false;
        static bool _1X1_2 = false;
        static bool _2X1_2 = false;
        static bool _3X1_2 = false;
        static bool _4X1_2 = false;
        static bool _1X1_3 = false;
        static bool _2X1_3 = false;
        static bool _3X1_3 = false;
        static bool _4X1_3 = false;
        static bool _1X2_0 = false;
        //static bool _2X2_0 = false; // FALSE
        static bool _3X2_0 = false;
        static bool _4X2_0 = false;
        static bool _1X2_1 = false;
        static bool _2X2_1 = true; // TRUE
        static bool _3X2_1 = false;
        static bool _4X2_1 = false;
        static bool _1X2_2 = false;
        //static bool _2X2_2 = false; // FALSE
        static bool _3X2_2 = false;
        //static bool _4X2_2 = false; // FALSE
        static bool _1X2_3 = false;
        //static bool _2X2_3 = false; // FALSE
        static bool _3X2_3 = false;
        //static bool _4X2_3 = false; // FALSE
        static bool _1X3_0 = false;
        //static bool _2X3_0 = false; // FALSE
        static bool _3X3_0 = false;
        //static bool _4X3_0 = false; // FALSE
        static bool _1X3_1 = false;
        static bool _2X3_1 = false;
        static bool _3X3_1 = false;
        //static bool _4X3_1 = false; // FALSE
        static bool _1X3_2 = false;
        static bool _2X3_2 = false;
        static bool _3X3_2 = false;
        static bool _4X3_2 = true; // TRUE
        static bool _1X3_3 = false;
        static bool _2X3_3 = false;
        static bool _3X3_3 = false;
        //static bool _4X3_3 = false; // FALSE
        static readonly bool[] CurVariables = new bool[] { /*_2X0_0, _1X0_1*/
/*, _2X0_1,*//* _3X0_1, _4X0_1, _1X0_2*/
 /*,_2X0_2,*/ _3X0_2, _4X0_2 /*,_1X0_3*/
, /*_2X0_3,*/ _3X0_3, _4X0_3, _1X1_0
, /*_2X1_0,*/ _3X1_0, _4X1_0 /*,_1X1_1*/
, /*_2X1_1,*/ _3X1_1, _4X1_1, _1X1_2
, _2X1_2, _3X1_2, _4X1_2, _1X1_3
, _2X1_3, _3X1_3, _4X1_3, _1X2_0
, /*_2X2_0,*/ _3X2_0, _4X2_0, _1X2_1
, /*_2X2_1,*/ _3X2_1, _4X2_1, _1X2_2
, /*_2X2_2,*/ _3X2_2/*, _4X2_2*/, _1X2_3
, /*_2X2_3,*/ _3X2_3/*, _4X2_3*/, _1X3_0
, /*_2X3_0,*/ _3X3_0, /*_4X3_0,*/ _1X3_1
, _2X3_1, _3X3_1, /*_4X3_1,*/ _1X3_2
, _2X3_2, _3X3_2, /*_4X3_2,*/ _1X3_3
, _2X3_3, _3X3_3/*, _4X3_3*/};

        static void Main(string[] args)
        {
            string varstr = "";
            for (int column = 0; column < 4; column++)
            {
                for (int row = 0; row < 4; row++)
                {
                    varstr += "X" + column + "_" + row+ ", ";
                    nodes.Add(new _3COL.Node(column + "," + row));
                }
                varstr += "\r\n";
            }


            bool result = ((_3X0_2 || _4X0_2) && (_3X0_3 || _4X0_3) && (_1X1_0 || _3X1_0 || _4X1_0) &&
            (_3X1_1 || _4X1_1) && (_1X1_2 || _2X1_2 || _3X1_2 || _4X1_2) && (_1X1_3 || _2X1_3 || _3X1_3 || _4X1_3) &&
            (_1X2_0 || _3X2_0 || _4X2_0) && (_1X2_1 || _3X2_1 || _4X2_1) &&
            (_1X2_2 || _3X2_2) && (_1X2_3 || _3X2_3) &&
            (_1X3_0 || _3X3_0) && (_1X3_1 || _2X3_1 || _3X3_1) &&
            (_1X3_2 || _2X3_2 || _3X3_2 || true) && (_1X3_3 || _2X3_3 || _3X3_3) &&
            !(_3X0_2 && _4X0_2) && !(_4X0_2 && _3X0_2) && !(_3X0_3 && _4X0_3) &&
            !(_4X0_3 && _3X0_3) && !(_1X1_0 && _3X1_0) &&
            !(_1X1_0 && _4X1_0) && !(_3X1_0 && _1X1_0) &&
            !(_3X1_0 && _4X1_0) && !(_4X1_0 && _1X1_0) && !(_4X1_0 && _3X1_0) &&
            !(_3X1_1 && _4X1_1) && !(_4X1_1 && _3X1_1) && !(_1X1_2 && _2X1_2) && !(_1X1_2 && _3X1_2) && !(_1X1_2 && _4X1_2) &&
            !(_2X1_2 && _1X1_2) && !(_2X1_2 && _3X1_2) && !(_2X1_2 && _4X1_2) && !(_3X1_2 && _1X1_2) && !(_3X1_2 && _2X1_2) &&
            !(_3X1_2 && _4X1_2) && !(_4X1_2 && _1X1_2) && !(_4X1_2 && _2X1_2) && !(_4X1_2 && _3X1_2) && !(_1X1_3 && _2X1_3) &&
            !(_1X1_3 && _3X1_3) && !(_1X1_3 && _4X1_3) && !(_2X1_3 && _1X1_3) && !(_2X1_3 && _3X1_3) && !(_2X1_3 && _4X1_3) &&
            !(_3X1_3 && _1X1_3) && !(_3X1_3 && _2X1_3) && !(_3X1_3 && _4X1_3) && !(_4X1_3 && _1X1_3) && !(_4X1_3 && _2X1_3) &&
            !(_4X1_3 && _3X1_3) && !(_1X2_0 && _3X2_0) && !(_1X2_0 && _4X2_0) &&
            !(_3X2_0 && _1X2_0) && !(_3X2_0 && _4X2_0) &&
            !(_4X2_0 && _1X2_0) && !(_4X2_0 && _3X2_0) && !(_1X2_1 && true) && !(_1X2_1 && _3X2_1) &&
            !(_1X2_1 && _4X2_1) && !(true && _1X2_1) && !(true && _3X2_1) && !(true && _4X2_1) && !(_3X2_1 && _1X2_1) &&
            !(_3X2_1 && true) && !(_3X2_1 && _4X2_1) && !(_4X2_1 && _1X2_1) && !(_4X2_1 && true) && !(_4X2_1 && _3X2_1) &&
            !(_1X2_2 && _3X2_2) 
            && !(_3X2_2 && _1X2_2) && !(_1X2_3 && _3X2_3) && !(_3X2_3 && _1X2_3) &&
            !(_1X3_0 && _3X3_0) &&
            !(_3X3_0 && _1X3_0) && !(_1X3_1 && _2X3_1) && !(_1X3_1 && _3X3_1) && !(_2X3_1 && _1X3_1) &&
            !(_2X3_1 && _3X3_1) && !(_3X3_1 && _1X3_1) && !(_3X3_1 && _2X3_1) &&
            !(_1X3_2 && _2X3_2) && !(_1X3_2 && _3X3_2) &&
            (_1X3_2 && true) && !(_2X3_2 && _1X3_2) && !(_2X3_2 && _3X3_2) && !(_2X3_2 && true) && !(_3X3_2 && _1X3_2) &&
            !(_3X3_2 && _2X3_2) && !(_3X3_2 && true) && !(true && _1X3_2) && !(true && _2X3_2) && !(true && _3X3_2) &&
            !(_1X3_3 && _2X3_3) && !(_1X3_3 && _3X3_3) && !(_2X3_3 && _1X3_3) && !(_2X3_3 && _3X3_3) &&
            !(_3X3_3 && _1X3_3) && !(_3X3_3 && _2X3_3));
 
            
            
            #region kram
            //for (int i = 0; i < 4; i++)
            //{
            //    nodes.GetColumn(i).Connect();
            //    nodes.GetRow(i).Connect();
            //}
            //for (int row = 0; row < 2; row++)
            //{
            //    for (int col = 0; col < 2; col++)
            //    {
            //        nodes.GetBox(col*2, row*2).Connect();
            //    }
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    nodes.Add(new _3COL.Node((i + 1).ToString()));
            //}
            //for (int i = 0; i < 15; i++)
            //{
            //    List<_3COL.Node> neededge = nodes.Where(n => n.Neighbours.Count < 3).ToList();
            //    if (neededge.Count < 2)
            //        continue;
            //    _3COL.Node n1 = neededge[rand.Next(0, neededge.Count)];
            //    _3COL.Node n2 = neededge.Where(n => n != n1).ToList()[rand.Next(0, neededge.Count - 1)];
            //    AddNeigbour(n1, n2);
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    List<_3COL.Node> neededge = nodes.Where(n => n.Neighbours.Count < 4).ToList();
            //    if (neededge.Count < 2)
            //        continue;
            //    _3COL.Node n1 = neededge[rand.Next(0, neededge.Count)];
            //    _3COL.Node n2 = neededge.Where(n => n != n1).ToList()[rand.Next(0, neededge.Count - 1)];
            //    AddNeigbour(n1, n2);
            //}
            //GraphPlotter.GraphPlott.PlottToFile(nodes, "asd" + rand.Next() + ".jpg", 1000, true);

            //_3COL.Node node1 = new _3COL.Node("1");
            //_3COL.Node node2 = new _3COL.Node("2");
            //_3COL.Node node3 = new _3COL.Node("3");
            //AddNeigbour(node1, node2);
            //AddNeigbour(node1, node3);
            //AddNeigbour(node2, node3);
            //nodes.Add(node1);
            //nodes.Add(node2);
            //nodes.Add(node3);
            //GraphPlotter.GraphPlott.PlottToFile(nodes, "asd.jpg", 1000, true);
            #endregion

            //SolveForVar(0);
            Expression expr = ToSAT(nodes);

            string s = expr.ToString();
            SATSolver.Program.OnFound += Program_OnFound;
            SATSolver.Program.Solve(expr);
        }

        static int counter = 0;

        static void SolveForVar(int index)
        {
            if (CurVariables.Length - 1 == index)
            {
                if (counter++ % 10000000 == 0)
                    Console.WriteLine(counter / 1000000);
                CurVariables[index] = true;
                bool result = ((_1X0_1) && (_3X0_2 || _4X0_2) && (_3X0_3 || _4X0_3) && (_1X1_0 || _3X1_0 || _4X1_0) &&
            (_3X1_1 || _4X1_1) && (_1X1_2 || _2X1_2 || _3X1_2 || _4X1_2) && (_1X1_3 || _2X1_3 || _3X1_3 || _4X1_3) &&
            (_1X2_0 || _3X2_0 || _4X2_0) && (_1X2_1 || _2X2_1 || _3X2_1 || _4X2_1) &&
            (_1X2_2 || _3X2_2) && (_1X2_3 || _3X2_3) &&
            (_1X3_0 || _3X3_0) && (_1X3_1 || _2X3_1 || _3X3_1) &&
            (_1X3_2 || _2X3_2 || _3X3_2 || true) && (_1X3_3 || _2X3_3 || _3X3_3) &&
            !(_3X0_2 && _4X0_2) && !(_4X0_2 && _3X0_2) && !(_3X0_3 && _4X0_3) &&
            !(_4X0_3 && _3X0_3) && !(_1X1_0 && _3X1_0) &&
            !(_1X1_0 && _4X1_0) && !(_3X1_0 && _1X1_0) &&
            !(_3X1_0 && _4X1_0) && !(_4X1_0 && _1X1_0) && !(_4X1_0 && _3X1_0) &&
            !(_3X1_1 && _4X1_1) && !(_4X1_1 && _3X1_1) && !(_1X1_2 && _2X1_2) && !(_1X1_2 && _3X1_2) && !(_1X1_2 && _4X1_2) &&
            !(_2X1_2 && _1X1_2) && !(_2X1_2 && _3X1_2) && !(_2X1_2 && _4X1_2) && !(_3X1_2 && _1X1_2) && !(_3X1_2 && _2X1_2) &&
            !(_3X1_2 && _4X1_2) && !(_4X1_2 && _1X1_2) && !(_4X1_2 && _2X1_2) && !(_4X1_2 && _3X1_2) && !(_1X1_3 && _2X1_3) &&
            !(_1X1_3 && _3X1_3) && !(_1X1_3 && _4X1_3) && !(_2X1_3 && _1X1_3) && !(_2X1_3 && _3X1_3) && !(_2X1_3 && _4X1_3) &&
            !(_3X1_3 && _1X1_3) && !(_3X1_3 && _2X1_3) && !(_3X1_3 && _4X1_3) && !(_4X1_3 && _1X1_3) && !(_4X1_3 && _2X1_3) &&
            !(_4X1_3 && _3X1_3) && !(_1X2_0 && _3X2_0) && !(_1X2_0 && _4X2_0) &&
            !(_3X2_0 && _1X2_0) && !(_3X2_0 && _4X2_0) &&
            !(_4X2_0 && _1X2_0) && !(_4X2_0 && _3X2_0) && !(_1X2_1 && _2X2_1) && !(_1X2_1 && _3X2_1) &&
            !(_1X2_1 && _4X2_1) && !(_2X2_1 && _1X2_1) && !(_2X2_1 && _3X2_1) && !(_2X2_1 && _4X2_1) && !(_3X2_1 && _1X2_1) &&
            !(_3X2_1 && _2X2_1) && !(_3X2_1 && _4X2_1) && !(_4X2_1 && _1X2_1) && !(_4X2_1 && _2X2_1) && !(_4X2_1 && _3X2_1) &&
            !(_1X2_2 && _3X2_2)
            && !(_3X2_2 && _1X2_2) && !(_1X2_3 && _3X2_3) && !(_3X2_3 && _1X2_3) &&
            !(_1X3_0 && _3X3_0) &&
            !(_3X3_0 && _1X3_0) && !(_1X3_1 && _2X3_1) && !(_1X3_1 && _3X3_1) && !(_2X3_1 && _1X3_1) &&
            !(_2X3_1 && _3X3_1) && !(_3X3_1 && _1X3_1) && !(_3X3_1 && _2X3_1) &&
            !(_1X3_2 && _2X3_2) && !(_1X3_2 && _3X3_2) &&
            (_1X3_2 && true) && !(_2X3_2 && _1X3_2) && !(_2X3_2 && _3X3_2) && !(_2X3_2 && true) && !(_3X3_2 && _1X3_2) &&
            !(_3X3_2 && _2X3_2) && !(_3X3_2 && true) && !(true && _1X3_2) && !(true && _2X3_2) && !(true && _3X3_2) &&
            !(_1X3_3 && _2X3_3) && !(_1X3_3 && _3X3_3) && !(_2X3_3 && _1X3_3) && !(_2X3_3 && _3X3_3) &&
            !(_3X3_3 && _1X3_3) && !(_3X3_3 && _2X3_3));
            if (result)
                {
                    Console.WriteLine("asd");
                    Console.ReadLine();
                    //CurResult.Add(CurVariables.GetSet());
                    //if (OnFound != null)
                    //    OnFound(CurVariables);
                }
                CurVariables[index] = false;
               result = ((_1X0_1) && (_3X0_2 || _4X0_2) && (_3X0_3 || _4X0_3) && (_1X1_0 || _3X1_0 || _4X1_0) &&
            (_3X1_1 || _4X1_1) && (_1X1_2 || _2X1_2 || _3X1_2 || _4X1_2) && (_1X1_3 || _2X1_3 || _3X1_3 || _4X1_3) &&
            (_1X2_0 || _3X2_0 || _4X2_0) && (_1X2_1 || _2X2_1 || _3X2_1 || _4X2_1) &&
            (_1X2_2 || _3X2_2) && (_1X2_3 || _3X2_3) &&
            (_1X3_0 || _3X3_0) && (_1X3_1 || _2X3_1 || _3X3_1) &&
            (_1X3_2 || _2X3_2 || _3X3_2 || true) && (_1X3_3 || _2X3_3 || _3X3_3) &&
            !(_3X0_2 && _4X0_2) && !(_4X0_2 && _3X0_2) && !(_3X0_3 && _4X0_3) &&
            !(_4X0_3 && _3X0_3) && !(_1X1_0 && _3X1_0) &&
            !(_1X1_0 && _4X1_0) && !(_3X1_0 && _1X1_0) &&
            !(_3X1_0 && _4X1_0) && !(_4X1_0 && _1X1_0) && !(_4X1_0 && _3X1_0) &&
            !(_3X1_1 && _4X1_1) && !(_4X1_1 && _3X1_1) && !(_1X1_2 && _2X1_2) && !(_1X1_2 && _3X1_2) && !(_1X1_2 && _4X1_2) &&
            !(_2X1_2 && _1X1_2) && !(_2X1_2 && _3X1_2) && !(_2X1_2 && _4X1_2) && !(_3X1_2 && _1X1_2) && !(_3X1_2 && _2X1_2) &&
            !(_3X1_2 && _4X1_2) && !(_4X1_2 && _1X1_2) && !(_4X1_2 && _2X1_2) && !(_4X1_2 && _3X1_2) && !(_1X1_3 && _2X1_3) &&
            !(_1X1_3 && _3X1_3) && !(_1X1_3 && _4X1_3) && !(_2X1_3 && _1X1_3) && !(_2X1_3 && _3X1_3) && !(_2X1_3 && _4X1_3) &&
            !(_3X1_3 && _1X1_3) && !(_3X1_3 && _2X1_3) && !(_3X1_3 && _4X1_3) && !(_4X1_3 && _1X1_3) && !(_4X1_3 && _2X1_3) &&
            !(_4X1_3 && _3X1_3) && !(_1X2_0 && _3X2_0) && !(_1X2_0 && _4X2_0) &&
            !(_3X2_0 && _1X2_0) && !(_3X2_0 && _4X2_0) &&
            !(_4X2_0 && _1X2_0) && !(_4X2_0 && _3X2_0) && !(_1X2_1 && _2X2_1) && !(_1X2_1 && _3X2_1) &&
            !(_1X2_1 && _4X2_1) && !(_2X2_1 && _1X2_1) && !(_2X2_1 && _3X2_1) && !(_2X2_1 && _4X2_1) && !(_3X2_1 && _1X2_1) &&
            !(_3X2_1 && _2X2_1) && !(_3X2_1 && _4X2_1) && !(_4X2_1 && _1X2_1) && !(_4X2_1 && _2X2_1) && !(_4X2_1 && _3X2_1) &&
            !(_1X2_2 && _3X2_2)
            && !(_3X2_2 && _1X2_2) && !(_1X2_3 && _3X2_3) && !(_3X2_3 && _1X2_3) &&
            !(_1X3_0 && _3X3_0) &&
            !(_3X3_0 && _1X3_0) && !(_1X3_1 && _2X3_1) && !(_1X3_1 && _3X3_1) && !(_2X3_1 && _1X3_1) &&
            !(_2X3_1 && _3X3_1) && !(_3X3_1 && _1X3_1) && !(_3X3_1 && _2X3_1) &&
            !(_1X3_2 && _2X3_2) && !(_1X3_2 && _3X3_2) &&
            (_1X3_2 && true) && !(_2X3_2 && _1X3_2) && !(_2X3_2 && _3X3_2) && !(_2X3_2 && true) && !(_3X3_2 && _1X3_2) &&
            !(_3X3_2 && _2X3_2) && !(_3X3_2 && true) && !(true && _1X3_2) && !(true && _2X3_2) && !(true && _3X3_2) &&
            !(_1X3_3 && _2X3_3) && !(_1X3_3 && _3X3_3) && !(_2X3_3 && _1X3_3) && !(_2X3_3 && _3X3_3) &&
            !(_3X3_3 && _1X3_3) && !(_3X3_3 && _2X3_3));
                if (result)
                {
                    Console.WriteLine("asd");
                    Console.ReadLine();
                    //CurResult.Add(CurVariables.GetSet());
                    //if (OnFound != null)
                    //    OnFound(CurVariables);
                }
            }
            else
            {
                CurVariables[index] = true;
                SolveForVar(index + 1);
                CurVariables[index] = false;
                SolveForVar(index + 1);
            }

        }

        private static void Program_OnFound(Variable[] variables)
        {
            foreach (var item in variables)
            {
                if(item.Value)
                {
                    VNode(item.Name).NodeColor = VColor(item.Name);
                }
            }
            GraphPlotter.GraphPlott.PlottToFile(nodes, "asd"+rand.Next()+".jpg", 1000, true);
            System.Threading.Thread.Sleep(1000);
        }

        static _3COL.Node VNode(string name)
        {
            name = name.Substring(name.IndexOf("X") + 1);
            return nodes.Find(v => v.NodeName == name);
        }

        static Color VColor(string name)
        {
            name = name.Substring(0,name.IndexOf("X"));
            return colors.ToList().Find(v => v.name == name).Color;
        }

        static Variable Vari(_3COL.Node node, CColor color)
        {
            string name = color.name + "X" + node.NodeName;
            if(curVariables.FirstOrDefault(v =>v.Name == name) == null)
            {
                Variable variable = new Variable(name);
                curVariables.Add(variable);
            }
            return curVariables.Find(v => v.Name == name);
        }

        static Expression ToSAT(List<_3COL.Node> nodes)
        {
            curVariables = new List<Variable>();
            AndOperator and = null;
            // Jeder Knoten muss mindestens eine Farbe haben
            foreach (var node in nodes)
            {
                OrOperator or = null;
                foreach (var color in colors)
                {
                    if (or == null)
                        or = new OrOperator(Vari(node, color), null);
                    else if (or.Right == null)
                        or.Right = Vari(node, color);
                    else or = new OrOperator(or, Vari(node, color));
                }
                if (and == null)
                    and = new AndOperator(or, null);
                else if (and.Right == null)
                    and.Right = or;
                else and = new AndOperator(and, or);
            }

            // Jeder Knoten darf maximal eine Farbe haben
            foreach (var node in nodes)
            {
                foreach (var c1 in colors)
                {
                    foreach (var c2 in colors)
                    {
                        if (c1 == c2)
                            continue;
                        and = new AndOperator(and, 
                            new NotOperator(
                                new AndOperator(
                                    Vari(node, c1), 
                                    Vari(node, c2))));
                    }
                }
            }

            // Mein Nachbar darf nicht die selbe farbe haben
            foreach (var conn in connections)
            {
                foreach (var c in colors)
                {
                    and = new AndOperator(and,
                        new NotOperator(
                            new AndOperator(
                                Vari(conn.Item1, c),
                                Vari(conn.Item2, c))));
                }
            }
            string s = and.ToString();
            return and;
        }


        static void AddNeigbour(_3COL.Node a, _3COL.Node b)
        {
            if (connections.FirstOrDefault(t => (t.Item1 == a && t.Item2 == b) || (t.Item1 == b && t.Item2 == a)) != null)
                return;
            a.AddNeighbour(b);
            connections.Add(new Tuple<_3COL.Node, _3COL.Node>(a, b));
        }
    }
}
