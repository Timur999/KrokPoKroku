using System;

namespace Classies.Model
{
    /* Klasa statyczna!
     * Może posiadac wyłącznie pola i metody statyczne! Służy jako kontener użytkowych pól i metod.
     * Aby uzywać zmiennych satycznych lub metod nie trzeba tworzyć instancji danej klasy. 
     * np. MyMath.Sin(10);
     */
    static class MyMath
    {
        public static Point Point;

        /* 'const' również jest polem statycznym.
         * Polami const mogą być wyłącznie zmienne niereferencyjne t.j. (liczbowe(int, float, ..), string, typy wyliczeniowe (enum)) 
         */
        public const double PI = 3.1415978254765454;

        // O metodach statycznych można powiedzieć, że są to metody klas. O polach statycznych mowimy poprostu pole/zmienna statycznych.
        public static double Sin(double x)
        {
            return x;
        }

        /* Jeśli istnieje potrzeba zaincjowania pewnych pól w klasie statycznej, możnemy utworzyć konstruktor domyślny.
         * Inne konstruktory są niedozwolone.
         * Konstuktor w klasie statycznej nie może mieć jawnie zdefiniowanego identyfikatora dostępu.
         * np. public static MyMath() - błąd; static MyMath(int a) - błąd
         */
        static MyMath()
        {
            Point = new Point(0, 0);
        }
    }
}
