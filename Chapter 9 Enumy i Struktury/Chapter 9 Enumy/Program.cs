using System;

/* 
 * Język C# posiada 2 rodzaje wartościowych typów danych: Wyliczeniowy (enum) i Strukture (Struct)
 * 
 * Enum (typ wyliczeniowy) jest wartościowym typem danych, zawiera wartość na stosie. Chcąc utworzyc reprezentacje pór roku, mozemy uzyc liczb calkowitych 0,1,2,3 i zapisac do zminnej poraRaoku. 
 * Jest to poprawne ale nie intuicyjne oraz do tej zminnej mozemy przypisac wartość poza zakresu. Dlatego lepiej wykorzystac enum (wyliczeniowy typ danych), którego wartość bedzie ograniczona.

 *  Struktyry również przechowuja wartośći na stosie. Gdy klasa jet mała lepiej jest uzyć struktury, gdyż zarządzanie pamięcią na stercie jest dodatkowym narzutem operacji do wykonania.
*/

namespace Enumy
{
    class Program
    {
        static void Main(string[] args)
        {
            StosowanieWyliczeniowychTypowDanych(); /* Przypisanie i odczytanie wartości, pokazanie enuma ze mozna uzywac jak normalnego typu wartosciowego, nullowalny enum. */
            OperacjeArytmetyczneNaEnumach(); /* Stosowanie operatorów artymetycznych na zmiennych typu wyliczeniowego */
            WartosciLiteralowWyliczeniowych(); /* Każdy literał ma reprezentanta w formie liczby całkowitej. Omówiny zakres dostepnych literałow oraz możliwość regulacji ilością */

            Console.Read();
        }


        // Wartości enuma nazywamy 'literałami' wyliczeniowymi.
        // Literały są reprezentowane przez liczby całkowite domyślnie zaczynając od zera. Może być reprezentowany przez każdy typ danych całkowitoliczbowego. Należy określic typ po ':'
        enum PoraRoku { Wiosna, Lato, Jesien, Zima };
        enum TestIQ : byte { niski = 80, sredni = 100, wysoki = 130, /*geniusz = 280 */ } // 280 wykracza poza zakres wartości byte.

        public static void StosowanieWyliczeniowychTypowDanych()
        {
            /* Przypisanie wartości
             * Do zmiennych wyliczeniowych można przypisać tylko wartości zdefiniowane w swoim typie wyliczeniowym, np. 
             */
            PoraRoku bialaPoraroku = PoraRoku.Zima;

            /* Odczytywanie wartości
             * Przed odczytaniem konieczne jest przypisanie jej pewnej wartości.
             * Każda zmienna typu wartościowego posiada metodę ToString().
            */
            Console.WriteLine(bialaPoraroku); // Wynik: Zima (Console.WriteLine automatycznie użyje metodę ToString())
            string goraca = PoraRoku.Lato.ToString();

            /* Należy zwrócic uwagę na użycie zapisu 'PoraRoku.Zima' zamiast poprostu 'Zima'.
             * Nazwy 'literałów' wyliczeniowych mają zakres zdefinowany przez typ wyliczniowy w którym są zdefinowane. W nawiasach klamrowych { } 
             */

            /* Uwaga!
             * Zmienne wyliczeniowe możemy używać jak pozostałe zmienne. Tworzyć zmienne typu PoraRoku, pola klas oraz parametry metody typu PoraRoku 
             */
            PoraRoku poraRoku;

            PoraRoku ZmienPoreRoku(PoraRoku poraRoku1)
            {
                return PoraRoku.Wiosna;
            }

            TestIQ wynik = TestIQ.wysoki;
            switch (wynik)
            {
                case TestIQ.niski:
                    Console.Write("uposledzony");
                    break;
                case TestIQ.sredni:
                    Console.Write("normalny");
                    break;
                case TestIQ.wysoki:
                    Console.Write($"{TestIQ.wysoki} IQ na poziomie: {(byte)TestIQ.wysoki}");
                    break;
            }

            /* Nullowalny typ wyliczeniowy!
             * Ponieważ typ wyliczeniowy jest typem wartościowym, możliwe jest utworzenie z niej zmiennej nulowalnej.
             */
            PoraRoku? kolorowa = null;
            if (!kolorowa.HasValue)
            {
                kolorowa = PoraRoku.Jesien;
            }

            Console.WriteLine(kolorowa.Value);
        }

        public static void OperacjeArytmetyczneNaEnumach()
        {
            PoraRoku poraRoku = PoraRoku.Jesien;
            poraRoku++;
            Console.WriteLine(poraRoku);
            --poraRoku;
            poraRoku += 2;
            poraRoku += 100;
            Console.WriteLine(poraRoku); // wynik 100. zostanie wyswielona liczba, gdyż nie ma takiej pory roku
            bool isSummer = poraRoku == PoraRoku.Lato;

            if (isSummer)
            {
                Console.WriteLine("Ide na plaże");
            }

            // season += Seasons.Spring; // BAD
            // season += (int)Seasons.Spring; // GOOD
        }

        // Dwa Literały reprezentowane przez tą samą liczbę. RepresentationOfTheEnumsValue - przykład
        enum Kolor : short { Czerwony = 1, Zielony, Niebieski, Bordowy = Czerwony }
        enum Status : sbyte { Sukces = 0, Poprawny = Sukces, Blad = 1 }
        public static void WartosciLiteralowWyliczeniowych()
        {
            /* Z każdym literałem wyliczeniowym powiązana jest liczba całkowita. Domyślnie jest to 'int', a pierwszy literał zaczyna się od 0 następne zawsze mają wartość +1.
             * Typ liczby całkowitej definiujemy po ':' 'byte', 'sbyte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong'.
             * Powiązana liczba całkowita z literałem nie może wykraczać poza dopuszczalny zakres wartości bazowego typu.
             * np, zakres short to 0 do 255, w tym przypadku nie moge przypisac literałowi liczby większej niz 255 oraz literałów nie może być więcej niż 255.
             */

            /* Aby pobrac wartość liczbową literału wyliczeniowego należy użyć RZUTOWANIA */
            Console.WriteLine((short)Kolor.Niebieski); // Wynik: 3
            Console.WriteLine((short)Kolor.Bordowy); // Wynik: 1
            Console.WriteLine(Kolor.Bordowy); // Wynik: Czerwony.
            Console.WriteLine(Status.Poprawny); // Wynik Poprawny. 
            Console.WriteLine((sbyte)Status.Poprawny); // Wynik 0.


            /*Note: Gdy zdefiniujemy typ wartości licznowej literału np. short to kazdy literał bedzie reprezentowany przez liczbę tego typu. 
             * Oszczędność pamięci.
             */
        }
    }
}
