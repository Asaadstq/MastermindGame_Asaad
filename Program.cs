namespace MastermindGame_Asaad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoreGame game = new CoreGame(args);
            game.Start();
        }
    }
}
