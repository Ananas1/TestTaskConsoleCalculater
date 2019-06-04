using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Multiplication : AbstractBinaryOperation
    {
        public override string GetID() 
        {
            return "*";
        }

        public override bool IsInput(string input)
        {
            return (input == GetID());
            
        }


        public override double Calculate(double arg1, double arg2)
        {
            return arg1 * arg2;
        }

        

    }
}
