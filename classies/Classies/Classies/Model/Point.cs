using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classies.Model
{
    class Point
    {
        // pola w klasie są inicjowane domyślną wartością: 0, false, null zależnie od typu pola. 
        // pola public powinny zaczynać się z Dużej litery 
        public int Longitude;

        // pola private powinny zaczynać się z małej litery lub z prefixem podkreślinka '_' a metody z małej.
        private int latitude;

        public Point()
        {

        }

        public Point(int longi, int lati)
        {
            this.Longitude = longi;
            this.latitude = lati;
        }

        public void GetPointValue()
        {
            // zmienne w deklarowane w metodach nie są inicjowane domyślną wartością.
            int a;

            // Use of unssigned local variable.
            // Console.WriteLine(a);
        }

        // Metoda instancji nazywamy gdy metoda operuje wyłącznie na danych konkretnej instancji klasy. (Pole statyczne jest częscią wspólną wszystkich instancji klasy)
        public void DisplayPoint()
        {
            Console.WriteLine($"x: {0} - y: {1}", Longitude, latitude);
        }

        public double DistanceTo(Point other)
        {
            int longiDiff = this.Longitude - other.Longitude;

            // latitude jest polem prywatnym. Słowo kluczowe private operuje na poziomie klasy, nie obiektu. Dwie instancje tej samej klasy mają dostęp do swoich pól prywatnych. 
            int latiDiff = this.latitude - other.latitude;
            double distance = Math.Sqrt(Math.Pow(longiDiff, 2) + Math.Pow(latiDiff, 2));

            return distance;
        }

        // Dekonstruktor służy do pobierania wartości z pól obiektu. Musi sie nazywać Deconstruct zwracac void i przyjmować outowe parametry
        public void Deconstruct(out int longi, out int lati)
        {
            longi = this.Longitude;
            lati = this.latitude;
        }


        // Notice: Nie należy deklarować 2 takich samych pól lub metod różniących się tylko wielkością liter. 
        // Uniemożliwi do integracej klasy z programami / rozwiązaniami, które zostały napisane w jezykach których nie rozrózniają wielkość liter takich jak Visual Basic.
    }
}
