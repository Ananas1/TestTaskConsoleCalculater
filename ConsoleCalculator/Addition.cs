using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Addition : AbstractBinaryOperation
    {
        public Addition() : base()
        {
            Priority = 1;
        }
        public override bool IsInput(string input)
        {
            return (input == GetID());
           
        }

        public override string GetID() 
        {
            return "+";
        }

        public override byte GetPriority(string input)
        {
            if (IsInput(input))
            {
                return Priority = 1;
            }
            else
            {
                return Priority = 0;
            }
        }

        public override double Calculate(double arg1, double arg2)
        {
            return arg1 + arg2;
        }
    }
}
