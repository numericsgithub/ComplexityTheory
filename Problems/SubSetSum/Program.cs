using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSetSum
{
    class Program
    {
        static void print(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write("{0}, ", item);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            new BackForm().ShowDialog();

            //NumberNode root = new NumberNode(50);
            //root.Insert(40);
            //root.Insert(45);
            //root.Insert(123);
            //root.Insert(20);
            //root.Insert(10);
            //root.Insert(41);
            //root.Insert(220);
            //root.Insert(1);
            //root.Insert(4);
            //Console.WriteLine(root.SumToMax(0, 300));
            //GraphPlotter.GraphPlott.PlottToFile(root.GetAll(), "lol.png", 2000, true);
            //Console.ReadLine();


            //SubSetSum subSet = new SubSetSum();
            //subSet.Set.Add(1);
            //subSet.Set.Add(3);
            //subSet.Set.Add(5);
            //subSet.Set.Add(7);
            //subSet.Set.Add(11);
            //subSet.Set.Add(13);
            //subSet.Set.Add(17);
            //subSet.Set.Add(19);
            //subSet.Set.Add(29);
            //subSet.Set.Add(39);
            //subSet.Set.Add(32);
            //subSet.Set.Add(36);
            //subSet.Set.Add(38);
            //subSet.Set.Add(21);
            //subSet.Set.Add(32);
            //subSet.Set.Add(191);
            //subSet.Set.Add(42);
            //subSet.Set.Add(46);
            //subSet.Set.Add(64);
            //subSet.Set.Add(53);
            //subSet.Set.Add(72);
            //subSet.Set.Add(78);
            //subSet.Set.Add(91);
            //subSet.Set.Add(93);
            //subSet.Set.Add(422);
            //subSet.Set.Add(426);
            //subSet.Set.Add(442);
            //subSet.Set.Add(472);
            //subSet.Set.Add(412);
            //print(subSet.Set);
            //List<int> vs = subSet.FindSubSet(subSet.Set.Sum());
            //print(vs);
            //Console.ReadLine();
        }
    }
}
