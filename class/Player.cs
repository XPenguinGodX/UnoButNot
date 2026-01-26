namespace UnoButNot.@class
{
    public class Player
    {
        public int playerID;
        public List<Card> playerHand;

        public Player(int id)
        {
            playerID = id;
            playerHand = new List<Card>();
        }

        public int getID()
        {
            return playerID;
        }
    }
}