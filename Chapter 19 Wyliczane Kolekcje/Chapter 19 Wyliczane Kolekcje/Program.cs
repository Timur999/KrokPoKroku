namespace Chapter_19_Wyliczane_Kolekcje
{
    /* W tym rozdziale zostanią opisana następujące zagadnienia:
     * - Tworzenie własnej kolekcji wyliczanej,
     * - Zasada działania pętli foreach,
     * - Domyślna wartości 'default' dla generycznych parametrów typu.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Zasada_Działania_Petli_Foreach();
            Tworzenie_Wlasnej_Kolekcji_Wyliczanej();
            Zasada_Dzialania_Moduly_Wyliczeniowego();
            Inicjiowanie_Zmiennej_Zdefiniowanej_Przy_Uzyciu_Parametru_Typu();
        }

        static void Zasada_Działania_Petli_Foreach()
        {
            /* Pętla foreach może zostać użyta tylko do kolekcji wyliczanych. ('enumerable' w skrócie: kolekcja musi dziedziczyć IEnumerable<T>)
             * 
             * 1. Na starcie pobiera obiekt 'numeratora' z kolekcji, wykonuyje metodę GetEnumerator(),
             * 2. potem za każdą iteracją wykonuje metode MoveNext numeratora sprawdzając czy istnieje kolejny element,
             * 3. jesli istnieje to pobiera wlaściwość Current.
             * 
             * Szerszy opis 'numeratora' znajduje sie w klasie TreeEnumerator.
            */
        }

        static void Tworzenie_Wlasnej_Kolekcji_Wyliczanej()
        {
            /* Kolekcja wyliczana musi dziedziczyć po IEnumerable<T> z przestrzeni System.Collections.Generic. 
             * (istnieje starsza wersja IEnumerable z przestrzeni nazw System.Collections,
             * ktora operuje na obiektach zamiast typach generycznych i jej już NIE UZYWAMY)
             * 
             * Interfejs IEnumerable zawiera jedna metode GetEnumerator, przykład w klasie Tree.
             * IEnumerator<TItem> GetEnumerator()
             */

            /* Następnie tworzymy własnego numeratora (inaczej moduł wyliczający), przyklad klasa TreeEnumerator.
             * moduł wyliczający mozemy traktować jak wskaźnik do elementow listy, np. jak ten czerwony kwadracik na kalendarzu.
             * 
             * Modul wyliczający tworzymy implementujac interfejs IEnumerator<TItem> który zawiera 
             * 1 propa Current i 2 metody MoveNext i Reset.
             */
        }

        static void Zasada_Dzialania_Moduly_Wyliczeniowego()
        {
            /* moduł wyliczający mozemy traktować jak wskaźnik do elementow listy,
             * na poczatku wskaźnika ustawiony jest PRZED PIERWSZYM elementem listy (lista[-1]).
             * Wywołanie metody MoveNext() przesuwa wskaźnik do następnego elementu (pierwsze wywołanie lista[0], drugie lista[1], ...)
             * Metoda MoveNext zwraca true jesli istnieje kolejny element listy i false gdy nie istnieje
             * i ustawia właściwość Current z którego korzysta foreach.
             * Metoda Reset ustawia wskaźnik spowrotem na pozycje początkową.
             */
        }

        static void Inicjiowanie_Zmiennej_Zdefiniowanej_Przy_Uzyciu_Parametru_Typu()
        {
            /* private TItem currentItem = default(TItem);
             * Klasa generyczna moze operować na różnych typach dancyh wartosciowy lub referencyjny. 
             * Slowo kluczowe 'default' przypisze domyślne wartości do zmiennych o typie generycznym (parametr typu T).
             * do zmiennej int przypisze wartosc 0 dla stringa null dla boola false a pola struktury zostaną zainicjiowane w ten sam sposób.
             */
        }
    }
}
