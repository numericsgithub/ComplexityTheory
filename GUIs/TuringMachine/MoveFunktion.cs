using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GraphPlotter;
using Microsoft.Glee.Drawing;

namespace TuringMachine
{
    [Serializable]
    public class MoveFunktion : ISerializable, IGraphNode
    {
        public int COUNTER;
        public int TB_INFO;
        private string stateName;
        private List<char> stateChars;

        /// <summary>
        /// Determines the state to trigger this state
        /// </summary>
        public string StateName { get => stateName; set => stateName = value.ToLower(); }

        /// <summary>
        /// Determines the state of the Bänders to trigger this state
        /// </summary>
        public IReadOnlyList<char> StateChars => stateChars.AsReadOnly();

        /// <summary>
        /// The things to write on the Bänders
        /// </summary>
        public IReadOnlyList<char> WriteChars => writeChars.AsReadOnly();

        /// <summary>
        /// The Directions the Bänders have to move
        /// </summary>
        public IReadOnlyList<Direction> Directions => directions.AsReadOnly();
        public string NewStateName { get => newStateName; }

        public string NodeName
        {
            get => StateName;
            set => throw new NotImplementedException();
        }
        public IEnumerable<NodeConnection> NodeConnectedTo
        {
            get => new List<NodeConnection>() { new NodeConnection(newStateName, this.ToString()) };
                //StateChars.GetString() + "->" + 
                //this.WriteChars.GetString() + 
                //this.Directions.GetString()) };
            set => throw new NotImplementedException();
        }
        public Color NodeColor { get; set; }

        private string newStateName;
        private List<char> writeChars;
        private List<Direction> directions;

        public MoveFunktion(string stateName, List<char> stateChars, 
            string newStateName, List<char> writeChars, 
            List<Direction> directions)
        {
            this.stateName = stateName;
            this.stateChars = stateChars;
            this.newStateName = newStateName;
            this.writeChars = writeChars;
            this.directions = directions;
            if (stateChars.Count != writeChars.Count + 1)
                throw new Exception("Falsche Anzahl an Chars");
            if (stateChars.Count != directions.Count)
                throw new Exception("Falsche Anzahl an Chars oder Directions");
        }

        protected MoveFunktion(SerializationInfo info, StreamingContext context)
        {
            this.stateName = info.GetString("stateName");
            this.stateChars = (List<char>)info.GetValue("stateChars", typeof(List<char>));
            this.newStateName = info.GetString("newStateName");
            this.writeChars = (List<char>)info.GetValue("writeChars", typeof(List<char>));
            this.directions = (List<Direction>)info.GetValue("directions", typeof(List<Direction>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("stateName", stateName, typeof(string));
            info.AddValue("stateChars", stateChars, typeof(List<char>));
            info.AddValue("newStateName", newStateName, typeof(string));
            info.AddValue("writeChars", writeChars, typeof(List<char>));
            info.AddValue("directions", directions, typeof(List<Direction>));
        }

        public override string ToString()
        {
            return "δ(" +stateName + StateChars.GetStringRE() + ") = (" + NewStateName+ ", " + writeChars.GetStringRE() + ", " + directions.GetString().Replace("<","l").Replace("-","s").Replace(">","r") + ")";
        }
    }
}
