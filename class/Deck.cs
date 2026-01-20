using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Collections;

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

    public Deck()
    {

    }

    public ArrayList<Card> Shuffle()
    {
        Random rand = new Random();

        int n = cards.Length;
        ArrayList<Card> shuffledDeck = new ArrayList<Card>();
        int[] numArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            //making sure there are no duplicates
            int randNum = rand.Next(0, n);
            while (numArray.Contains(randNum))
            {
                randNum = rand.Next(0, n);
            }

            numArray[i] = randNum;
            shuffledDeck.Add(cards[randNum]);
        }
        return shuffledDeck;
    }
}