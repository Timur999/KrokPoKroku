using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Mammal
    {
        private string Name;
        public Mammal() { }
        public Mammal(string name) { this.Name = name; }
        public void Breathing() { }
        public void Eating() { }
        public void Speaking()
        {
            Console.WriteLine("Jestem Ssakiem");
        }
        public virtual void MyName()
        {
            Console.WriteLine(Name);
        }
    }
}
