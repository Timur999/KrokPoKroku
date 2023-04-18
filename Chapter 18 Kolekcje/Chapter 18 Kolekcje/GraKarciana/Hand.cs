using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.GraKarciana
{
    internal class Hand
    {
        internal int HandSize { get; }

        private List<PlayingCard> cardsInHand { get; } = new List<PlayingCard>();

        public Hand(int handSize)
        {
          this.HandSize = handSize;
        }

        public void AddCardToHand(PlayingCard card)
        {
            if(cardsInHand.Count < HandSize)
            {
                cardsInHand.Add(card);
            }
        }

        public void ShowCards()
        {
            foreach(var card in cardsInHand)
            {
                Console.WriteLine(card);
            }
        }
    }
}
