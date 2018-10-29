using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLib
{
    public class StringReader
    {
        public readonly string Text;
        public int Position { get; private set; }
        public bool IsAtEnd => Text.Length == Position;
        public bool IsOneBeforeEnd => Text.Length - 1 == Position;
        public bool IsAtStart => 0 == Position;

        public StringReader(string text)
        {
            this.Text = text;
        }

        public void ConsumeWhiteSpace()
        {
            while (Peek().IsWhiteSpace() && !IsAtEnd)
                Next();
        }

        public string ReadMaybeQuotedString()
        {
            if (Peek() == '"')
                return ReadQuotedString();
            else return ReadAlphaNumericString();
        }

        public string ReadQuotedString()
        {
            if (Peek() != '"')
                throw new Exception("Expected '\"' " + this);
            Next();
            string str = "";
            while (Peek() != '"' && !IsAtEnd)
                str += Next();
            Next();
            return str;
        }

        /// <summary>
        /// Gets the next character from the stream
        /// </summary>
        /// <returns>Either the next character or '\0' if the stream is empty</returns>
        public char Next()
        {
            if (IsAtEnd)
                return '\0';
            return Text[Position++];
        }

        /// <summary>
        /// Gets the next character from the stream without consuming it
        /// </summary>
        /// <returns>Either the next character or '\0' if the stream is empty</returns>
        public char Peek()
        {
            if (IsAtEnd)
                return '\0';
            return Text[Position];
        }

        /// <summary>
        /// Sets the position in the stream
        /// </summary>
        public void Seek(int position)
        {
            if (position < 0 || position > Text.Length)
                throw new Exception("invalid position in stream");
            Position = position;
        }

        /// <summary>
        /// Gets the rest of the String from the current Position without consuming
        /// </summary>
        /// <returns></returns>
        public string PeekRestString()
        {
            return Text.Substring(Position);
        }

        public string ReadAlphaString()
        {
            string result = "";
            char c;
            while (true)
            {
                c = (char)this.Peek();
                if (!c.IsAlpha())
                    break;
                this.Next();
                result += c;
            }
            return result;
        }

        public string ReadNumericString()
        {
            string result = "";
            char c;
            while (true)
            {
                c = (char)this.Peek();
                if (!c.IsNumeric())
                    break;
                this.Next();
                result += c;
            }
            return result;
        }

        public string ReadAlphaNumericString()
        {
            string result = "";
            char c;
            while (true)
            {
                c = (char)this.Peek();
                if (!c.IsAlphaNumeric())
                    break;
                this.Next();
                result += c;
            }
            return result;
        }

        public override string ToString()
        {
            return "At Position: " + Position + " Current char: " + Peek() + " Rest of string: \"" + PeekRestString() + "\"";
        }
    }
}
