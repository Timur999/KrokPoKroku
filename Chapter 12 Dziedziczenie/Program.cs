using Chapter_12_Dziedziczenie.Animals;
using System;

// Klasa może dziedziczyc tylko po jednej klasie bazowej pod warunkiem, że nie została zapieczętowana 'sealed'.
// W C# dzidziczenie ma zawsze charakter publiczny oznacza to, że dziedziczy wszystkie pola i metody bez względu na ich modyfikator dostępności.
// Mechanizm dziedziczenia nie dotyczy struktur. Wszystkie struktury dziedziczą po klasie abstrakcyjnej 'System.ValueType'.
// 'System.ValueType' to klasa określająca sposób działania wszystkich, przechowywanych na stosie, wartościowych typów danych.

namespace Chapter_12_Dziedziczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            Convert(new Horse("konik"));
            Ukrywanie();

            Console.ReadLine();
        }

        public static void Init()
        {
            Horse myHorse = new Horse();
            myHorse.PutSaddle();
            Mammal mammal = myHorse;
            // mammal.PutSaddle(); błąd. Metoda PutSaddle() (Załuż siodło) jest tylko w klasie Horse.

            // Mammal someMammal = new Mammal();
            // Horse someHorse = someMammal;  błąd.
        }

        // Ważną zaletą Dziedziczenia jest to, że do tej metody mogę przekazać każdy obiekt klasy dziedziczącej po Mammal.
        public static void Convert(Mammal mammal)
        {
            Horse myHorse = mammal as Horse; // Wiecej na temat 'as' w rozdział 8 Wartości i Referecje - SaveCasting
            if (myHorse != null) 
            {
                myHorse.PutSaddle(); 
            }
        }

        public static void Ukrywanie() // Nazewnictwo: przesłonięcie/ukrycie metody. Chodzi o to samo.
        {
            // Klasy Horse i Mammal posiadają metody o takiej samej sygnaturze - public void Speaking(). 
            // Horse przysłania/ukrywa metode Mammal.Speaking() i tworzy własną - public new void Speaking().
            Horse horse = new Horse();
            Mammal mammalHorse = new Horse();            

            horse.Speaking(); // Wynik na konsoli 'Jestem Koniem'
            mammalHorse.Speaking(); //Wynik na konsoli 'Jestem Ssakiem'

            //Note: Na sygnaturę metody składa się:
            // nazwa metody oraz ilość i typ parametrów.
            // Typ zwracanej wartośćci nie ma znaczenia.
        }

        public static void VirtualOveride() // Nadpisanie
        {
            Mammal mammalHorse = new Horse();

            // W klasie Mammal metoda MyName() jest virtualna. Klasa Horse ją nadpisuje (override). 
            mammalHorse.MyName(); // Wykona się metoda z klasy Horse.

            //Note: Gdyby MyName była przesłonięta a nie nadpisana to wykonałaby się metoda z klasy Mammal.
        }
    }
}
