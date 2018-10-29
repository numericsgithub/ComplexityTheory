using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATSolver
{
    public partial class MainForm : Form
    {
        private string lastfile = "";

        public MainForm()
        {
            InitializeComponent();
            numFontSize.Value = 12;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int cursor = tbInput.SelectionStart;
            tbInput.Text = tbInput.Text
                .Replace("€", LogicParser.CHAR_EXISTS + "")
                .Replace("@", LogicParser.CHAR_FORALL + "")
                .Replace("&", LogicParser.CHAR_AND + "")
                .Replace("|", LogicParser.CHAR_OR + "")
                .Replace("!", LogicParser.CHAR_NOT + "");
            tbInput.SelectionStart = cursor;
            if (cbCalcOnChange.Checked)
                Calc();
        }

        private void bCalc_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private void Calc()
        {
            Expression expr;
            try
            {
                expr = LogicParser.Parse(tbInput.Text);
            }
            catch (Exception ex)
            {
                tbResult.Text = ex.Message + "\r\n" + "\r\n";
                tbResult.Text += ex.StackTrace;
                return;
            }
            //DateTime start = DateTime.Now;
            List<List<string>> results = Program.Solve(expr);
            //tbResult.Text  DateTime.Now.Subtract(start).TotalSeconds + "");
            string fileout = "";
            foreach (var result in results)
            {
                string line = "";
                foreach (var value in result)
                {
                    line += value + ", ";
                }
                fileout += line + "\r\n";
            }
            tbResult.Text = fileout;
            if (cbCreateGraph.Checked)
            {
                try
                {
                    List<Expression> exprs = new List<Expression>();
                    exprs.Add(expr);
                    exprs.AddRange(expr.GetAllExpressions());
                    pictureBox1.Image = null;
                    string filename = "lol" + new Random().Next() + ".png";
                    GraphPlotter.GraphPlott.PlottToFile(exprs, filename, (int)numSize.Value, false);
                    pictureBox1.Image = Image.FromFile(filename);
                    if (System.IO.File.Exists(lastfile))
                        System.IO.File.Delete(lastfile);
                    lastfile = filename;
                }
                catch { }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            if (System.IO.File.Exists(lastfile))
                System.IO.File.Delete(lastfile);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(lastfile) && System.IO.File.Exists(lastfile))
                System.Diagnostics.Process.Start(lastfile);
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            tbInput.Font = new Font("Courer New", (int)numFontSize.Value, FontStyle.Regular);
        }
    }
}
