using Chapter_12_Dziedziczenie.Animals;
using System;

/* Klasa może dziedziczyc tylko po jednej klasie bazowej pod warunkiem, że nie została zapieczętowana 'sealed'.
 * W C# dzidziczenie ma zawsze charakter publiczny oznacza to, że dziedziczy wszystkie pola i metody bez względu na ich modyfikator dostępności.
 * Mechanizm dziedziczenia nie dotyczy struktur! Wszystkie struktury dziedziczą po klasie abstrakcyjnej 'System.ValueType'.
 * 'System.ValueType' to klasa określająca sposób zachowania wszystkich zmiennych przechowywanych na stosie, wartościowych typów danych.
 * Klasa 'System.Object' jest główną klasą bazową wszystkich klas. Wszystkie klasy niejawnie dziedziczą po niej. Kompilator dokonuje niejawnej zmiany definicji każdej klasy.
 * np. Class Ssak : System.Object (Możemy to robić jawnie, ale po co).
*/
namespace Chapter_12_Dziedziczenie
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            Konwersja(new Kon("konik"));
            Ukrywanie();
            Przesłanianie();
            Int32.TryParse(Console.ReadLine(), out int i);
            Polimorfizm(i);
            ExtendedMethods();

            Console.ReadLine();
        }

        public static void Init()
        {
            Ssak mojSsak = new Ssak();
            Kon mojKon = new Kon();
            mojKon.ZaluzSiodlo();
            mojSsak = mojKon;
            mojSsak.ZaluzSiodlo(); // błąd. Odwołujac się do obiektu klasy Kon za pomocą zmiennej typu 'Ssak' możemy korzystać tylko z metod i właściwości zdefiniowanych w klasie 'Ssak'
                                   // Metoda ZaluzSiodlo() (ang. put saddle) jest tylko w klasie Kon.

            Ssak jakisSsak = new Ssak();
           // Kon jakisKon = jakisSsak;  // błąd. Nie można przypisać obiektu klasy 'Ssak' to zmiennej typu 'Kon'. Klasa 'Kon' "rozszerza" klase 'Ssak' i zawiera wiecej pól i metod, dlatego jest to niemożliwe.

            // Możliwe jest przypisanie pod warunkiem, że obiekt klasy 'Ssak' tak naprawde jest Koniem. Można to sprawdzić za pomocą operatorów 'as', 'is' lub rzutowania przykład poniżej.
            Kon konik = new Kon();
            Ssak ssak = konik;
            Kon konPonownie;
            if(ssak is Kon)
            {
                konPonownie = (Kon)ssak;
            }

            Delfin delfin = new Delfin();
            ssak = delfin;

            konPonownie = ssak as Kon; // Oprator as zwróci 'null', gdyż obiekt 'ssak' jest rownież obiektem klasy 'Delfin' a nie 'Kon'.
        }

        // Ważną zaletą Dziedziczenia jest to, że do tej metody mogę przekazać każdy obiekt klasy dziedziczącej po klase bazowej.
        public static void Konwersja(Ssak ssak)
        {
            Kon mojKon = ssak as Kon; // Wiecej na temat 'as' w rozdział 8 Wartości i Referecje - SaveCasting
            if (mojKon != null) 
            {
                mojKon.ZaluzSiodlo(); 
            }
        }

        public static void Ukrywanie() // Nazewnictwo: maskowanie/ukrycie metody. Chodzi o to samo.
        {
            /* Klasy Kon i Ssak posiadają metody o takiej samej sygnaturze - public void PobierzImie(). 
             * Kon ukrywa metode Ssak.PobierzImie() i tworzy własną - public new void PobierzImie().
             * Gdy jakaś klasa dziedziczyć bedzie po klasie 'Kon' to odziedziczy tą metodę po klasie 'Kon' a nie 'Ssak'. Ponieważ ta metoda została ukryta.
            */

            Kon kon = new Kon("Konik");
            Ssak ssakKon = new Kon("Konik Roman");
            Zebra zebra = new Zebra("Zebra Irena");

            kon.PobierzImie(); // Wynik na konsoli 'Lubie biegac!'
            ssakKon.PobierzImie(); //Wynik na konsoli 'Konik Roman'
            zebra.PobierzImie(); // Wynik na konsoli 'Lubie biegac!'

            // Note: Na sygnaturę metody składa się: nazwa metody oraz ilość i typ parametrów. Typ zwracanej wartośćci nie ma znaczenia.
        }

        public static void Przesłanianie() // Nazewnictwo: nadpisanie/przesłanianie metody
        {
            /* Metoda która z założenia służy do tego, aby została przeszłonięta przez inna implementacje nazywamy metodą 'wirtualną'.
             * Więcej o metodzie wirtualnej i override w klasie 'Ssak' i 'Kon'. 
             * Różnica pomiedzy 'Przesłonięciem'(ang. overriding) a 'Ukrywaniem' 
             * Przesłonięcie metody polega na tym aby metoda wykonywała te same zadanie w sposób zależny od danej klasy.
             * Ukrycie metody - metody mogą wykonywać dwa całkowicie różne zadania. Ukrycie metody jest często błędem.
            */

            Ssak ssak = new Ssak();
            Kon kon = new Kon();
            Zebra zebra = new Zebra();
            Delfin defin = new Delfin();


            /* Metoda wirtalna a 'polimorfizm'
             * Przy pomocy metod wirtualnych można wywoływać różne wersje tej samej metody w zależności od faktycznego typu obiektu przekazanego do zmiennej.
             * Typ obiektu może być tworzony dynamicznie, w trakcie działania programu.
             */
            // W klasie Ssak metoda Mowa() jest virtualna. Klasa Kon ją nadpisuje (override). 
            ssak = kon;
            ssak.Mowa(); // Wykona się metoda z klasy Kon.

            ssak = zebra;
            ssak.Mowa(); // Wykona się metoda z klasy Zebra.

            // defin nie implementuje metody Mowa()
            ssak = defin;
            ssak.Mowa(); // Wykona się metoda z klasy Ssak.

            /*Note: Gdyby metoda Mowa() była ukryta a nie nadpisana to wykonałaby się metoda z klasy Ssak.
             * Jednak tak nie jest i na tym właśnie polaga polimorfizm (wiele form). 
             */
        }

        public static void Polimorfizm(int index)
        {
            Ssak ssak;
            switch (index)
            {
                case 1:
                    ssak = new Kon(); 
                    break;
                case 2:
                    ssak = new Zebra();
                    break;
                case 3:
                    ssak = new Delfin();
                    break;
                default:
                    ssak = new Ssak();
                    break;
            }

            ssak.Mowa();

            // Na podstawie podanego parametru mogę utworzyć różny obiek i za pomocą jednej instrukcji wykonać metodę zaimplementowaną w sposób zależny od klasy.
        }

        public static void ExtendedMethods()
        {
            int i = 10;
            // Metoda Negate() jest metoda rozszerzającą, zefiniowaną w kasie statycznej Extension. static int Negate(this int i) 
            Console.WriteLine(i.Negate());
        }
    }
}
