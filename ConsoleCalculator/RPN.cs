using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleCalculator
{
    public class RPN
    {
        static AbstractBinaryOperation add = new Addition();
        static AbstractBinaryOperation sub = new Subtraction();
        static AbstractBinaryOperation div = new Division();
        static AbstractBinaryOperation mult = new Multiplication();
        static AbstractBinaryOperation op = new Addition();
        public static Dictionary<string, AbstractBinaryOperation> setOfOperations = new Dictionary<string, AbstractBinaryOperation>
        {
            [add.GetID()] = new Addition(),
            [sub.GetID()] = new Subtraction(),
            [mult.GetID()] = new Multiplication(),
            [div.GetID()] = new Division()
        };
      
        public RPN() //конструктор для операндов
        {         

        }
       
        public static IEnumerable<string> SeparateToken(string inputExpression)
        {
            int iter = 0;
            string Token;         
            while (iter < inputExpression.Length)
            {
                Token = string.Empty + inputExpression[iter];

                if (!setOfOperations.ContainsKey(Token))
                {
                    if (Char.IsDigit(inputExpression[iter]))
                    {
                        for (int i = iter + 1; i < inputExpression.Length && (Char.IsDigit(inputExpression[i]) || inputExpression[i] == '.'); i++)
                        {
                            Token += inputExpression[i];
                        }
                    }
                }            
                yield return Token;
                iter += Token.Length;
            }
        }

        public static string[] ConvertToRPN(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string token in Validation.Sep(input.ToString()))

            {
                if ((setOfOperations.ContainsKey(token.ToString())) || token.Equals("(") || token.Equals(")"))
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
                        
                        else if ( stack.Peek().Equals("(") || (setOfOperations[token].GetPriority(token) > setOfOperations[(stack.Peek()).ToString()].GetPriority((stack.Peek()).ToString())) )
                        {                            
                            stack.Push(token);                            
                        }
                        else
                        {
                            while (stack.Count > 0 && (setOfOperations[token].GetPriority(token) <= setOfOperations[(stack.Peek()).ToString()].GetPriority((stack.Peek()).ToString())))
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

        public double Result(string input)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queueOfElements = new Queue<string>(ConvertToRPN(input));
            string lit = queueOfElements.Dequeue();
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            while (queueOfElements.Count >= 0) 
            {
                if (!setOfOperations.ContainsKey(lit.ToString()))
                {
                    stack.Push(lit);
                    try
                    {
                        lit = queueOfElements.Dequeue();
                    }
                    catch
                    {
                        throw new InvalidOperationException(("Ошибка ввода"));
                    }
                }

                else if (setOfOperations.TryGetValue(lit.ToString(), out sub))
                {
                    double result;
                    op = (setOfOperations[lit.ToString()]);
                                
                    result = op.Calculate(Convert.ToDouble(stack.Pop(), provider), Convert.ToDouble(stack.Pop(), provider)); 
                    string specifier = "G";
                    stack.Push(result.ToString(specifier, CultureInfo.InvariantCulture));
                    if (queueOfElements.Count > 0)
                    {
                        lit = queueOfElements.Dequeue();
                    }
                    else
                        break;
                }

            }
            return Convert.ToDouble(stack.Pop(), provider);
        }
    }
}

