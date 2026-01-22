namespace GameUI.views
{
    public class GameUI
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Uno But Not!");
        }

        public int getPlayerCount()
        {
            Console.WriteLine("Please enter the number of players (1-6):");
            int playerCount = 0;
            while (playerCount < 1 || playerCount > 6)
            {
                try
                {
                    playerCount = int.Parse(Console.ReadLine());
                    if (playerCount < 1 || playerCount > 6)
                    {
                        Console.WriteLine("Invalid number of players. Please enter a number between 1 and 6:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
            }
            return playerCount;
        }

        





        
    }
}