using ParseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuringMachine
{
    public static class TuringParser
    {
        public static List<char> ReadBandContent(string text)
        {
            
            text = text.Replace("\r", "").Replace("\n", "").Replace("\t","").Replace(" ","");
            return ParseCharArray(new StringReader(text)).ToList();
        }

        public static List<Band> ReadBaender(string text)
        {
            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            List<Band> baender = new List<Band>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Replace(" ", "").Replace("\t", "");
                try
                {
                    if (!String.IsNullOrWhiteSpace(line))
                        baender.Add(new Band(ReadBandContent(line)));
                }
                catch (Exception ex)
                {
                    throw new Exception("Error parsing line " + (i + 1) + " \"" + line + "\" \r\nInner Exception: " + ex, ex);
                }
            }
            return baender;
        }

        public static MoveFunktion[] ParseMoveFunctions(string text)
        {
            string formal = "";

            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            List<MoveFunktion> moveFunktions = new List<MoveFunktion>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Replace(" ", "").Replace("\t", "");
                if (line.Contains("//"))
                {
                    formal += line += "\r\n";
                    continue;
                }
                try
                {
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        MoveFunktion m = ParseMoveFunction(new StringReader(line));
                        m.TB_INFO = i;
                        formal += m + "\r\n";
                        moveFunktions.Add(m);
                    } else formal += "\r\n";
                } catch (Exception ex)
                {
                    throw new Exception("Error parsing line " + (i+1) + " \"" + line + "\" \r\nInner Exception: " + ex, ex);
                }
            }
            List<string> states = moveFunktions.Select(n => n.StateName).ToList();
            List<string> ust = new List<string>();
            foreach (var item in states)
            {
                if (!ust.Contains(item))
                    ust.Add(item);
            }
            string s = ust.GetString();
            return moveFunktions.ToArray();
        }

        private static MoveFunktion ParseMoveFunction(StringReader reader)
        {
            string fromState = reader.ReadAlphaNumericString();
            if (String.IsNullOrWhiteSpace(fromState))
                throw new Exception("The from-State is empty");
            IEnumerable<char> fromInput = ParseCharArray(reader);
            if (reader.Next() != '-')
                throw new Exception("Ecpected \"->\" " + reader);
            if (reader.Next() != '>')
                throw new Exception("Ecpected \"->\" " + reader);
            string toState = reader.ReadAlphaNumericString();
            IEnumerable<char> writeChars = ParseCharArray(reader);
            IEnumerable<Direction> directions = ParseDirectionArray(reader);
            return new MoveFunktion(fromState, fromInput.ToList(), toState, writeChars.ToList(), directions.ToList());
        }

        private static IEnumerable<char> ParseCharArray(StringReader reader)
        {
            List<char> chars = new List<char>();
            if (reader.Next() != '(')
                throw new Exception("Array not starting with '(' " + reader);
            while (true)
            {
                chars.Add(reader.Next());
                if (reader.Peek() == ',')
                    reader.Next();
                else break;
            }
            if (reader.Next() != ')')
                throw new Exception("Array not ending with ')' " + reader);
            return chars;
        }

        private static IEnumerable<Direction> ParseDirectionArray(StringReader reader)
        {
            List<Direction> directions = new List<Direction>();
            if (reader.Next() != '(')
                throw new Exception("Array not starting with '(' " + reader);
            while (true)
            {
                try
                {
                    directions.Add((Direction)reader.Next());
                }catch
                {
                    throw new Exception("Unkown Direction " + reader);
                }
                if (reader.Peek() == ',')
                    reader.Next();
                else break;
            }
            if (reader.Next() != ')')
                throw new Exception("Array not ending with ')' " + reader);
            return directions;
        }
    }
}