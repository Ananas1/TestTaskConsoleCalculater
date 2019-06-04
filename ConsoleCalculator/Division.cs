using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Division : AbstractBinaryOperation
    {
 
        public override bool IsInput(string input)
        {
            return (input == GetID());
            
        }

        public override string GetID() 
        {
            return "/";
        }

        public override double Calculate(double arg1, double arg2)
        {
            if (arg1 == 0)
            {
                throw new InvalidOperationException( ("Деление на 0 запрещено!"));
            }
            return arg2 / arg1;
        }
    }
}
