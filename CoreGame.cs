using System;


namespace MastermindGame_Asaad
{
    internal class CoreGame
    {

        private SecretCode secretCode;
        private int maxAttempts = 10; // default value
        private int currentRound = 0;

        public CoreGame(string[] args)
        {
            string? codeFromArgs = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-c" && i + 1 < args.Length)
                {
                    codeFromArgs = args[i + 1];
                }
                else if (args[i] == "-t" && i + 1 < args.Length)
                {
                    if (int.TryParse(args[i + 1], out int attempts))
                    {
                        maxAttempts = attempts;
                    }
                }
            }

            secretCode = new SecretCode(codeFromArgs);
        }

        public void Start()
        {
            Display.ShowIntro();

            while (currentRound < maxAttempts)
            {
                Display.ShowRound(currentRound);

                string? input = Console.ReadLine();
                if (input == null) break;

                if (!InputValidator.IsValid(input))
                {
                    Display.ShowInvalidInput();
                    continue;
                }

                int[] guess = InputValidator.ParseToDigitArray(input);
                var (wellPlaced, misplaced) = secretCode.CompareWith(guess);

                Display.ShowResult(wellPlaced, misplaced);

                if (wellPlaced == 4)
                {
                    Display.ShowVictory();
                    return;
                }

                currentRound++;
            }

            Display.ShowGameOver();
            Display.ShowSecretCode(secretCode.GetDigits());
        }
    }
}
