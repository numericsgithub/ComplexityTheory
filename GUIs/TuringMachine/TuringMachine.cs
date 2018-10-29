using Microsoft.Glee.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TuringMachine
    {
        public const string START_STATE_NAME = "start";
        public const string END_STATE_NAME = "end";

        private List<Band> baender;
        private List<MoveFunktion> functions;
        private string currentState;

        public List<char> CurrentChars => baender.ReadCurrentChars();
        public IReadOnlyList<Band> Baender => baender.AsReadOnly();
        public IReadOnlyList<MoveFunktion> Functions => functions.AsReadOnly();
        public string CurrentState { get => currentState; }

        public TuringMachine(List<Band> baender, List<MoveFunktion> functions)
        {
            this.baender = baender;
            this.functions = functions;
            currentState = START_STATE_NAME;
        }

        public MoveFunktion PerformStep(bool print = false, int imgSize = 1900, string filename = "img.jpg")
        {
            if (currentState == "end")
                return null;
            MoveFunktion moveFunktion = functions.GetFunction(CurrentChars, currentState);
            if (print)
            {
                IEnumerable<MoveFunktion> fu = functions.Where(x => x.StateName == currentState);
                foreach (var item in fu)
                {
                    item.NodeColor = Color.Red;
                }
                GraphPlotter.GraphPlott.PlottToFile(functions, filename, imgSize);
                foreach (var item in fu)
                {
                    item.NodeColor = Color.White;
                }
            }

            if (moveFunktion.WriteChars.Count + 1 != baender.Count)
                throw new Exception("Falsche anzahl an Änderungen in Funktion");
            // Die aktuellen Positionen auf den Bändern beschreiben
            for (int i = 1; i < baender.Count; i++)
                baender[i].Current = moveFunktion.WriteChars[i - 1];
            // Die Bänder Bewegen
            for (int i = 0; i < baender.Count; i++)
                baender[i].Move(moveFunktion.Directions[i]);
            // Den Status ändern
            currentState = moveFunktion.NewStateName;

            return moveFunktion;
        }

        public void Print()
        {
            Console.WriteLine("Current State: " + currentState);
            foreach (var item in baender)
            {
                item.Print();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in baender)
            {
                result += item.ToString() + "\r\n";
            }
            result += "\r\n";
            foreach (var item in functions)
            {
                result += item.ToString() + "\r\n";
            }
            return result;
        }
    }
}
