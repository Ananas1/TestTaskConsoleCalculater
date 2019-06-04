namespace ConsoleCalculator
{

    public class Subtraction : AbstractBinaryOperation
    {
 

        public override bool IsInput(string input)
        {
            return (input == GetID());
                       
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
