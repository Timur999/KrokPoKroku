using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Kon : Ssak
    {
        string Nazwa;
        public Kon(string nazwa) : base(nazwa) 
        { 
            this.Nazwa = nazwa;
        }

        // Nie jawnie wywołanie domyślnego kostruktora klasy bazowej. 
        public Kon() { } // Kopilator: public Horse() : base(){ } 

        public void ZaluzSiodlo() { }

        // Słowo kluczowe 'new' w tym przypadku nie eliminuje zjawiska ukrywania.
        // Jest to informacja, że jesteśmy pewni, że chcemy mieć dwie niezależne metody.
        // Bez słowa kluczowego 'new', kod zostanie skompilowany ale z odpowiednim warningiem. 
        // Metoda Kon.PobierzImie() ukrywa odziedziczoną metode PobierzImie() z klasy Ssak.
        // W konsekwencji gdy klasa kon stanie się klasą bazową dla innej klasy np. Zebra to metoda PobierzImie() z klasy 'Ssak' nie bedzie widoczna tylko z klasy 'Kon'. 
        public new void PobierzImie() // Metoda ukryta.
        {
            Console.WriteLine("Lubie biegac!");
        }

        // Wykonuje te same zadanie co metoda virtualna z klasy Ssak ale w sposób zależny od tej klasy.
        public override void Mowa() 
        {
            Console.WriteLine("Jestem Koniem ");
        }

        // Nie użycie override na metodzie wirtualnej oznacza, że zostanie ukryta.
        public void Jedz()
        {
            Console.WriteLine("Pije pije pije");
        }

        // Jawnie zdefiniowanie metody przesłonętej, jako wirtualna jest nie prawidłowe. Kompilator podpowiada, że jest to ukrywanie metody.
        public virtual void Oddychaj()
        {
            Console.Write("Wdech");
            Console.Write("Uplyneło 5 sekund");
            Console.Write("Wydech");
        }

    }
}
