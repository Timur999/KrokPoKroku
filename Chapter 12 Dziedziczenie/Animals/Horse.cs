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
        // Jest to informacja: jeśteśmy pewni, że chcemy mieć 2 niezależne metody.
        // Bez 'new' kod zostanie skompilowany ale z odpowiednim warningiem. 
        // Metoda Horse.Speaking ukrywa odziedziczoną metode Speaking() z klasy Mammal.
        public new void Speaking() // Metoda przesłonięta/ukryta.
        {
            Console.WriteLine("Jestem Koniem ");
        }

        public override void MyName() // Metoda nadpisana.
        {
            Speaking();
            base.MyName();
        }
    }
}
