using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public static class Extensions
    {
        public static List<char> ReadCurrentChars(this List<Band> baender)
        {
            List<char> chars = new List<char>();
            foreach (var item in baender)
                chars.Add(item.Current);
            return chars;
        }

        public static bool IsEqual(this List<char> chars, IReadOnlyList<char> others)
        {
            if (chars.Count != others.Count)
                throw new Exception("Die Listen müssen gleich lang sein!");
            for (int i = 0; i < chars.Count; i++)
                if (chars[i] != others[i])
                    return false;
            return true;
        }

        public static string GetString<TYPE>(this IEnumerable<TYPE> chars)
        {
            List<TYPE> list = chars.ToList();
            string text = "(";
            for (int i = 0; i < list.Count; i++)
            {
                text += list[i];
                if (i + 1 < list.Count)
                    text += ",";
            }
            return text + ")";
        }

        public static string GetStringRE(this IEnumerable<char> chars)
        {
            string text = chars.GetString();
            return text.Replace("~", "Δ").Replace("#", "∎");
        }

        public static string GetString(this IEnumerable<Direction> chars)
        {
            List<Direction> list = chars.ToList();
            string result = "(";
            for (int i = 0; i < list.Count; i++)
            {
                result += (char)list[i];
                if (i + 1 < list.Count)
                    result += ",";
            }
            return result + ")";
        }

        public static MoveFunktion GetFunction(this List<MoveFunktion> functions, List<char> chars, string state)
        {
            foreach (var item in functions)
            {
                if (item.StateName == state && chars.IsEqual(item.StateChars))
                    return item;
            }
            throw new Exception("Nicht definierter Zustand! " + state);
        }

        public static string GetString(this List<char> list)
        {
            string result = "(";
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
                if (i + 1 < list.Count)
                    result += ",";
            }
            return result + ")";
        }
    }
}
