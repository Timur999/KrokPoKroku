
namespace Chapter_15_Wlasciwosci.Model
{
    enum Kolor : byte
    {
        Czerwony, Zielony, Niebieski
    }

    interface IKolor
    {
        /* Powszechną praktyką jest nadawnie właściwością nazw zgodnie z nazwą ich typu */
        Kolor Kolor { get; set; }
    }

    class Kwadrat : IKolor
    {
        private Kolor _kolor;
        public Kolor Kolor { get { return this._kolor; } set { _kolor = value; } }
    }

    class Prosokat : IKolor
    {
        private Kolor _kolor;
        public virtual Kolor Kolor { get { return this._kolor; } set { _kolor = value; } }
    }

    class Trójkat : IKolor
    {
        private Kolor _kolor;

        // jawnie zaimplementowana właściwość interfejsu nie może być wirtualna
        Kolor IKolor.Kolor
        {
            get { return this._kolor; }
            set { _kolor = value; }
        }
    }

    class Kolo 
    {
        private Kolor _kolor;
        private int _promien;
        private int _x;
        private int _y;
        public Kolor Kolor => this._kolor;
        public int Promien { set => _promien = value; }
        public int X { set => _x = value; }
        public int Y { set => _y = value; }

        public Kolo()
        {
            this._kolor = Kolor.Czerwony;
        }

        public Kolo(Kolor kolor)
        {
            this._kolor = kolor;
        }
    }
}