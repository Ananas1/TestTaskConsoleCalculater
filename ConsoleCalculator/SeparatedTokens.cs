using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class SeparatedTokens
    {
        // constructor
        public SeparatedTokens(string input)
        {

        }

        public static IEnumerable<string> SeparateToken(string inputExpression)
        {
            int iter = 0;
            string Token;
            while (iter < inputExpression.Length)
            {
                Token = string.Empty + inputExpression[iter];

                if (!RPN.setOfOperations.ContainsKey(Token))
                {
                    if (Char.IsDigit(inputExpression[iter]))
                    {
                        for (int i = iter + 1; i < inputExpression.Length && (Char.IsDigit(inputExpression[i]) || inputExpression[i] == '.'); i++)
                        {
                            Token += inputExpression[i];
                        }
                    }
                }
                yield return Token;
                iter += Token.Length;
            }
        }

    }
}
