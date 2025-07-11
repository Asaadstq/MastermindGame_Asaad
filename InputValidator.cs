using System;

namespace MastermindGame_Asaad
{
    internal class InputValidator
    {
        // Checks if input is valid: 4 digits, only 0–8, and all digits are unique
        public static bool IsValid(string input)
        {
            if (input.Length != 4)
                return false;

            if (!input.All(char.IsDigit))
                return false;

            int[] digits = input.Select(c => int.Parse(c.ToString())).ToArray();

            // Check that all digits are between 0–8
            if (digits.Any(d => d < 0 || d > 8))
                return false;

            // Optional: Check for unique digits only (Mastermind rule)
            if (digits.Distinct().Count() != 4)
                return false;

            return true;
        }

        // Parses the valid string input into int[]
        public static int[] ParseToDigitArray(string input)
        {
            return input.Select(c => int.Parse(c.ToString())).ToArray();
        }
    }
}
