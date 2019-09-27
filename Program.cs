using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator Program! At any time, press CTRL + C to exit");

            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += delegate {
                System.Environment.Exit(0);
            };

            var upperBoundText = UserInput("Please enter a maximum number allowed for any of the individual entries: ");

            decimal upperBound;

            if (!Decimal.TryParse(upperBoundText, out upperBound))
            {
                ErrorAndExit("I'm sorry, that's not a valid number");
            }

            var allowNegativesText = UserInput("Would you like to allow Negative numbers to be processed? (Y/N): ");

            var allowNegatives = allowNegativesText.ToUpper().StartsWith("Y");

            var secondaryDelimiter = UserInput("Please enter a seccondary delimiter that should be allowed, alongside the comma: ");

            var calculator = new Services.Calculator(upperBound, allowNegatives, secondaryDelimiter);
            var validOps = new List<string> { "+", "-", "*", "/" };

            var loop = true;

            while (loop)
            {
                var op = UserInput("Please enter an operation to perform [ + - * / ]: ");

                if (!validOps.Contains(op))
                {
                    ErrorAndExit("I'm sorry, that's not a valid operator");
                }

                var input = UserInput("Please enter a sequence of numbers to perform the operation on: ");

                var response = calculator.Calculate(input, op);

                if (response.Success)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(response.Formula);
                    Console.WriteLine();

                    var continueInput = UserInput("Would you like to perform another calculation? (Y/N): ");
                    
                    loop = continueInput.ToUpper().StartsWith("Y");
                }
                else
                {
                    ErrorAndExit(response.Message);
                }
            }
        }

        static string UserInput(string inputMessage)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write(inputMessage);
            var output = Console.ReadLine();
            return output;
        }

        static void ErrorAndExit(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(errorMessage);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press Any Key to exit program");
            Console.Read();
            System.Environment.Exit(0);
        }
    }
}