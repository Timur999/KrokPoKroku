using System;

namespace Chapter_7_Tworzenie_zarzadzanie_klasami_i_obiektami.Model
{
    class Kwadrat
    {
        private Kwadrat KwadratBliziak;
        private float dlugoscBoku = 0f;

        private Kwadrat()
        {
            Console.WriteLine("Wywołanie konstruktora prywatnego!");
        }

        public Kwadrat(float dlugoscBoku)
        {
            this.dlugoscBoku = dlugoscBoku;
        }

        public Kwadrat KlonujKwadrat()
        {
            KwadratBliziak = new Kwadrat();
            KwadratBliziak.dlugoscBoku = this.dlugoscBoku;

            return KwadratBliziak;
        }
    }
}
