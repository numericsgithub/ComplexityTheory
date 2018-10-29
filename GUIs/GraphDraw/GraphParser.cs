using Microsoft.Glee.Drawing;
using ParseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDraw
{
    public class GraphParser
    {
        static List<GraphNode> CurNodes;

        public static List<GraphNode> ParseGraphString(string text)
        {
            text = text.Replace("\r","");
            CurNodes = new List<GraphNode>();
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    ParseLine(new StringReader(lines[i]));
                }
                catch  (Exception ex){ throw new Exception("Error in line " + (i + 1) + "\r\n\r\n " + ex.Message, ex);  }
            }

            return CurNodes;
        }

        private static void ParseLine(StringReader reader)
        {
            reader.ConsumeWhiteSpace();
            if (reader.IsAtEnd)
                return;
            // Check for // Comment
            if(reader.Peek() == '/')
            {
                reader.Next();
                if (reader.Peek() == '/')
                    return;
                reader.Seek(0);
            }
            // Read First Name Part
            string firstName = reader.ReadMaybeQuotedString();
            GraphNode firstNode = GetNode(firstName);
            reader.ConsumeWhiteSpace();

            // Check if it is a Edge or Node Command
            if (reader.Peek() == '(')
            {
                reader.Next();
                reader.ConsumeWhiteSpace();
                Color color = ParseColorString(reader);
                firstNode.NodeColor = color;
            }
            else if (reader.Peek() == '-')
            {
                reader.Next();
                char nodetype = reader.Next();
                reader.ConsumeWhiteSpace();
                GraphNode secoundNode = GetNode(reader.ReadMaybeQuotedString());
                reader.ConsumeWhiteSpace();
                string annotation = "";
                if (reader.Peek() == '(')
                {
                    reader.Next();
                    reader.ConsumeWhiteSpace();
                    annotation = reader.ReadMaybeQuotedString();
                }
                if(nodetype == '>')
                    firstNode.Connections.Add(new GraphPlotter.NodeConnection(secoundNode.NodeName, annotation));
                else
                {
                    GraphPlotter.NodeConnection connection = new GraphPlotter.NodeConnection(secoundNode.NodeName, annotation);
                    connection.CustomEdgeAttr = new EdgeAttr();
                    connection.CustomEdgeAttr.ArrowHeadAtSource = ArrowStyle.None;
                    connection.CustomEdgeAttr.ArrowHeadAtTarget = ArrowStyle.None;
                    connection.CustomEdgeAttr.Label = annotation;
                    firstNode.Connections.Add(connection);
                }
            }
        }

        private static GraphNode GetNode(string name)
        {
            GraphNode node = CurNodes.FirstOrDefault(n => n.NodeName == name);
            if(node == null)
            {
                node = new GraphNode(name);
                CurNodes.Add(node);
            }
            return node;
        }

        private static Color ParseColorString(StringReader reader)
        {
            reader.ConsumeWhiteSpace();
            if (reader.Peek() == '#')
            {
                reader.Next();
                byte r = byte.Parse(reader.ReadAlphaNumericString());
                reader.ConsumeWhiteSpace();
                reader.Next();
                reader.ConsumeWhiteSpace();
                byte g = byte.Parse(reader.ReadAlphaNumericString());
                reader.ConsumeWhiteSpace();
                reader.Next();
                reader.ConsumeWhiteSpace();
                byte b = byte.Parse(reader.ReadAlphaNumericString());
                reader.ConsumeWhiteSpace();
                reader.Next();
                reader.ConsumeWhiteSpace();
                return new Color(r, g, b);
            }
            else return ColorParseStuff.FromName(reader.ReadAlphaString().ToLower());
        }
    }
}
