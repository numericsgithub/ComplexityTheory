using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsApplication
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

            Microsoft.Glee.Drawing.Graph graph = new
Microsoft.Glee.Drawing.Graph("");
            graph.AddEdge("A", "B");
            graph.AddEdge("A", "B");
            graph.FindNode("A").Attr.Fillcolor =
            Microsoft.Glee.Drawing.Color.Red;
            graph.FindNode("B").Attr.Fillcolor =
            Microsoft.Glee.Drawing.Color.Blue;
            Microsoft.Glee.GraphViewerGdi.GraphRenderer renderer
            = new Microsoft.Glee.GraphViewerGdi.GraphRenderer
            (graph);
            renderer.CalculateLayout();
            int width = 500;
            Bitmap bitmap = new Bitmap(width, (int)(graph.Height *
            (width / graph.Width)), PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            bitmap.Save("test1.png");

            //        //create a form
            //        System.Windows.Forms.Form form = new
            //System.Windows.Forms.Form();
            //        //create a viewer object
            //        Microsoft.Glee.GraphViewerGdi.GViewer viewer
            //= new Microsoft.Glee.GraphViewerGdi.GViewer();
            //        //create a graph object
            //        Microsoft.Glee.Drawing.Graph graph = new
            //Microsoft.Glee.Drawing.Graph("graph");
            //        //create the graph content
            //        graph.AddEdge("A", "B");
            //        graph.AddEdge("B", "C");
            //        graph.AddEdge("A", "C").EdgeAttr.Color =
            //Microsoft.Glee.Drawing.Color.Green;
            //        graph.FindNode("A").Attr.Fillcolor =
            //Microsoft.Glee.Drawing.Color.Magenta;
            //        graph.FindNode("B").Attr.Fillcolor =
            //Microsoft.Glee.Drawing.Color.MistyRose;
            //        Microsoft.Glee.Drawing.Node c =
            //graph.FindNode("C");
            //        c.Attr.Fillcolor =
            //Microsoft.Glee.Drawing.Color.PaleGreen;
            //        c.Attr.Shape =
            //Microsoft.Glee.Drawing.Shape.Diamond;
            //        //bind the graph to the viewer viewer.Graph = graph;
            //        //associate the viewer with the form
            //        form.SuspendLayout();
            //        viewer.Dock =
            //System.Windows.Forms.DockStyle.Fill;
            //        form.Controls.Add(viewer);
            //        form.ResumeLayout();
            //        ///show the form
            //        ///
            //form.ShowDialog();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
  }
}