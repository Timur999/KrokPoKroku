using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaLinkedList
    {
        internal static void Kolekcja_LinkedList()
        {
            /* Jest to lista dwukierunkowa
             * Każdy element zawiera referencje do porzedniego elementu Previous oraz do następnego Next.
             * Właściwość Prevoius dla pierwszego elementu ustawiona jest na null. Z kolei w ostanim elemencie property Next jest nullem.
             * 
             * Nie obsługuje notacji tablicowej przy sprawdzaniu i dodawaniu elementów np. lista[0] == 1, lista[0] = 1
             * 
             * Dodwanie: metoda AddFirst(), AddLast(), AddAfter(), AddBefore()
             * 
             * Wlasciwosci: First, Last
             * 
             * Usuwanie: Remove(), RemoveLast(), RemoveFirst()
             */

            Dodawanie();
            Usuwanie();
            Iteracja();
        }

        static void Dodawanie()
        {
            /* LinkedList<int> lista = new LinkedList<int>() { 1, 2, 3 };
             * Taka inicjalizacja jest nie poprawna bo nie zawiera metody Add()
            */

            LinkedList<int> lista = new LinkedList<int>();

            lista.AddFirst(1);
            lista.AddFirst(2); // wsatwi na początku listy przesuwając wszystkie elementy o jeden do przodu.
                               // Ustawi referencje Next do drugiego elementu oraz referencje Prevoius drugiego elementu do nowo-dodanego.
            lista.AddLast(3); //  wstawi na końcu listy.
                              //  Ustawi property Prevoius do przedostatniego elementu oraz referencje Next przedostatniego elementu do nowo-dodanego.

            lista.AddAfter(lista.Last, 5); // dodaj przed.
                                           // Trzeba najpierw pobrać element przed którym będzie wstawiony nowy.
            lista.AddBefore(lista.First, 4); // dodaj za.
                                             // Trzeba najpierw pobrać element za którym będzie wstawiony nowy.
        }

        static void Usuwanie()
        {
            LinkedList<int> lista = new LinkedList<int>();
            foreach (int x in new[] { 1, 2, 10, 3 })
            {
                lista.AddFirst(x);
            }

            lista.Remove(10); // usunie przedostatni element listy o wartości 10.
            lista.Remove(lista.First); // usunie pierwszy element listy.

            lista.RemoveFirst();
            lista.RemoveLast();

            // Nie posiada metody RemoveAt, która przyjmuje indeks
        }

        static void Iteracja()
        {
            LinkedList<int> lista = new LinkedList<int>();
            foreach (int x in new[] { 1, 2, 3 })
            {
                lista.AddLast(x);
            }

            LinkedListNode<int> odPierwszegoElementu = lista.First; // nie zwraca inta tylko LinkedListNode<int>
            while (odPierwszegoElementu != null)
            {
                Console.Write(odPierwszegoElementu.Value + ", "); // 1, 2, 3,
                odPierwszegoElementu = odPierwszegoElementu.Next;
            }

            LinkedListNode<int> odOstatniegoElementu = lista.Last; // nie zwraca inta
            while (odOstatniegoElementu != null)
            {
                Console.Write(odOstatniegoElementu.Value + ", "); // 3, 2, 1,
                odOstatniegoElementu = odOstatniegoElementu.Previous;
            }

            foreach (int liczba in lista)  // a tu zwraca inta
            {
                Console.Write(liczba + ", "); // 1, 2, 3,
            }

            /* !!!UWAGA!!! Nie wolno w żaden sposób modyfikować listy (AddFirst, AddLast, Remove) podczas iteracji po tej kolekcji za pomocą 'foreach'.
             * Próba zostanie zakończona wyjątkiem System.InvalidOperationException. Collection was modified; enumeration operation may not execute. 
             * Operacja wyliczania nie może się wykonać.
            */
            foreach (int liczba in lista)
            {
                if (liczba % 2 != 0)
                {
                    lista.AddLast(liczba);
                }
                else
                {
                    lista.Remove(liczba);
                }
            }

            /* Natomiast podczas iteracji Listy za pomocą pętli 'for' lub 'while' możemy ją Modyfikować.
             * Należy jednak uważać na pewne pułapki opisane niżej:
             * - po usunięciu któregoś elementu lista przesuwa swoje elementy aby zasłonić dziure,
             * a sam element ustawia swoje properties: Next, Prevoius, List na null zostawia tylko Value (sam element nie jest nullem)
             *   lista.Remove(element) -> element.Next == null (true)
             *   
             * - dodawanie co iteracje nowego elementu na końcu list AddLast() spowoduje wyjątek OutOfMemeoryException
             *   natomiast dodanie na początku AddFirst zadziała poprawnie. Podwoi tylko liczbe elementów.
             */

            for (var element = lista.First; element != null; element = element.Next)
            {
                if(element.Value == 3)
                {
                    lista.Remove(element);
                }
                // po usunięciu 3 elementu pętla zakonczy działanie bo element.Next == null
            }
        }
    }
}
