using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Lambda_i_Delegate
{
    internal class Delegaty
    {
        public delegate int Calculate(int a, int b);
        public delegate T DelegateAggregate<T>(T a, T b);

        public Delegaty()
        {
            /* Dodanie metody do delegate za pomocą wyrażeń lambda */
            Calculate cal2 = (x, y) => x + y;
            cal2 += (x, y) => x / y;
            cal2(3, 4);

            /* Dodanie metody do delegate za pomocą metod nazwanych */
            Calculate cal = MojaMetodaAdd;
            cal += MojaMetodaSubstract;
            cal(2, 4);

            int MojaMetodaAdd(int x, int y)
            {
                return x + y;
            }
            int MojaMetodaSubstract(int x, int y) => x - y; 
        }

        public static void Cwiczenia_z_UzyciemLamdy_i_Delegat()
        {
            MojaLista<int> mojaListaIntow = new MojaLista<int>() { 2, 5 };
            mojaListaIntow.Find(x => x > 4);

            MojaLista<string> bracia = new MojaLista<string>() { "Pawel", "Mateusz", "Tomek" };
            bracia.Find(x => x.Length > 2);
            bracia.Aggregate( (longest, next) => longest.Length >= next.Length ? longest : next );
        }

        class MojaLista<T> : ICollection<T> // Dodałem ten interfejs tylko po to aby móc zainicjalizowac liste podczas deklaracji.
        {
            private T[] values;

            // Definiowanie delegatu w klasie chyba nie jest zalecane. Delegat 'Predicate<T>' użyty w metodzie 'Find' kolekcji 'List<T>' znajduje się poza klasą.
            public delegate bool DelegateFind(T a); 

            public int Count { get { return values.Length; } }

            public bool IsReadOnly => throw new NotImplementedException();

            public void Add(T item)
            {
                if (values == null)
                {
                    values = new T[] { item };
                }
                else
                {
                    var temp = new T[values.Length + 1];
                    values.CopyTo(temp, 0);
                    temp[temp.Length - 1] = item;

                    values = temp;
                }
            }

            public T Get(int index)
            {
                if (index >= values.Length)
                {
                    return default(T);
                }

                return values[index];
            }

            // obiekt predict traktujemy jak metode, poniewaz delegaty przechowują referencje do metod.
            public T Find(DelegateFind predict)
            {
                foreach (T element in values)
                {
                    if (predict(element))
                    {
                        return element;
                    }
                }

                return default(T); // lub poprostu 'default' kompilator sie domysli
            }

            // predykat bedzie metodą która sprawdza długosc 2 zmiennych i zwraca ten dłuższy (public delegate T DelegateAggregate<T>(T a, T b);)
            public T Aggregate(DelegateAggregate<T> predict) 
            {
                T searchingElement = default; // lub default(T) kompilator sie domysli
                if (values.Length > 1)
                {
                    searchingElement = values[0];
                }

                for (int i = 0; i < values.Length - 1; i++)
                {
                    searchingElement = predict(searchingElement, values[i + 1]);
                }

                return searchingElement;
            }

            public MojaLista<T> FindAll(Predicate<T> predict) // Predicate<T> znajduje sie w przestrzeni nazw System.
            {
                MojaLista<T> listaTemp = new MojaLista<T>();
                foreach (T element in values)
                {
                    if (predict(element))
                    {
                        listaTemp.Add(element);
                    }
                }

                return listaTemp;
            }

            //Nie istotne w omawianym temacie.
            public void Clear() => throw new NotImplementedException();
            public bool Contains(T item) => throw new NotImplementedException();
            public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();
            public bool Remove(T item) => throw new NotImplementedException();
            public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        }
    }
}
