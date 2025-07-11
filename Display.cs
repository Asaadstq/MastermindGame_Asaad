using System;

namespace MastermindGame_Asaad
{
    internal class Display
    {

        public static void ShowIntro()
        {
            Console.WriteLine("Can you break the code?");
            Console.WriteLine("Enter a valid guess");
            Console.WriteLine("---");
        }

        public static void ShowRound(int round)
        {
            Console.WriteLine($"Round {round}");
        }

        public static void ShowResult(int wellPlaced, int misplaced)
        {
            Console.WriteLine($"Well placed pieces: {wellPlaced}");
            Console.WriteLine($"Misplaced pieces: {misplaced}");
        }

        public static void ShowVictory()
        {
            Console.WriteLine("Congratz! You did it!");
        }

        public static void ShowInvalidInput()
        {
            Console.WriteLine("Wrong input!");
        }

        public static void ShowGameOver()
        {
            Console.WriteLine("Game Over. Better luck next time!");
        }

        public static void ShowSecretCode(int[] code)
        {
            Console.WriteLine("Secret code was: " + string.Join("", code));
        }
    }
}
