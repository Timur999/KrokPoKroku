using Classies.Model;
using System.Collections.Generic;

namespace Chapter_7_Tworzenie_zarzadzanie_klasami_i_obiektami.Model
{
    static class Mapa
    {
        private static List<Punkt> punkty;

        static Mapa()
        {
            punkty = new List<Punkt>();
        }

        public static void DodajPunktNaMapie(Punkt punkt)
        {
            punkty.Add(punkt);
        }

        public static List<Punkt> PobierzPunkty()
        {
            return punkty;
        }
    }
}
