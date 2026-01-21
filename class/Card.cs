namespace UnoButNot.@class
{
    using UnoButNot.Enums;
    public class Card
    {
        public Color cardColor;
        public Symbol cardValue;

        public Card(Color color, Symbol value)
        {
            cardColor = color;
            cardValue = value;
        }
    }
}