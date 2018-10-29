using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSetSum
{
    public class SubSetSum
    {
        public List<int> Set;

        public SubSetSum()
        {
            Set = new List<int>();
        }

        private List<int> Reduce(int z)
        {
            List<int> res = new List<int>();
            foreach (int item in Set)
            {
                if (item < z)
                    res.Add(item);
            }
            return res;
        }

        public List<int> FindSubSet(int z)
        {
            Random rand = new Random();
            int[] set = Reduce(z).ToArray();
            for (uint i = 1; i < uint.MaxValue; i++)
            {
                // Procedural
                int zahl = 0;
                for (int pos = 0; pos < set.Length; pos++)
                    if ((i & (1 << pos)) != 0)
                        zahl += set[pos];
                if(zahl == z)
                {
                    List<int> res = new List<int>();
                    for (int pos = 0; pos < set.Length; pos++)
                        if ((i & (1 << pos)) != 0)
                            res.Add(set[pos]);
                    return res;
                }

                // Random guess
                zahl = 0;
                uint r = (uint)rand.Next();
                for (int pos = 0; pos < set.Length; pos++)
                    if ((r & (1 << pos)) != 0)
                        zahl += set[pos];
                if (zahl == z)
                {
                    List<int> res = new List<int>();
                    for (int pos = 0; pos < set.Length; pos++)
                        if ((r & (1 << pos)) != 0)
                            res.Add(set[pos]);
                    return res;
                }
            }
            return null;
        }
    }
}
