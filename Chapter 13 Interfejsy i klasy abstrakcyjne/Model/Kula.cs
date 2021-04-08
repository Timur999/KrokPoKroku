using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model
{
    class Kula : Bryla, IRuch, IOblicz, IPozycja
    {
        private double promien;

        // Niejawnie zaimplementowany interferjs. Metoda jest dostępna dla obiektu o typie 'IRuch', 'IOblicz' oraz 'Kula'.
        public decimal ObliczDystansDo(Bryla bryla)
        {
            throw new NotImplementedException();
        }

        public double ObliczObjetosc()
        {
            throw new NotImplementedException();
        }

        decimal IRuch.WykonajRuch(PozycjaNaOsi poz)
        {
            throw new NotImplementedException();
        }

        public override double ObliczObwod()
        {
            return Math.PI * promien;
        }

        // Metoda zamknięta. Klasa pochodna nie dziedziczy tej metody.
        public sealed override void PobierzNazwe()
        {
            string nazwa = nazwaBryly; // pole 'nazwaBryly' jest prywatne w klasie bazowej. Nie dostępne.
            Console.WriteLine("Kula");
        }

        public bool Porownaj(Kula innaKula)
        {
            return this.promien == innaKula.promien; // pomimo, że pole 'promien' jest prywante to mamy do niej dostęp w klasie w obiekcie 'innaKula'.
        }

        public PozycjaNaOsi PobierzPozycje()
        {
            return pozycjaNaOsi; // pole 'pozycjaNaOsi' jest proteced  w klasie bazowej. Dostępne na poziome klasy, nie dostępne poza klasą.
        }

        double IOblicz.ObliczDystansDo(Bryla bryla)
        {
            if(this.pozycjaNaOsi == bryla.pozycjaNaOsi) // pomimo, że pole 'pozycjaNaOsi' jest protected to z poziomu klasy pochodnej jest nie dostępne dla obiektu z parametru.
            {
                return 0;
            }

            Kula kula = bryla as Kula;
            kula.pozycjaNaOsi;  // Teraz jest dostępne
        }
    }
}
