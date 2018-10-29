using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public class AndOperator : BinaryOperator
    {
        protected override string operatorName => "AND";
        protected override char operatorChar => LogicParser.CHAR_AND;

        public AndOperator(Expression left, Expression right)
            :base(left, right)
        {
        }

        public override bool Exec()
        {
            return Right.Exec() && Left.Exec();
        }

        public string ToStringNoClamps()
        {
            if (!(Left is AndOperator) && !(Right is AndOperator))
                return  Left.ToString() + " " + this.operatorChar + " " + Right.ToString() ;
            string res = "";
            if (Left is AndOperator)
                res += ((AndOperator)Left).ToStringNoClamps();
            else res += this.operatorChar + " " + Left.ToString();
            if (Right is AndOperator)
                res += ((AndOperator)Right).ToStringNoClamps();
            else res += this.operatorChar + " " + Right.ToString();
            return res;
        }

        public override string ToString()
        {
            if (!(Left is AndOperator) && !(Right is AndOperator))
                return "(" + Left.ToString() + " " + this.operatorChar + " " + Right.ToString() + ")";
            string res = "(";
            if (Left is AndOperator)
                res += ((AndOperator)Left).ToStringNoClamps();
            else res += this.operatorChar + " " + Left.ToString();
            if (Right is AndOperator)
                res += ((AndOperator)Right).ToStringNoClamps();
            else res += this.operatorChar + " " + Right.ToString();
            return res + ")";
        }
    }
}
