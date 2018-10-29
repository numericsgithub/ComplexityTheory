using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class Band
    {
        private int index;
        private List<char> list;

        public int Index
        { get { return index; } }

        public char Current
        {
            get => list[index];
            set => list[index] = value;
        }
        public IReadOnlyList<char> List => list.AsReadOnly();

        public Band()
        {
            index = 0;
            list = new List<char>();
            list.Add(Char.Start);
        }

        public Band(List<char> chars)
        {
            index = 0;
            list = chars;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Stay:
                    break;
                case Direction.Right:
                    index++;
                    if (index == list.Count)
                        list.Add(Char.Empty);
                    break;
                case Direction.Left:
                    if (index == 0)
                        throw new Exception("Das Band ist bereits am Anfang");
                    index--;
                    break;
                default:
                    break;
            }
        }

        public void Print()
        {
            Console.Write("|");
            for (int i = 0; i < list.Count; i++)
            {
                if(index == i)
                {
                    ConsoleColor back = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write((char)list[i]);
                    Console.BackgroundColor = back;
                }
                else
                    Console.Write((char)list[i]);
                Console.Write("|");
            }
        }

        public override string ToString()
        {
            return list.GetString();
        }
    }

    public static class Char
    {
        public const char One = '1';
        public const char Zero = '0';
        public const char Start = '~';
        public const char Empty = '#';
    }

    public enum Direction
    {
        Stay = '-',
        Right = '>',
        Left = '<',
    }
}
