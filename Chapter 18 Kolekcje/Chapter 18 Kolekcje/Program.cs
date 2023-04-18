using System;
using System.Collections.Generic;
using System.Linq;
using Chapter_18_Kolekcje.Kolekcje;
using Chapter_18_Kolekcje.Lambda;
using Chapter_18_Kolekcje.Lambda_i_Delegate;

namespace Chapter_18_Kolekcje
{
    /* 
      Biblioteka klas .NET Framework udostepnia kilka kolekcji - znajduja sie w przestrzeni System.Collection.Generic (Jak wskazuje nazwa są typu generycznego)
      
      Każda kolekcja ma swoje silne i słabe strony i jest zoptymalizowna pod kątem przechowywana i dostępu do danych:
      - Stack <T> (stos) implementuje model kolejki LIFO (Dodawanie Push, Pobieranie Pop (zwraca i usuwa ostatnio dołążony element ze stosu, czyli pierwszy z góry stosu)).
      - Queue <T> kolejka implementuje kolejke FIFO (Dodawanie Enqueue, Pobiera Enqueue (zwraca i usuwa najstarszy element z kolejki, czyli ostatni element ze stosu)).
      - List<T> obiekty dostepne za pomoca indeksu, podobna do tablicy ale posiada dodatkowe mozliwości wyszukania i sortowania elementow.
      - LinkedList<T> uporządkowana lista umożliwiająca dodawanie i usuwanie na obu koncach. Moze zachowywac sie jak stos lub kolejka, ale umożliwia tez dostęp bezposredni.
      - HashSet<T> Nieuporządkowana lista, zoptymalizowana aby pobierać szybko dane. Zawiera metody w stylu działań na zbiorach. (Sprawdzanie podzbiorów, częsci wspolnej itp).
      - Dictionary<TKey, TValue> dostęp do elementów za pomocą klucza.
      - SortedList<TKey, TValue> Posortowana lista par klucz/wartość. Klucze muszą implementować interfejs IComparable<T>.
      
      Biblioteka klas .NET Framework udostępnia jeszcze INNE typy kolejek które znajdują się w przestrzeni nazw System.Collection.
      Zostały one dodane (w .NET Framework v.2.0) przed typami generycznymi  w .NET Framework v.3.0) przechowują referencje do obiektów i podczas zapisu-odczytu należy je rzutować.
      NIE należy z nich korzystać w nowych projektach.
      Jedyną klasa w tej przestrzeni, która nie przechowuje referencji jest BitArray.
      Implementuje ona tabelę wartości logicznych, wykorzystując typ int. (Konstrukcja przypomina IntBits z rozdzialu 16)
      
      Są jeszcze kolekcje przeznaczone do działań wielowątkowych, znajdują sie w przestrzniu System.Collection.Concurrent.
      Więcej w rozdziale 24 "Skracanie czasu reakcji za pomocą działań asynchoronicznych".
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Tablice();
            Różnice_Tablice_Kolekcje();
            Inicjalizacja_Kolekcji();
            Wyszukiwanie_Elementów_Kolekcji();

            KolekcjaList.Kolekcja_List();
            KolekcjaLinkedList.Kolekcja_LinkedList();
            KolekcjaKolejki.Kolekcja_Kolejka();
            KolekcjaStos.Kolekcja_Stos();
            KolekcjaDictionary.Kolekcja_Dictionary();
            KolekcjaSortedList.Kolekcja_SortedList();
            KolekcjaHashSet.Kolekcja_HashSet();

            WyrazenieLambda.Wyrazenie_Lambda();
            Delegaty.Cwiczenia_z_UzyciemLamdy_i_Delegat();

            Console.ReadLine();
        }

        static void Tablice()
        {
            /* - Rozmiar tablicy jest stały. Jeżeli chcemy zmienic rozmiar tablicy, tworzymy nową i kopiujemy wszystkie elementy ze starej tablicy
             * - Dostep do danych - tylko za pomocą indeksu całkowitego w nawiasach kwadratowych (tzw. notacja tablicowa)
             * - Usuwananie elementu, musimy cofnąć o 1 pozycje wszystkie elementy.
             * - Dodawanie elementu, musimy przesunąć wszystkie elementy o 1.
             */
        }

        static void Różnice_Tablice_Kolekcje()
        {
            /* - Rozmiar kolekcji jest dynamiczny.
             * - Jest jednowymiarowa ale elementami kolekcji mogą być inne kolekcje.
             * - Niektóre kolekcje posiadają metodę ToArray która na podstawie kolekcji generuje tablice,
             * ponadto posiadają one również konstruktor który na podstawie tablicy utworzy kolekcje.
             */
        }

        static void Inicjalizacja_Kolekcji()
        {
            /* Inicjalizacja List<T> 
             * metoda: Add()
             * lub podczas deklaracji: */
            List<int> lista = new List<int> { 1, 2, 3 }; // kompilator wewnetrznie zamieni to na wywołanie metody Add().
            lista[1] = 4;

            /* Inicjalizacja Stack<T> Queue<T>
            * metoda: Pop(), Push()
            * 
            * Inicjalizacja Dictionary<TKey, TValue>
            * notacja indeksora: */
            Dictionary<string, int> persons = new Dictionary<string, int>()
            {
                ["John"] = 52,
                ["Jenny"] = 34
            };

            /* para kluczy jako typ anonimowy: */
            Dictionary<string, int> otherPersons = new Dictionary<string, int>()
            {
               { "John", 52 },
               { "Jenny", 34 }
            };
            otherPersons["John"] = 44; // Wartość zostanie podmieniona!!!
            otherPersons.Add("John", 45); // Exception taki klucz istnieje!!!

            /* Zalecane jest uzywanie notacji indeksora zawsze gdy jest to możliwe. */
        }

        static void Wyszukiwanie_Elementów_Kolekcji()
        {
            /* Kolekcje Słownikowe Dictionary
             * Wyszukiwanie:
             * - po kluczu,
             * - metoda ContainsKey,
             * - Linqu
             */
            Dictionary<string, int> persons = new Dictionary<string, int>()
            {
                ["John"] = 52,
                ["Jenny"] = 34
            };
            int johnsAge = persons["John"];
            persons.ContainsKey("John");
            persons.Select(x => x.Key == "John");

            /* Inne kolekcje które nie zawierają klucza.
             * List<T>, LinkedList<T>
             * posiadają metodę Find która zwraca element kolekcji.
             * Argumentem metody Find jest 'predykat' określający kryteria wyszukiwania.
             * Predykat ma postać metody która zwraca wartość logiczną.
             * W przypadku metody Find predykat wykonuje się dla każdego elementu kolekcji.
             * 
             * Inne metody: FindLast(), FindAll()
             * 
             * Najprostrzym sposobem dodania predykatu jest wyrażenie 'lambda'. (Można też uzyć metod anonimowych lub metod nazwanych ale nie jest to zalecane.)
             * Wyrażenie 'lambda' zwraca metodę.
             */

            List<int> lista = new List<int> { 1, 2, 3 };
            lista.Find((int x) => { return x == 0; }); // predykatem jest wyrażenie lambda

            lista.Find(x => SzukajStarszegoNizJohn(x)); // predykatem jest metoda nazwana
           
            bool SzukajStarszegoNizJohn(int x)
            {
                return x > johnsAge;
            }
        }
    }
}
