using System;


namespace MastermindGame_Asaad
{
    internal class SecretCode
    {
        private int[] digits;

        // Constructor: accept code or generate new one
        public SecretCode(string? code = null)
        {
            if (code != null && code.Length == 4 && code.All(char.IsDigit))
            {
                digits = code.Select(c => int.Parse(c.ToString())).ToArray();
            }
            else
            {
                digits = GenerateRandomCode();
            }
        }

        // Generate a random 4-digit code with digits from 0–8 (no duplicates)
        private int[] GenerateRandomCode()
        {
            Random rand = new Random();
            List<int> pool = Enumerable.Range(0, 9).ToList();  // digits 0 to 8
            List<int> code = new List<int>();

            while (code.Count < 4)
            {
                int index = rand.Next(pool.Count);
                code.Add(pool[index]);
                pool.RemoveAt(index); // ensure uniqueness
            }

            return code.ToArray();
        }

        // Compare a guess with the secret and return (wellPlaced, misplaced)
        public (int wellPlaced, int misplaced) CompareWith(int[] guess)
        {
            int wellPlaced = 0;
            int misplaced = 0;

            bool[] matchedSecret = new bool[4];
            bool[] matchedGuess = new bool[4];

            // First pass: count well-placed digits
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == digits[i])
                {
                    wellPlaced++;
                    matchedSecret[i] = true;
                    matchedGuess[i] = true;
                }
            }

            // Second pass: count misplaced digits
            for (int i = 0; i < 4; i++)
            {
                if (matchedGuess[i]) continue;

                for (int j = 0; j < 4; j++)
                {
                    if (!matchedSecret[j] && guess[i] == digits[j])
                    {
                        misplaced++;
                        matchedSecret[j] = true;
                        break;
                    }
                }
            }

            return (wellPlaced, misplaced);
        }

        // Optional: for testing/debugging
        public int[] GetDigits()
        {
            return digits;
        }
    }
}
