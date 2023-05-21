using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_19_Iterator
{
    public class ProstaKolekcja<T> : IEnumerable<T>
    {
        private readonly List<T> data;

        public ProstaKolekcja(params T[] _data)
        {
            //wypełnianie listy
            data = new List<T>();
            for (int i = 0; _data.Length > i; i++)
            {
                data.Add(_data[i]);
            }
        }

        // GetEnumerator nie zwraca obiektu modułu wyliczającego ale w pętli iteruje po liście i zwraca każdy element.
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in data)
            {
                /* yield możemy traktować jako prośbę o chwilowe wstrzymanie metody i przekazanie wartości z powrotem do modułu Wywołującego.
                   Gdy moduł wywołujący żada nastepnej wartości, to metoda wznawia działanie tam gdzie przerwała prace.
                   po wyczerpaniu elementow z listy, wychodzi z pęli i to jest koniec Iteracji. */
                yield return item;
            }
        }

        // Alternatywny sposób iterowania po wlasnej kolekcji za pomocą pętli foreach.        
        public IEnumerable<T> Reverse //Note: Wlasciwość zwraca typ IEnumerable<T>, a nie IEnumerator<T>.
        {
            get
            {
                for (int i = data.Count - 1; i >= 0; i--)
                {
                    yield return data[i];
                }
            }
            // Przyklad uzycia: foreach (var band in musicBands.Reverse)
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
