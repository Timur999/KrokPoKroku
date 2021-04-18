using System;

namespace Chapter_15_Wlasciwosci.Model
{
    struct Punkt
    {
        private int _x;
        private int _y;

        public int X
        { 
            get { return this._x; }
            set { this._x = SprawdzZakres(value, 1920); }
        }

        public int Y
        {
            get => this._y; /* Dla prostych właściwości zaleca się stosować wyrażenia wcielone */
            set { this._y = SprawdzZakres(value, 1080); } /* tu też można zastosować wyrażenie wcielone ale nic nie stoi na przeszkodzie by to mixować. */
        }

        private int SprawdzZakres(int wartosc, int maxZakres)
        {
            if(wartosc < 0 || wartosc > maxZakres)
            {
                throw new ArgumentException("Punkt: Wartość poza zakresu");
            }

            return wartosc;
        }
    }
}
