using Exceptions.Model;
using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Calculator.Add();
                unchecked
                {
                    int a = Calculator.Add(int.MaxValue, 1);
                }
                checked
                {
                    int a = Calculator.Add(int.MaxValue, 1);
                }

                //Note: Domyślnie wszystkie operacje są unchecked znaczy się nie jest sprawdzany czy int przekroczył maxymalną wartość. Ma to wpływ na wydajność.
                // checked i unchecked działa dla kodu (operacji arytmetycznych) bezpośrednio w nawiasach {}, nie działa dla kodu w funkcjach, przykład wyżej.
                // Te słowa kluczowe działają wyłącznie dla operacji arytmetycznych liczb całkowitych int long. Operacji arytmetyczne na liczbach zmiennoprzecinkowych nigdy nie zgłoszą wyjątku przepełnienia OverflowException,
                // nawet przy dzieleniu przez 0.0 gdyż .NET posiada specjalną zmienna reprezentującą nieskonczoność. double.PositiveInfinity;
                // Można zmienić domyśle dziłanie odznaczając checkbosa "Check for arytmetic overflow/underflow" w właściwościach projektu. Properties -> Build -> Advance

                int overflowInt = unchecked(int.MaxValue + 1);
                checked
                {
                    int w = int.MaxValue;
                    //w++; // OverflowException
                }

                Console.WriteLine(overflowInt); // minumum int 


                // Zgłaszanie wyjątków. Throw. Uzywamy gdy chcemy zgłosić jakiś wyjątek np. gdy podamy nieprawidłowy operator arytmetyczny. 1 ? 4
                Calculator.On();

            }
            catch (OverflowException oEx)
            {
                Console.WriteLine("This instruction will excecute when in method Calculator.Add() occurs exception OverflowException (It is call Propagowanie Wyjatków).");
                Console.WriteLine("Propagowanie wyjatkow: wynoszenie wyjątkow, które nie zostały obsłużone w metodze których wystąpiły do metod które je wywołały.");
                Console.WriteLine("Oprócz wyjątku zostanie także zwrócone sterowanie programu. Następna instrukcja kodu zostanie wykonana w tej klasie.");
                Console.WriteLine(oEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Obsługa każdego wyjątku. Wszystkie wyjątki dziedzicą z klasy Exception. W tej sytuacji jeśli nie wystąpi wyjatek OverflowException lub inne wyjatki obsłuzone w klasie Calculator.Add()." +
                    "Obsługa wyjątku nastąpi w tym miejscu. Należy pamietac aby ustawiac wyjątki od szczegółówych do najbardziej ogołnych." +
                    "Try catch sprawdza jakiego wyjatek wystąpił. Exception przechwyci każdy rodzaj wyjatku, gdyż wszystkie wyjątki dziedziczą właśnie po klasie 'Exception'.");
                Console.WriteLine(ex.Message);
            }

            //Note: Niektóe wyjątku mogą być spowodowane przez inne wyjątki. Czyli zródło problemu jest gdzie indziej. Możemy to przeanalizować sprawdzając InnerException szukajac zródła problemu. 
            // Jeśli InnerException = null znaczy, że jestesmy u celu

            //Tip: Menu Debug -> Windows ->  Exceptions setting -> Pokaze sie ramka w dole ekranu -> rozwijamy Common Language Runtime Exceptions -> wybieramy exception który nas interesuje.
            // W tej chwili jeśli dany exception wystąpi, Debuger przejdzie do kodu który spowodował exception wyswietlając uzyteczną ramke z informacjami o wyjątku.

            Console.ReadKey();
        }
    }
}
