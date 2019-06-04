using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleCalculator
{
    public class Validation
    {
        public void Sep (string inputExpression)
        {
            RPN ez = new RPN();
            List<string> tokens = RPN.SeparateToken(inputExpression).ToList();
            //RPN.SeparateToken(exp);
            for (int i = 0; i < tokens.Count(); i++ )
            {

               Console.WriteLine($"Токены из Sep {tokens[i]}");  
            }

        }
        
        public Validation()
        {
        }
    }
}
