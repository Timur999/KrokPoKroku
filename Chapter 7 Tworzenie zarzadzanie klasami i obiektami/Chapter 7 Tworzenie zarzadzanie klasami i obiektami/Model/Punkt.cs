using System;

namespace Classies.Model
{
    class Punkt
    {
        private int x, y;

        public Punkt() { }

        public Punkt(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double OdlegloscDo(Punkt punktB)
        {
            int xRoznica = this.x - punktB.x;
            int yRoznica = this.y - punktB.y;
            return Math.Sqrt(xRoznica * xRoznica + yRoznica * yRoznica);
            // Słowo kluczowe private operuje na poziomie klasy, nie obiektu. Dwie instancje tej samej klasy mają dostęp do swoich pól prywatnych. 
        }

        // Dekonstruktor służy do pobierania wartości pól obiektu. Musi sie nazywać Deconstruct, zwracac void i przyjmować outowe parametry
        public void Deconstruct(out int longi, out int lati)
        {
            longi = this.x;
            lati = this.y;
        }

        public override string ToString()
        {
            return $"{x} - {y}";
        }
    }
}
