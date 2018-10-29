using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Glee;
using Microsoft.Glee.Splines;
using P = Microsoft.Glee.Splines.Point;

namespace DrawingFromGleeGraph {
    public partial class Form1 : Form {
        GleeGraph gleeGraph;
        public Form1() {
            InitializeComponent();
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
        }

        void Form1_SizeChanged(object sender, EventArgs e) {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e) {

            base.OnPaint(e);
            if (gleeGraph == null)
                gleeGraph = CreateAndLayoutGraph();

            DrawFromGraph(e.Graphics);
        }

        private void DrawFromGraph(Graphics graphics) {
            SetGraphicsTransform(graphics);
            Pen pen = new Pen(Brushes.Black);
            DrawNodes(pen,graphics);
            DrawEdges(pen,graphics);
        }

        private void SetGraphicsTransform(Graphics graphics) {

            RectangleF r = this.ClientRectangle;
            
            Microsoft.Glee.Splines.Rectangle gr = this.gleeGraph.BoundingBox;
            if (r.Height > 1 && r.Width > 1) {
                float scale = Math.Min(r.Width / (float)gr.Width, r.Height / (float)gr.Height);
                float g0 = (float)(gr.Left + gr.Right) / 2;
                float g1 = (float)(gr.Top + gr.Bottom) / 2;

                float c0 = (r.Left + r.Right) / 2;
                float c1 = (r.Top + r.Bottom) / 2;
                float dx = c0 - scale * g0;
                float dy = c1 + scale * g1;
                graphics.Transform = new System.Drawing.Drawing2D.Matrix(scale, 0, 0, -scale, dx, dy);
            }
        }

        private void DrawEdges( Pen pen, Graphics graphics) {
            foreach (Edge e in gleeGraph.Edges)
                DrawEdge(e, pen, graphics);
        }

        private void DrawEdge(Edge e, Pen pen, Graphics graphics) {
            ICurve curve = e.Curve;
            Curve c = curve as Curve;
            if (c != null) {
                foreach (ICurve s in c.Segs) {
                    LineSeg l = s as LineSeg;
                    if (l != null)
                        graphics.DrawLine(pen, GleePointToDrawingPoint(l.Start), GleePointToDrawingPoint(l.End));
                    CubicBezierSeg cs = s as CubicBezierSeg;
                    if (cs != null)
                        graphics.DrawBezier(pen, GleePointToDrawingPoint(cs.B(0)), GleePointToDrawingPoint(cs.B(1)), GleePointToDrawingPoint(cs.B(2)), GleePointToDrawingPoint(cs.B(3)));

                }
                if (e.ArrowHeadAtSource)
                    DrawArrow(e, pen, graphics, e.Curve.Start, e.ArrowHeadAtSourcePosition);
                if (e.ArrowHeadAtTarget)
                    DrawArrow(e, pen, graphics, e.Curve.End, e.ArrowHeadAtTargetPosition);
            }
        }

        private void DrawArrow(Edge e, Pen pen, Graphics graphics, P start, P end) {
            PointF[] points;
            float arrowAngle = 30;

            P dir = end - start;
            P h = dir;
            dir /= dir.Length;

            P s = new P(-dir.Y, dir.X);

            s *= h.Length * ((float)Math.Tan(arrowAngle * 0.5f * (Math.PI / 180.0)));

            points = new PointF[] { GleePointToDrawingPoint(start + s), GleePointToDrawingPoint(end), GleePointToDrawingPoint(start - s) };

            graphics.FillPolygon(pen.Brush, points);
        }

       
        private void DrawNodes(Pen pen, Graphics graphics) {
            foreach (Node n in gleeGraph.NodeMap.Values)
                DrawNode(n, pen, graphics);
        }

        private void DrawNode(Node n, Pen pen, Graphics graphics) {
            ICurve curve = n.MovedBoundaryCurve;
            Ellipse el = curve as Ellipse;
            if (el != null) {
                graphics.DrawEllipse(pen, new RectangleF((float)el.BBox.Left, (float)el.BBox.Bottom,
                    (float)el.BBox.Width, (float)el.BBox.Height));
            } else {
                Curve c = curve as Curve;
                foreach (ICurve seg in c.Segs) {
                    LineSeg l=seg as LineSeg;
                    if(l!=null)
                        graphics.DrawLine(pen, GleePointToDrawingPoint(l.Start),GleePointToDrawingPoint(l.End));
                }
            }
        }

        private System.Drawing.Point GleePointToDrawingPoint(Microsoft.Glee.Splines.Point point) {
            return new System.Drawing.Point((int)point.X, (int)point.Y);
        }

        private GleeGraph CreateAndLayoutGraph() {
            double w = 30;
            double h = 20;
            GleeGraph graph = new GleeGraph();
            Node a = new Node("a", new Ellipse(w, h, new P()));
            Node b = new Node("b", CurveFactory.CreateBox(w, h, new P()));
            Node c = new Node("c", CurveFactory.CreateBox(w, h, new P()));
            graph.AddNode(a);
            graph.AddNode(b);
            graph.AddNode(c);
            Edge e = new Edge(a, b);
            e.ArrowHeadAtSource = true;
            e.UserData = "ASDasd";
            graph.AddEdge(e);
            graph.AddEdge(new Edge(a,b));
            graph.AddEdge(new Edge(a,c));
            graph.CalculateLayout();
            return graph;
        }
    }
}