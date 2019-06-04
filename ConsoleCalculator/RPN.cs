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
        //private Stack<double> litteralStack;
        // public static Dictionary<string, AbstractBinaryOperation> setOfOperations = new Dictionary<string, AbstractBinaryOperation>();
        public static Dictionary<string, AbstractBinaryOperation> setOfOperations = new Dictionary<string, AbstractBinaryOperation>
        {
            [add.GetID()] = new Addition(),
            [sub.GetID()] = new Subtraction(),
            [mult.GetID()] = new Multiplication(),
            [div.GetID()] = new Division()
        };
    //Конструкторы, но с ними пока хз что, по ходу дела будет видно. 
    //setOfOperations.Add(Addition.GetID(), new Addition());
    

        //var setOfOperations = new Dictionary<string, Type>();

        //setOfOperations.Add(.GetID(), typeof(Addition));
        //setOfOperations.Add(Addition.GetID(), new Addition());
        //setOfOperations.Add(sub.GetID(), new Subtraction());
        //setOfOperations.Add(mult.GetID(), new Multiplication());
        //setOfOperations.Add(div.GetID(), new Division());
        public RPN() //конструктор для операндов
        {
            //Dictionary<string, AbstractBinaryOperation> setOfOperations = new Dictionary<string, AbstractBinaryOperation>();

           

        }
        //var setOfOperations = new Dictionary<string, AbstractOperation>();
        //setOfOperations.Add(Addition.GetID(), new Addition());
        //setOfOperations.Add(Subtraction.GetID(), new Subtraction());
        //    setOfOperations.Add(Multiplication.GetID(), new Multiplication());
        //    setOfOperations.Add(Division.GetID(), new Division());
        //Type Ad = setOfOperations[Addition.GetID()];
        //public object a = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //object add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //bject add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);
        //object add = Activator.CreateInstance(setOfOperations[Addition.GetID()]);

        //public RPN(int literall)
        //{
          //  this.litteralStack = new Stack<double>((literall));
        //}

        //public RPN()
        //{
        //    this.litteralStack = new Stack<double>();
        //}

        //public static List<string> SeparateToken(string inputExpression)
        //сюда же прикрутить валидатор на токены
        public static IEnumerable<string> SeparateToken(string inputExpression)
        {
            int iter = 0;
            string Token;         
            while (iter < inputExpression.Length)
            {
                Token = string.Empty + inputExpression[iter];
                Console.WriteLine(setOfOperations.ContainsKey(Token));

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
           // List<string> outputSeparated2 = new List<string>();
            Stack<string> stack = new Stack<string>();
            //AbstractOperation operand = new RPN.setOfOperations();
            //string operand = new setOf(input);
            //string token;
            //foreach (AbstractOperation operand in setOfOperations)
            //{
            //Console.WriteLine(token);

            //AbstractBinaryOperation value = new Addition();

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

            //foreach (AbstractBinaryOperation op in setOfOperations.Values)  
            //{
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            while (queueOfElements.Count >= 0)  //???
            {
                //Console.WriteLine($" op {op}");
                if (!setOfOperations.ContainsKey(lit.ToString()))
                {
                        //Console.WriteLine($" условие {setOfOperations.ContainsKey(lit.ToString())}, op {op}");
                    stack.Push(lit);
                        //Console.WriteLine($"добавили в стек число {lit}");
                    lit = queueOfElements.Dequeue();
                    Console.WriteLine($"след эл из очереди {lit}");

                }

                else if (setOfOperations.TryGetValue(lit.ToString(), out sub))
                {
                        //Console.WriteLine($" условие {setOfOperations[lit.ToString()]}, op {op}");
                    double result;
                    op = (setOfOperations[lit.ToString()]);
                    AbstractOperation.Equals(lit, add.GetID());
                    //AbstractBinaryOperation op = new setOfOperations(lit.ToString());
                    
                    Console.WriteLine(op);
                    result = op.Calculate(Convert.ToDouble(stack.Pop(), provider), Convert.ToDouble(stack.Pop(), provider)); //string value = "";
                    string specifier = "G";
                    //CultureInfo culture;
                    //culture = CultureInfo.CreateSpecificCulture("en")

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
            //}
           // return 0 ;
        }
    }
}

