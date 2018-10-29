using ParseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATSolver
{
    public class LogicParser
    {
        public const char CHAR_AND = '∧';
        public const char CHAR_OR = '∨';
        public const char CHAR_NOT = '¬';
        public const char CHAR_EXISTS = '∃';
        public const char CHAR_FORALL = '∀';

        public static Expression Parse(string text)
        {
            text = text.Replace(" ", "").Replace("\t", "").Replace("\n","").Replace("\r","");
            lastExpression = null;
            knownVariables = new List<Variable>();
            StringReader reader = new StringReader("("+text+")");
            return ParseExpression(reader);
        }

        private static Expression lastExpression;
        private static List<Variable> knownVariables;

        private static Expression ParseExpression(StringReader reader)
        {
            char c = (char)reader.Peek();
            if (c.IsAlphaNumeric())
                return ParseVariable(reader);
            switch (c)
            {
                case '(':
                    return ParseInnerExpression(reader);
                case CHAR_AND:
                    return ParseAndOperator(reader);
                case CHAR_OR:
                    return ParseOrOperator(reader);
                case CHAR_NOT:
                    return ParseNotOperator(reader);
                case CHAR_FORALL:
                    return ParseForAllOperator(reader);
                case CHAR_EXISTS:
                    return ParseExistsOperator(reader);
                default:
                    throw new Exception("Unkown char '" + c + "' " + (int)c + " " + reader);
            }
        }

        private static ForAllOperator ParseForAllOperator(StringReader reader)
        {
            if (reader.Next() != CHAR_FORALL)
                throw new Exception(reader + "");
            List<Variable> variables = ParseVariableListWithAtLeastOne(reader);
            variables.ForEach(v => v.IsForAll = true);
            if (reader.Next() != ':')
                throw new Exception("Tried to parse "+ CHAR_FORALL + " expression expected a ':' after Variable " + reader);
            Expression right = ParseExpression(reader);
            for (int i = variables.Count - 1; i > 0; i--)
                right = new ForAllOperator(right, variables[i]);
            ForAllOperator forAll = new ForAllOperator(right, variables[0]);
            lastExpression = forAll;
            return forAll;
        }

        private static ExistsOperator ParseExistsOperator(StringReader reader)
        {
            if (reader.Next() != CHAR_EXISTS)
                throw new Exception(reader + "");
            List<Variable> variables = ParseVariableListWithAtLeastOne(reader);
            //variables.ForEach(v => v.IsForAll = true);
            if (reader.Next() != ':')
                throw new Exception("Tried to parse " + CHAR_OR + " expression expected a ':' after Variable " + reader);
            Expression right = ParseExpression(reader);
            for (int i = variables.Count - 1; i > 0; i--)
                right = new ExistsOperator(right, variables[i]);
            ExistsOperator exists = new ExistsOperator(right, variables[0]);
            lastExpression = exists;
            return exists;
        }

        private static NotOperator ParseNotOperator(StringReader reader)
        {
            if (reader.Next() != CHAR_NOT)
                throw new Exception(reader + "");
            Expression right = ParseExpression(reader);
            NotOperator not = new NotOperator(right);
            lastExpression = not;
            return not;
        }

        private static OrOperator ParseOrOperator(StringReader reader)
        {
            if (reader.Next() != CHAR_OR)
                throw new Exception(reader + "");
            Expression left = lastExpression;
            Expression right = ParseExpression(reader);
            OrOperator or = new OrOperator(left, right);
            lastExpression = or;
            return or;
        }

        private static AndOperator ParseAndOperator(StringReader reader)
        {
            if (reader.Next() != CHAR_AND)
                throw new Exception(reader + "");
            Expression left = lastExpression;
            Expression right = ParseExpression(reader);
            AndOperator and = new AndOperator(left, right);
            lastExpression = and;
            return and;
        }

        private static Expression ParseInnerExpression(StringReader reader)
        {
            if (reader.Next() != '(')
                throw new Exception("Tried to parse inner expression without a '(' at the beginning " + reader);
            Expression inner = ParseExpression(reader);
            lastExpression = inner;
            if (reader.Peek() != ')')
            {
                inner = ParseExpression(reader);
                if (!(inner is BinaryOperator))
                    throw new Exception("Expected binary operator in inner expression but found " + inner.ToString() + " " + reader);
                lastExpression = inner;
            }
            if (reader.Peek() != ')')
            {
                // Parse ongoing expression
                while (reader.Peek() == LogicParser.CHAR_AND || reader.Peek() == LogicParser.CHAR_OR)
                {
                    Expression expression = ParseExpression(reader);
                    lastExpression = expression;
                    inner = expression;
                }
            }
            reader.Next();
            return inner;
        }

        private static List<Variable> ParseVariableListWithAtLeastOne(StringReader reader)
        {
            List<Variable> variables = new List<Variable>();
            while (true)
            {
                variables.Add(ParseVariable(reader));
                if (reader.Peek() == ',')
                    reader.Next();
                else break;
            }
            return variables;
        }

        private static Variable ParseVariable(StringReader reader)
        {
            string varname = reader.ReadAlphaNumericString();
            if (String.IsNullOrWhiteSpace(varname))
                throw new Exception("Varname is null or empty " + reader);
            Variable variable = new Variable(varname);
            if (knownVariables.Contains(variable))
                variable = knownVariables[knownVariables.IndexOf(variable)];
            else knownVariables.Add(variable);
            lastExpression = variable;
            return variable;
        }
    }
}
