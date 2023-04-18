using Chapter_18_Kolekcje.Lambda_i_Delegate;
using System;
using System.Collections.Generic;

namespace Chapter_18_Kolekcje.Lambda
{
    internal class WyrazenieLambda
    {
        /* Po co uzywać Wyrażeń Lambda?
         * Aby w wygodny sposób przekazywać metodę do delegate.
         * Lambda jest rozwinięciem metod anonimowych i zaleca się ich używanie zamiast metod anonimowych.
         * Co to jest Delegate?
         * Przechowuje referencje do metod, nie do obiektów. (innymi słowy: wskaźnik na funkcje).
         */
        internal static void Wyrazenie_Lambda()
        {
            /* Wyrażenie 'lambda' zwraca metodę.
             * Normalna metoda składa się ze 4 części: typ wartości zwracanej, nazwy metody, listy parametrów i ciała metody.
             * Wyrażenie 'lambda' tylko z 2: zawiera tylko liste parametrów i ciało metody.
             * Typ wartości zwracanej jest wyliczany z kontekstu.
             * 
             * Składnia:
             * - Jeśli zwiera wiecej niz 1 lub nie zawiera żadnego parametru podajemy nawiasy () przed operatorem =>,
             * - Jeżeli zawiera tylko 1 parametr możemy pominąć nawiasy klamrowe (),
             * - Operator => informuje ze jest to wyrażenie lambda,
             * - Może zawierać wiele instrukcji, może być dowolnie formatowany w sposób dla nas najbardziej czytelny, po każdej instrukcji dodajemy średnik ';',
             * - Jeżeli zawiera tylko 1 instrukcje możemy pominąć nawiasy klamrowe {} oraz średnik ; (jednak potrzebny jest średnik kończący całą instrukcje),
             * 
             * Inne ważne informacje:
             * - Typ parametru nie jest wymagany zostanie on wyliczony z konteksu,
             * - Możemy do parametru dodać słowo ref wówczas zmiany parametru nie bedą lokalne (nie jest to zalecane),
             * - Typ wartości zwracanej jest wyliczany z kontekstu i musi on być zgodny z odpowiednim delegatem,
             * - Zasięg zmiennych zdefiniowanych w metodzie wyrażenia lambdy jest taki sam jak w normalnych metodach,
             * - Wyrażenie lambda może korzystać ze zmiennych zdefinowanych poza wyrażeniem o ile są w jego zakresie, przykład LambdaZasięgZmiennych()
             */

            /* !!!WAZNE!!! 
             * kolekcja.Find(x => x == 0);
             * w rodziale 3 operator => służy do definiowania 'metod wcielających wyrażenie'. Jest to jeden z wielu zastosowań tego operatora.
             * Mimo to 'metody wcielające wyrażenie' i 'wyrażenie lambda' różnią się znacznie pod względem semantycznym (i funkcjionalnym) i nie należy ich mylić.
             * To nie to samo!!!
             */

            LambdaZasięgZmiennych();

            RóżneFormyWyrażeńLambda();

            WyrażeniaLambda_i_MetodyAnonimowe();

            Delegaty.Cwiczenia_z_UzyciemLamdy_i_Delegat();
        }

        static void LambdaZasięgZmiennych()
        {
            int x = 4; // zmienna loklalna
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            var w = list.Find(a => a == x); // można użyć zmienna 'x' w metodzie wyrażenia lambdy

            // taki sam przyklad z uzyciem zwyklej metody 
            list.Find(a => MotodaNaLoda(a)); // (jest to chyba połączenie lambdy i metody. Zawiera znak '=>' który informuje ze jest to wyrazenie lambda)
            bool MotodaNaLoda(int a)
            {
                return a == x; // w zwykłej metodzie też możana uzyc x.
            }
        }

        public delegate T DelegatWykonajDzialanie<T>(ref T a, T b);

        static void RóżneFormyWyrażeńLambda()
        {
            // x => x * 2 
            // x => { x * 2; }
            // (int x) => x / 2
            // () => obiekt.Metoda()
            // (x, y) => { x++; return x/y; }
            // (ref int x, int y) => { x++; return x/y; }

            DelegatWykonajDzialanie<int> wykonajDzialanie = (ref int a, int b) => { a += b;  return a; };
            wykonajDzialanie += (ref int a, int b) => { a *= b; return a; };

            int x = 2;
            wykonajDzialanie(ref x, 4);

            Console.WriteLine(x); // 24 (2+4 = 6 / 6*4 = 24)
        }

        public delegate void DelegatLotNaMarsa();
        public delegate T DelegatKalkulator<T>(T a, T b, List<T> results);

        static void WyrażeniaLambda_i_MetodyAnonimowe()
        {
            /* Wyrażenia Lambda zostały dodane do .NET Framework w wersji 3.0.
             * Metody anonimowe wcześniej w wersji 2.0. (Klasy anonimowe zostały krótko opisane w rozdziale 7 Tworzenie zarzadzanie klasami i obiektami).
             * Działają one podobnie ale Lambda jest lepsza i z niej należy korzystać (chyba, że sie nie da z jakiegoś powodu).
             * Metody anonimowe zostały dodane głównie po to, aby w wygodny sposób definiować delegaty (bez konieczności tworzenia metod nazwanych)
             * Składnia metody anonimowej:
             * - Metode anonimową trzeba poprzedzić słowem kluczowym 'delegate',
             * - Wszystkie wymagane parametry trzeba podać w nawiasach () po słowie 'delegate'.
             */

            DelegatLotNaMarsa lotNaMarsa = delegate { Console.WriteLine("Uruchomione Silki"); };
            lotNaMarsa += delegate { Console.WriteLine("10, 9, ..., 0"); };
            lotNaMarsa += delegate { Console.WriteLine("START!!!"); }; // metoda anonimowa
            lotNaMarsa += () => { Console.WriteLine("START!!!"); }; // wyrazenie lambda

            lotNaMarsa();

            // Zainicjiowanie delegata za pomocą metody anonimowa
            DelegatKalkulator<decimal> wykonajObliczenia = delegate (decimal a, decimal b, List<decimal> r)
            {
                r.Add(a + b);
                return a + b;
            };
            // Dodanie do delegata metodę anonimową
            wykonajObliczenia += delegate (decimal a, decimal b, List<decimal> r) // metoda anonimowa
            {
                r.Add(a * b);
                return a * b;
            };
            // Dodanie do delegata wyrażenie lambda
            wykonajObliczenia += (a, b, r) => { r.Add(a * b); return a * b; }; // wyrazenie lambda

            // Wykonanie/wywołanie delegata - wykonają się wszystkie 3 metody.
            List<decimal> wyniki = new List<decimal>();
            wykonajObliczenia(2m, 4.7m, wyniki);

            // Metodę anonimową można również podawac jako parameter w miejsce delegata (tak samo jak wyrażenie lambda), np.
            List<int> oceny = new List<int> { 1, 2, 3, 4, 5, 6 };
            int wynik = oceny.Find(delegate (int x) { return x == 6; }); // metoda anonimowa
            wynik = oceny.Find((int x) => { return x == 6; }); // wyrażenie lambda
            Console.WriteLine("Ocena celująca to: " + wynik);

            /* Podsumowanie:
             * Wyrażenia Lamba oferują składnie bardziej zwięźlejszą i bardziej naturalną. Jest częściej stosowana oraz zalecana.
             * Zalecane jest używanie wyrażeń lambda!!!
             */
        }
    }
}
