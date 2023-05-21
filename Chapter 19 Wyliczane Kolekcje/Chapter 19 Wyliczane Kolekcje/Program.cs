namespace Chapter_19_Wyliczane_Kolekcje
{
    /* W tym rozdziale zostanią opisana następujące zagadnienia:
     * - Tworzenie własnej kolekcji wyliczanej,
     * - Zasada działania pętli foreach,
     * - Domyslnej wartości 'default' dla generycznych parametrów typu.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Zasada_Działania_Petli_Foreach();
            Tworzenie_Wlasnej_Kolekcji_Wyliczanej();
            Inicjiowanie_Zmiennej_Zdefiniowanej_Przy_Uzyciu_Parametru_Typu();
        }

        static void Zasada_Działania_Petli_Foreach()
        {
            /* Pętla foreach może zostać użyta tylko do kolekcji wyliczanych. (w skrócie: kolekcja musi dziedziczyć IEnumerable<T>)
             * 
             * 1. Na starcie pobiera obiekt enumeratora z kolekcji,
             * 2. potem za każdą iteracją wykonuje metode MoveNext enumeratora sprawdzając czy istnieje kolejny element,
             * 3. jesli istnieje to pobiera wlaściwość Current.
             * 
             * Szerszy opis enumeratora znajduje sie w klasie TreeEnumerator.
            */
        }

        static void Tworzenie_Wlasnej_Kolekcji_Wyliczanej()
        {
            /* Kolekcjia wyliczana musi dziedziczyć pod IEnumerable z przestrzeni System.Collections.Generic. 
             * (istnieje starsza wersja IEnumerable ktora operuje na obiektach zamiast typach generycznych i jej już NIE uzywamy)
             * 
             * Interfejs IEnumerable zawiera jedna metode GetEnumerator, przykład w klasie Tree.
             * IEnumerator<TItem> GetEnumerator()
             */

            /* Następnie tworzymy własnego enumeratora (inaczej moduł wyliczający), przyklad klasa TreeEnumerator.
             * moduł wyliczający mozemy traktować jak wskażnik do elementow listy, np. jak ten czerwony kwadracik na kalendarzu.
             * 
             * Modul wyliczający tworzymy implementujac interfejs IEnumerator<TItem> który zawiera 
             * 1 propa Current i 2 metody MoveNext i Reset.
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
