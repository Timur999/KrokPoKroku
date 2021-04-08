using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model
{
    class Kostka : Bryla, IOblicz, IRuch, IPozycja
    {
        private double dlugoscKrawedzA;
        private double dlugoscKrawedzB;
        private double dlugoscKrawedzC;

        public Kostka() :base() { }

        public Kostka(double A, double B, double C, PozycjaNaOsi pozycja)
        {
            this.dlugoscKrawedzA = A;
            this.dlugoscKrawedzB = B;
            this.dlugoscKrawedzC = C;
            this.pozycjaNaOsi = pozycja;
        }

        // Jawnie zaimplementowany interferjs. Metoda jest dostępna tylko dla obiektu zapisanego w zmiennej o typie 'IRuch'
        decimal IRuch.ObliczDystansDo(Bryla bryla)
        {
            return 0;
        }

        // Jawnie zaimplementowany interferjs. Metoda jest dostępna tylko dla obiektu zapisanego w zmiennej o typie 'IOblicz'
        decimal IOblicz.ObliczDystansDo(Bryla bryla)
        {
            return 0;
        }

        public double ObliczObjetosc()
        {
            return dlugoscKrawedzA * dlugoscKrawedzB * dlugoscKrawedzC;
        }

        public decimal WykonajRuch(PozycjaNaOsi poz)
        {
            throw new NotImplementedException();
        }

        public override double ObliczObwod()
        {
            return 2 * dlugoscKrawedzA + 2 * dlugoscKrawedzB;
        }

        // Metoda zamknięta. Klasa pochodna nie dziedziczy tej metody.
        public sealed override void PobierzNazwe()
        {
            Console.WriteLine("Kostka");
        }
    }
}
