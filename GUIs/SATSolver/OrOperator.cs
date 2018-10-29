using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public class OrOperator : BinaryOperator
    {
        protected override char operatorChar => LogicParser.CHAR_OR;
        protected override string operatorName => "OR";

        public OrOperator(Expression left, Expression right)
            :base (left, right)
        {
        }

        public override bool Exec()
        {
            return (Left.Exec()) || Right.Exec();
        }

        public string ToStringNoClamps()
        {
            if (!(Left is OrOperator) && !(Right is OrOperator))
                return Left.ToString() + " " + this.operatorChar + " " + Right.ToString();
            string res = "";
            if (Left is OrOperator)
                res += ((OrOperator)Left).ToStringNoClamps();
            else res += this.operatorChar + " " + Left.ToString();
            if (Right is OrOperator)
                res += ((OrOperator)Right).ToStringNoClamps();
            else res += this.operatorChar + " " + Right.ToString();
            return res;
        }

        public override string ToString()
        {
            if (!(Left is OrOperator) && !(Right is OrOperator))
                return "(" + Left.ToString() + " " + this.operatorChar + " " + Right.ToString() + ")";
            string res = "(";
            if (Left is OrOperator)
                res += ((OrOperator)Left).ToStringNoClamps();
            else res += this.operatorChar + " " + Left.ToString();
            if (Right is OrOperator)
                res += ((OrOperator)Right).ToStringNoClamps();
            else res += this.operatorChar + " " + Right.ToString();
            return res + ")";
        }
    }
}
