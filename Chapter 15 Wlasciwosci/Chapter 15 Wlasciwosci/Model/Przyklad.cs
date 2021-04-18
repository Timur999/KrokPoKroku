using System;

namespace Chapter_15_Wlasciwosci.Model
{
    interface IPrzyklad
    {
        int X { get; set; }
        int Y { get; }
        int Z { set; }
    }
    class Przyklad : IPrzyklad
    {
        public int X { get; set; }

        public int Y { get; } 

        public int Z { set; } // Błąd kompilacji, nie można zdefiniować 'Automatycznej Właściwości' tylko do zapisu.

        /* Sposoby inicjalizacji 'Automatycznej Właściwości' tylko do odczytu.
         * Sa 2 sposoby: 
         * 1. przy definicji właściwości
         * 2. w konstruktorze.
         * Uwaga - stosujemy tylko jeden ze sposobów. Wartość w konstruktorze nadpisze wartość zainicjiowaną podczas definicji 'właściwości'.
         */
        public DateTime DataUtworzenia { get; } = DateTime.Now;

        public Przyklad()
        {
            this.Y = 10; // właściwość tylko do odczytu zainicjiowana w tylko w konsruktorze.
            this.DataUtworzenia = DateTime.Now; // nie poprawnie bo
        }
    }
}
