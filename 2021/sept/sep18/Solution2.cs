using System;
using System.Collections.Generic;
using System.Linq;

namespace sep18
{
    /// <summary>
    /// Solution based on a flat expression, followed by a recursive evaluation of the expression.
    /// </summary>
    public class Solution2 : ISolution
    {
        public bool EnableDebug { get; set; }
        private char[] operators = new char[] { '+', '-', '*', 'c' };
        public IList<string> AddOperators(string num, int target)
        {
            var result = new HashSet<string>();

            #region Solution 
            var expression = new char[num.Length * 2 - 1];
            int index = 0;
            foreach (var c in num)
            {
                expression[index] = c;
                if (index > 0) expression[index - 1] = '_';
                index += 2;
            }

            var solutionSpace = BuildSolutionSpace(num.Length - 1);

            foreach (var solution in solutionSpace)
            {
                if (FillExpression(ref expression, solution, target))
                {
                    result.Add(Print(expression));
                }
            }
            #endregion

            return result.ToList();
        }


        /// <summary>
        /// Given input string length, build a matrix of all possible solutions.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private List<List<char>> BuildSolutionSpace(int length)
        {
            List<List<char>> result = new List<List<char>>();
            if (length == 1)
            {
                result = new List<List<char>>();
                foreach (var op in operators)
                {
                    result.Add(new List<char>() { op });
                }

                return result;
            }

            // if length is not 1, apply recursion
            foreach (var entry in BuildSolutionSpace(length - 1))
            {
                foreach (var op in operators)
                {
                    var newEntry = new List<char>(entry);
                    newEntry.Add(op);
                    result.Add(newEntry);
                }
            }
            return result;

        }

        /// <summary>
        /// Build expression from solution space and check if valid solution
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="solution"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool FillExpression(ref char[] expression, List<char> solution, int target)
        {
            var index = 1;

            foreach (var item in solution)
            {
                expression[index] = item;
                index += 2;
            }
            return (Evaluate(expression, target));
        }

        /// <summary>
        /// Prints the expression into a string 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string Print(char[] expression)
        {
            var result = new string(expression);
            result = result.Replace("c", "");

            return result;
        }


        /// <summary>
        /// Evaluates an expression if matches target value and has proper syntax
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="target"></param>
        /// <returns>true if valid</returns>
        private bool Evaluate(char[] expression, int target)
        {

            bool validExpression = true;
            var result = 0;
            var concatExpression = new List<string>();

            // concat pass 
            bool concat = false;

            foreach (var c in expression)
            {
                if (c != 'c' && !concat)
                {
                    concatExpression.Add(c.ToString());
                }
                else if (c == 'c')
                {
                    concat = true;
                }
                else
                {
                    concatExpression[concatExpression.Count - 1] += c;
                    concat = false;
                }

                // find leading zero expression
                if (concatExpression[concatExpression.Count - 1].Length > 1 && concatExpression[concatExpression.Count - 1][0] == '0') validExpression = false;
            }


            // mult pass 
            var multExpression = new List<string>();
            bool mult = false;

            foreach (var s in concatExpression)
            {

                if (s != "*" && !mult)
                {
                    multExpression.Add(s);
                }
                else if (s == "*")
                {
                    mult = true;
                }
                else
                {
                    int op1, op2;
                    Int32.TryParse(multExpression[multExpression.Count - 1], out op1);
                    Int32.TryParse(s, out op2);
                    multExpression.RemoveAt(multExpression.Count - 1);
                    multExpression.Add((op1 * op2).ToString());
                    mult = false;
                }
            }


            // add/sub pass 
            bool lastWasAdd = false;
            Int32.TryParse(multExpression[0], out result);

            for (int i = 1; i < multExpression.Count; i++)
            {

                switch (multExpression[i])
                {
                    case "+":
                        lastWasAdd = true;
                        break;
                    case "-":
                        lastWasAdd = false;
                        break;
                    default:
                        int op2;
                        Int32.TryParse(multExpression[i], out op2);
                        result += lastWasAdd ? op2 : -op2;
                        break;
                }
            }
            return (result == target) && validExpression;
        }
    }
}