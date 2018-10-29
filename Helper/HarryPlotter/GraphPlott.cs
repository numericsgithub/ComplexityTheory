using Microsoft.Glee.Drawing;
using Microsoft.Glee.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace GraphPlotter
{
    public static class GraphPlott
    {
        public static string PlottToFile(IEnumerable<IGraphNode> plottables, string filename, int imgsize = 500, bool open = false)
        {
            Bitmap bitmap = PlottToBitMap(plottables, imgsize);
            bitmap.Save(filename);
            if(open)
                System.Diagnostics.Process.Start(filename);
            return filename;
        }

        public static Bitmap PlottToBitMap(IEnumerable<IGraphNode> plottables, int imgsize = 500)
        {
            Graph graph = new Graph("");

            foreach (var node in plottables)
            {
                if (node.NodeColor != Microsoft.Glee.Drawing.Color.Transparent)
                {
                    Node n = graph.AddNode(node.NodeName);
                    n.Attr.Fillcolor = node.NodeColor;
                }
                foreach (var edge in node.NodeConnectedTo)
                {
                    Edge newedge = graph.AddEdge(node.NodeName, edge.Text, edge.TargetNode);
                    newedge.Attr.Fontsize = 10;
                    if (edge.CustomEdgeAttr != null)
                        newedge.EdgeAttr = edge.CustomEdgeAttr;
                    //if (edge.Color != Microsoft.Glee.Drawing.Color.Transparent)
                    //    newedge.Attr.Color = edge.Color;
                }
            }

            GraphRenderer renderer = new GraphRenderer(graph);
            renderer.CalculateLayout();
            Bitmap bitmap = new Bitmap(imgsize, (int)(graph.Height *
            (imgsize / graph.Width)), PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            return bitmap;
        }
    }
}
