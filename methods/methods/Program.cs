using methods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    class Program
    {
        static void Main(string[] args)
        {
            //metoda wcielająca wyrażenie
            int minusNumbers(int a, int b) => a - b;
            int plusNumbers(int a, int b) => Add(a, b);

            //próba rzutowania typu
            double x = 10;
            float y = 10f;
            //Add(x, y); // cannot convert doble and float to int
            int t = 1;
            int u = 1;
            Multi(t, u); // nie jawnie rzutuje inta na inny typ

            //krotka (tuple) mała kolekcja wartości. Aby użyc krotki nalezy zainstalować pakiet ValueTuple.
            int retValue1, retValue2;
            (retValue1, retValue2) = Devide(11, 2);

            //Testy
            //CalculateSalary.Start();

            ShowResult(retValue1, retValue2);

            //rekurencja
            Console.WriteLine(Game.Play("Tomas"));

            Console.ReadKey();
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Multi(double a, float b)
        {
            return a * b;
        }

        static (int, int) Devide(int a, int b)
        {
            var devidedResult = a / b;
            var remaider = a % b;
            return (devidedResult, remaider);
        }


        static void ShowResult(int result)
        {
            Console.WriteLine($"result: {result}");
        }

        static void ShowResult(int result1, int result2)
        {
            Console.WriteLine($"result: {result1} and {result2}");
        }
    }
}
