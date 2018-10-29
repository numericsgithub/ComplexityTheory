using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianDeluxe
{
    public static class Extensions
    {
        public static int GetAmountOfSmallerNumbers(this List<int> list, int num)
        {
            int numbersSmallerThenNum = 0;
            foreach (var number in list)
            {
                if (number < num)
                    numbersSmallerThenNum++;
            }
            return numbersSmallerThenNum;
        }
    }
}
