using Chapter_14_Zarzadzanie_pamiecia.Model;
using System;
using System.IO;

/* W tym rozdziale omowione zostało działąnie Garbage Colletora, Destruktory, interfejs IDisposable oraz instrukcja using.
 * 
 * Dane wartościowe są niszczone i pamięć jest zwalniana na stos z chwilą opuszczenia ich zakresu. (np. po opuszczeniu funkcji)
 * Pamięc na stercie potrzebna do przechowywana danych referencyjnych jest zarządzana przez CLR.
 *
 * Proces przedzielania pamięci odbywa się za pomocą operatora 'new'. Operator 'new' alokuje fragment surowej pamięci potrzebnej do pomieszczenia obiektu.
 * Następnie przekształca fragment surowej pamięci w obiekt przy użyciu konstruktora.
 * 
 * Gdy obiekt wykracza poza zakres, przestaje istnieć referencja do obiektu. Jeśli żadna zmienna nie zawiera referencji do tego obiektu
 * to możliwe bedzie usunięcie tego obiektu oraz przywrócenie zajmowanej przez niego pamięci. Ten proces jest zarządzany przez CLR i Garbage Collector.
 * Proces ten jest podzielony na 2 fazy:
 * 1. Środowisko CLR musi dokonać pewne porządki. Proces ten można kontrolować pisząc własny 'Destruktor'.
 * 2. CLR zwraca na sterte pamięć przedzieloną obiektowi do którego nie istnieje już żadna referencja.
 * 
 * Proces niszczenia obiektu i zwracania zajmowanej przez niego pamięci nosi nazwę 'processu oczyszczania pamięci' (ang. garbage collection - dosł. zbieranie śmieci).
 */

namespace Chapter_14_Zarzadzanie_pamiecia
{
    class Program
    {
        static void Main(string[] args)
        {
            Tworzenie_Destruktorów();
            Ograniczenia_Destruktorów();
            Kolektor_Śmieci();
            Działanie_Procesu_Oczyszczania_Pamieci();
            Metoda_Dispose_z_Poziomu_Destruktora();
            Wielowątkowość_a_Metoda_Dispose();

            Console.ReadKey();
        }

        static void Tworzenie_Destruktorów()
        {
            /* Destruktorów można używać do wykonywania niezbędnych porządków przed usunięciem obiektu.
             * Środowisko CLR automatycznie wyczyści wszelkie zarządzane zasoby używane przez usuwany obiekt (zarządzane zasoby to np. tablica) np. jeśli obiekt zawiera tablice,
             * pamięć zajmowana przez tą tablice zostanie również zwolniona podczas usuwania obiektu. Zatem w wielu przypdakach nie ma potrzeby tworzyć własnego destruktora.
             * Jeśli jednak zarządzany zasób jest bardzo duży (np. tablica jest wielowymiarowa) to warto natychmiast oznaczyć ten zasób jako przezaczony do usunięcia wstawiając null
             * dla dowolnych referencji wskazującego ten zasób (gdy już nam jest niepotrzebny). (Osobiście unikałbym tego).
             * Ponadto 'destruktory' są bardzo przydatne, gdy usuwany obiekt odwołuje się bezpośrednio lub pośrednio do zasobu niezarządzanego. (zasoby niezarządzane to np. strumienie plikowe,
             * uchwyty plików, połączenia sieciowe lub do bazy danych oraz inne zasoby zarządzane przez Windows)
             * Tak więc jeśli jakaś metoda otwiera plik to warto rozwarzyć stworzenie destruktora, który zamknie plik. Tworzenie 'destruktora' do tego celu jest jednak nie najlepszym rozwiązaniem
             * ponieważ musimy czekać na zamknięcie pliku aż środowisko CLR wywoła 'destruktor'. Lepszym rozwiązaniem jest użucie metody sprzątającej w try, finally a najlepiej instrukcji 'using'.
             */

            /* 'Destruktor' jest podobny do konstruktora z tym, że jest on wywoływany przez CLR gdy zniknie ostatnia referencja do obiektu */

            /* Przykład klasa: PrzetwarzaniePliku.cs */
            /* Wewnętrznie kompilator przekształca 'destruktor' w metodę przesłaniającą metode Object.Finalize. Zatem faktycznie bedzie to wyglądać tak:
             * Nie można w klasie nadpisać metody Finalize() ani wywołać ją bezpośrednio w kodzie.
             */

            /* 
               ~PrzetwarzaniePliku()
                {
                   // w tym miejscu znajduje się mój wlasny kod
                }
             
                protected override void Finalize()
                {
                    try
                    {
                        // w tym miejscu znajduje się mój wlasny kod
                    }
                    finally
                    {
                        base.Finalize();
                    }
                }
             */

            /* Jak widać nasz kod zostanie wywołany w bloku instrukcji try i nawet jeśli nasz kod zgłosi wyjątek zostanie wykonana metoda z klasy bazowej Finalize(). */
        }

        static void Ograniczenia_Destruktorów()
        {
            /* 1. 'Destruktory' można stosować tylko w referencyjnych typach danych.
             * 2. 'Destruktory' nie posiadają żadnych modyfikatorów dostępu i nigdy nie są wywoływane jawnie z poziomu kodu źródłowego. 'Destruktor' jest wywoływany przez Garbage Collector.
             * 3. 'Destruktory' nie mogą posiadać żadnych parametrów (wynika to z faktu, że nie jest on wywoływany jawnie przez programiste tylko przez GC).
             */
        }

        static void Kolektor_Śmieci()
        {
            /* Kolektor śmieci zapewnia następujące gwarancje:
             * 1. Każdy obiekt zostanie zniszczony a 'destruktor' zostanie wywołany. Niezniszczone obiekty zostaną zniszczeone przy zakonczeniu działania programu.
             * 2. Każdy obiekt zostanie zniszczony tylko jeden raz.
             * 3. Każdy obiekt zostanie zniszczony tylko gdy referencja do niego nie bedzie już istniała. 
             */

            /* Kiedy GC rozpoczyna proces czysczenia?
             * Działanie gabrage collectora jest kosztowne, dlatego środowisko CLR wywołuje go tylko gdy jest taka potrzeba, m.in. gdy brakuje pamięci lub gdy rozmiar sterty przekroczy pewną
             * ustaloną w systemie wartość progową.
             * 
             * Proces czyszczenia można uruchomić z poziomu kodu wywołując statyczną metode 'Collect' z klasy GC.
             * Z wyjątkiem kilku szczególnych przypadków niezaleca się tego robić. Proces czyszczenia działa asynchronicznie a wieć wątek który wywyłał metoda GC.Collect() nie czeka na jej zakończenie
             * a więc po jej wywołaniu nadal nie wiadomo czy nasze obiekty zostały już zniszczone a pamięć przywrócona. Wybór dogodnego uruchomienia 'Kolektora śmieci' lepiej zostawić CLR.
             */
        }

        static void Działanie_Procesu_Oczyszczania_Pamieci()
        {
            /* 'Kolektor Śmieci' działa jako osobny wątek i może być uruchamiany tylko w pewnych momentach, zwykle po napotkaniu konca metody. 
             * Podczas jego działania wsztymuje on pracę pozostałych wątków, ponieważ 'Kolektor' może przemieszczać obiekty w pamięci i aktualizować referencje do tych obiektów, czego nie można robić
             * w trakcie ich działania. (Wątek ang. Thread to osobna ścieżka wykonywania programu. Są wykorzystywane do równoczesnego wykonywania kilku operacji).
             * 
             * Kroki które wykonuje 'Kolektor Śmieci' to:
             * 1. Budowanie mapy wszystkich osiągalnych obiektów. Budowanie polega na śledzeniu pol referencyjnych wewnątrz obiektów. Obiekty poza tej mapy są uznawane jako nieosiągalne.
             * 2. Sprawdzanie, czy dowolny z nieosiągalnych obiektów posiada destruktor, który trzeba wykonać (proces nosi nazwę finalizacji). Nieosiągalne obiekty wymagające finalizacji zostają przeniesione
             *    do specjalnej kolecji freachable (obiektów f-osiągalnych)
             * 3. Dealokowanie pozostałych nieosiągalnych obiektów (tych które nie wymagają finalizacji) poprzez przenoszenie osiągalnych obiektów w dół sterty (co powoduje Defragmentacje sterty)
             *    i zwalnianie pamięci znajdującej się na szczycie sterty. (Gdy kolektor przenosi osiągalne obiekty w dół sterty aktualizuje on wszystkie referencje do tego obiektu).
             * 4. Po zakończeniu kroku 3, następuje wznowienie pozostałych wątków aplikacji.
             * 5. Wykonywanie finalizacji obiektów nieosiągalnych, które wymagają finalizacji (czyli obiektów z kolekcji freachable) w swoim własnym wątku.
             */
        }

        static void Zalecania()
        {
            /* Tworzenie 'destruktorów' zwiększa złożoność, utrudnia działanie 'Kolektora Śmieci' i w ogólności zmniejsza wydajność aplikacji. Jeśli klasa nie zawiera 'destruktora' to 'Garbage Collector' 
             * nie musi umieszczać obiektów nieosiągalnych w kolekcji 'freachable' i nie musi przeprowadzać ich finalizacji.
             * Dlatego trzeba unikać tworzenia 'destruktorów' i stosować je tylko gdy są niezbędne tj. do zwalniania zasobów niezarządzanych np. uchwyt pliku. Zamiast tworzenia 'destruktora' lepiej jest 
             * do tego celu użyć instrukcji 'using'.
             * 
             * Tworząc własny 'destruktor' należy być ostrożnym. W szczególności jeśli w destruktorze odwłujemy się do innych obiektów. Nie mamy pewności, czy 'Kolektor Śmieci' nie wykonał już destruktora
             * na tych obiektach. Nie ma żadnej gwarancji finalizacji obiektów, dlatego należy tworzyć destruktor tak aby nie był on zależny od innych destruktorów.
             */
        }

        static void Metody_Sprzątające()
        {
            /* Czasami zwalnianie zasoób przy pomocy destruktora jest niepożądane. Takie zasoby jak uchwyty plików, połączenia z bazą danych lub połączenia sieciowe należy zwalniać natychmiast po zakończeniu
             * pracy z nimi. Metoda sprzątające (ang. disposal).
             * Klasa która posiada własną metodę sprzątającą to np. TextReader (służy do odczytywania znaków ze strumienia wejsciowego). Klasa TextReader posiada metode wirtualną 'Close()' która zamyka strumien.
             * Klasa StreamReader (odczytuje znaki ze strumienia, takich jak np. otwarty plik) oraz klasa StringReader (Odczytuje znaki z łańcucha znakowego) dziedziczą po klasie TextReader i obie nadpisują/
             * przesłaniają metode 'Close()'.
             */

            Sprzątanie("scieŻka");
            Sprzątanie_Odporne_Na_Wystąpienie_Wyjątku("scieżka");
            Instrukcja_Using_Oraz_Interfejs_IDisposable("scieżka");
        }

        static void Sprzątanie(string sciezka)
        {
            TextReader odczyt = new StreamReader(sciezka);
            string linia = null;

            while((linia = odczyt.ReadLine()) != null)
            {
                Console.WriteLine(linia);
            }

            odczyt.Close(); // Po zakończeniu pracy, wywołujemy metodę sprzątającą.

            // Przykład nie odporny na wystąpenie wyjątku.
        }

        static void Sprzątanie_Odporne_Na_Wystąpienie_Wyjątku(string sciezka)
        {
            TextReader odczyt = new StreamReader(sciezka);
            string linia = null;
            try
            {
                while ((linia = odczyt.ReadLine()) != null)
                {
                    Console.WriteLine(linia);
                }
            }
            finally
            {
                odczyt.Close(); // Po zakończeniu pracy, wywołujemy metodę sprzątającą.
            }
        }

        static void Instrukcja_Using_Oraz_Interfejs_IDisposable(string sciezka)
        {
            /* Zmienna zadeklarowana w instrukcji 'using' musi implementować interfejs 'IDisposable'. klasa TextReader to robi a w metodzie 'Dispose()' wykonuje metodę 'Close()'.
             * Gdy instrukcja 'using' zakończy swoje działanie to na obiekcie który został zdefiniowany w using zostanie użyta metoda 'Dispose()'.
             * Metoda 'Dispose()' zostanie wykonana tylko na obiekcie 'odczyt' na obiekcie 'pp' już nie, pomimo, że klasa  'PrzetwarzaniePliku' również implementuje interfejs 'IDisposable'.
             */

            using (TextReader odczyt = new StreamReader(sciezka))
            {
                PrzetwarzaniePliku pp = new PrzetwarzaniePliku("");
                string linia = null;
                while( (linia = odczyt.ReadLine()) != null )
                {
                    Console.WriteLine(linia);
                }
            }

            /* Przykład z instrukcją 'using' jest równoznaczy z: */

            TextReader odczytPliku = new StreamReader(sciezka);
            string liniaZPliku = null;
            try
            {
                while( (liniaZPliku = odczytPliku.ReadLine()) != null )
                {
                    Console.WriteLine(liniaZPliku);
                }
            }
            finally
            {
               if(odczytPliku != null )
                {
                    ((IDisposable)odczytPliku).Dispose();
                }
            }
        }

        static void Metoda_Dispose_z_Poziomu_Destruktora()
        {
            /* Wywołanie metody 'Dispose()' z poziomu 'destruktora' pełni funkcje zabezpieczająco na wypadek, gdyby programista nie użył instrukcji 'using' */

            Przyklad przyklad = new Przyklad();
            przyklad.PewnaMetoda();
            przyklad.Dispose();
            przyklad.PewnaMetoda(); // zostanie zgłoszony wyjątek.
        }

        static void Wielowątkowość_a_Metoda_Dispose()
        {
            InnyPrzyklad innyPrzyklad = new InnyPrzyklad();

            innyPrzyklad.Dispose();
        }
    }
}
