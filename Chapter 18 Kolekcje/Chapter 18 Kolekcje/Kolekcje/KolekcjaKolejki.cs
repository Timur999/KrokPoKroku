using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaKolejki
    {
        internal static void Kolekcja_Kolejka()
        {
            /* Klasa Queue<T> jest typu FIFO (first-in, first out)
             * 
             * Dodawanie: Enqueue() - Dodawanie odbywa sie końcu kolejki
             * 
             * Usuwanie: Dequeue() - Pobieranie i usuwanie elementu z początku kolejki
             * 
             * Iteracja: pętla foreach - iteracja nie powoduje usunięcia z elementu z kolejki
             *           możemy użyc pętli 'for' lub 'while' jednak aby pobrać wartość z nalezy użyć metody Dequeue() która usunie ten element z kolejki
             */

            DodawanieUsuwanie();
            Iteracja();
        }

        static void DodawanieUsuwanie()
        {
            Queue<int> kolejka = new Queue<int>();
            foreach (int x in new[] { 1, 2, 3, 4 })
            {
                kolejka.Enqueue(x);
            }

            foreach (int x in kolejka)
            {
                Console.Write(x + ", "); // 1, 2, 3, 4,
            }

            Console.WriteLine("Po odjęciu");
            Console.WriteLine(kolejka.Count); // 4
            kolejka.Dequeue();
            Console.WriteLine(kolejka.Count); // 3
            foreach (int x in kolejka)
            {
                Console.WriteLine(x); // 2, 3, 4,
            }
        }

        static void Iteracja()
        {
            // Taka inicjalizacja jest Niiepoprawna bo kolekcja Queue nie implementuje metody Add().
            Queue<int> lista = new Queue<int>() { 1, 2, 3 };

            // Poprawna inicjalizacja:
            Queue<int> kolejka = new Queue<int>();
            foreach (int x in new[] { 1, 2, 3, 4 })
            {
                kolejka.Enqueue(x);
            }

            /* !!!UWAGA!!! Nie wolno w żaden sposób modyfikować listy (Enqueue, Dequeue) podczas iteracji po tej kolekcji za pomocą 'foreach'.
             * Próba zostanie zakończona wyjątkiem System.InvalidOperationException: 'Collection was modified after the enumerator was instantiated.'
             * Kolekcja została zmodyfikowana po utworzeniu obiektu enumerator.
             */
            foreach (int liczba in kolejka)
            {
                kolejka.Enqueue(liczba+1);
            }

            /* Natomiast podczas iteracji Kolekji za pomocą pętli 'for' lub 'while' możemy ją Modyfikować.
             * Należy jednak uważać na pewne pułapki opisane niżej:
             * - po takiej iteracji koleka bedzie pusta bo używamy metody Dequeue(), warunek kończący to  kolejka.Count > 0.
             * - dodawanie co iteracje nowgo elementu spowoduje exception OutOfMemeoryException
             */
            
            for (var index = 0; kolejka.Count > 0; index++)
            {
                if (index == 3)
                {
                    kolejka.Enqueue(5);
                }
                var zdjetyElement = kolejka.Dequeue();
                Console.Write(zdjetyElement); // 12345
            }

            Console.Write(kolejka.Count); // 0
        }
    }
}
