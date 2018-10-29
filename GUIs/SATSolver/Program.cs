using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SATSolver
{
    public class Program
    {
        //static NotOperator not(Expression opt)
        //{
        //    return new NotOperator(opt);
        //}

        //static AndOperator and(Expression left, Expression right, params Expression[] ops)
        //{
        //    if(ops == null || ops.Length == 0)
        //        return new AndOperator(left, right);
        //    List<Expression> operators = ops.ToList();
        //    Expression nextop = operators[0];
        //    operators.RemoveAt(0);
        //    return and(new AndOperator(left, right), nextop, operators.ToArray());
        //}

        //static AndOperator and(params Variable[] ops)
        //{
        //    if (ops.Length == 2)
        //        return new AndOperator(ops[0], ops[1]);
        //    List<Variable> operators = ops.ToList();
        //    Expression nextop = operators[2];
        //    operators.RemoveAt(0);
        //    operators.RemoveAt(0);
        //    operators.RemoveAt(0);
        //    return and(new AndOperator(ops[0], ops[1]), nextop, operators.ToArray());
        //}

        //static OrOperator or(Expression left, Expression right)
        //{
        //    return new OrOperator(left, right);
        //}

        //static Expression negKonjun(params Variable[] variables)
        //{
        //    return not(and(variables));
        //}

        //static Expression konjunk(int konsize, params Variable[] inputvariables)
        //{
        //    List<Variable> vars = inputvariables.ToList();
        //    Expression result = null;
        //    while (vars.Count > 0)
        //    {
        //        List<Variable> curvars = new List<Variable>();
        //        for (int i = 0; i < konsize; i++)
        //        {
        //            curvars.Add(vars[0]);
        //            vars.RemoveAt(0);
        //        }
        //        if (result == null)
        //            result = negKonjun(curvars.ToArray());
        //        else
        //            result = new AndOperator(result, negKonjun(curvars.ToArray()));
        //    }
        //    return result;
        //}

        static void Main(string[] args)
        {
            new MainForm().ShowDialog();
            ////string input = " (a  & (b | ((!c) | f) ))& (x | b)";
            ////while(input.Contains("  "))
            ////    input = input.Replace("  ", " ");
            ////PutNested(input);
            //Variable a = new Variable("a");
            //Variable b = new Variable("b");
            //Variable c = new Variable("c");
            //Variable d = new Variable("d");
            //Variable e = new Variable("e");
            //Variable f = new Variable("f");
            //Variable g = new Variable("g");
            //Variable h = new Variable("h");
            //Variable i = new Variable("i");
            //Variable j = new Variable("j");
            ////Variable k = new Variable("k");
            ////Variable l = new Variable("l");
            ////Expression or = konjunk(2, 
            ////    a, b, a, c, a, f, b, b, b, g, b, h,
            ////    c, b, c, d, c, i, d, c, d, e, d, h,
            ////    e, d, e, f, e, g, f, a, f, e, f, j,
            ////    g, b, g, e, g, i, h, b, h, d, h, j,
            ////    i, c, i, g, i, j, j, f, j, h, j, i);



            //Expression expr;
            //try
            //{
            //    Console.WriteLine("Example: !(a & b) | a");
            //    Console.Write("Please put in a one-line expression: ");
            //    expr = LogicParser.Parse("!(g | f) & !(b | (a & (a | (g | k))))");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine();
            //    Console.WriteLine(ex.StackTrace);
            //    return;
            //}
            //List<List<string>> results = Solve(expr);
            //string fileout = "";
            //foreach (var result in results)
            //{
            //    string line = "Solution: ";
            //    foreach (var value in result)
            //    {
            //        line += value + ", ";
            //    }
            //    fileout += line + "\n";
            //    Console.WriteLine(line);
            //}
            //Console.WriteLine();
            //Console.WriteLine(expr.ToString());
            //Console.WriteLine();
            //System.IO.File.WriteAllText("results.txt", fileout);
            //Console.WriteLine("Results also printed in file results.txt in the current directory");
            //List<Expression> exprs = new List<Expression>();
            //exprs.Add(expr);
            //exprs.AddRange(expr.GetAllExpressions());
            //GraphPlotter.GraphPlott.PlottToFile(exprs, "lol.png", 1900, true);
            //Console.ReadLine();
        }

        public static List<List<string>> Solve(Expression expr)
        {
            Variable[] vars = expr.GetVariables().ToArray();
            List<Variable> variables = new List<Variable>();
            foreach (var item in vars)
            {
                if (variables.Contains(item) || item.IsForAll)
                    continue;
                variables.Add(item);
            }
            variables.Sort();
            //variables.Remove("1X0,0");
            //variables.Remove("1X0,2");
            //variables.Remove("1X0,3");
            //variables.Remove("2X0,1");
            //variables.Remove("2X0,2");
            //variables.Remove("2X0,3");
            //variables.Remove("2X1,1");
            //variables.Remove("1X1,0");
            //variables.Remove("3X0,0");
            //variables.Remove("4X0,0");
            //variables.Remove("2X0,1");
            //variables.Remove("3X0,1");
            //variables.Remove("4X0,1");

            //variables.Remove("4X3,0");
            //variables.Remove("4X3,1");
            //variables.Remove("4X3,3");
            //variables.Remove("2X2,0");
            //variables.Remove("2X3,0");
            //variables.Remove("2X3,1");
            //variables.Remove("2X2,2");
            //variables.Remove("2X2,3");

            //variables.Remove("4X2,3");
            //variables.Remove("4X2,2");
            //variables.Remove("2X3,2");
            //variables.Remove("2X2,2");


            //variables.Remove("1X2,1");
            vars = variables.ToArray();
            List<List<string>> result = new List<List<string>>();
            curExpr = expr;
            CurResult = result;
            CurVariables = vars;
            SolveForVar(0);
            //int max = (int)Math.Pow(2, vars.Length);
            //for (int i = 0; i < max; i++)
            //{
            //    Binarise(i, vars);
            //    if (expr.Exec())
            //        result.Add(vars.GetSet());
            //}
            return result;
        }

        static Expression curExpr;
        static List<List<string>> CurResult;
        static Variable[] CurVariables;

        public delegate void Found(Variable[] variables);
        public static event Found OnFound;
        private static Random rand = new Random();

        static void SolveForVar(int index)
        {
            if (CurVariables.Length - 1 == index)
            {
                CurVariables[index].Value = false;
                if (curExpr.Exec())
                {
                    CurResult.Add(CurVariables.GetSet());
                    if (OnFound != null)
                        OnFound(CurVariables);
                }
                CurVariables[index].Value = true;
                if (curExpr.Exec())
                {
                    CurResult.Add(CurVariables.GetSet());
                    if (OnFound != null)
                        OnFound(CurVariables);
                }
            }
            else
            {
                CurVariables[index].Value = false;
                SolveForVar(index + 1);
                CurVariables[index].Value = true;
                SolveForVar(index + 1);
            }

        }

        static void Binarise(int number, params Variable[] vars)
        {
            for (int i = 0; i < vars.Length; i++)
            {
                int cache = number >> i;
                if (cache % 2 == 0)
                    vars[i].Value = false;
                else vars[i].Value = true;
            }
        }
    }
}
