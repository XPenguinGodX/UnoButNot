namespace UnoButNot.@class
{
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Reflection.Metadata;
    using System.Collections;
    using UnoButNot.Enums;

    public class Deck
    {
        private static readonly Card[] cards = new Card[]
        {
        new Card(Color.RED, Symbol.ZERO), new Card(Color.RED, Symbol.ONE), new Card(Color.RED, Symbol.TWO), new Card(Color.RED, Symbol.THREE), new Card(Color.RED, Symbol.FOUR), new Card(Color.RED, Symbol.FIVE), new Card(Color.RED, Symbol.SIX), new Card(Color.RED, Symbol.SEVEN), new Card(Color.RED, Symbol.EIGHT), new Card(Color.RED, Symbol.NINE), new Card(Color.RED, Symbol.ONE), new Card(Color.RED, Symbol.TWO), new Card(Color.RED, Symbol.THREE), new Card(Color.RED, Symbol.FOUR), new Card(Color.RED, Symbol.FIVE), new Card(Color.RED, Symbol.SIX), new Card(Color.RED, Symbol.SEVEN), new Card(Color.RED, Symbol.EIGHT), new Card(Color.RED, Symbol.NINE),
        new Card(Color.RED, Symbol.SKIP), new Card(Color.RED, Symbol.REVERSE), new Card(Color.RED, Symbol.DRAW_TWO), new Card(Color.RED, Symbol.SKIP), new Card(Color.RED, Symbol.REVERSE), new Card(Color.RED, Symbol.DRAW_TWO),

        new Card(Color.GREEN, Symbol.ZERO), new Card(Color.GREEN, Symbol.ONE), new Card(Color.GREEN, Symbol.TWO), new Card(Color.GREEN, Symbol.THREE), new Card(Color.GREEN, Symbol.FOUR), new Card(Color.GREEN, Symbol.FIVE), new Card(Color.GREEN, Symbol.SIX), new Card(Color.GREEN, Symbol.SEVEN), new Card(Color.GREEN, Symbol.EIGHT), new Card(Color.GREEN, Symbol.NINE), new Card(Color.GREEN, Symbol.ONE), new Card(Color.GREEN, Symbol.TWO), new Card(Color.GREEN, Symbol.THREE), new Card(Color.GREEN, Symbol.FOUR), new Card(Color.GREEN, Symbol.FIVE), new Card(Color.GREEN, Symbol.SIX), new Card(Color.GREEN, Symbol.SEVEN), new Card(Color.GREEN, Symbol.EIGHT), new Card(Color.GREEN, Symbol.NINE),
        new Card(Color.GREEN, Symbol.SKIP), new Card(Color.GREEN, Symbol.REVERSE), new Card(Color.GREEN, Symbol.DRAW_TWO), new Card(Color.GREEN, Symbol.SKIP), new Card(Color.GREEN, Symbol.REVERSE), new Card(Color.GREEN, Symbol.DRAW_TWO),

        new Card(Color.BLUE, Symbol.ZERO), new Card(Color.BLUE, Symbol.ONE), new Card(Color.BLUE, Symbol.TWO), new Card(Color.BLUE, Symbol.THREE), new Card(Color.BLUE, Symbol.FOUR), new Card(Color.BLUE, Symbol.FIVE), new Card(Color.BLUE, Symbol.SIX), new Card(Color.BLUE, Symbol.SEVEN), new Card(Color.BLUE, Symbol.EIGHT), new Card(Color.BLUE, Symbol.NINE), new Card(Color.BLUE, Symbol.ONE), new Card(Color.BLUE, Symbol.TWO), new Card(Color.BLUE, Symbol.THREE), new Card(Color.BLUE, Symbol.FOUR), new Card(Color.BLUE, Symbol.FIVE), new Card(Color.BLUE, Symbol.SIX), new Card(Color.BLUE, Symbol.SEVEN), new Card(Color.BLUE, Symbol.EIGHT), new Card(Color.BLUE, Symbol.NINE),
        new Card(Color.BLUE, Symbol.SKIP), new Card(Color.BLUE, Symbol.REVERSE), new Card(Color.BLUE, Symbol.DRAW_TWO), new Card(Color.BLUE, Symbol.SKIP), new Card(Color.BLUE, Symbol.REVERSE), new Card(Color.BLUE, Symbol.DRAW_TWO),

        new Card(Color.YELLOW, Symbol.ZERO), new Card(Color.YELLOW, Symbol.ONE), new Card(Color.YELLOW, Symbol.TWO), new Card(Color.YELLOW, Symbol.THREE), new Card(Color.YELLOW, Symbol.FOUR), new Card(Color.YELLOW, Symbol.FIVE), new Card(Color.YELLOW, Symbol.SIX), new Card(Color.YELLOW, Symbol.SEVEN), new Card(Color.YELLOW, Symbol.EIGHT), new Card(Color.YELLOW, Symbol.NINE), new Card(Color.YELLOW, Symbol.ONE), new Card(Color.YELLOW, Symbol.TWO), new Card(Color.YELLOW, Symbol.THREE), new Card(Color.YELLOW, Symbol.FOUR), new Card(Color.YELLOW, Symbol.FIVE), new Card(Color.YELLOW, Symbol.SIX), new Card(Color.YELLOW, Symbol.SEVEN), new Card(Color.YELLOW, Symbol.EIGHT), new Card(Color.YELLOW, Symbol.NINE),
        new Card(Color.YELLOW, Symbol.SKIP), new Card(Color.YELLOW, Symbol.REVERSE), new Card(Color.YELLOW, Symbol.DRAW_TWO), new Card(Color.YELLOW, Symbol.SKIP), new Card(Color.YELLOW, Symbol.REVERSE), new Card(Color.YELLOW, Symbol.DRAW_TWO),

        new Card(Color.WILD, Symbol.WILD), new Card(Color.WILD, Symbol.DRAW_FOUR), new Card(Color.WILD, Symbol.WILD), new Card(Color.WILD, Symbol.DRAW_FOUR), new Card(Color.WILD, Symbol.WILD), new Card(Color.WILD, Symbol.DRAW_FOUR), new Card(Color.WILD, Symbol.WILD), new Card(Color.WILD, Symbol.DRAW_FOUR)
        };
        private static List<Card> deck = new List<Card>();

        public Deck()
        {
            Console.WriteLine("Creating and Shuffling Deck...");
            deck = Shuffle();
            Console.WriteLine("Deck Created and Shuffled!");
        }


        public List<Card> Shuffle()
        {
            Random rand = new Random();
            List<Card> shuffledDeck = cards.ToList(); // Copy original deck

            for (int i = shuffledDeck.Count - 1; i > 0; i--)
            {
                //swaps cards with a random index that has already been added which shuffles the deck faster but less randomly
                int j = rand.Next(0, i + 1); 
                Card temp = shuffledDeck[i];
                shuffledDeck[i] = shuffledDeck[j];
                shuffledDeck[j] = temp;
            }

            return shuffledDeck;
        }

    }
}