using System.Text;
using UnoButNot.@class;
using UnoButNot.Enums;

namespace GameUI.views
{
    public class GUI
    {
        public void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("        WELCOME TO UNO BUT NOT       ");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public int getPlayerCount()
        {
            
            return PromptInt("How many players are there? (2-4): ", min: 2, max: 4);
        }

        public void DisplayTurnHeader(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"            PLAYER {player.playerID}'S TURN");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        public void DisplayTopCard(Card topCard)
        {
            Console.WriteLine("TOP CARD:");
            displayCard(topCard);
            Console.WriteLine();
        }

        public void DisplayHand(Player player)
        {
            Console.WriteLine($"PLAYER {player.playerID} HAND:");
            Console.WriteLine("-------------------------------------");

            if (player.playerHand.Count == 0)
            {
                Console.WriteLine("(empty)");
                Console.WriteLine();
                return;
            }

           
            for (int i = 0; i < player.playerHand.Count; i++)
            {
                Card c = player.playerHand[i];
                Console.Write($"[{i}] ");
                PrintCardMini(c);
            }

            Console.WriteLine();
        }

      
        public string PromptPlayerAction()
        {
            while (true)
            {
                Console.Write("Type (P)lay a card or (D)raw a card: ");
                string? input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "P" || input == "PLAY")
                    return "play";

                if (input == "D" || input == "DRAW")
                    return "draw";

                Console.WriteLine("Invalid choice. Enter P or D.");
            }
        }

        public int PromptCardIndexToPlay(int handCount)
        {
            return PromptInt($"Choose a card index (0 - {handCount - 1}): ", 0, handCount - 1);
        }

        
        public Color PromptWildColor()
        {
            Console.WriteLine();
            Console.WriteLine("Choose a color for the WILD:");
            Console.WriteLine("1) RED");
            Console.WriteLine("2) GREEN");
            Console.WriteLine("3) BLUE");
            Console.WriteLine("4) YELLOW");

            int choice = PromptInt("Enter 1-4: ", 1, 4);

            return choice switch
            {
                1 => Color.RED,
                2 => Color.GREEN,
                3 => Color.BLUE,
                _ => Color.YELLOW
            };
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void Pause(string message = "Press ENTER to continue...")
        {
            Console.WriteLine();
            Console.Write(message);
            Console.ReadLine();
        }

        public void Clear()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                // Ignore any exceptions
            }
        }

        
        public string displayCard(Card card)
        {
            
            string plain = RenderCardPlain(card);

            
            PrintCardColored(card);

            return plain;
        }

        private void PrintCardColored(Card card)
        {
            ConsoleColor oldFg = Console.ForegroundColor;
            ConsoleColor oldBg = Console.BackgroundColor;

           
            Console.ForegroundColor = ToConsoleColor(card.cardColor);

            string valueText = SymbolToText(card.cardValue);
            string colorText = card.cardColor.ToString();

           
            Console.WriteLine("┌────────────────┐");
            Console.WriteLine($"│ {colorText,-14} │");
            Console.WriteLine("│                │");
            Console.WriteLine($"│      {valueText,-8}│");
            Console.WriteLine("│                │");
            Console.WriteLine($"│ {colorText,14} │");
            Console.WriteLine("└────────────────┘");

            Console.ForegroundColor = oldFg;
            Console.BackgroundColor = oldBg;
        }

        private string RenderCardPlain(Card card)
        {
            StringBuilder sb = new StringBuilder();
            string valueText = SymbolToText(card.cardValue);
            string colorText = card.cardColor.ToString();

            sb.AppendLine("┌────────────────┐");
            sb.AppendLine($"│ {colorText,-14} │");
            sb.AppendLine("│                │");
            sb.AppendLine($"│      {valueText,-8}│");
            sb.AppendLine("│                │");
            sb.AppendLine($"│ {colorText,14} │");
            sb.AppendLine("└────────────────┘");

            return sb.ToString();
        }

       
        private void PrintCardMini(Card card)
        {
            ConsoleColor oldFg = Console.ForegroundColor;
            Console.ForegroundColor = ToConsoleColor(card.cardColor);

            string v = SymbolToText(card.cardValue);
            string c = card.cardColor.ToString();

            
            if (card.cardColor == Color.WILD)
                Console.Write($"[{c} {v}]");
            else
                Console.Write($"[{c} {v}]");

            Console.ForegroundColor = oldFg;
            Console.WriteLine();
        }

     

        private int PromptInt(string prompt, int min, int max)
        {
            int value;

            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                    continue;
                }

                return value;
            }
        }

        private ConsoleColor ToConsoleColor(Color color)
        {
            return color switch
            {
                Color.RED => ConsoleColor.Red,
                Color.GREEN => ConsoleColor.Green,
                Color.BLUE => ConsoleColor.Blue,
                Color.YELLOW => ConsoleColor.Yellow,
                Color.WILD => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }

        private string SymbolToText(Symbol symbol)
        {
            return symbol switch
            {
                Symbol.ZERO => "0",
                Symbol.ONE => "1",
                Symbol.TWO => "2",
                Symbol.THREE => "3",
                Symbol.FOUR => "4",
                Symbol.FIVE => "5",
                Symbol.SIX => "6",
                Symbol.SEVEN => "7",
                Symbol.EIGHT => "8",
                Symbol.NINE => "9",

                Symbol.SKIP => "SKIP",
                Symbol.REVERSE => "REV",
                Symbol.DRAW_TWO => "+2",
                Symbol.WILD => "WILD",
                Symbol.DRAW_FOUR => "+4",

                _ => symbol.ToString()
            };
        }

        // Asks the player which card to play (or draw)
        public Card GetPlayerMove(Player player, Card topCard)
        {
            DisplayTurnHeader(player);
            DisplayTopCard(topCard);
            DisplayHand(player);

    string action = PromptPlayerAction();
    if (action == "play")
    {
        if (player.playerHand.Count == 0)
        {
            Console.WriteLine("No cards to play. You must draw.");
            return null;
        }
        int idx = PromptCardIndexToPlay(player.playerHand.Count);
        return player.playerHand[idx];
    }
            // if they chose draw
            return null;
        }

// Ask the player what color they want for a Wild card
    public Color ChooseColor()
    {
    return PromptWildColor();
    }
    }
}