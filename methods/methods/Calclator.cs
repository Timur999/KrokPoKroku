using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace methods
{
    public static class Calclator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        //Metoda Przeciążona
        public static int Add(int a, int b, int c)
        {
            return a + b + c;
        }


        public static double Multi(double a, float b)
        {
            return a * b;
        }

        public static(int, int) Devide(int a, int b)
        {
            var devidedResult = a / b;
            var remaider = a % b;
            return (devidedResult, remaider);
        }

        public static void ShowResult(int result)
        {
            Console.WriteLine($"result: {result}");
        }

        public static void ShowResult(int result1, int result2)
        {
            Console.WriteLine($"result: {result1} and {result2}");
        }
    }
}
