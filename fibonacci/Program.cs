using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    class Program
    {
        static void Main()
        {
            var program = new Program();

            while (true)
            {
                Console.WriteLine("To exit enter 'x'.");
                Console.WriteLine("Please provide ordinal of a Fibonacci number:");

                var ordinalText = Console.ReadLine();

                if (ordinalText == "x") return;

                if (!ulong.TryParse(ordinalText, out var ordinal))
                {
                    Console.WriteLine("Entered value is not a number!");
                    continue;
                }

                if (ordinal < 1)
                {
                    Console.WriteLine("Enter a positive number!");
                    continue;
                }

                try
                {
                    var fibonacciNumber = program.GetFibonacciNumber(ordinal);

                    Console.WriteLine("Fibonacci({0:N0}) = {1:N0}", ordinal, fibonacciNumber);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error occured: {exception.Message}");
                }

                Console.WriteLine();
                Console.WriteLine();
            }

        }

        //ulong GetFibonacciNumber(ulong ordinal)
        //{
        //    if (ordinal < 1) throw new ArgumentOutOfRangeException(nameof(ordinal), ordinal, "Argument is less than minimum value of 1.");

        //    if (ordinal == 1) return 1;
        //    if (ordinal == 2) return 1;

        //    return GetFibonacciNumber(ordinal - 2) + GetFibonacciNumber(ordinal - 1);
        //}

        ulong GetFibonacciNumber(ulong ordinal)
        {
            if (ordinal < 1) throw new ArgumentOutOfRangeException(nameof(ordinal), ordinal, "Argument is less than minimum value of 1.");

            var fibonacciArray = new ulong[ordinal];

            for (ulong i = 0; i < ordinal; i++)
            {
                fibonacciArray[i] = i <= 1 ? 1 : checked(fibonacciArray[i - 1] + fibonacciArray[i - 2]);
            }

            return fibonacciArray[ordinal - 1];
        }
    }
}
