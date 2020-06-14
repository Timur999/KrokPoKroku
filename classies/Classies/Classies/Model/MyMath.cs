using System;

namespace Classies.Model
{
    // klasa statyczna może posiadac wyłącznie pola i metody statyczne. Służy jako kontener potrzebnych pól i metod.
    static class MyMath
    {
        public const double PI = 3.1415978254765454;
        public static Point point;

        public static double Sin(double x)
        {
            return x;
        }


        // Jeśli istnieje potrzeba zaincjowania pewnych pól można utworzyć konstruktor domyślny inne konstruktory są niedozwolone (Nie może mieć jawnie zdefiniowanego identyfikatora dostępu)
        static MyMath()
        {
            point = new Point();
        }
    }
}
