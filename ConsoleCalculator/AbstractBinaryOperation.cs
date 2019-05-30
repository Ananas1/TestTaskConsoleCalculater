using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
    public abstract class AbstractBinaryOperation : AbstractOperation
    {


        //    public abstract bool IsInput(string input);
        public abstract double Calculate(double arg1, double arg2);

        public override void Calculate(Stack<double> stack)
        {
            double arg1 = stack.Pop();
            double arg2 = stack.Pop();

            double res = Calculate(arg1, arg2);
            stack.Push(res);//throw new NotImplementedException();
        }

        public override byte GetPriority(string input)
        {
            if (IsInput(input))
            {
                return Priority = 2;
            }
            else
            {
                return Priority = 0;
            }
        }
        //public abstract bool IsInput(string input);

        //    public AbstractBinaryOperation()
        //    {

        //    }

        //    //public abstract double СalcSulate(Stack<double> stack);
        //public override void Calculate(Stack<double> stack)
        //{

        //}
    }
}
