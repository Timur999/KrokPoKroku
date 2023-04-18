using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Kolekcje
{
    internal class KolekcjaDictionary
    {
        internal static void Kolekcja_Dictionary()
        {
            /* Klasa Dictionary<TKey, TValue> elementy są połączeniem klucza i wartości
             * Wewnętrznie implementuje 2 tablice. Jedną na klucze i druką na wartości.
             * 
             * Cechy kolekcji Dictionary:
             * - Nie może posiadać dwóch takich samych kluczy,
             * - Jest rozproszoną strukturą danych, która działa najwydajniej gdy ma dużo wolnej pamięci,
             * - Dictionary składa się z elementów KeyValuePair. Podczas iteracji kolekcji dostajemy kopie klucza i wartości które są tylko do odczytu.
             * 
             * Odwołanie do elementu: za pomocą klucza w [] (tzw. notacja tablicowa)
             * 
             * Dodawanie: metoda Add(), notacja tablicowa dictionary["Zbroja"] = 10
             * 
             * Usuwanie: Remove(Key)
             * 
             * Iteracja: tylko petla foreach (Nie wolno modyfikowac listy podczas iteracji w perli foreach)
             * 
             * Metoda ContainsKey do sprawdzania czy istnieje element
             */

            Inicjalizacja();
            Dodawanie();
            Usuwanie();

            /* Przestrzeń nazw System.Collections.Generic zawiera rownież klasę 'SortedDictionary<TKey, TValue>', która posiada elementy posortowane według klucza. */
        }

        static void Inicjalizacja()
        {
            Dictionary<string, int> sklep = new Dictionary<string, int> { ["Zbroja"] = 100, ["Miecz"] = 200 };
            // Wewntrznie kompilator zamieni powyższa inicjacje na wywołanie motody Add

            sklep.Add("Tarcza", 300);
            sklep.Add("Miecz", 400); // Zostanie zgłoszony wyjątek ze taki klucz istnieje
            sklep["Miecz"] = 400; // Wartość zostanie podmieniona
            sklep["Amulet zakonnika"] = 1050; // Zostanie dodany nowy element
        }

        static void Dodawanie()
        {
            Dictionary<int, string> slownik = new Dictionary<int, string> { [1] = "Jeden", [2] = "Dwa" };
            slownik.Add(3, "Trzy");
            slownik[4] = "Cztery";

            foreach (var keyValue in slownik)
            {
                Console.Write(keyValue.Value + ", "); // Jeden, Dwa, Trzy, Cztery,
            }

            foreach (var keyValue in slownik)
            {
                if (keyValue.Key == 4)
                {
                    //keyValue.Value = 800; // Zmienna tylko do odczytu. -> Bład na etapie kompilacji. 
                }
            }
        }

        static void Usuwanie()
        {
            Dictionary<string, int> sklep = new Dictionary<string, int> { ["Zbroja"] = 100, ["Miecz"] = 200 };

            if (sklep.ContainsKey("Zbroja"))
            {
                sklep.Remove("Zbroja");
            }

            foreach (var towar in sklep)
            {
                Console.WriteLine(towar.Key + " Cena: " + towar.Value); // Miecz Cena: 200
            }

            /* !!!UWAGA!!! Nie wolno w żaden sposób modyfikować Dictionary (Add, Remove, czy za pomocą notacji tablicowej) podczas iteracji po tej kolekcji za pomocą pętli foreach.
             * Próba zostanie zakończona wystąpieniem wyjątku 'System.InvalidOperationException. Collection was modified; enumeration operation may not execute.' 
             * Operacja wyliczania nie może się wykonać.
             */

            Dictionary<int, string> liczby = new Dictionary<int, string> { [1] = "Jeden", [2] = "Dwa" };
            foreach (var liczba in liczby)
            {
                if(liczba.Key == 2)
                {
                    liczby.Add(3, "Trzy");
                }
            }

            /* Natomiast podczas iteracji Dictionary za pomocą pętli 'for' lub 'while' możemy ją Modyfikować.
             * Należy jednak uważać na pewne pułapki opisane niżej:
             * - po usunięciu elementu np. 3 z pięciu, 2 ostatnie elementy przesuną się aby zamknąć dziure.
             *    lista = new <int, string> { [1] = "Jeden", [2] = "Dwa", [3] = "Trzy" };
             *    if lista[i] == 2 -> lista.Remove(i)
             *    zmienna3 = lista[i] // lista[i] odwołuje się do 2 elementu z listy, czyli lista[2] == "Trzy" 
             *    
             * - po usunięciu elementu ostatniego elementu, nie bedziemy mogli się do niego juz odwołać
             *    lista.Remove(i);
             *    if lista[i] == costam //  OutOfRangeException, bo ostatni element został usunięty i już nie istnieje w kolekcji.
             *    
             * - dodawanie co iteracje nowgo elementu spowoduje exception OutOfMemeoryException
             */
            for (var index = 0; sklep.Count > index; index++)
            {
                if (liczby[index] == "Dwa")
                {
                    liczby[3] = "Trzy";
                }

                if (liczby[index] == "Trzy") // "Trzy" to jest ostatni element w kolekcji, jak go usuniemy to nie bedziemy mogli odwołać się do tego elementu
                {
                    liczby.Remove(index); // usuwamy ostani element
                }

                Console.Write(liczby[index]); // odwołujemy się do ostatniego elementu, który został usunięty. OutOfRangeException
            }
        }
    }
}
