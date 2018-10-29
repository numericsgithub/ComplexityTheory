using SATSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3COL_TO_SAT
{
    public static class Extensions
    {
        public static List<_3COL.Node> GetColumn(this List<_3COL.Node> list, int index)
        {
            List<_3COL.Node> nodes = new List<_3COL.Node>();
            foreach (var item in list)
            {
                if (item.NodeName.StartsWith(index + ""))
                    nodes.Add(item);
            }
            return nodes;
        }

        public static List<_3COL.Node> GetRow(this List<_3COL.Node> list, int index)
        {
            List<_3COL.Node> nodes = new List<_3COL.Node>();
            foreach (var item in list)
            {
                if (item.NodeName.EndsWith(index + ""))
                    nodes.Add(item);
            }
            return nodes;
        }

        public static List<_3COL.Node> GetBox(this List<_3COL.Node> list, int column, int row)
        {
            string[] names = { (column + "," + row), ((column + 1) + "," + row), (column + "," + (row + 1)), ((column + 1) + "," + (row + 1)) };
            List<_3COL.Node> nodes = new List<_3COL.Node>();
            foreach (var item in list)
            {
                if (names.Contains(item.NodeName))
                    nodes.Add(item);
            }
            return nodes;
        }

        public static void Connect(this List<_3COL.Node> list)
        {
            foreach (var a in list)
            {
                foreach (var b in list)
                {
                    a.AddNeighbour(b);
                }
            }
        }
    }
}
