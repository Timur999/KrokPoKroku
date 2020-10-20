using Chapter_12_Dziedziczenie.Animals;
using System;

// Klasa może dziedziczyc tylko po jednej klasie bazowej pod warunkiem, że nie została zapieczętowana 'sealed'.
// W C# dzidziczenie ma zawsze charakter publiczny oznacza to, że dziedziczy wszystkie pola i metody bez względu na ich modyfikator dostępności.
// Mechanizm dziedziczenia nie dotyczy struktur! Wszystkie struktury dziedziczą po klasie abstrakcyjnej 'System.ValueType'.
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
            Przesłanianie();
            ExtendedMethods();

            Console.ReadLine();
        }

        public static void Init()
        {
            Mammal mammal = new Mammal();
            Horse myHorse = new Horse();
            myHorse.PutSaddle();
            mammal = myHorse;
            // mammal.PutSaddle(); błąd. Metoda PutSaddle() (Załuż siodło) jest tylko w klasie Horse.

            // Mammal someMammal = new Mammal();
            // Horse someHorse = someMammal;  błąd.
        }

        // Ważną zaletą Dziedziczenia jest to, że do tej metody mogę przekazać każdy obiekt klasy dziedziczącej po klase bazowej.
        public static void Convert(Mammal mammal)
        {
            Horse myHorse = mammal as Horse; // Wiecej na temat 'as' w rozdział 8 Wartości i Referecje - SaveCasting
            if (myHorse != null) 
            {
                myHorse.PutSaddle(); 
            }
        }

        public static void Ukrywanie() // Nazewnictwo: maskowanie/ukrycie metody. Chodzi o to samo.
        {
            // Klasy Horse i Mammal posiadają metody o takiej samej sygnaturze - public void MyName(). 
            // Horse ukrywa metode Mammal.MyName() i tworzy własną - public new void MyName().
            Horse horse = new Horse();
            Mammal mammalHorse = new Horse();            

            horse.MyName(); // Wynik na konsoli 'Jestem Koniem'
            mammalHorse.MyName(); //Wynik na konsoli 'Jestem Ssakiem'

            //Note: Na sygnaturę metody składa się: nazwa metody oraz ilość i typ parametrów.
            //      Typ zwracanej wartośćci nie ma znaczenia.
        }

        public static void Przesłanianie() // Nazewnictwo: nadpisanie/przesłanianie metody
        {
            // Różnica pomiedzy 'Przesłonięciem'(ang. overriding) a 'Ukrywaniem' 
            // Przesłonięcie metody polega na tym aby metoda wykonywała te same zadanie w sposób zależny od danej klasy.
            // Ukrycie metody - metody mogą wykonywać dwa całkowicie różne zadania. Ukrycie metody jest często błędem.
            
            Mammal mammal = new Mammal();
            Horse horse = new Horse();
            Zebra zebra = new Zebra();
            Dolphin dolphin = new Dolphin();

            // W klasie Mammal metoda Speaking() jest virtualna. Klasa Horse ją nadpisuje (override). 
            mammal = horse;
            mammal.Speaking(); // Wykona się metoda z klasy Horse.

            mammal = zebra;
            mammal.Speaking(); // Wykona się metoda z klasy Zebra.

            // dolphin nie implementuje metody Speaking()
            mammal = dolphin;
            mammal.Speaking(); // Wykona się metoda z klasy Mammal.

            //Note: Gdyby Speaking była przesłonięta a nie nadpisana to wykonałaby się metoda z klasy Mammal.
        }

        public static void ExtendedMethods()
        {
            int i = 10;
            // Metoda Negate() jest metoda rozszerzającą, zefiniowaną w kasie statycznej Extension. static int Negate(this int i) 
            Console.WriteLine(i.Negate());
        }
    }
}
