using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaHashSet
    {
        internal static void Kolekcja_HashSet()
        {
            /* Klasa HashSet<T> Nieuporządkowana lista, zoptymalizowana aby pobierac szybko dane. 
             * Zawiera metody w stylu działań na zbiorach. Takich jak ustalenie przynależności do zbioru, generowanie sumy lub części wspólnej zbiorów
             * 
             * Dodawanie: Add()
             * 
             * Usuwanie: Remove()
             * 
             * Działania na zbiorach:
             * IntersectWith(zbiór) - iloczyn zbiorów
             * UnionWith(zbiór) - suma
             * ExceptWith(zbiór) - różnica
             * Metody te zmieniają kolekcje generując całkowice nową kolekcje.
             * 
             * Ustalenie czy dane z jednej kolekcji HasSet<T> są podzbiorem lub nadzbriorem innej kolekcji HasSet<T> bez zmieniania jej wartości.
             * IsSubsetOf(zbiór), IsSupersetOf(zbiór), IsProperSubsetOf(zbiór), IsProperSupersetOf(zbiór).
             * 
             * Wewnętrznie kolekcja HasSet<T> jest przechowywana jako tablica mieszająca (hash table)
             * Szybkie wyszukiwanie elementów,
             * Duża kolekcja zajmuje dużo miejsca aby zapewnić szybkie wyszukiwanie
             */

            Metoda_IntersectWith();
            Metoda_UnionWith();
            Metoda_ExceptWith();
            Metody_Czy_Jest_PodZbiór_Nadzbiór();

            /* Przestrzeń nazw System.Collections.Generic zawiera rownież klasę 'SortedSet<T>', która posiada posortowane elementy.
             * Kolekcje SortedSet<T> i HashSet<T> można łączyć i używać metod do sprawdzania zbiorów.
             */
        }

        static void Metoda_IntersectWith()
        {
            HashSet<int> liczbyPierwsze = new HashSet<int>() { 1, 2, 3, 7, 13 };
            HashSet<int> liczby = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (int liczba in liczby)
            {
                Console.Write(liczba + ", ");
            }
            Console.WriteLine();

            liczby.IntersectWith(liczbyPierwsze);

            foreach (int liczba in liczby)
            {
                Console.Write(liczba + ", "); // 1, 2, 3, 7
            }
            Console.WriteLine("Metoda_IntersectWith");
        }

        static void Metoda_UnionWith()
        {
            HashSet<int> liczbyPierwsze = new HashSet<int>() { 1, 2, 3, 7, 13 };
            HashSet<int> liczby = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            liczby.UnionWith(liczbyPierwsze);

            foreach (int liczba in liczby)
            {
                Console.Write(liczba + ", "); // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13,
            }
            Console.WriteLine("Metoda_UnionWith");
        }

        static void Metoda_ExceptWith()
        {
            HashSet<int> liczbyPierwsze = new HashSet<int>() { 1, 2, 3, 7, 13 };
            HashSet<int> liczby = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            liczby.ExceptWith(liczbyPierwsze);

            foreach (int liczba in liczby)
            {
                Console.Write(liczba + ", "); //4, 5, 6, 8, 9, 10,
            }
            Console.WriteLine("Metoda_ExceptWith");
        }

        static void Metody_Czy_Jest_PodZbiór_Nadzbiór()
        {
            HashSet<int> liczbyPierwsze = new HashSet<int>() { 1, 2, 3, 7 };
            HashSet<int> liczby = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // metody zwracają wartość logiczną i nie są destrykcyjne
            Console.WriteLine(liczby.IsSubsetOf(liczbyPierwsze)); // false
            Console.WriteLine(liczby.IsSupersetOf(liczbyPierwsze)); // true
            Console.WriteLine(liczby.IsProperSubsetOf(liczbyPierwsze)); // false
            Console.WriteLine(liczby.IsProperSupersetOf(liczbyPierwsze)); // true
        }
    }
}
