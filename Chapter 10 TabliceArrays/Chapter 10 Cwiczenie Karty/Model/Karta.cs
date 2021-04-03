
namespace Chapter_10_Cwiczenie_Karty.Model
{
    struct Karta
    {
        public Kolor kolor { get; }
        public string nazwa { get; }

        public Karta(Kolor _kolor, string _nazwa)
        {
            this.kolor = _kolor;
            this.nazwa = _nazwa;
        }

        public override string ToString()
        {
            return $"{nazwa} {kolor}";
        }
    }
}
