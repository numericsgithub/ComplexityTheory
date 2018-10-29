using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateGraph();
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            try
            {
                List<GraphNode> nodes = GraphParser.ParseGraphString(tbInput.Text);
                Bitmap bitmap = GraphPlotter.GraphPlott.PlottToBitMap(nodes, (int)numImageSize.Value);
                pictureBox1.Image = bitmap;
                tbError.Text = "Created " + nodes.Count + " Nodes";
            }
            catch (Exception ex)
            {
                tbError.Text = ex.Message;
                tbError.Select(0, 0);
            }
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            tbInput.Font = new Font("Courer New", (float)numFontSize.Value, FontStyle.Regular);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                try
                {
                    List<GraphNode> nodes = GraphParser.ParseGraphString(tbInput.Text);
                    GraphPlotter.GraphPlott.PlottToFile(nodes, filename, (int)numImageSize.Value, false);
                    tbError.Text = "Created " + nodes.Count + " Nodes";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
