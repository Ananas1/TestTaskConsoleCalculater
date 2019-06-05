using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleCalculator
{
    public class Validation
    {
        public static string[] Sep(string inputExpression)
        {
            List<string> tokens = SeparatedTokens.SeparateToken(inputExpression).ToList();
            List<string> outputTokens = new List<string>();
            string insertsymb = "0";
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            if (inputExpression == string.Empty)
            {
                throw new InvalidOperationException(("Пустое выражение"));
            }
            if (RPN.setOfOperations.ContainsKey(tokens[0]) && (RPN.setOfOperations[tokens[0]].GetPriority(tokens[0]) == 1))
            {
                tokens.Insert(0, "0");

            }
            else if (RPN.setOfOperations.ContainsKey(tokens[0]) && (RPN.setOfOperations[tokens[0]].GetPriority(tokens[0]) == 2))
            {
                throw new InvalidOperationException("Ошибка ввода данных!");
            }
            for (int i = 0; i < tokens.Count(); i++)
            {
                outputTokens.Insert(i, tokens[i]);

                if (RPN.setOfOperations.ContainsKey(tokens[i]) && (RPN.setOfOperations.ContainsKey(tokens[i + 1])))
                {
                    if (RPN.setOfOperations[tokens[i]].GetPriority(tokens[i]) < (RPN.setOfOperations[tokens[i + 1]].GetPriority(tokens[i + 1])))
                    {
                        throw new InvalidOperationException("Ошибка ввода данных!");
                    }
                    else if (RPN.setOfOperations[tokens[i]].GetPriority(tokens[i]) >= (RPN.setOfOperations[tokens[i + 1]].GetPriority(tokens[i + 1])))
                    {
                        if (RPN.setOfOperations[tokens[i]].GetPriority(tokens[i]) == 1)
                        {
                            insertsymb = "0";
                        }
                        else if (RPN.setOfOperations[tokens[i]].GetPriority(tokens[i]) == 2)
                        {
                            insertsymb = "1";
                        }
                        tokens.Insert(i + 1, "(");
                        tokens.Insert(i + 2, insertsymb);
                        tokens.Insert(i + 5, ")");
                    }
                }
                else if (!RPN.setOfOperations.ContainsKey(tokens[i]) && tokens[i] != ")" && tokens[i] != "(")
                {
                    try
                    {
                        Convert.ToDouble(tokens[i], provider);
                    } 
                    catch
                    {
                        throw new InvalidOperationException(("Ошибка ввода"));
                    }
                }            
            }

            return outputTokens.ToArray();
        }
       
    }
}
