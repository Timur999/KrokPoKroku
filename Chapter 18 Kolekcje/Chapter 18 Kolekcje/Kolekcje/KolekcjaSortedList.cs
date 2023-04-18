using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaSortedList
    {
        internal static void Kolekcja_SortedList()
        {
            /* Klasa SortedList<TKey, TValue> podobna do Dictionary<TKey, TValue>.
             * Również zawiera tablice kluczy i tablice wartości powiązanych ze sobą, różnica jest taka, że klucze są posortowane.
             * Dodawanie obiektów trwa dłużej ale pobieranie krócej niż w kolekcji SortedDictionary<TKey, TValue>. 
             * Ponadto zajmuje mniej miejsca niż SortedDictionary<TKey, TValue>. 
             * 
             * Dodawanie nowego elementu:
             * najpierw dodawany jest do tablicy z kluczami o takim indeksie aby tablica była posortowana,
             * potem do tablicy wartościami o takim samym indeksie dodawana jest wartość.
             * Automatycznie synchonizuje położenie wszystkich kluczy i wartości podczas usuwania i dodawania.
             * 
             * Odwołanie do elementu: za pomocą klucza w [] (tzw. notacja tablicowa)
             * 
             * Dodawanie: metoda Add(), notacja tablicowa sortedList["Zbroja"] = 10
             * 
             * Usuwanie: Remove(Key)
             * 
             * Iteracja: tylko petla foreach (Nie wolno modyfikowac listy podczas iteracji w perli foreach)
             */

            Przyklad();
        }

        static void Przyklad()
        {
            SortedList<string, int> sklep = new SortedList<string, int>()
            {
                ["Zbroja"] = 100,
                ["Miecz"] = 200,
                ["Tarcza"] = 300
            };

            sklep.Add("Hełm", 400);
            //sklep.Add("Miecz", 400); // bład taki klucz juz istnieje
            sklep["Miecz"] = 600;

            foreach (KeyValuePair<string, int> przedmiot in sklep)
            {
                Console.WriteLine(przedmiot.Key + " " + przedmiot.Value);
            }

            /* Helm 400
             * Miecz 600
             * Tarcza 300
             * Zbroja 100
             */
        }
    }
}
