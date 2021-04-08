using System;

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model
{
    abstract class Bryla
    {
        protected PozycjaNaOsi pozycjaNaOsi;

        private string nazwaBryly;

        public Bryla() { Console.WriteLine("Tworze bryłe."); }

        public abstract double ObliczObwod();

        public virtual void PobierzNazwe()
        {
            Console.WriteLine("Bryła");
        }

        public void UstawPozycje(PozycjaNaOsi pozycjaNaOsi) 
        {
            this.pozycjaNaOsi = pozycjaNaOsi;
        }
    }
}
