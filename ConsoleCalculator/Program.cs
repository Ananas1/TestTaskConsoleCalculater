using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculation calculation = new Calculation; 
            //RPN calc = new RPN();
            string expression;
            do
            {
                Console.Write("Введите выражение: ");
                expression = (Console.ReadLine().Replace(" ", string.Empty)).Replace(',', '.').Replace(':', '/').ToLower();
                Console.WriteLine(RPN.SeparateToken(expression));


            }
            while (Console.ReadLine() != "");  //что-то не работает. Идея в том, что бы выводить сообщение: "Вы ввели пустую строку"
        }
    }
}
