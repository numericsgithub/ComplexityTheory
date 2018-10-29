using GraphPlotter;
using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> all = new List<Item>();
            for (int i = 0; i < 15; i++)
            {
                all.Add(new Item(i + 1));
            }
            List<SubSet> subSets = new List<SubSet>();
            subSets.Add(new SubSet(all.Where(n => n.Name < 4).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 10).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 5 && n.Name < 10).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 11 && n.Name < 17).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 13 && n.Name < 14).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 2 && n.Name < 7).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 0 && n.Name < 3).ToList()));
            subSets.Add(new SubSet(all.Where(n => n.Name >= 4 && n.Name < 8).ToList()));
            SetCover cover = new SetCover();
            List<IGraphNode> graphNodes = new List<IGraphNode>();
            graphNodes.Add(cover);
            graphNodes.AddRange(all);
            graphNodes.AddRange(subSets);
            while (PickItBitch(cover, subSets, all))
            {
            }
            GraphPlotter.GraphPlott.PlottToFile(graphNodes, "asd.jpg", 1500, true);
        }

        static bool PickItBitch(SetCover cover, List<SubSet> subsets, List<Item> all)
        {
            List<Item> diff = all.Where(n => !cover.Items.Contains(n)).ToList();
            if (diff.Count == 0)
                return false;
            List<SubSet> ubrig = subsets.Where(s => !cover.Sets.Contains(s)).ToList();
            SubSet best = ubrig.First();
            int bestCoverCount = 0;
            foreach (var set in subsets)
            {
                List<Item> covered = diff.Where(n => set.Items.Contains(n)).ToList();
                if (covered.Count > bestCoverCount)
                {
                    best = set;
                    bestCoverCount = covered.Count;
                }
            }
            best.NodeColor = Color.Red;
            cover.Sets.Add(best);
            return true;
        }
    }
}
