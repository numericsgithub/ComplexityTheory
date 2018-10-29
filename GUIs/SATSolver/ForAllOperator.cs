using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphPlotter;

namespace SATSolver
{
    public class ForAllOperator : Expression
    {
        public override IEnumerable<NodeConnection> NodeConnectedTo
        {
            get
            {
                List<NodeConnection> nodes = new List<NodeConnection>();
                string forVarable = ForVariable.Name;
                Expression expr = InnerExpression;
                while (expr is ForAllOperator)
                {
                    forVarable += "," + ((ForAllOperator)expr).ForVariable;
                    expr = ((ForAllOperator)expr).InnerExpression;
                }
                nodes.Add(new NodeConnection(expr.NodeName, "FOR ALL("+ forVarable + ")"));
                return nodes;
            }
            set
            { }
        }

        public Variable ForVariable;
        public Expression InnerExpression;

        public ForAllOperator(Expression innerExpression, Variable forVaraible)
        {
            this.InnerExpression = innerExpression;
            ForVariable = forVaraible;
        }

        public override bool Exec()
        {
            ForVariable.Value = true;
            bool result1 = InnerExpression.Exec();
            ForVariable.Value = false;
            bool result2 = InnerExpression.Exec();
            return result1 && result2;
        }

        public override string ToString()
        {
            if(InnerExpression is ForAllOperator)
            {
                string res = LogicParser.CHAR_FORALL+ForVariable.ToString();
                Expression expr = InnerExpression;
                while(expr is ForAllOperator)
                {
                    res += "," +  ((ForAllOperator)expr).ForVariable.ToString();
                    if (((ForAllOperator)expr).InnerExpression is ForAllOperator)
                        expr = ((ForAllOperator)expr).InnerExpression;
                    else break;
                }
                res += "(" + ((ForAllOperator)expr).InnerExpression + ")";
                return res;
            }
            return LogicParser.CHAR_FORALL + ForVariable.ToString() + "(" + InnerExpression.ToString() + ")";
        }

        public override IEnumerable<Variable> GetVariables()
        {
            return InnerExpression.GetVariables();
        }

        public override IEnumerable<Expression> GetAllExpressions()
        {
            List<Expression> exps = new List<Expression>();
            Expression expr = InnerExpression;
            while (expr is ForAllOperator)
                expr = ((ForAllOperator)expr).InnerExpression;
            exps.Add(expr);
            exps.AddRange(expr.GetAllExpressions());
            return exps;
        }
    }
}
