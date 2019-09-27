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
        /// Sums up the numbers provided in the input, ignores numbers greater than the upper bound and invalid inputs
        /// Default delimiters include , and linebreak, but custom delimiters can be used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatorResponse Sum(string input)
        {
            return Calculate(input, "+");
        }

        /// <summary>
        /// Subtracts all the following numbers from the first provided in the input, ignores numbers greater than the upper bound and invalid inputs
        /// Default delimiters include , and linebreak, but custom delimiters can be used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatorResponse Difference(string input)
        {
            return Calculate(input, "-");
        }

        /// <summary>
        /// Multiplies all of the numbers provided in the input, ignores numbers greater than the upper bound and invalid inputs
        /// Default delimiters include , and linebreak, but custom delimiters can be used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatorResponse Product(string input)
        {
            return Calculate(input, "*");
        }

        /// <summary>
        /// Divides the first number from the list by all of the following numbers provided in the input, ignores numbers greater than the upper bound and invalid inputs
        /// Default delimiters include , and linebreak, but custom delimiters can be used
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatorResponse Quotient(string input)
        {
            return Calculate(input, "/");
        }

        private CalculatorResponse Calculate(string input, string operatorChar)
        {
            var response = new CalculatorResponse { Success = true };

            try
            {
                if (input == null) throw new Exception("Null Input");

                var tokens = Tokenize(input);

                if (tokens.Any(t => t.Errored))
                {
                    response.Success = false;

                    var invalidTokens = tokens.Where(t => t.Errored).Select(t => t.Token);
                    var invalidTokenString = string.Join(", ", invalidTokens);

                    throw new Exception(string.Format("The following inputs were rejected: {0}", invalidTokenString));
                }

                decimal result = 0;

                if (tokens.Any())
                {
                    switch (operatorChar)
                    {
                        case "+":
                            {
                                result = tokens.Sum(t => t.Value);
                                break;
                            }
                        case "-":
                            {
                                result = tokens.First().Value;

                                var otherTokens = tokens.Skip(1);

                                foreach (var t in otherTokens)
                                {
                                    result -= t.Value;
                                }

                                break;
                            }
                        case "*":
                            {
                                result = tokens.First().Value;

                                var otherTokens = tokens.Skip(1);

                                foreach (var t in otherTokens)
                                {
                                    result *= t.Value;
                                }

                                break;
                            }
                        case "/":
                            {
                                result = tokens.First().Value;

                                var otherTokens = tokens.Skip(1);

                                foreach (var t in otherTokens)
                                {
                                    result /= t.Value;
                                }

                                break;
                            }
                    }
                }

                response.Value = result;
                response.Formula = Formula(tokens, operatorChar, result);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
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


        /// <summary>
        /// Combines the tokens values with their result to show a string representation of the formula that was performed
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="operatorChar"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private string Formula(List<CalculatorToken> tokens, string operatorChar, decimal result)
        {
            var format = "{0} = {1}";

            var tokenValues = tokens.Select(t => t.Value);
            var operations = string.Join(string.Format(" {0} ", operatorChar), tokenValues);

            var output = string.Format(format, operations, result);

            return output;
        }
    }
}