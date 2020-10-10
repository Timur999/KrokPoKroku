using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Horse : Mammal
    {
        string Name;
        public Horse(string name) : base(name) 
        { 
            this.Name = name;
        }

        // Nie jawnie wywołanie domyślnego kostruktora klasy bazowej. 
        public Horse() { } // Kopilator: public Horse() : base(){ } 

        public void PutSaddle() { }

        // Słowo kluczowe 'new' w tym przypadku nie eliminuje zjawiska ukrywania.
        // Jest to informacja, że jesteśmy pewni, że chcemy mieć dwie niezależne metody.
        // Bez słowa kluczowego 'new', kod zostanie skompilowany ale z odpowiednim warningiem. 
        // Metoda Horse.MyName() ukrywa odziedziczoną metode MyName() z klasy Mammal.
        public new void MyName() // Metoda ukryta.
        {
            Console.WriteLine("Mieszkam w stajni.");
        }

        // Wykonuje te same zadanie co metoda virtualna ale w sposób zależny od tej klasy.
        public override void Speaking() 
        {
            Console.WriteLine("Jestem Koniem ");
        }

        // Nie użycie override na metodzie wirtualnej oznacza, że zostanie ukryta.
        public void Eating()
        {
            Console.WriteLine("Pije pije pije");
        }

        // Jawnie zdefiniowanie metody przesłonętej, jako virtualna.
        // Nie trzeba tego robic. Metodę override również możemy przesłaniać.
        public virtual void Breathing()
        {
            Console.Write("Wdech");
            Console.Write("Uplyneło 5 sekund");
            Console.Write("Wydech");
        }

    }
}
