using System;

namespace Exceptions.Model
{
    static class Calculator
    {
        private static int a;
        private static int b;
        private static bool catchError = false;
        private static char CalulateOperand;
        private static decimal Reslut;

        public static void On()
        {
            InputLeftOperand();
            InputCalulateOperand();
            InputRightOperand();

            switch (CalulateOperand)
            {
                case '+':
                    Reslut = Add();
                    break;
                case '-':
                case '*':
                case '/':
                    break;
            }

            DisplayResult(Reslut.ToString());
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
                Console.WriteLine("W tym przypadku nie zostanie wykonana obsługa wjątku która jest niżej. Wyjątek zostanie zwrócony do metody która wywołała tę metode." +
                    " Jeśli nie znajdzię obsługi wyjątku DivideByZeroException, procedura się powtórzy. Jeśli wyjątek nie znajdzie odpowieniej obsługi wyjątku, program zakonczy się sygnalizując nie obsłużony wyjątek. (unhandled exception)");
            }
            catch (DivideByZeroException dEx)
            {
                Console.WriteLine(dEx.Message);
            }

            Console.WriteLine("This instruction will only executed if FormatException occurs or no exception occurs.");
            Console.WriteLine("W przypadku gdy wystąpi wyjątek i nie bedzie to FormatException nie wyswietli się ten komunikat.");
        }
    }
}
