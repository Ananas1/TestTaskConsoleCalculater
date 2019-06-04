using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Multiplication : AbstractBinaryOperation
    {

        //public new byte Preority { get; set; }


        //public Multiplication()
        //{
        //    Priority = 2;
        //}
        public override string GetID() //допилить override
        {
            return "*";
        }

        public override bool IsInput(string input)
        {
            return (input == "*");
            
        }

        //public override byte GetPriority(string input)
        //{
        //    if (IsInput(input))
        //    {
        //        return Priority = 2;
        //    }
        //    else
        //    {
        //        return Priority = 0;
        //    }
        //}
        public override double Calculate(double arg1, double arg2)
        {
            return arg1 * arg2;
        }

        

    }
}
