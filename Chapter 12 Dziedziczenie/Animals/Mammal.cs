using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Mammal
    {
        private string Name;
        public Mammal() { }
        public Mammal(string name) { this.Name = name; }
        public void MyName()
        {
            Console.WriteLine(Name);
        }

        // Metoda która w założeniu ma zostać przesłonieta nazywamy metodą 'wirtualną'.
        // 1. Metoda 'wirtualna' nie mogą byc prywatne.
        // 2. Sygnatury metod virtual i override muszą byc identyczne ponadto muszą zwracać wartość tego samego typu.
        // 3. Jesli metoda w klasa pochodnej nie uzywa overide na metodzie virtualnej to ją ukrywa, przykład klasa Horse.
        // 4. Metoda przesłaniająca (zadeklarowana z słowem kluczowym override) niejawnie sama jest wirtualna.
        // Inaczej mówiąc może zostać przesłonięta przez klase pochodną. Istnieje również możliwość zadeklarowania jawnie tej metody.
        public virtual void Speaking()
        {
            Console.WriteLine("Jestem Ssakiem");
        }

        public virtual void Eating()
        {
            Console.WriteLine("Jem jem jem");
        }

        public virtual void Breathing()
        {
            Console.Write("Wdech");
            Console.Write("Uplyneła minuta");
            Console.Write("Wydech");
        }
    }
}
