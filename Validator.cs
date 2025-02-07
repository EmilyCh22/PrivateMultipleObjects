using System;
namespace Lesson4_PrivateMultipleObjects
{
    class Validator
    {
        public static string InputValidString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
                    return input;
                else
                {
                    Console.WriteLine("No blank strings allowed. Please try again.");
                    continue;
                }
            }
        }

        public static int InputValidInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int intInput))
                    return intInput;
                else
                {
                    Console.WriteLine("Please input an integer.");
                    continue;
                }
            }
        }

        public static double InputValidDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double doubleInput))
                    return doubleInput;
                else
                {
                    Console.WriteLine("Please input a number.");
                    continue;
                }
            }
        }
    }
}
