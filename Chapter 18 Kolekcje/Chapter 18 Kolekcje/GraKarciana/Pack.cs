using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_18_Kolekcje.GraKarciana
{
    internal class Pack
    {
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;

        public Dictionary<Suits, List<PlayingCard>> CardPack { get; }

        private Random randomCardSelector = new Random();

        internal Pack()
        {
            CardPack = new Dictionary<Suits, List<PlayingCard>>(NumSuits);

            for (Suits suit = Suits.Club; suit <= Suits.Diamond; suit++)
            {
                List<PlayingCard> cardsInSuit = new List<PlayingCard>(CardsPerSuit);
                for (CardValue value = CardValue.Two; value <= CardValue.Ace; value++)
                {
                    cardsInSuit.Add(new PlayingCard(suit, value));
                }
                CardPack.Add(suit, cardsInSuit);
            }

            //foreach (Suits suit in Enum.GetValues(typeof(Suits))) { }
        }

        public PlayingCard DealCardFromPack()
        {
            Suits randomSuit = (Suits)randomCardSelector.Next(Pack.NumSuits);
            while (IsSuitEmpty(randomSuit))
            {
                randomSuit = (Suits)randomCardSelector.Next(Pack.NumSuits);
            }

            CardValue randomValue = (CardValue)randomCardSelector.Next(Pack.CardsPerSuit);
            while (IsCardAlreadyDealed(randomSuit, randomValue))
            {
                randomValue = (CardValue)randomCardSelector.Next(Pack.CardsPerSuit);
            }

            var cardsInSuit = CardPack[randomSuit];
            var card = cardsInSuit.FirstOrDefault(c => c.Value == randomValue);
            cardsInSuit.Remove(card);

            return card;
        }

        private bool IsCardAlreadyDealed(Suits suit, CardValue value)
        {
            var cardsInSuit = CardPack[suit];

            return !cardsInSuit.Exists(c => c.Suit == suit && c.Value == value);
        }

        private bool IsSuitEmpty(Suits suit) => CardPack[suit].Count == 0;
    }

    internal class PlayingCard
    {
        public Suits Suit { get; }
        public CardValue Value { get; }

        internal PlayingCard(Suits suit, CardValue cardValue)
        {
            Suit = suit;
            Value = cardValue;
        }

        public override string ToString()
        {
            return $" {Value} of {Suit}s ";
        }
    }

    enum Suits
    {
        Club,
        Spade,
        Heart,
        Diamond
    }

    enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
