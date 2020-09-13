using System;

namespace Chapter_10_TabliceArrays.Cards
{
    class Player
    {
        public const int MaxCardInHand = 13;
        private PlayingCard[] _playingCardsPerPlayer = new PlayingCard[MaxCardInHand];
        private int _playingCardsCounter = 0;

        public void AddPlayerCard(PlayingCard card)
        {
            if(_playingCardsCounter >= MaxCardInHand)
            {
                throw new ArgumentException("Too many cards!");
            }
            _playingCardsPerPlayer[_playingCardsCounter++] = card;
        }

        public void Check()
        {
            foreach(PlayingCard card in _playingCardsPerPlayer)
            {
                Console.Write($"{card}; ");
            }
            Console.WriteLine("\n");
        }
    }
}
