﻿namespace BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "{{[[((])]]}}";
            Console.WriteLine(isBalanced(s));
        }




        public static string isBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char,char> bracketPairs = new Dictionary<char, char>() { 
                { '{','}' } ,
                { '[',']' } ,
                { '(',')' } 
            };

            foreach (char c in s)
            {
                if (bracketPairs.ContainsKey(c))    // open bracket
                {
                    stack.Push(c);
                }
                else if (bracketPairs.ContainsValue(c))// close bracket
                {
                    // empty stack or  c not a pair with top of stack
                    if (stack.Count == 0 || bracketPairs[stack.Peek()] != c)
                    {
                        return "NO";
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

    }
}





/*
 * A bracket is considered to be any one of the following characters:
 * (, ), {, }, [, or ].

Two brackets are considered to be a matched pair if the an opening bracket 
(i.e., (, [, or {) occurs to the left of a closing bracket (i.e., ), ], or }) of 
the exact same type. There are three types of matched pairs of brackets: 
[], {}, and ().

A matching pair of brackets is not balanced if the set of brackets it encloses
are not matched. For example, {[(])} is not balanced because the contents in 
between { and } are not balanced. The pair of square brackets encloses a single, 
unbalanced opening bracket, (, and the pair of parentheses encloses a single, 
unbalanced closing square bracket, ].

By this logic, we say a sequence of brackets is balanced if the following conditions are met:

It contains no unmatched brackets.
The subset of brackets enclosed within the confines of a matched pair of brackets 
is also a matched pair of brackets.
Given  strings of brackets, determine whether each sequence of brackets is balanced.
If a string is balanced, return YES. Otherwise, return NO.

Function Description

Complete the function isBalanced in the editor below.

isBalanced has the following parameter(s):

string s: a string of brackets
Returns

string: either YES or NO
Input Format

The first line contains a single integer n, the number of strings.
Each of the next n lines contains a single string s, a sequence of brackets.

Constraints
1 <= n <= 10^3
1 <= |s| <= 10^3, where s is the length of the sequence.
All chracters in the sequences ∈ { {, }, (, ), [, ] }.


Output Format

For each string, return YES or NO.

Sample Input

STDIN           Function 
-----           -------- 
3               n = 3 
{[()]}          first s = '{[()]}' 
{[(])}          second s = '{[(])}' 
{{[[(())]]}}    third s ='{{[[(())]]}}'

Sample Output

YES
NO
YES


Explanation

The string {[()]} meets both criteria for being a balanced string.
The string {[(])} is not balanced because the brackets enclosed by the matched
pair { and } are not balanced: [(]).
The string {{[[(())]]}} meets both criteria for being a balanced string.
 */