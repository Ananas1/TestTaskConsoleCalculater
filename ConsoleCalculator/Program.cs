using System;


namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression;
            do
            {
                Console.Write("Введите выражение: ");
                expression = (Console.ReadLine().Replace(" ", string.Empty)).Replace(',', '.').Replace(':', '/').ToLower();
                RPN calc = new RPN();
                try
                {
                    double calculatorOutput = calc.Result(expression);
                    Console.Write("Результат: ");
                    Console.WriteLine(calculatorOutput);
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error: " + error.Message);
                }        

            }
            while (true); 
        }
    }
}
