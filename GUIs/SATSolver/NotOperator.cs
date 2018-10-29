using GraphPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public class NotOperator : Expression
    {
        public override IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                nodes.Add(new NodeConnection(InnerExpression.NodeName, "NOT"));
                return nodes;
            }
            set
            { }
        }

        public Expression InnerExpression;

        public NotOperator(Expression value)
        {
            this.InnerExpression = value;
        }

        public override bool Exec()
        {
            return !(InnerExpression.Exec());
        }

        public override string ToString()
        {
            return LogicParser.CHAR_NOT + InnerExpression.ToString();
        }

        public override IEnumerable<Variable> GetVariables()
        {
            return InnerExpression.GetVariables();
        }

        public override IEnumerable<Expression> GetAllExpressions()
        {
            List<Expression> exps = new List<Expression>();
            exps.Add(InnerExpression);
            exps.AddRange(InnerExpression.GetAllExpressions());
            return exps;
        }
    }
}
