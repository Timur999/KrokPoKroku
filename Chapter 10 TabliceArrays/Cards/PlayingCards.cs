
namespace Chapter_10_TabliceArrays.Cards
{
    enum Value { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }
    enum Suit { Clubs, Diamonds, Hearts, Spades }

    class PlayingCard
    {
        //readonly mozemy przypisac wartosc tylko podczas deklaracji lub w konstruktorze.
        private readonly Value _cardValue;
        private readonly Suit _cardSuit;

        public Value CardsValue { get { return _cardValue; } }
        public Suit CardsSuit { get {return _cardSuit; } }
        public PlayingCard(Value cardValue, Suit cardSuit)
        {
            this._cardValue = cardValue;
            this._cardSuit = cardSuit;
        }

        public override string ToString()
        {
            return $"{_cardValue} {_cardSuit}";
        }
    }
}
