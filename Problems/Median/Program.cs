using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median
{
    class Program
    {
        static Random random = new Random();
        const int SEARCHFOR = -1;
        const int SAMPLECOUNT = 10;
        const int LISTCOUNT = 40000000;
        static List<int> mainlist = new List<int>();

        static double initTime = 0;
        static double initCount = 0;


        static List<int> GetList()
        {
            DateTime start = DateTime.Now;

            // 1,65 Secs
            //Parallel.For(0, LISTCOUNT, ((x) => mainlist[x] = random.Next()));

            // 0,91 Secs
            for (int i = 0; i < 40000000; i++)
                mainlist[i] = random.Next();

            initTime += DateTime.Now.Subtract(start).TotalSeconds;
            initCount++;
            Console.Title = "Init Time " + initTime + " Avg " + initTime / initCount;
            
            return mainlist;
        }

        static void Perform(string message, Action<List<int>> action)
        {
            double secs = 0;
            for (int i = 0; i < SAMPLECOUNT; i++)
            {
                List<int> mainlist = GetList();
                DateTime start = DateTime.Now;
                action(mainlist);
                secs += DateTime.Now.Subtract(start).TotalSeconds;
            }
            Console.WriteLine(message + secs/SAMPLECOUNT);
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
                mainlist.Add(i+1);

            //// # # # Suchen # # #
            //Perform("LAMBDA Find ", (list) => list.Find(x => x == SEARCHFOR));
            //GC.WaitForFullGCComplete();
            //Perform("LAMBDA FindAll ", (list) => list.FindAll(x => x == SEARCHFOR).Count());
            //GC.WaitForFullGCComplete();
            //Perform("LAMBDA Select ", (list) => list.Select(x => x == SEARCHFOR).Count());
            //GC.WaitForFullGCComplete();
            //Perform("LAMBDA FirstOrDefault ", (list) => list.FirstOrDefault(x => x == SEARCHFOR));
            //GC.WaitForFullGCComplete();
            //Perform("LAMBDA Where ", (list) => list.Where(x => x == SEARCHFOR).Count());
            //GC.WaitForFullGCComplete();
            //Perform("for ", (list) => {
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        if (list[i] == SEARCHFOR)
            //        {
            //            Console.Title = list[i] + "";
            //            break;
            //        }
            //    }
            //});
            //GC.WaitForFullGCComplete();
            //Perform("foreach ", (list) => {
            //    foreach (var item in list)
            //    {
            //        if (item == SEARCHFOR)
            //            break;
            //    }
            //});
            //GC.WaitForFullGCComplete();
            //Perform("from where ", (list) => {
            //    var res = (from num in list
            //              where num < 5
            //              select num).Count();
            //});
            //GC.WaitForFullGCComplete();
            //Console.ReadLine();






            // Searching in an unsorted List 
            // for a specified Value
            // - - - - - - - - - - - - - - - - - - - - - - -
            // for            0,06450369 Secounds
            // foreach        0,14420825 Secounds
            // LAMBDA Find    0,15540891 Secounds
            // LAMBDA FindAll 0,16720955 Secounds
            // LAMBDA Where   0,24051375 Secounds
            // from where     0,27161553 Secounds
            // LAMBDA Select  0,48422771 Secounds
            // LAMBDA FirstOD 0,53993087 Secounds






            // Check with Sort and n/2
            int realMean = 0;
            {
                List<int> copy = new List<int>();
                foreach (var item in mainlist)
                    copy.Add(item);
                copy.Sort();
                realMean = copy[copy.Count / 2];
            }
            Console.WriteLine("The Mean is " + realMean);

            int k = mainlist.Count / 2;

            {
                DateTime start = DateTime.Now;
                Console.WriteLine("the NON => calculated one is " + FindKthElement(k, mainlist) + " " + DateTime.Now.Subtract(start).TotalSeconds);
            }
            {
                DateTime start = DateTime.Now;
                Console.WriteLine("the SUPER => calculated one is " + FindKthElement2(k, mainlist) + " " + DateTime.Now.Subtract(start).TotalSeconds);
            }
            {
                SynchronizedCollection<int> coll = new SynchronizedCollection<int>();
                foreach (var item in mainlist)
                {
                    coll.Add(item);
                }
                DateTime start = DateTime.Now;
                Console.WriteLine("the PARALELL => calculated one is " + FindKthElementPara(k, coll) + " " + DateTime.Now.Subtract(start).TotalSeconds);
            }
            Console.ReadLine();
        }

        private static int FindKthElement2(int k, List<int> list)
        {
            // 1) Pick Random Value
            int x = list[random.Next(0, list.Count)];

            // 2) Count all that are <= x
            int m = 0;
            m = list.Where(num => num <= x).Count();

            if (m == k)
            {
                return x;
            }
            else if (m > k)
            {
                List<int> sublist = list.Where(num => num <= x).ToList();
                if(sublist.Count() == list.Count())
                    return x;
                return FindKthElement2(k, sublist);
            }
            else 
            {
                List<int> sublist = list.Where(num => num > x).ToList();
                if(sublist.Count() == list.Count())
                    return x;
                return FindKthElement2(k - m, sublist);
            }
        }

        private static int FindKthElement(int k, List<int> list)
        {
            // 1) Pick Random Value
            int x = list[random.Next(0, list.Count)];

            // 2) Count all that are <= x
            int m = 0;
            foreach (var item in list)
                if (item <= x)
                    m++;

            if (m == k)
            {
                return x;
            }
            else if (m > k)
            {
                List<int> sublist = new List<int>();
                foreach (var item in list)
                {
                    // sublist so that ai <= x
                    if (item <= x)
                        sublist.Add(item);
                }
                if (sublist.Count == list.Count)
                    return x;
                return FindKthElement(k, sublist);
            }
            else //if (m < k)
            {
                List<int> sublist = new List<int>();
                foreach (var item in list)
                {
                    // sublist so that ai > x
                    if (item > x)
                        sublist.Add(item);
                }
                if (sublist.Count == list.Count)
                    return x;
                return FindKthElement(k - m, sublist);
            }
        }

        private static int FindKthElementPara(int k, SynchronizedCollection<int> list)
        {
            // 1) Pick Random Value
            int x = list[random.Next(0, list.Count)];

            // 2) Count all that are <= x
            int m = 0;
            //foreach (var item in list)
            //    if (item <= x)
            //        m++;
            Parallel.ForEach<int>(list, (num) => { if (num <= x) m++; });

            if (m == k)
            {
                return x;
            }
            else if (m > k)
            {
                SynchronizedCollection<int> sublist = new SynchronizedCollection<int>();
                //foreach (var item in list)
                //{
                //    // sublist so that ai <= x
                //    if (item <= x)
                //        sublist.Add(item);
                //}
                Parallel.ForEach<int>(list, (num) => { if (num <= x) sublist.Add(num); });

                if (sublist.Count == list.Count)
                    return x;
                return FindKthElementPara(k, sublist);
            }
            else //if (m < k)
            {
                SynchronizedCollection<int> sublist = new SynchronizedCollection<int>();
                //foreach (var item in list)
                //{
                //    // sublist so that ai > x
                //    if (item > x)
                //        sublist.Add(item);
                //}
                Parallel.ForEach<int>(list, (num) => { if (num > x) sublist.Add(num); });
                if (sublist.Count == list.Count)
                    return x;
                return FindKthElementPara(k - m, sublist);
            }
        }
    }
}
