using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valuesAndReferences.Model;

namespace valuesAndReferences
{
    // Typy wartościowe mają stały rozmiar.
    // Gdy deklarujemy zmienną typu wartościowego to kopilator rezerwuje na stosie odpowiedni rozmiar pamięci aby pomieścic wartość danego typu np. int ma rozmiar 4 bajtow (32bity).
    // Typy referencyjne
    // Gdy deklarujemy zmienna typu referencyjnego to kopilator rezerwuje na 'stosie' (ang. stack) niewielką ilość pamięci aby móc zapisac adres (referencje) do obiektu.
    // Faktyczny przydział pamięci nastąpi na stercie (ang. heap) dopiero podczas tworzenia obiektu za pomocą słowa kluczowego 'new' oraz zostanie przypisana od niego referencja.
    // Stos - System przydziela każdej aplikacji własny stos.
    // Podczas wykonywania metody pamieć potrzebna do przechowywania parametrów funkcji oraz lokalnych zmiennych funkcji jest rezerwowana na stosie. Po zakończeniu metody lub przy zgłoszeniu wyjątku ta pamięć jest zwalniana
    // 
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
            Pass.Reference(wi);

            // Kompilator rezerwuje pamiec i przekazuje referencje do zmiennej
            WrappedInt wi2 = new WrappedInt();
            // Nadpisujemy referencje, do poprzedniego miejsca w pamięci żadna zmienna już się nie odwołuje więc Garbage collection odzyskuje zaalokowaną pamięc. Ten proces jest kosztowny czasowo-sprzętowo.
            wi2 = wi;
            // Dobrą praktyką jest aby przypisywać/kopiować referencje do zmiennej gdy nie zawiera jeszcze żadnej referencji.
            WrappedInt wi3 = null;
            if (wi3 == null)
            {
                wi3 = wi;
            }
        }

        static void ConditionalNullOperator()
        {
            // Operator warunkowy wartości null (?)
            Pass p = null;

            // Operatorem warunkowym null przed uzyciem metody na obiekcie sprawdza czy dany obiekt nie jest null`em.
            // Jeśli jest null`em to dana metoda NIE zostanie wykonana 

            // W tym przypadku instrukcja zostanie pominięta.
            Console.WriteLine($"p value is: {p?.ToString()}");  // Wyswietli się "p value is:" |  Console.WriteLine($"p value is: {null}");

            string stringValue = p?.ToString(); // przypisze nulla  

            // OtherObject jest null`em
            p = new Pass();
            int? intValue = p.OtherObject?.GetIntegerValue();  // przypisze nulla  

            // Note: Jeśli obj jest nullem to metoda zostanie pominięta i zostanie przypisana wartość obiektu.
        }

        static void NullableVariable()
        {
            // Zmienne Nullowalne (Typy danych dopuszczające zapis wartości null). Zmienne Nullowalne są typu referencyjnego.
            // Możliwe jest tworzenie bardziej rozbudowanych zmienncyh nullowalnych niż poniższy przykład.
            int? a = null;

            // zmienne nullowalne posiadają 2 właściwości:
            bool b = a.HasValue; //sprawdza czy zmienna 'a' posiada zwykłą wartość (reprezentującą przez typ wartościowy (prosty))
            int v = a.Value; //zwraca wartość typu prostego jeśli istnieje.

            // Pass? objPass = null; Błąd kompilacji
            // Note: Zmienne referencyjne nie można przerobić na 'nullowalną' gdyż do nich zawsze można przypisać nulla. Zmienne referencyjne nie posiadają tych 2 własciwości.
        }

        static void RefAndOutParameterType()
        {
            // Modyfikatory ref i out powodują, że parametry funkcji stają się aliasem/przedłużeniem jej argumentu.

            WrappedInt wrappedInt = new WrappedInt(10);
            int iValue = 4;
            ChangeValue(wrappedInt, iValue); // zmienne przekazane w funkcji nazywamy argumentami.
            Console.WriteLine($"{wrappedInt.Value}, {iValue}"); // 14, 4
            ChangeValue(ref wrappedInt, ref iValue);
            Console.WriteLine($"{wrappedInt.Value}, {iValue}"); // 1, 9

            // Modyfikator 'out' umożliwia przekazanie zmiennych (wartosciowych i referencycjnych) do funkcji przed ich zainicjowaniem. W takiej funkcji musi nastąpić przypisanie wartości do argumentu.
            int arg;
            DoIncrement(out arg); 
        }

        static void ChangeValue(WrappedInt wrappedInt, int iValue) // zmienne funkcji nazywamy parametrami.
        {
            // Do funkcji przekazujemy kopie wartości. Nie operujemy na orginalnej zmiennej. W tym przypadku na kopii referencji która wskazuje na ten sam obiekt i kopii inta (2 osobne instancje).
            wrappedInt.Value = 14;
            iValue = 9;
        }

        static void ChangeValue(ref WrappedInt wrappedInt, ref int iValue) // przekazujemy obiekt, nie tworzymy kopii.
        {
            // Do funkcji przekazujemy prawdziwy obiekt (argument)
            wrappedInt.Value = 99;
            WrappedInt otherWrappedInt = new WrappedInt(1);
            // zmieniamy referencje do obiektu. (Wartość na stosie)
            wrappedInt = otherWrappedInt;
            // zmieniamy wartość na stosie.
            iValue = 9;
        }

        static void DoIncrement(out int param)
        {
            // param++; 
            // błąd kompilacji, 'param' tak naprawdę jest 'arg' przed wykonaniem takiej operacji nalezy ją najpierw zainicjować.

            param = 0;
            param++;
        }

        static void SystemObjectClass()
        {
            // Zmienna klasy object moze przechowywać referencje dowolnego obiektu. Zmienne referencyjne przechowują na stosie wyłącznie referencje do obiektu znajdującego się na stercie.
   
            WrappedInt w1 = new WrappedInt();
            // Rezewujemy pamięć potrzebną do pomieszczenia WrappedInt na stercie (ang.heap) i zapisujemy do niej referencje. (do pudełka typu object)
            object o = w1;

            //Note: Rekomedowanie jest uzywanie aliasu 'object' zamiast System.Object tak samo jak 'string' zamiast System.String
        }
        static void Boxing()
        {
            // Zmienne typu 'object' mogą również przechowywać wartości zmiennych typu wartościowego.
            int value = 13;

            // Środowisko uruchomieniowe alokuje odpowienią ilość pamięci ze sterty (ang.heap) aby pomieścić odpowiedni typ danych, przekazuje kopię wartości na sterte i przekazuje do niej referencje na stos.
            object ob = value;

            value++; //14
            ob.ToString(); //13

            //Note: Taka operacja nazywa sie opakowywaniem (ang. Boxing)            
        }
        static void UnBoxing() //Rozpakowywanie
        {
            object obj = 33;
            // Rzutowanie (ang. cast) zmiennej object z powrotem do zmiennej wartościowej/prostej
            // Kompilator generuje kod, który podczas wykonywania programu sprawdza zgodność typów pomiędzy typem zdefinowanym w () a rzeczywistym typem przechowywanym w obiekcie (na stercie).
            int i = (int)obj;

            // Zostanie skompilowany bez błedu ale w czasie wykonywania zostanie zgloszony wyjątek InvalidCastException
            //WrappedInt wrapInt = (WrappedInt)obj;
            //decimal d1 = (decimal)obj;

            //Note: Operacje Pakowania i Rozpakowania ze względu na alokowanie dodatkowej pamięci na stercie i dodatkowe instrukcje sprawdzające poprawność typu są bardzo kosztowne sprzętowo

            // Rzutowanie typu wartościowego -- Inna Bajka
            // Zadziała. Kompilator podpowiada, że '(decimal)' jest niewymagany. Wartość liczbowa Int jest mniejszej precyzji od decimala, w takich wypadkach można rzutować 'niejawnie'.  
            decimal d2 = (decimal)i;
            decimal d3 = 15.99m;
            // Zadziała. Należy 'jawne' określenie typu danych.
            int i2 = (int)d3;
        }
        static void SaveCastingOperatorIsAndAs()  //Save casting - operator is and as. Bezpieczne rzutowanie
        {
            // Kompilator nie sprawdza czy typy są ze sobą zgodne lecz srodowisko uruchomieniowe (.Net) to robi!

            WrappedInt wrapInt = new WrappedInt();
            object obj = new WrappedInt();

            // Operator 'is' wykorzystywany jest do sprawdzenia typu obiektu.
            // Operator 'is' ma 2 argumenty po lewej referencje do obiektu i po prawej typ dancyh. Jeśli typ danych zgadza się z typem obiektu znajdującym się na stercie zwróci 'true' jeśli nie 'false'
            bool b = wrapInt is WrappedInt; // true
            b = wrapInt is object; // true
            b = obj is WrappedInt; //true

            // SAVE CASTING
            if (obj is WrappedInt)
            {
                WrappedInt temp = (WrappedInt)obj; // Operacja bezpieczna
            }

            // Operator 'as' pełni taką samą role co operacja SAVE CASTING. Równiez posiada 2 arg. po lewej referencje do obiektu na stercie po prawej typ danych.
            // Środowisko uruchomieniowe w czasie wykonywania programu podejmie próbe rzutowania, gdy sie powiedzie zwróci wartość w przciwnym razie NULL`a.
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
            switch (o)
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
