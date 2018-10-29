using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianDeluxe
{
    class Program
    {
        static readonly Random rand = new Random();
        static readonly int[] ALL_N = new int[] {
            (int)Math.Pow(2, 4), (int)Math.Pow(2, 8),
            (int)Math.Pow(2, 12), (int)Math.Pow(2, 16),
            (int)Math.Pow(2, 20), (int)Math.Pow(2, 24),
            (int)Math.Pow(2, 28) };

        static void Main(string[] args)
        {
            #region TEST DOKUMENTATION
            string str = "";
            for (int nIndex = 1; nIndex < 5; nIndex++)
            {
                for (int testIndex = 0; testIndex < 5; testIndex++)
                {
                    int n = ALL_N[nIndex];
                    List<int> A = new List<int>();
                    for (int i = 0; i < n; i++)
                    {
                        int newzahl = rand.Next();
                        A.Add(newzahl);
                    }
                    int failes = 0;
                    int gmed;
                    DateTime time = DateTime.Now;
                    while (true)
                    {
                        try
                        {
                            gmed = MedianDeluxe(A, n);
                            Console.WriteLine("Geschäzter Median: " + gmed);
                            break;
                        }
                        catch
                        {
                            failes++;
                        }
                    }
                    TimeSpan timeSpan = DateTime.Now.Subtract(time);

                    List<int> controlList = new List<int>();
                    A.ForEach(a => controlList.Add(a));
                    time = DateTime.Now;
                    controlList.Sort();
                    TimeSpan conTime = DateTime.Now.Subtract(time);
                    int controllMedian = controlList[controlList.Count / 2];
                    string curstr = n + "\t" + controllMedian + "\t" + gmed + "\t"
                        + failes + "\t" + timeSpan.TotalMilliseconds + "\t" + timeSpan.Ticks + "\t"
                        + conTime.TotalMilliseconds + "\t" + conTime.Ticks + "\t";
                    Console.WriteLine(curstr);
                    str += curstr + "\r\n";
                }
            }
            /* # # # TEST DOKU # # # 
             * Es werden 6 Tests durchgeführt.
             * 3 mit 256 Elementen
             * 3 mit 65536 Elementen
             */
            // Testet die Methoden
            //for (int j = 0; j < 3; j++)
            //{

            //    List<int> A = new List<int>();
            //    for (int i = 0; i < n; i++)
            //    {
            //        int newzahl = rand.Next();
            //        A.Add(newzahl);
            //    }
            //    Test(A);
            //}

            //for (int j = 0; j < 1; j++)
            //{

            //    int n = ALL_N[3];
            //    List<int> A = new List<int>();
            //    for (int i = 0; i < n; i++)
            //    {
            //        int newzahl = rand.Next();
            //        A.Add(newzahl);
            //    }
            //    Test(A);
            //}
            //Console.WriteLine("Abgeschlossen!!");
            //Console.ReadLine();
            #endregion
            System.IO.File.WriteAllText("lol.txt", str);
            Console.ReadLine();
        }

        public static void Test(List<int> A)
        {
            int n = A.Count;
            List<int> controlList = new List<int>();
            A.ForEach(a => controlList.Add(a));
            controlList.Sort();
            Console.WriteLine("Ein Array mit " + A.Count + " Elementen. Jeder wert liegt zwischen 0 und " + int.MaxValue);
            Console.WriteLine("ControllList Median: " + controlList[controlList.Count / 2]);
            //Console.WriteLine("SimpleMedian Median: " + MedianSimple(A));
            while (true)
            {
                try
                {
                    int gmed = MedianDeluxe(A, n);
                    Console.WriteLine("Geschäzter Median: " + gmed);
                    Console.WriteLine("Abstand zwischen den beiden: " + (controlList[controlList.Count / 2] - gmed));
                    break;
                }
                catch 
                {

                }
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// Berechnet den Median für die Liste A. 
        /// Eine schlechte aber deterministische version.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int MedianSimple(List<int> A)
        {
            foreach (var number in A)
            {
                if (A.GetAmountOfSmallerNumbers(number) == A.Count / 2)
                    return number;
            }
            return A.First();
        }

        /// <summary>
        /// Berechnet den Median für die Liste A
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MedianDeluxe(List<int> A, int n)
        {
            // Schritt 1 -> R bilden
            int[] R = new int[(int)Math.Pow(n, 0.75)];
            {
                List<int> A_copy = new List<int>();
                A.ForEach(a => A_copy.Add(a));
                for (int i = 0; i < R.Length; i++)
                {
                    int index = rand.Next(0, A_copy.Count);
                    R[i] = A_copy[index];
                    A_copy.RemoveAt(index);
                }
            }

            // Schritt 2 -> Sortiere R
            {
                List<int> R_cache = R.ToList();
                R_cache.Sort();
                R = R_cache.ToArray();
            }

            // Schritt 3 -> Sei d die (0.5 * n^0.75 - sqrt(n)) - kleinste Zahl von R
            int d_index = (int)(0.5 * Math.Pow(n, 0.75) - Math.Sqrt(n));
            int d = R[d_index];

            // Schritt 4 -> Sei d die (0.5 * n^0.75 + sqrt(n)) - kleinste Zahl von R
            int u_index = (int)(0.5 * Math.Pow(n, 0.75) + Math.Sqrt(n));
            int u = R[u_index];

            // Schritt 5 -> Sei C die Menge aller Zahlen, die zwischen u und d (einschlislich liegen)
            // FRAGE: auch u einschlieslich??? -> Annahme: ja
            List<int> C = new List<int>();
            foreach (var a in A)
            {
                if (a >= d && a <= u)
                    C.Add(a);
            }
            // Sei l_d die Anzahl der Elemente von A, die kleiner als d sind;
            int l_d = 0;
            foreach (var a in A)
                if (a < d)
                    l_d++;
            // Sei l_u die Anzahl der Elemente von A, die gößer sind als u
            int l_u = 0;
            foreach (var a in A)
                if (a > u)
                    l_u++;

            // Schritt 6 -> Falls l_d > 0.5n oder l_u > 0.5n oder |C| > 4*n^0.75 return fail
            if ((l_d > 0.5 * n) || (l_u > 0.5 * n) || C.Count > 4 * Math.Pow(n, 0.75))
            {
                throw new Exception("Failed");
            }

            // Schritt 7 (optional) -> Sortiere C aufsteigend und gib das Element an Position 0.5n -l_d + 1 zurück
            C.Sort(); // AUFSTEIGEND???
            return C[(int)(0.5 * n - l_d + 1)];
        }
    }
}
