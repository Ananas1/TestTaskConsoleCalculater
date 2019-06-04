using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{

    public class Subtraction : AbstractBinaryOperation
    {
        //public Subtraction()
        //{
        //    Preority = 1;
        //}

        public override bool IsInput(string input)
        {
            return (input == "-");
                       
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

        public override string GetID() //допилить override
        {
            return "-";
        }

        public override double Calculate(double arg1, double arg2)
        {
            return arg2 - arg1;
        }
    }
}
