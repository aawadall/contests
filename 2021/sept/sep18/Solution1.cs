using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sep18
{
    public class Solution1 : ISolution
    {
        public bool EnableDebug { get; set; }

        public IList<string> AddOperators(string num, int target)
        {
            Trace.WriteLine("AddOperators");
            var result = new List<string>();

            // define ditctionary of trees and populate with possible solutions 
            var treeDict = new Dictionary<TreeNode, int>();
            // try all possible combinations filling in our binary tree, squeezing in a binary operator between each pair of digits
            // digits will be only leaf nodes
            var digits = num.ToCharArray();
            var treeDepth = (int)Math.Ceiling(Math.Log(digits.Length));
            // for (var i = 0; i < treeDepth - 1; i++)
            // {
            var tree = new TreeNode(Oprand.Add);
            tree.Left = new TreeNode(digits[0]);
            tree.Right = new TreeNode(digits[1]);

            // tree.Left.Left = new TreeNode(digits[0]);
            // tree.Left.Right = new TreeNode(digits[1]);
            // tree.Right.Left = new TreeNode(digits[2]);
            // tree.Right.Right = new TreeNode(digits[3]);

            Trace.WriteLine(tree.Print());
            Trace.WriteLine(tree.Evaluate());

            //}
            return result;
        }
    }

    // Tree node
    public class TreeNode
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public Oprand Value { get; set; }



        public TreeNode(Oprand value, TreeNode left, TreeNode right)
        {
            // do not allow numeric values used as operators
            if ((int)value > 9) throw new System.Exception("Invalid operator");
            Value = value;
            Left = left;
            Right = right;
        }
        public TreeNode(char ch)
        {
            Value = (Oprand)(ch - '0');
        }
        public TreeNode(int value)
        {
            Value = (Oprand)value;
        }
        public TreeNode(Oprand op)
        {
            Value = op;
        }

        public int Evaluate()
        {
            if (Left == null && Right == null) return (int)Value;
            switch (Value)
            {
                case Oprand.Add: return Left.Evaluate() + Right.Evaluate();
                case Oprand.Subtract: return Left.Evaluate() - Right.Evaluate();
                case Oprand.Multiply: return Left.Evaluate() * Right.Evaluate();
                case Oprand.Concatinate: return Left.Evaluate() * 10 + Right.Evaluate();
            }
            throw new System.Exception("Invalid operator");
        }

        public string Print()
        {
            string result = "";

            switch (Value)
            {
                case Oprand.Add:
                    result = "+";
                    break;
                case Oprand.Subtract:
                    result = "-";
                    break;
                case Oprand.Multiply:
                    result = "*";
                    break;
                default:
                    result = $"{(int)Value}";
                    break;
            }

            if (Left != null && Right != null)
            {
                result = $"({Left.Print()}{result}{Right.Print()})";
            }

            return result;
        }
    }

    // enumerate all possible elements in the tree
    public enum Oprand
    {
        _0,
        _1,
        _2,
        _3,
        _4,
        _5,
        _6,
        _7,
        _8,
        _9,
        Add,
        Subtract,
        Multiply,
        Concatinate,
    }
}