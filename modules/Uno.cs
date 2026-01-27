namespace UnoButNot.modules
{
    using System;
    using System.Collections.Generic;
    using UnoButNot.@class;
    using UnoButNot.Enums;
    using GameUI.views;

    public class Uno
    {
        
        private readonly List<Player> players = new List<Player>();
        private readonly GUI ui = new GUI();

        
        private int currentPlayerIndex = 0;
        private int direction = 1; 

        
        private Card topCard;
        private Color activeColor;

        
        private readonly List<Card> discardPile = new List<Card>();

        public void StartGame()
        {
            ui.Clear();
            ui.DisplayWelcome();

            Deck deckObj = new Deck();
            List<Card> drawPile = deckObj.Cards;

            int numPlayers = ui.getPlayerCount();

            players.Clear();
            for (int i = 1; i <= numPlayers; i++)
                players.Add(new Player(i));

            
            for (int i = 0; i < 7; i++)
            {
                foreach (Player p in players)
                    DrawCards(p, drawPile, 1);
            }

            
            SetStartingTopCard(drawPile);

            while (true)
            {
                Player current = players[currentPlayerIndex];
                bool playedCard = false;
                bool turnComplete = false;
                while (!turnComplete)
                {
                    Card? chosen = ui.GetPlayerMove(current, topCard);

                    if (chosen == null)
                    {
                        DrawCards(current, drawPile, 1);
                        turnComplete = true;
                    }
                    else if (CanPlayCard(chosen))
                    {
                        int skip = PlayCard(current, chosen, drawPile);
                        if (current.playerHand.Count == 0)
                        {
                            ui.ShowMessage($"Game Over! Player {current.playerID} wins!");
                            return;
                        }

                        AdvanceTurn(skip);
                        playedCard = true;
                        turnComplete = true;
                    }
                    else
                    {
                        ui.ShowMessage("Invalid card! You must match color/value or play a Wild.");
                    }
                }

                
                if (!playedCard)
                {
                    AdvanceTurn();
                }
            }
        }

        private void SetStartingTopCard(List<Card> drawPile)
        {
            while (true)
            {
                RefillDeckIfEmpty(drawPile);

                topCard = drawPile[0];
                drawPile.RemoveAt(0);

                
                bool isActionOrWild =
                    topCard.cardColor == Color.WILD ||
                    topCard.cardValue == Symbol.SKIP ||
                    topCard.cardValue == Symbol.REVERSE ||
                    topCard.cardValue == Symbol.DRAW_TWO ||
                    topCard.cardValue == Symbol.DRAW_FOUR;

                if (!isActionOrWild)
                {
                    activeColor = topCard.cardColor;
                    return;
                }

                
                discardPile.Add(topCard);
            }
        }

        private void AdvanceTurn(int skip = 0)
        {
            currentPlayerIndex =
                (currentPlayerIndex + direction * (1 + skip) + players.Count) % players.Count;
        }

        private void DrawCards(Player player, List<Card> drawPile, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RefillDeckIfEmpty(drawPile);
                if (drawPile.Count == 0) return;

                player.playerHand.Add(drawPile[0]);
                drawPile.RemoveAt(0);
            }
        }

        private void RefillDeckIfEmpty(List<Card> drawPile)
        {
            if (drawPile.Count > 0) return;
            if (discardPile.Count == 0) return;
            drawPile.AddRange(discardPile);
            discardPile.Clear();
            ShuffleInPlace(drawPile);
        }

        private void ShuffleInPlace(List<Card> list)
        {
            Random rand = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                Card temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private bool CanPlayCard(Card card)
        {
            return card.cardColor == activeColor ||
                   card.cardColor == Color.WILD ||
                   card.cardValue == topCard.cardValue;
        }

        private int ApplyCardEffect(Card card, List<Card> drawPile)
        {
            switch (card.cardValue)
            {
                case Symbol.SKIP:
                    return 1;

                case Symbol.REVERSE:
                    direction *= -1;
                    
                    if (players.Count == 2)
                        return 1;
                    return 0;

                case Symbol.DRAW_TWO:
                    
                    int nextIdx2 = (currentPlayerIndex + direction + players.Count) % players.Count;
                    DrawCards(players[nextIdx2], drawPile, 2);
                    return 1;

                case Symbol.DRAW_FOUR:
                   
                    activeColor = ui.ChooseColor();
                    int nextIdx4 = (currentPlayerIndex + direction + players.Count) % players.Count;
                    DrawCards(players[nextIdx4], drawPile, 4);
                    return 1;

                case Symbol.WILD:
                    activeColor = ui.ChooseColor();
                    return 0;
            }

            return 0;
        }

       
        private int PlayCard(Player player, Card card, List<Card> drawPile)
        {
            player.playerHand.Remove(card);

     
            if (topCard != null)
                discardPile.Add(topCard);

            topCard = card;

            if (card.cardColor == Color.WILD)
                activeColor = ui.ChooseColor();
            else
                activeColor = card.cardColor;

            return ApplyCardEffect(card, drawPile);
        }
    }
}
