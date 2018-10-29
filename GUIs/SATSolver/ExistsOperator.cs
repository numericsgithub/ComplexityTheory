using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphPlotter;

namespace SATSolver
{
    public class ExistsOperator : Expression
    {
        public override IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                string forVarable = ForVariable.Name;
                Expression expr = InnerExpression;
                while (expr is ExistsOperator)
                {
                    forVarable += "," + ((ExistsOperator)expr).ForVariable;
                    expr = ((ExistsOperator)expr).InnerExpression;
                }
                nodes.Add(new NodeConnection(expr.NodeName, "EXISTS(" + forVarable + ")"));
                return nodes;
            }
            set
            { }
        }

        public Variable ForVariable;
        public Expression InnerExpression;

        public ExistsOperator(Expression innerExpression, Variable forVaraible)
        {
            this.InnerExpression = innerExpression;
            ForVariable = forVaraible;
        }

        public override bool Exec()
        {
            bool lastValue = ForVariable.Value;
            ForVariable.Value = true;
            bool result1 = InnerExpression.Exec();
            ForVariable.Value = false;
            bool result2 = InnerExpression.Exec();
            ForVariable.Value = lastValue;
            if (result1 || result2)
                return InnerExpression.Exec();
            return false;
        }

        public override string ToString()
        {
            if (InnerExpression is ExistsOperator)
            {
                string res = LogicParser.CHAR_EXISTS + ForVariable.ToString();
                Expression expr = InnerExpression;
                while (expr is ExistsOperator)
                {
                    res += "," + ((ExistsOperator)expr).ForVariable.ToString();
                    if (((ExistsOperator)expr).InnerExpression is ExistsOperator)
                        expr = ((ExistsOperator)expr).InnerExpression;
                    else break;
                }
                res += "(" + ((ExistsOperator)expr).InnerExpression + ")";
                return res;
            }
            return LogicParser.CHAR_EXISTS + ForVariable.ToString() + "(" + InnerExpression.ToString() + ")";
        }

        public override IEnumerable<Variable> GetVariables()
        {
            return InnerExpression.GetVariables();
        }

        public override IEnumerable<Expression> GetAllExpressions()
        {
            List<Expression> exps = new List<Expression>();
            Expression expr = InnerExpression;
            while (expr is ExistsOperator)
                expr = ((ExistsOperator)expr).InnerExpression;
            exps.Add(expr);
            exps.AddRange(expr.GetAllExpressions());
            return exps;
        }
    }
}
