using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public abstract class BinaryOperator : Expression
    {
        protected abstract string operatorName { get; }
        protected abstract char operatorChar { get; }

        public override IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                nodes.Add(new NodeConnection(Left.NodeName, operatorName));
                nodes.Add(new NodeConnection(Right.NodeName, operatorName));
                return nodes;
            }
            set
            { }
        }

        public Expression Left;
        public Expression Right;

        public BinaryOperator(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override IEnumerable<Variable> GetVariables()
        {
            return Left.GetVariables().Concat(Right.GetVariables());
        }

        public override IEnumerable<Expression> GetAllExpressions()
        {
            List<Expression> exps = new List<Expression>();
            exps.Add(Left);
            exps.Add(Right);
            exps.AddRange(Left.GetAllExpressions());
            exps.AddRange(Right.GetAllExpressions());
            return exps;
        }

     
    }
}
