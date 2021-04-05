using System;

namespace Chapter_12_Dziedziczenie.Animals
{

    class Ssak : System.Object
    {
        private string Nazwa;

        public Ssak() { }
        public Ssak(string nazwa) { this.Nazwa = nazwa; }

        public void PobierzImie()
        {
            Console.WriteLine(Nazwa);
        }

        // Metoda która w założeniu ma zostać przesłonieta nazywamy metodą 'wirtualną'.
        // 1. Metoda 'wirtualna' nie może być prywatna. Podobnie metody ovveride, ponieważ klasa pochodna nie może zmianiać poziomu ochrnony odziedziczonej metody.        
        // 2. Sygnatury metod virtual i override muszą byc identyczne, ponadto muszą zwracać wartość tego samego typu.
        // 3. Jeśli metoda w klasa pochodnej nie używa override na metodzie virtualnej to ją ukrywa. Przykład w klasie Kon.
        // 4. Metoda przesłaniająca (zadeklarowana z słowem kluczowym override) niejawnie sama jest wirtualna.
        // Inaczej mówiąc metoda override może zostać przesłonięta przez klase pochodną. Nie jest możliwe zadeklarowania jawnie tej metody jako wirtualnej.
        public virtual void Mowa()
        {
            Console.WriteLine("Jestem Ssakiem");
        }

        public virtual void Jedz()
        {
            Console.WriteLine("Jem jem jem");
        }

        public virtual void Oddychaj()
        {
            Console.WriteLine("Wdech");
            Console.WriteLine("Uplyneła minuta");
            Console.WriteLine("Wydech");
        }

        public override string ToString()
        {
            string tekstZBazowki = base.ToString();

            return "Moj tekst " + tekstZBazowki;
        }
    }
}
