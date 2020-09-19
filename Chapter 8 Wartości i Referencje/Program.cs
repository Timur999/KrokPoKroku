using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valuesAndReferences.Model;

namespace valuesAndReferences
{
    // Typy wartościowe mają stały rozmiar.
    // Gdy deklarujemy zmienną typu wartościowego to kopilator rezerwuje na stosie odpowiedni rozmiar pamięci aby pomieścic wartość danego typu np. int zajmuje 4 bajty (32bity).
    // Typy referencyjne
    // Gdy deklarujemy zmienna typu referencyjnego to kopilator rezerwuje na 'stosie' (ang. stack) niewielką ilość pamięci aby zapisac adres (referencje) do obiektu.
    // Faktyczny przydział pamięci nastąpi na stercie (ang. heap) dopiero podczas tworzenia obiektu za pomocą słowa kluczowego 'new' oraz zostanie przypisana od zmiennej referencja.
    // Stos - System przydziela każdej aplikacji własny stos.
    // Podczas wykonywania metody pamieć potrzebna do przechowywania parametrów funkcji oraz lokalnych zmiennych funkcji jest rezerwowana na stosie.
    // Po zakończeniu metody lub przy zgłoszeniu wyjątku ta pamięć jest zwalniana.
    class Program
    {
        static void Main(string[] args)
        {
            CopyAndPassRefToObject();
            ConditionalNullOperator();
            NullableVariable();
            RefAndOutParameterType();
            SystemObjectClass();
            Boxing();
            UnBoxing();
            SaveCastingOperatorIsAndAs();
            SwitchStatement();
            Console.ReadKey();
        }

        static void CopyAndPassRefToObject()
        {
            WrappedInt wi = new WrappedInt();
            Pass.Reference(wi); // Przekazujemy referencje do obiektu 'wi'. Do funkcji zawsze trawia wartość ze stosu.

            // Kompilator rezerwuje pamiec i przekazuje referencje do zmiennej
            WrappedInt wi2 = new WrappedInt();

            //Garbage collection 
            // Nadpisujemy referencje, do poprzedniego miejsca w pamięci żadna zmienna już się nie odwołuje więc Garbage collection odzyskuje zaalokowaną pamięc.
            // Ten proces jest kosztowny czasowo-sprzętowo.
            wi2 = wi;
            // Dobrą praktyką jest aby przypisywać/kopiować referencje do zmiennej gdy nie zawiera jeszcze żadnej referencji.
            WrappedInt wi3 = null;
            if (wi3 == null)
            {
                wi3 = wi;
            }

            // Note: Do funkcji zawsze trawia wartość ze stosu.
        }

        static void ConditionalNullOperator()
        {
            // Operator warunkowy wartości null (?)
            Pass p = null;

            // Operator warunkowy null przed uzyciem metody instancji sprawdza czy dany obiekt/instancja nie jest null`em.
            // Jeśli jest null`em to dana metoda NIE zostanie wykonana. 

            // W tym przypadku instrukcja zostanie pominięta.
            Console.WriteLine($"p value is: {p?.ToString()}");  // Wyswietli się "p value is:" |  Console.WriteLine($"p value is: {null}");

            string stringValue = p?.ToString(); // Nie zostanie zgłoszony wyjątek. Do zmiennej stringValue przypisze nulla  

            // OtherObject jest null`em
            p = new Pass();
            int? intValue = p.OtherObject?.GetIntegerValue();  //  Do zmiennej intValue przypisze nulla           
        }

        static void NullableVariable()
        {
            // Zmienne Nullowalne (Typy danych dopuszczające zapis wartości null). Zmienne Nullowalne są typu referencyjnego.
            int? a = null;

            // Zmienne Nullowalne posiadają 2 właściwości:
            bool b = a.HasValue; // Sprawdza czy zmienna 'a' posiada wartość.
            int v = a.Value; // Zwraca wartość typu prostego jeśli istnieje.

            // Pass? objPass = null; Błąd kompilacji
            // Zmienne referencyjne nie można przerobić na Zmienną Nullowalną gdyż do nich zawsze można przypisać nulla. Zmienne referencyjne nie posiadają tych 2 własciwości.

            //Note: Zmienne Nullowalne są typu referencyjnego.
        }

        static void RefAndOutParameterType()
        {
            // Modyfikatory ref i out powodują, że parametry funkcji stają się aliasem/przedłużeniem jej argumentu. Funkcja nie tworzy kopii tylko pracuje na oryginale.

            WrappedInt wrappedInt = new WrappedInt(10);
            int iValue = 4;
            ChangeValue(wrappedInt, iValue); // zmienna przekazana do metody nazywamy argumentem.
            Console.WriteLine($"{wrappedInt.Value}, {iValue}"); // 14, 4
            ChangeValue(ref wrappedInt, ref iValue);
            Console.WriteLine($"{wrappedInt.Value}, {iValue}"); // 1, 9

            // Modyfikator 'out' umożliwia przekazanie zmiennych (wartosciowych i referencycjnych) do funkcji przed ich zainicjowaniem.
            // W takiej funkcji musi nastąpić przypisanie wartości do argumentu.
            int arg;
            DoIncrement(out arg);

            //Note: Z modyfikatorami 'out' 'ref' funkcja nie tworzy kopii zmiennej tylko pracuje na oryginale.
        }

        static void ChangeValue(WrappedInt wrappedInt, int iValue)
        {
            // Do funkcji trafia wartość ze stosu, następnie funkcja tworzy zmienną tego samgo typu i o tej samej wartości (kopie).
            wrappedInt.Value = 14;
            iValue = 9;

            //Note: W tym przypadku metoda utworzy 2 kopie.
        }

        static void ChangeValue(ref WrappedInt wrappedInt, ref int iValue) 
        {
            // Funkcja nie tworzy kopii.

            wrappedInt.Value = 99;

            // Zmieniamy wartość na stosie.
            wrappedInt = new WrappedInt(1); 
            iValue = 9;

            //Note: Funkcja nie tworzy kopii zmiennych tylko pracuje na oryginale.
        }

        static void DoIncrement(out int param)
        {
            // param++; 
            // błąd kompilacji, 'param' jest argumentem, przed wykonaniem takiej operacji nalezy ją najpierw zainicjować.

            param = 0;
            param++;
        }

        static void SystemObjectClass()
        {
            // Zmienna typu 'object' moze przechowywać referencje do dowolnego obiektu.
   
            WrappedInt w1 = new WrappedInt();
            object o = w1;

            //Note: Rekomedowanie jest uzywanie aliasu 'object' zamiast System.Object tak samo jak 'string' zamiast System.String
        }
        static void Boxing() // Opakowywaniem (ang. Boxing)       
        {
            // Opakowywanie zmiennych typu referencyjnego
            // Zmienne typu 'object' mogą również przechowywać wartości zmiennych typu wartościowego.
            int value = 13;

            // Środowisko uruchomieniowe alokuje odpowienią ilość pamięci na stercie (ang.heap) aby pomieścić odpowiedni typ danych.
            // Przekazuje kopię wartości na sterte i przekazuje do niej referencje na stos.
            object ob = value;

            value++; //14
            ob.ToString(); //13

            //Note: Tworzenie zmiennej referencyjnej na podstawie zmiennej wartościowej. Taka operacja nazywa sie opakowywaniem (ang. Boxing)            
        }
        static void UnBoxing() // Rozpakowywanie
        {
            object obj = 33;
            // Rzutowanie (ang. cast) zmiennej object z powrotem do zmiennej wartościowej/prostej.
            // Kompilator generuje kod, który podczas wykonywania programu sprawdza zgodność typów pomiędzy typem zdefinowanym w () a rzeczywistym typem przechowywanym w obiekcie (na stercie).
            int intValue = (int)obj;

            // Zostanie skompilowany bez błedu ale w czasie wykonywania zostanie zgloszony wyjątek: InvalidCastException
            //WrappedInt wrapInt = (WrappedInt)obj;
            //decimal d1 = (decimal)obj;

            //Uwaga: Nie mylić unboxingu z rzutowaniem typów wartościowych.
            // Rzutowanie typu wartościowego -- Inna Bajka
            // Wartość liczbowa 'int' jest mniejszej precyzji niż 'decimal', w takich wypadkach można rzutować 'niejawnie'.  
            decimal d2 = (decimal)intValue; // Zadziała. Kompilator podpowiada, że '(decimal)' jest niewymagany.
            decimal d3 = 15.99m;
            // Rzutowanie decimal do inta. Należy 'jawne' określenie typu danych.
            int i2 = (int)d3; 

            //Note: Operacje Pakowania i Rozpakowania ze względu na alokowanie dodatkowej pamięci na stercie i dodatkowe instrukcje sprawdzające poprawność typu są bardzo kosztowne sprzętowo
        }
        static void SaveCastingOperatorIsAndAs()  //Save casting - operator 'is' i 'as'. Bezpieczne rzutowanie
        {
            // Kompilator nie sprawdza czy typy zmiennych są ze sobą zgodne lecz srodowisko uruchomieniowe (.Net)

            WrappedInt wrapInt = new WrappedInt();
            object obj = new WrappedInt();

            // Operator 'is' wykorzystywany jest do sprawdzenia typu obiektu.
            // Jeśli typ danych zgadza się z typem obiektu znajdującym się na stercie zwróci 'true' jeśli nie 'false'.
            bool b = wrapInt is WrappedInt; // true
            b = wrapInt is object; // true
            b = obj is WrappedInt; //true

            // SAVE CASTING
            if (obj is WrappedInt)
            {
                WrappedInt temp = (WrappedInt)obj; // Operacja bezpieczna
            }
            else
            {
                WrappedInt temp = null;
            }

            // Operator 'as' pełni taką samą role co operacja SAVE CASTING. Równiez posiada 2 arg. po lewej referencje do obiektu na stercie po prawej typ danych.
            // Środowisko uruchomieniowe w czasie wykonywania programu podejmie próbę rzutowania, gdy sie powiedzie zwróci wartość w przciwnym razie NULL`a.
            WrappedInt temp2 = obj as WrappedInt; 
            if(temp2 != null)
            {
                // Operacja rzutowania zakonczyła sie sukcesem
            }

            // Note: Więcej na temast 'is', 'as' ma przedstawiac rozdział 12 (Dziedziczenie).
        }
        static void SwitchStatement()
        {
            Circle c = new Circle(11);
            Square s = new Square(14);
            Triangle t = new Triangle(17);

            object o = t;
            if(o is Square mySquare) // Referencja dostepna w obiekcie 'mySquare'. Jej zasieg nie wykracza poza ifa ani case.
            {
                Console.WriteLine(mySquare.SideLength);
            }else if(o is Circle myCircle) { }

            switch (o) // case sprawdza typ danych obiektu o.  Działanie jak za pomoca instruckji if powyzej.
            {
                case Circle circle:
                    Console.WriteLine("o is circle {0}", circle.ToString());
                    break;
                case Square square:
                    Console.WriteLine("o is square {0}", square.ToString());
                    break;
                case Triangle triangle when triangle.SideLength > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.SideLength);
                    break;
                case Triangle triangle:
                    Console.WriteLine("o is triangle");
                    break;
            }
            switch (o) // case i when
            {
                case Triangle triangle when triangle.SideLength > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.SideLength);
                    break;
                case Triangle triangle when triangle.SideLength > 10:
                    Console.WriteLine("Small triangle {0}", triangle.SideLength);
                    break;
            }
        }
    }

}
