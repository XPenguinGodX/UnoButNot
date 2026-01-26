namespace UnoButNot.modules
{
    //This method should be used to handle the game and should have no methods that handle game logic. 
    //This should only make the game run as it should and call all the methods from another class.

    //these import stuff so I can use arrayList
    using System.Collections.Generic;
    using UnoButNot.@class;
    using UnoButNot.Enums;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using GameUI.views;

    public class Uno
    {
        private void DebugState(string message)
{
    Console.WriteLine("\n--- " + message + " ---");
    Console.WriteLine($"Top Card: {topCard.cardColor} {topCard.cardValue}");
    Console.WriteLine($"Active Color: {activeColor}");
    Console.WriteLine($"Current Player: {players[currentPlayerIndex].playerID}");
    Console.WriteLine($"Direction: {(direction == 1 ? "Clockwise" : "Counter-Clockwise")}");
}

        //this List will hold the players and each unique number represents a player.
        //we should loop through this for the order of players for each turn
        List<Player> players = new List<Player>();
        Player currentPlayer = null;
        GUI ui = new GUI();

        private int currentPlayerIndex = 0;
        private int direction = 1;
        private Card topCard;
        private Color activeColor;
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
            for (int i = 0; i < 7; i++)
            {
                foreach (Player p in players)
                {
                DrawCards(p, deck.Cards, 1);
                }
            }
            topCard = deck.Cards[0];
            deck.Cards.RemoveAt(0);
            activeColor = topCard.cardColor;


            while(!winGame(players))
            {
                
            Player current = players[currentPlayerIndex];

            bool turnComplete = false;

            while (!turnComplete)
            {
                Card chosen = ui.GetPlayerMove(current, topCard);

               if (chosen == null) // player chose to draw
                {
                    DrawCards(current, deck.Cards, 1);
                    turnComplete = true;
                }
                else if (CanPlayCard(chosen))
                {
                    PlayCard(current, chosen, deck.Cards);
                    turnComplete = true;
                }
                else
                {
                    ui.ShowMessage("Invalid card! You must play a card that matches the color, value, or is a Wild.");
                }
            }
            AdvanceTurn();
        }
        ui.ShowMessage("Game Over! We have a winner!");
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

        private void AdvanceTurn(int skip = 0)
        { 
            currentPlayerIndex =
                (currentPlayerIndex + direction * (1 + skip) + players.Count) % players.Count;
        }
        private void DrawCards(Player player, List<Card> deck, int count)
        {
        for (int i = 0; i < count; i++)
        {
        if (deck.Count == 0) return;
        player.playerHand.Add(deck[0]);
        deck.RemoveAt(0);
        }
        }

    private void ApplyCardEffect(Card card, List<Card> deck)
    {
    switch (card.cardValue)
    {
        case Symbol.SKIP:
            AdvanceTurn(skip: 1);
            break;

        case Symbol.REVERSE:
            direction *= -1;
            if (players.Count == 2)
                AdvanceTurn(skip: 1);
            break;

        case Symbol.DRAW_TWO:
            AdvanceTurn();
            DrawCards(players[currentPlayerIndex], deck, 2);
            AdvanceTurn(); 
            break;

        case Symbol.DRAW_FOUR:
            AdvanceTurn();
            DrawCards(players[currentPlayerIndex], deck, 4);
            AdvanceTurn(); 
            break;

        case Symbol.WILD:
            activeColor = ui.ChooseColor();
            break;
    }
    }

    private bool CanPlayCard(Card card)
    {
    return card.cardColor == activeColor ||
    card.cardColor == Color.WILD ||
    card.cardValue == topCard.cardValue;
    }

    private void PlayCard(Player player, Card card, List<Card> deck)
    {
    player.playerHand.Remove(card);
    topCard = card;
    if (card.cardColor == Color.WILD)
        activeColor = ui.ChooseColor();
    else
        activeColor = card.cardColor;
    ApplyCardEffect(card, deck);
    }

}}