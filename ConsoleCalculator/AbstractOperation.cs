using System.Collections.Generic;

namespace ConsoleCalculator
{
    public abstract class AbstractOperation
    {

        public byte Priority { get; set; }

        public abstract void Calculate(Stack <double> stack);

        public abstract bool IsInput(string input);

        public abstract byte GetPriority(string input);
    }
}
