using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaStos
    {
        internal static void Kolekcja_Stos()
        {
            /* Klas Stack<T> to kolejka typu LIFO (Last-in, first-out) inaczej stos
             * 
             * Dodawanie: metoda Push() na góre stosu
             * 
             * Usuwanie: metoda Pop() zdjęcie elementu z góry stosu
             * 
             * Iteracja: pętla foreach - iteracja nie powoduje usunięcia z elementu ze stosu
             *           możemy użyc pętli 'for' lub 'while' jednak aby pobrać wartość z nalezy użyć metody Pop() która usunie ten element ze stosu
             */
        }

        static void Stos()
        {
            // Taka inicjalizacja jest Niepoprawna bo kolekcja Stos nie implementuje metody Add().
            Stack<int> stos = new Stack<int>() { 1, 2, 3 };

            // Poprawna inicjalizacja:
            Stack<int> stos = new Stack<int>();
            stos.Push(1);
            stos.Push(2);
            stos.Push(3);

            foreach (int x in stos)
            {
                Console.Write(x + ", "); // 3, 2, 1,
            }

            foreach (int x in stos)
            {
                Console.Write(x + ", "); // 3, 2, 1,
            }

            Console.WriteLine("Po odjęciu");
            stos.Pop();
            foreach (int x in stos)
            {
                Console.Write(x + ", "); // 2, 1,
            }

            /* !!!UWAGA!!! Nie wolno w żaden sposób modyfikować listy (Push, Pop) podczas iteracji po tej kolekcji za pomocą 'foreach'.
             * Próba zostanie zakończona wyjątkiem System.InvalidOperationException: 'Collection was modified after the enumerator was instantiated.'
             * Kolekcja została zmodyfikowana po utworzeniu obiektu enumerator.
             */
            foreach (int liczba in stos)
            {
                stos.Push(liczba + 1);
            }
        }
    }
}
