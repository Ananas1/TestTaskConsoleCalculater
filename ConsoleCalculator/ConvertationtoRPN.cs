using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class ConvertationtoRPN
    {
        public ConvertationtoRPN()
        {

        }

        static readonly List<string> outputSeparated = new List<string>();
        static readonly Stack<string> stack = new Stack<string>();
        public static string[] ConvertToRPN(string input)
        {
            
            foreach (string token in Validation.Sep(input.ToString()))

            {
                if ((RPN.setOfOperations.ContainsKey(token.ToString())) || token.Equals("(") || token.Equals(")"))
                {
                    if (stack.Count > 0 && !token.Equals("("))
                    {
                        if (token.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }

                        else if (stack.Peek().Equals("(") || (RPN.setOfOperations[token].GetPriority(token) > RPN.setOfOperations[(stack.Peek()).ToString()].GetPriority((stack.Peek()).ToString())))
                        {
                            stack.Push(token);
                        }
                        else
                        {
                            while (stack.Count > 0 && (RPN.setOfOperations[token].GetPriority(token) <= RPN.setOfOperations[(stack.Peek()).ToString()].GetPriority((stack.Peek()).ToString())))
                            {
                                outputSeparated.Add(stack.Pop());

                            }
                            stack.Push(token);
                        }

                    }
                    else
                    {
                        stack.Push(token);
                    }

                }
                else
                {
                    outputSeparated.Add(token);
                }
            }
            if (stack.Count > 0)
            {
                foreach (string t in stack)
                {
                    outputSeparated.Add(t);
                }
            }

            return outputSeparated.ToArray();

        }

    }
}
