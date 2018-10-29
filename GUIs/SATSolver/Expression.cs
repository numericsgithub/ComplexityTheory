using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public abstract class Expression : IGraphNode
    {
        public string NodeName { get { return ToString(); } set { } }
        public abstract IEnumerable<NodeConnection> NodeConnectedTo { get; set; }
        public Microsoft.Glee.Drawing.Color NodeColor
        {
            get { return Microsoft.Glee.Drawing.Color.White; }
            set { }
        }

        public abstract bool Exec();

        public abstract IEnumerable<Variable> GetVariables();
        public abstract IEnumerable<Expression> GetAllExpressions();
    }
}
