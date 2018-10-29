using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public static class Extensions
    {
        public static bool StartsWithOperator(this string input)
        {
            if (input.StartsWith(LogicParser.CHAR_OR + "")
                || input.StartsWith(LogicParser.CHAR_NOT + "")
                || input.StartsWith(LogicParser.CHAR_FORALL + "")
                || input.StartsWith(LogicParser.CHAR_EXISTS + "")
                || input.StartsWith(LogicParser.CHAR_AND + ""))
                return true;
            return false;
        }

        public static List<string> GetSet(this IEnumerable<Variable> vars)
        {
            List<string> list = new List<string>();
            foreach (var item in vars)
            {
                if (!item.IsForAll)
                    list.Add(item.Name + "=" + (item.Value ? "T" : "F"));
            }
            return list;
        }

        public static char ReadChar(this System.IO.StringReader reader)
        {
            char[] res = new char[1];
            if (reader.Read(res, 0, 1) == 1)
                return res[0];
            else return (char)0;
        }

        public static bool IsAlphaNumeric(this char c)
        {
            return IsAlpha(c) || IsNumeric(c);
        }

        public static bool IsNumeric(this char c)
        {
            return c >= 48 && c <= 57;
        }

        public static bool IsAlpha(this char c)
        {
            return IsUpperCaseAlpha(c) || IsLowerCaseAlpha(c);
        }

        public static bool IsUpperCaseAlpha(this char c)
        {
            return c >= 65 && c <= 90;
        }

        public static bool IsLowerCaseAlpha(this char c)
        {
            return c >= 97 && c <= 122;
        }

        //public static int IndexOfFirstOperator(this string input)
        //{
        //    int or = input.IndexOf("|");
        //    int and = input.IndexOf("&");
        //    int not = input.IndexOf("!");
        //    //if(or != -1 || )
        //}

        //public static Operator GetMatchingOperator(this string input)
        //{
        //    string opch;
        //    if (StartsWithOperator(input))
        //        opch = input.Substring(0, 1);
        //    else
        //    {
        //        if(opch)
        //    }
        //}


        public static void Remove(this List<Variable> list, string name)
        {
            Variable vari = list.FirstOrDefault(n => n.Name == name);
            if (vari != null)
                list.Remove(vari);
        }
    }
}
