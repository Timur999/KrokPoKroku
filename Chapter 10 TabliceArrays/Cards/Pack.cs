
using System;

namespace Chapter_10_TabliceArrays.Cards
{
    class Pack
    {
        public const int numOfCard = 52;
        private PlayingCard[] _cardPack;

        public Pack()
        {
            _cardPack = new PlayingCard[numOfCard];
            InitalizePackOfCard();
        }

        private void InitalizePackOfCard()
        {
            int index = 0;
            for(Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for(Value val = Value.Two; val <= Value.Ace; val++)
                {
                    _cardPack[index++] = new PlayingCard(val, suit);
                }
            }
        }

        public PlayingCard[] GetPackCard()
        {
            return _cardPack;
        }

        public PlayingCard DealCardFromPack()
        {
            Random rand = new Random();
            int randIndex = rand.Next(numOfCard);
            while (this.isCardAlreadyDealt(randIndex))
            {
                randIndex = rand.Next(numOfCard);
            }
            PlayingCard card = _cardPack[randIndex];
            _cardPack[randIndex] = null;
            
            return card;
        }

        private bool isCardAlreadyDealt(int randIndex)
        {
            if(this._cardPack[randIndex] == null)
            {
                return true;
            }
            return false;
        }

        // Opytmalizacja metody isCardAlreadyDealt  
        private bool isCardAlreadyDealtOptm(int randIndex) => (this._cardPack[randIndex] == null);
    }
}
