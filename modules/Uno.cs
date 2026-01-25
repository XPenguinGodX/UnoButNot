namespace UnoButNot.modules
{
    //This method should be used to handle the game and should have no methods that handle game logic. 
    //This should only make the game run as it should and call all the methods from another class.

    //these import stuff so I can use arrayList
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using UnoButNot.@class;
    using System.IO;
    using System;
    using GameUI.views;

    public class Uno
    {
        //this List will hold the players and each unique number represents a player.
        //we should loop through this for the order of players for each turn
        List<Player> players = new List<Player>();
        GUI ui = new GUI();
        //This method should start the game and call all the methods needed to run the game.
        public void StartGame()
        {
            ui.Clear();
            ui.DisplayWelcome();
            Deck deck = new Deck();
            
            int numPlayers = 0;
            while(numPlayers <= 0 || numPlayers > 4)
                numPlayers= ui.getPlayerCount();
            for (int i = 1; i <= numPlayers; i++)
            {
                players.Add(new Player(i));
            }
            //give each player 7 cards right here (not the while loop)

            while(!winGame(players))
            {
                
            }
            //We need to ask how many players there will be
        }
        private bool winGame(List<Player> players)
        {
            foreach (Player p in players)
            {
                if (p.playerHand.Count == 0)
                    return true;
            }
            return false;
        }
    }
}