using System;

namespace Drzewo_Binarne.Model
{
    /* isnieje również interface IComparable który operuje na typie object jednak nie jest to rozwiązenie bezpieczne pod kątem typu.
     * W takim przypadku w metodzie CompareTo wymagane bedzie rzutowanie do wymaganego obiekty w tym przypadku Okrąg
     * Zaleca się uzywac IComparable<T> ponieważ metoda CompareTo bedzie zawierac parametr typu Okrag a nie object.
     */
    internal class Okrag : IComparable<Okrag>
    {
        private float radius;
        public Okrag(int radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public int CompareTo(Okrag obj)
        {
            /* Jeżeli musimy utworzyć klasę która zapewni jakiś mechanizm porównywania obiektów danej klasy zgodnie z naturalnym (albo i nienaturalnym) porządkiem,
             * to POWINNISMY zaimplementować interfejs 'IComparable'. Zawiera on metode 'CompareTo' która przyjmuje w parametrze obiekt do porównania z BIEŻĄCĄ instancją
             * i zwraca liczbe całkowitą zgodnie z poniższym opisem:
             * 
             * Mniejsza niż 0, gdy Bieżąca instancja jest mniejsza od wartości parametru,
             * 0, gdy Bieżąca instancja jest równa wartości parametru,
             * Większa niż 0, gdy Bieżąca instancja jest większa od wartości parametru,
             */

            /* W tym przypadku porównywać 2 obiekty bedziemy na podstawie pola okręgu */

            Okrag okragObj = obj;

            if (this.Area() > okragObj.Area())
            {
                return 1;
            }

            if (this.Area() == okragObj.Area())
            {
                return 0;
            }

            return -1;
        }

    }
}
