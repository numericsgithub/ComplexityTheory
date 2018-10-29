using ParseLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubSetSum
{
    public partial class BackForm : Form
    {
        public readonly int[] primes = new int[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997
        };

        public NumberNode root;

        public BackForm()
        {
            InitializeComponent();
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 150; i++)
            {
                int num = primes[rand.Next(1, primes.Length - 80)];
                if (!list.Contains(num))
                    list.Add(num);
            }
            string s = "";
            for (int i = 0; i < list.Count; i++)
            {
                s += list[i];
                if (i + 1 < list.Count)
                    s += ",";
            }
            textBox1.Text = "(" + s + ")";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            calc();
        }

        private void calc()
        {
            StringReader reader = new StringReader(textBox1.Text.Replace(" ", "").Replace("\t", "").Replace("\r", "").Replace("\n", ""));
            List<int> list = reader.ParseIntArray().ToList();
            root = new NumberNode(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                root.Insert(list[i]);
            }
            root.SumToMax(0, (int)numericUpDown1.Value);
            string file = "lolTOURINGBILD" + new Random().Next() + ".jpg";
            GraphPlotter.GraphPlott.PlottToFile(root.GetAll(), file, 1000, false);
            pictureBox1.Image = Image.FromFile(file);
        }

        private void BackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in System.IO.Directory.GetFiles(Environment.CurrentDirectory))
            {
                if (item.Contains("lolTOURINGBILD") && item.EndsWith(".jpg"))
                    try
                    {
                        System.IO.File.Delete(item);
                    }
                    catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 150; i++)
            {
                int num = primes[rand.Next(1, primes.Length - 80)];
                if (!list.Contains(num))
                    list.Add(num);
            }
            string s = "";
            for (int i = 0; i < list.Count; i++)
            {
                s += list[i];
                if (i + 1 < list.Count)
                    s += ",";
            }
            textBox1.Text = "(" + s + ")";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int num = rand.Next(1, 20);
                if (!list.Contains(num))
                    list.Add(num);
            }
            string s = "";
            for (int i = 0; i < list.Count; i++)
            {
                s += list[i];
                if (i + 1 < list.Count)
                    s += ",";
            }
            textBox1.Text = "(" + s + ")";
        }
    }
}
