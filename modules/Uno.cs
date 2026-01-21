namespace UnoButNot.Modules
{
    //This method should be used to handle the game and should have no methods that handle game logic. 
    //This should only make the game run as it should and call all the methods from another class.

    //these import stuff so I can use arrayList
    using System.Xml.Serialization;
    using System.Collections.Generic;
    public class Uno
    {
        //this List will hold the players and each unique number represents a player.
        //we should loop through this for the order of players for each turn
        List<int> players = new List<int>();
        //This method should start the game and call all the methods needed to run the game.
        public void StartGame()
        {
            Deck deck = new Deck();
            System.Console.WriteLine("Game Started!");
            //We need to ask how many players there will be
        }
    }
}