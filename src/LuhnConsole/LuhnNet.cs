using System;
using System.Text;

namespace LuhnNet
{
    /// <summary>
    /// Provides methods to perform Luhn algorithm validations.
    /// </summary>
    public static class Luhn
    {
        private static readonly byte[] _doubledValues = new byte[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };
        private static readonly Random _random = new Random();

        /// <summary>
        /// Checks if a number is valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException();
            }

            var sum = Sum(number.RemoveSpaces());

            return sum > 0 && sum % 10 == 0;
        }

        /// <summary>
        /// Generate a random string to be summed
        /// </summary>
        public static string Generate()
        {
            const string prefix = "600649666921";
            long num = _random.NextInt64();
            string number = num.ToString()
                .PadLeft(6, '0')
                .Substring(0, 6);
            string input = prefix + number;
            return input + CalculateCheckDigit(input);
        }

        /// <summary>
        /// Returns the check digit that will make the number valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        public static byte CalculateCheckDigit(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException();
            }

            var sum = Sum((number + "0").RemoveSpaces());
            var lastDigit = sum % 10;

            return (byte)(lastDigit == 0 ? 0 : 10 - lastDigit);
        }

        private static string RemoveSpaces(this string text) => text.Replace(" ", "");

        private static byte Sum(string number)
        {
            var length = number.Length;
            byte sum = 0;
            var shouldBeDoubled = true;

            while (length > 0)
            {
                if (!byte.TryParse(number[--length].ToString(), out byte digit))
                {
                    Console.WriteLine("Invalid value: " + number);
                    throw new Exception($"Invalid character found at position {length}.");
                }

                sum += (shouldBeDoubled ^= true) ? _doubledValues[digit] : digit;
            }

            return sum;
        }
    }
}
