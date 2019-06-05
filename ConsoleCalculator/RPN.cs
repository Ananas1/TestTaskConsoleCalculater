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
       
        

        public double Result(string input)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queueOfElements = new Queue<string>(ConvertationtoRPN.ConvertToRPN(input));
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

