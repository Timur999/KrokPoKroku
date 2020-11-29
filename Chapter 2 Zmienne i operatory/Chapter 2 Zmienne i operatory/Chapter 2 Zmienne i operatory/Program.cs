using System;

/* Identyfikatory to nazwy do identyfikowania różnych elementów programu np. nazwy klas, przestrzeni nazw, metod, zmiennych.
 * W jezyku C# identyfikatory muszą spełniać następujące warunki:
 * identyfikatory muszą składać się z liter (małych lub dużych) cyfr i znaku podkreślnika '_'
 * identyfikatory muszą rozpoczynać się od liery (małej lub dużej) lub od znaku podkreślnika '_'
 */


namespace Chapter_2_Zmienne_i_operatory
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // Zasady nazywania zmiennych
        static void NazywanieZmiennych()
        {
            /* Rekomendowane jest nazywać zmienne z małej liery nie uzywając znaku '_'. W przypadku integracji takiego programu 
             * z programem napisanym w języku Visual Basic nastąpiłby błąd, gdyż Visual Basic nie rozróżnia wielkości liter w nazwach
             * zmiennych a także uniemożliwia nazywać zmienne rozpoczynając od podkreślnika '_'.
             */

            // Używamy notacji camelCase 
            int zmienna, mojaZmienna, _zmienna, zmienna9, Zmienna;

            //Note: wszystkie nazwy są prawidłowe ale tylko 2 pierwsze są zgodne z podanymi zaleceniami w książce.
        }

        static void DeklarowanieZmiennych()
        {
            // W jezyku C# nie dopuszczalne jest deklarowanie zmiennych w sposób niejawny np. Visual Basic jest to dozwolone.
            int wiek;


            /* .Net Framework w tle przekonwertuje wartosc całkowitą na zmiennoprzecinkową. Jest to stosunkowo mało szkodliwa lecz
             *  nie koniecznie dobra praktyka. Powinniśmy jawnie zdefiniować, że bedziemy zapisywać wartość zmiennoprzecinkową dodając sufix 'F'/'f'.
             */
            float punktX;
            punktX = 42;
            punktX = 42F;


            /* Lietrały które zawierają znak dziesiętny w postaci '.' są traktowane przez kompilator jako literały typu o podwójnej precyzji (double).
             * Jeśli przypisujemy wartość 0.42 do float'a musimy dodać sufix (w istocie kopilator C# bedzie tego wymagał. kod sie nie skompiluje)
             */
            punktX = 0.42F;


            // Użycie sufixu L oznacza, że literał jest typu long, a M jest to decimal (decimal wartości finansowe).
            long l = 1L;
            decimal d = 12M;


            // Gdy do zmiennej lokalnej nie przypiszemy wartości to zostanie przypisana wartość losowa.
            int pusta;
            // Console.WriteLine(pusta); Kompilator nie zezwala używać zmiennej bez wartości.
        }

        static void Operatory()
        {
            /* + - * / można stoswać na wszystkich zmiennych typy primitywnego oprócz bool i string.
             * Na stringach dozwolone jest uzycie +.
             * Zalecane jest aby uzywać interpolacji łancuchów zamiast operatora + (lepsza wydajność).
             */
            int wiek = 42;
            Console.WriteLine($"Mam lat {wiek}");


            /* Rezultat działań arytmetycznych jest takiego samego typu jak zmienne w działaniu. 
             * Jeśli dzielimy liczby całkowite to wynik zostanie zaokrąglony w dół.
             * Jeśli typy zmiennych w wyrażeniu są różne to przed operacją zostanie wartość int przekonwertowana do double. (nie jest to błędem
             * ale uznawane za złą praktykę w programowaniu)
             */
            double resultDouble = 5.0 / 2.0; // 2.5
            float resultFloat = 5.0f / 2.0f; // 2.5
            int resultInt = 5 / 2; // 2
            double resultDouble2 = 5 / 2.0; // 2.5
        }

        static void TypInfinityINan()
        {
            /* Typ double i float oferują specjalne wartości: infinity i Nan (not a number)
             * Infinity + 10 = Infinity
             * Nan + 10 = Nan
             * Infinity * 0 = Nan
             */
            double infinity = 5.0 / 0.0;
            double nan = 0.0 / 0.0;         
        }

        static void OperatorModulo()
        {
            // w C# operator reszty z dzielenia możemy zastosować na każdym numerycznym typie danych
            double result = 7.0 % 2.4; // wynik 2.2
        }

        static void PierwszenstwoOperatorow()
        {
            /* Operatory muliplikatywne (*, / i %) maja pierwszeństwo przed operatorami addytywnymi
             * operacje są wykonywane od lewej do prawej np. 4/2*3 = 2*3 = 6
             * są operatorami łącznymi lewostronie
             */
        }

        static void OperatorPrzypisania() // znak równości
        {
            // Operator przypisania zwraca wartość. Jest operatorem łącznym prawostronie
            int myInt1;
            int myInt2;
            int myInt3;
            int myInt4 = myInt3 = myInt2 = myInt1 = 10;

           
            int myInt5, myInt6, myInt7 = 10;
            // Uwaga: Tylko myInt7 posiada wartość 
        }

        static void NieJawnyTypDanych() 
        {
            var myInt = 10;
            var myString = "c#";
           
            // var myVariable; błąd, kompilator nie może określić typu danych.
        }
    }
}
