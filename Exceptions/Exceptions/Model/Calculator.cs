using System;
using System.Collections.Generic;

namespace Exceptions.Model
{
    static class Calculator
    {
        private static int a;
        private static int b;
        private static bool catchError = false;
        private static char CalulateOperand;
        private static decimal Result;
        private static List<decimal> ListOfResluts;

        public static void On()
        {
            InitalizeListOfResluts();
            InputLeftOperand();
            InputCalulateOperand();
            InputRightOperand();
            
            switch (CalulateOperand)
            {
                case '+':
                    Result = Add();
                    ListOfResluts.Add(Result);
                    break;
                case '-':
                case '*':
                case '/':
                    break;
            }

            DisplayResult(Result.ToString());
        }

        public static int Add()
        {
            //GetUserValue();
            return a + b;
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static void DisplayResult(string result)
        {
            try
            {
                if (string.IsNullOrEmpty(result))
                {
                    catchError = true;
                }
                Console.WriteLine(result.ToString());
            }
            catch (Exception Ex) when (catchError == true)
            {
                //Note: Filtry wyjątków. Obsługa wyjątków tylko gdy catchError = true
                Console.WriteLine("Filtry wyjątków. Obsługa wyjątków tylko gdy catchError = true");
                Console.WriteLine(Ex.Message);
            }
        }

        private static void InputCalulateOperand()
        {
            Console.Write("Input calculate operand: ");
            string userValue = Console.ReadLine();
            char chosenCalculateOperand = userValue[0];
            switch (chosenCalculateOperand)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    CalulateOperand = chosenCalculateOperand;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Nie prawidłowy operator. Argument z poza zakresu.");
            }
        }

        private static void InputLeftOperand()
        {
            try
            {
                Console.Write("Input left operand: ");
                string userValue = Console.ReadLine();
                a = Int32.Parse(userValue);
            }catch(FormatException fEx)
            {
                Console.WriteLine(fEx.Message);
            }
        }

        private static void InputRightOperand()
        {
            try
            {
                Console.Write("Input left operand: ");
                string userValue = Console.ReadLine();
                b = Int32.Parse(userValue);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine(fEx.Message);
            }
        }

        private static void GetUserValue()
        {
            try
            {
                Console.WriteLine("Input number a:");
                string userValue = Console.ReadLine();
                a = Int32.Parse(userValue);
                Console.WriteLine("Input number b:");
                userValue = Console.ReadLine();
                b = Int32.Parse(userValue);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine($"Input value is not a number. Error message: {fEx.Message}");
                decimal c = a / b; //b is 0 (zero).
                //Note: a i b są intem, takie działanie wyrzuci wyjątek 'OverflowException'. Opertacje na liczbach zmiennoprzecinkowych nigdy nie zgłoszą wyjątku przepełnienia 'OverflowException',
                // nawet przy dzieleniu przez 0.0 gdyż .NET posiada specjalną zmienna reprezentującą nieskonczoność. 'double.PositiveInfinity'

                //Note: W tym przypadku nie zostanie wykonana obsługa wjątku która jest niżej 'DivideByZeroException'. Wyjątek zostanie zwrócony do metody która wywołała tę metode.
                // Jeśli nie znajdzię obsługi wyjątku DivideByZeroException, procedura się powtórzy. Jeśli wyjątek nie znajdzie odpowieniej obsługi wyjątku, program zakonczy się sygnalizując błąd: nie obsłużony wyjątek. (unhandled exception)");
            }
            catch (DivideByZeroException dEx)
            {
                Console.WriteLine(dEx.Message);
            }

            Console.WriteLine("This instruction will only executed if FormatException, DivideByZeroException occurs or no exception occurs.");
            //Note: W przypadku gdy wystąpi wyjątek i nie bedzie to FormatException lub DivideByZeroException nie wyswietli się ten komunikat.
        }

        private static void InitalizeListOfResluts()
        {
            if(ListOfResluts == null)
            {
                ListOfResluts = new List<decimal>();
            }
        }

        public static void Off()
        {
            try
            {
                a = 10;
                b = 0;
                Console.Clear();
                Console.WriteLine($"This instruction throw exception: 10/0 = {a/b}. But before exception will be handled, execute finally content.");
                //Note: Najpierw wykona się blok finally a potem catch DivideByZeroException w metodzie wyżej.
            }
            finally
            {
                if (ListOfResluts != null)
                {
                    ListOfResluts.Clear();
                }
            }
           
        }
    }
}
