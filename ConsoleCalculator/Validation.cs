using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleCalculator
{
    public class Validation
    {
        public static string[] Sep(string inputExpression)
        {
            List<string> tokens = RPN.SeparateToken(inputExpression).ToList();
            List<string> outputTokens = new List<string>();
            string insertsymb = "0";
            if (RPN.setOfOperations.ContainsKey(tokens[0]) && (RPN.setOfOperations[tokens[0]].GetPriority(tokens[0]) == 1))
            {
                Console.WriteLine("первый символ строки + или -");
                tokens.Insert(0, "0");

            }
            else if (RPN.setOfOperations.ContainsKey(tokens[0]) && (RPN.setOfOperations[tokens[0]].GetPriority(tokens[0]) == 2))
            {
                Console.WriteLine("первый символ строки * или /");
                throw new InvalidOperationException("Ошибка ввода данных!");
            }
            for (int i = 0; i < tokens.Count(); i++)
            {
                outputTokens.Insert(i, tokens[i]);
                if (RPN.setOfOperations.ContainsKey(tokens[i]) && RPN.setOfOperations.ContainsKey(tokens[i]))
                {
                    if ((RPN.setOfOperations.ContainsKey(tokens[i])) && (RPN.setOfOperations.ContainsKey(tokens[i+1])))
                    {
                        if (RPN.setOfOperations[tokens[i]].GetPriority(tokens[i]) < (RPN.setOfOperations[tokens[i+1]].GetPriority(tokens[i+1])))
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
                               // tokens.Insert(i + 1, insertsymb);
                                //outputTokens.Insert(i + 1, tokens[i + 1]);
                            }

                            tokens.Insert(i+1, "(");
                           // outputTokens.Insert(i + 1, tokens[i + 1]);
                            tokens.Insert(i+2, insertsymb);
                            //outputTokens.Insert(i + 2, tokens[i + 2]);
                            tokens.Insert(i+5, ")");
                            //outputTokens.Insert(i+5, tokens[i + 5]);
                        }




                    }
                }
        //if (tokens[i] )
                {

                }
                //outputTokens[i] = tokens[i];
               Console.WriteLine($"Токены из Sep {tokens[i]}  и результат {outputTokens[i]}");  
            }

            return outputTokens.ToArray();
        }
        
        public Validation()
        {
        }
    }
}
