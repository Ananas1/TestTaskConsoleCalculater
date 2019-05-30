using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class RPN
    {
        private Stack<double> litteralStack;
        public static Dictionary<string, Type> setOfOperations;

        //Конструкторы, но с ними пока хз что, по ходу дела будет видно. 
        static RPN() //конструктор для операндов
        {
            var setOfOperations = new Dictionary<string, AbstractOperation>();
            //var setOfOperations = new Dictionary<string, Type>();

            //setOfOperations.Add(Addition.GetID(), typeof(Addition));
            setOfOperations.Add(Addition.GetID(), new Addition());
            
            setOfOperations.Add(Addition.GetID(), new Subtraction());
            setOfOperations.Add(Addition.GetID(), new Multiplication());
            setOfOperations.Add(Addition.GetID(), new Division());

        }
        //Type Ad = setOfOperations[Addition.GetID()];
        //public object a = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //object add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //bject add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //object add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);

        public RPN(int literall)
        {
            this.litteralStack = new Stack<double>((literall));
        }

        public RPN()
        {
            this.litteralStack = new Stack<double>();
        }

        public static List<string> SeparateToken(string inputExpression)
        {

            List<string> Inputs = new List<string>();
            int iter = 0;
            string Token;         
            while (iter < inputExpression.Length)
            {
                Console.WriteLine($"Итерация: {iter}");
                Token = string.Empty + inputExpression[iter];
                if (setOfOperations.ContainsKey(Token))
                //if (!setOfOperations.ContainsKey(inputExpression[iter].ToString()))
                {
                    if (Char.IsDigit(inputExpression[iter]))
                    {
                        for (int i = iter + 1; i < inputExpression.Length && (Char.IsDigit(inputExpression[i]) || inputExpression[i] == '.'); i++)
                        {
                            Token += inputExpression[i];
                        }
                    }
                }
                iter += Token.Length;
                Console.WriteLine($"Токен: {Token}");
                Inputs.Add(Token);
            }

            //}
            return Inputs;

        }

        //public static string[] ConvertToRPN(string input)
        //{
        //    List<string> outputSeparated = new List<string>();
        //    List<string> outputSeparated2 = new List<string>();
        //    Stack<string> stack = new Stack<string>();
        //    //AbstractOperation operand = new RPN.setOfOperations();
        //    //string operand = new setOf(input);
        //    //string token;
        //    foreach (AbstractOperation operand in setOfOperations)
        //    {
        //        //Console.WriteLine(token);
        //        foreach (string token in SeparateToken(input))
        //        {
        //            //Console.WriteLine(operand);
        //            if (operand.IsInput(token) || token.Equals("(") || token.Equals(")"))
        //            {
        //                if (stack.Count > 0 && !token.Equals("("))
        //                {
        //                    if (token.Equals(")"))
        //                    {
        //                        string s = stack.Pop();
        //                        //Console.WriteLine($"Вершина стека {s}");
        //                        while (s != "(")
        //                        {
        //                            outputSeparated.Add(s);
        //                            //Console.WriteLine($"Вершина стека2 {s}");
        //                            s = stack.Pop();
        //                           // Console.WriteLine($"Переопределили s = новая вершина стека2 {s}");
        //                        }
        //                    }
        //                    else if (operand.GetPriority(token) > operand.GetPriority(stack.Peek()))
        //                    {
        //                        stack.Push(token);
        //                        //Console.WriteLine($"Вытащили из стека {token}");
        //                    }
        //                    else
        //                    {
        //                        while (stack.Count > 0 && operand.GetPriority(token) <= operand.GetPriority(stack.Peek()))
        //                        {
        //                            //Console.WriteLine($"Вытащили вершину стека и добавили выходстроку {stack.Peek()}");
        //                            outputSeparated.Add(stack.Pop());
                                    
        //                        }
        //                        //Console.WriteLine($"Добавили в стек {token}");
        //                        stack.Push(token); //возможно косяк и надо добавить в тело while
        //                    }

        //                }
        //                else
        //                {
        //                   // Console.WriteLine($"Добавили в стек {token}");
        //                    stack.Push(token);
        //                }
                                          
                                              
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Добавили в выходнуюстроку число{token}");
        //                outputSeparated.Add(token);

        //            }
        //        }
        //        if (stack.Count > 0)
        //        {
        //            foreach (string t in stack)
        //            {
        //                outputSeparated.Add(t);
        //               Console.WriteLine($"Добавили в выходную строку из стека {t}");
        //            }
        //        }
        //        foreach (string p in outputSeparated)
        //        {
        //            Console.WriteLine(p); 
        //        }
        //        // return outputSeparated.ToArray();
        //        //outputSeparated2.Add(token);

        //    }
        //    //Console.WriteLine(outputSeparated[0]);
        //    //Console.WriteLine(outputSeparated[1]);
        //    //Console.WriteLine(outputSeparated[2]);
        //    //Console.WriteLine(outputSeparated[3]);
        //    //Console.WriteLine(outputSeparated[4]);
        //    //foreach (string p in outputSeparated)
        //    //{
        //    //    Console.WriteLine(p);
        //    //}
        //    return outputSeparated.ToArray();
        //}
    }
}

