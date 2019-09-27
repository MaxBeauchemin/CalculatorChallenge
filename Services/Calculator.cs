using Calculator.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Calculator
    {
        private int _upperBound = 1000;

        /// <summary>
        /// Sums up the numbers provided in the input, ignores numbers greater than 1000 and invalid inputs
        /// Default delimiters include , and linebreak, but custom delimiters can be used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatorResponse Sum(string input)
        {
            var response = new CalculatorResponse { Success = true };

            var tokens = Tokenize(input);

            if (tokens.Any(t => t.Errored))
            {
                response.Success = false;

                //TODO: Add valid error message for invalid tokens
                response.Message = "ERROR";
            }
            else
            {
                response.Value = tokens.Sum(t => t.Value);
            }

            return response;
        }

        /// <summary>
        /// Splits up the input string and returns all of the digits between the delimiters
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<CalculatorToken> Tokenize(string input)
        {
            var delimiters = new List<string> { ",", "\n" };

            //TODO: Add custom delimiters from input, adjust start index of input string to parse

            var rawTokens = input.Split(delimiters.ToArray(), StringSplitOptions.None);

            var tokens = new List<CalculatorToken>();

            foreach (var raw in rawTokens)
            {
                var token = new CalculatorToken
                {
                    Token = raw
                };

                decimal value;

                if (Decimal.TryParse(raw, out value))
                {
                    token.Value = value;

                    //Check lower bound (error)
                    if (value < 0)
                    {
                        token.Errored = true;
                    }

                    //Check upper bound (act as 0)
                    if (value > _upperBound)
                    {
                        token.Value = 0;
                    }
                }

                tokens.Add(token);
            }

            return tokens;
        }
    }
}