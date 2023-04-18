using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaList
    {
        public static void Kolekcja_List()
        {
            /* Podobna do tablicy
             * Odwołanie do obiektu za pomocą indeksu w [] (tzw. notacja tablicowa)
             * Dodawanie elementów za pomocą metody Add(). Notacaja tablicowa nie jest dozwolona
             * Usuwanie elementów, metoda Remove(), RemoveAt()
             * Wstawianie elemntu w środek listy, metoda Insert()
             * Metoda Sort() do sortowania.
             * Określenie ilości, metoda Count w tablicy metoda Length.
             */

            /* Klasa kolekcji List<T> nie posiada takich ograniczeń jak tablica.
             * Nie musimy określać jej wielkości. Bedzie się sama skalować. Jest to dodatkowe obciążenie dlatego istnieje możliwość określenia początkowej wielkości.
             * Jeżeli w pewnym momencie elementów bedzie więcej, wtedy kolekcja zostanie automatycznie rozszerzona.
             */

            Pojemność();
            Usuwanie();
            Iteracja();
        }

        static void Pojemność()
        {
            /* Jeśli lista jest pusta Capacity = 0.
             * Po dodaniu elementu zostaje zwiększona o 4.
             * Po przekroczeniu Capacity zostaje zwiększone o kolejne 4.
             * Po usunięciu elemntu Capacity zostaje takie same, nawet jeśli można byłoby zmiejszyć
            */

            List<int> lista = new List<int>();
            lista.Capacity = 3; // Co jaką wartość lista ma się skalować w górę. Domyślnie jest 4.
            
            lista.AddRange(new[] { 1,2,3 });
            Console.WriteLine("lista.Count = " + lista.Count); //3
            Console.WriteLine("lista.Capacity = " + lista.Capacity); //3

            lista.Add(4);
            Console.WriteLine("lista.Count = " + lista.Count); //4
            Console.WriteLine("lista.Capacity = " + lista.Capacity); //6

            lista.Remove(1);
            Console.WriteLine("lista.Count = " + lista.Count); //3
            Console.WriteLine("lista.Capacity = " + lista.Capacity); //6
        }

        static void Usuwanie()
        {
            // Po usunięciu elementu lista automatycznie przesunie elementy i "zamknie dziure"
            List<int> lista = new List<int>() { 1, 2, 3, 4, 5, 10 };
            lista.Remove(10); // podajemy wartość a nie indeks

            lista.RemoveAt(2); // podajemy indeks, zostanie usunieta 3
        }

        static void Iteracja()
        {
            List<int> lista = new List<int>();

            lista = new List<int> { 1, 2, 3, 4, 5 }; // Gdy inicjujemy liste podczas deklaracji tak naprawdę wykonnujemy metodę Add!
            foreach (int x in new[] { 1, 2, 3, 4, 5 }) // Równoważność z inicjalizacją podczas deklaracji.
            {
                lista.Add(x); 
            }

            /* !!!UWAGA!!! Nie wolno w żaden sposób modyfikować listy (Add, Remove, Insert) podczas iteracji po tej kolekcji za pomocą pętli foreach.
             * Próba zostanie zakończona wystąpieniem wyjątku 'System.InvalidOperationException. Collection was modified; enumeration operation may not execute.' 
             * Operacja wyliczania nie może się wykonać.
            */
            foreach (int liczba in lista)
            {
                if (liczba % 2 != 0)
                {
                    lista.Add(liczba);
                }
                else
                {
                    lista.Remove(liczba);
                }
            }

            /* Natomiast podczas iteracji Listy za pomocą pętli 'for' lub 'while' możemy ją Modyfikować.
             * Należy jednak uważać na pewne pułapki opisane niżej:
             * - po usunięciu elementu np. 3 z pięciu, 2 ostatnie elementy przesuną się aby zamknąć dziure.
             *    lista = new {1,2,3,4,5}
             *    if lista[i] == 3 -> lista.Remove(i)
             *    zmienna4 = lista[i] // lista[i] odwołuje się do 3 elementu z listy, czyli lista[3] == 4
             *    
             * - po usunięciu elementu ostatniego elementu, nie bedziemy mogli się do niego juz odwołać
             *    lista.RemoveAt(i);
             *    if lista[i] == costam //  OutOfRangeException, bo ostatni element został usunięty i już nie istnieje w kolekcji.
             *    
             * - dodawanie co iteracje nowgo elementu spowoduje exception OutOfMemeoryException
             */
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] % 2 == 0)
                {
                    lista.RemoveAt(i); // trzeba mieć jednak na uwadze, że jak usuniemy ostatni element to nie bedziemy mogli odwołać się do niego.
                }
                if (lista[i] % 2 != 0) // OutOfRangeException, bo ostatni element jest nieparzysty i już nie istnieje w kolekcji.
                {
                    lista.Add(i); // bez przerwy dodawanie elementów też powoduje problem OutOfMemeoryException. (pod warunkiem, że bedziemy dodawac element co iteracje)
                }
                if (lista[i] % 10 == 2)
                {
                    lista.Insert(i, 100);
                }
            }
        }
    }
}
