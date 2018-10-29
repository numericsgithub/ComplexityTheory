using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GG
{
    public partial class Game : Form
    {
        List<Node> nodelist = new List<Node>();
        Random random;

        public Game()
        {
            InitializeComponent();
            random = new Random();
            nodelist = new List<Node>();
            int nodeCount = random.Next(10, 20);
            for (int i = 0; i < nodeCount; i++)
            {
                nodelist.Add(new Node(i + 1));
            }
        }
    }
}
