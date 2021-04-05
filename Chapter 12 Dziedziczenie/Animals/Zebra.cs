using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Zebra : Kon
    {
        public Zebra(string name) : base(name) { }
        public Zebra() : base() { }

        public override void Mowa()
        {
            Console.WriteLine("Jestem Zebrą ");
        }

        public override void Oddychaj()
        {
            base.Oddychaj();
        }
    }
}
