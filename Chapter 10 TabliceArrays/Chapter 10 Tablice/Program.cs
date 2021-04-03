using System;

/* Tablice to zmiene typu referencyjnego, są obiektami klasy 'System.Array'. 
 * Wszystkie elementów tablicy muszą być tego samego typu. Mogą przechowywać zmienne typu wartosiowego i referencyjnego. (klasy, struktury, enumy, daty)
 * Elementy tablicy zajmują ciągły blok pamięci na stercie bezwzględu na jakiego typu elementy zawiera. Jeśli tablica jest typu int to pamięć potrzebna na przechowanie elementów jest alokowana na stercie
 * a nie na stosie. Jest to jeden z przypadków w którym pamięć potrzebna do przechowywania zmiennej typu wartościowego nie jest alokowana na stosie.
 * Podczas inicjiowania tablicy następuje faktyczny przydział pamięci, należy podać rozmiar tablicy. Jeśli nie podamy wartości, kompilator przypisze wszystkim elementą tablicy wartości domyślne (0, null, false)
 * Sama deklaracja zaalokuje tylko niewielką ilość pamięci na stosie do przechowania referencji.
 * Ponieważ pamięć potrzebna do przechowania instancji tablicy na stercie jest alokowana dynamicznie (podczas działania programu) rozmiar tablicy nie musi być wartością stałą.
 * Dopuszczalne jest utworzenie tablicy o rozmiarze 0. Rozmiar tablicy jest wyznaczany w sposób dynamiczny i może się zdażyć, że bedzie on równy 0. Nie oznacza to, że tablicą będzie nullem, tylko tablicą o zerowej 
 * liczbie elementów. Wartości elementów również nie muszą być stałe np:
 * int[] tab = new tab[Console.ReadLine()];
 * 
 */

namespace Chapter_10_Tablice
{
    class Program
    {
        /* Metoda Main - punkt wejścia do programu, za pomocą jej argumentu możemy przekazać dane do programu, gdy program jest uruchamiany z poziomu  wiersza poleceń (konsoli CMD.)
         * Windows przekazuje te dane do wspólnego środowiksa uruchomieniowego CLR, który następnie przekazuje je do medody Main. Przydatne przy tworzeniu programów narzędziowych,
         * które uruchamiane bedą z poziomu scryptu.
         * Aby uruchomić aplikację z poziomu konsoli należy dodać zmienną srodowiskową Path "C:\Windows\Microsoft.NET\Framework\v4.0.30319", 
         * wpisac sieżkę do folderu zawierającego program, nastepnie nazwe programu i podac parametry po spacji np: HelloWord d:\fotki\fota.jpg d:\fotki\kot.jpg
         */
        static void Main(string[] args)
        {
            InicjalizacjaTablic();
            KopiowanieTablic();
            TabliceWielowymiarowe();
            TabliceNieregularne();

            foreach (var arg in args)
            {
                Console.WriteLine($"Podales: {arg}");
            }
            
            Console.ReadKey();
        }

        static void InicjalizacjaTablic()
        {
            // deklaracja, alokuje pamieć na stosie potrzebną do przechowania referencji. 
            // Konwencja nazewnicza: tablice nazywamy w liczbie mnogiej.
            int[] liczby;
            liczby = new int[2] { 1, 2 };
            liczby = new int[] { 1, 2 };
            Random r = new Random();
            liczby = new int[] { r.Next() % 5, r.Next() % 5 };
            string[] imiona = { "Tomasz", "Michał" };
            object[] obiekty = { new object(), new object() };
            var imonaKotow = new[] { "Borys", "Mija" };
            //var imonaKotow = { "Borys", "Mija" }; // źle
            var przekonwertowanoNaDouble = new[] { 1, 2, 3.44, 9.99999 };
            /* Wszstkie elementy tablicy muszą być zgodne z typem tablicy. W niektórych przypadkach jeśli to możliwe może nastąpić konwersja. Generalnie lepiej unikać mieszania typów danych w nadziei, że 
             * kompilator wykona za nas odpowiednią konwersje. 
             */
            var zmienneAnonimowe = new[] { new { Imie = "Tomasz", Wiek = 29 }, new { Imie = "Johny", Wiek = 39 } };
        }

        static void KopiowanieTablic()
        {
            /* Klasa System.Array oferuje kilka metod do kopiowania. Wszystkie te metody tworzą kopię płytką tablicy. */

            // Metoda instancji CopyTo. Kopiuje zawartość tablicy rozpoczynając od wskazanego indexu. 
            int[] liczby = { 1, 3, 5, 8, 4, 0 };
            int[] tab = new int[liczby.Length];
            liczby.CopyTo(tab, 0);

            // Metoda statyczna Copy. Tak samo jak w przypadku uzycia CopyTo należy zainicjiować kopie tablicy o rozmiarze tablicy orginalnej.
            int[] tab2 = new int[liczby.Length];
            Array.Copy(liczby, tab2, 2);
            // Podanie niepoprawnego indexu spowoduje zgłoszenie wyjątku. Gdy index < 0 ArgumentOutOfRangeException. Gdy index > tab.Length ArgumentException.

            // Metoda Clone. Zwraca obiekt klasy object zamiast Array dlatego należy rzutować 
            int[] tab3 = liczby.Clone() as int[];

            // Note: gdy chcemy zrobić kopię głęboką należy użyc pętli.
        }

        static void TabliceWielowymiarowe()
        {
            /* Nie ma ograniczeń co do wymiarów lecz trzeba być swiadomy, że tablice 3 i więcej wymiarowe mogą zajmować dużo miejsca i należy być przygotowanym na wyjątek OutOfMemoryException */

            int[,] tabelka = new int[2, 3];
            int[,,] kostka = new int[5, 5, 5];
        }

        static void TabliceNieregularne()
        {
            /* Inaczej tablice tablic */
            int[][] elementy = new int[4][];
            int[] kolumna0 = new int[2];
            int[] kolumna1 = new int[6];
            int[] kolumna2 = new int[5];
            int[] kolumna3 = new int[1];

            elementy[0] = kolumna0;
            elementy[1] = kolumna1;
            elementy[2] = kolumna2;
            elementy[3] = kolumna3;

            foreach(var tablica in elementy)
            {
                foreach (var element in tablica)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
