using System;

namespace Chapter_12_Dziedziczenie.Animals
{
    class Zebra : Horse
    {
        public Zebra(string name) : base(name) { }
        public Zebra() : base() { }

        public override void Speaking()
        {
            Console.WriteLine("Jestem Zebrą ");
        }

        public override void Breathing()
        {
            base.Breathing();
        }
    }
}
