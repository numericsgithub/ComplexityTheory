using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public class Variable : Expression, IComparable<Variable>
    {
        public override IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                return nodes;
            }
            set
            { }
        }

        public string Name;
        public bool Value;
        public bool IsForAll;

        public Variable(string name)
        {
            this.Name = name;
        }

        public override bool Exec()
        {
            return Value;
        }

        public override string ToString()
        {
            return Name;
        }

        public override IEnumerable<Variable> GetVariables()
        {
            var list = new List<Variable>();
            list.Add(this);
            return list;
        }

        public override IEnumerable<Expression> GetAllExpressions()
        {
            List<Expression> exps = new List<Expression>();
            exps.Add(this);
            return exps;
        }

        // this is first one '=='
        public static bool operator ==(Variable obj1, Variable obj2)
        {
            if ((object)obj1 == null && (object)obj2 == null)
                return true;
            if ((object)obj1 == null || (object)obj2 == null)
                return false;
            return obj1.Name == obj2.Name;
        }

        // this is second one '!='
        public static bool operator !=(Variable obj1, Variable obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            return this == (Variable)obj;
        }

        public int CompareTo(Variable other)
        {
            return Name.CompareTo(other.Name);
        }

        public override int GetHashCode()
        {
            var hashCode = -1660305023;
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<NodeConnection>>.Default.GetHashCode(NodeConnectedTo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }
    }
}
