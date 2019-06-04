using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public class Division : AbstractBinaryOperation
    {
        //public Division()
        //{
          //  Priority = 2;
        //}

        public override bool IsInput(string input)
        {
            return (input == "/");
            
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
        public override string GetID() //допилить override
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
