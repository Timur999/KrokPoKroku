using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.GraKarciana
{
    internal class TableForPlayingCards
    {
        private List<Hand> hands;

        private Pack pack;

        internal TableForPlayingCards(int handsNumber, int handSize)
        {
            hands = new List<Hand>(handsNumber);
            for(int i = 0; i < handsNumber; i++)
            {
                hands.Add(new Hand(handSize));
            }
            pack = new Pack();
        }

        public void Deal()
        {
            foreach (var hand in hands)
            {
                for(var i = 0; i < hand.HandSize; i++)
                {
                    var card = pack.DealCardFromPack();
                    hand.AddCardToHand(card);
                }
            }
        }

        public void ShowAll()
        {
            foreach(var hand in hands)
            {
                hand.ShowCards();
                Console.WriteLine();
            }
        }

        public void Play()
        {
            TableForPlayingCards tableforPlayingCards = new TableForPlayingCards(4, 13);
            tableforPlayingCards.Deal();
            tableforPlayingCards.ShowAll();
        }
    }
}
