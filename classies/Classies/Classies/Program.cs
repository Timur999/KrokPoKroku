using Classies.Model;

// Statyczne instrukcje using. Te klasy są dodane do zasięgu i można z ich korzystać bez wpisywania nazwy klasy.
using static System.Math;
using static System.Console;

// Hermetyzacja polega na zasłonięciu zasady działania metody, klasy. Ważne aby realizował swoję zadanie

namespace Classies
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            Point point2 = new Point(10,100);
            double distance = point.DistanceTo(point2);
            WriteLine(distance);

            // wywołanie dekonstruckji. Nalezy pamietac zeby zainstalowac nuget System.ValueType aby uzywac krotki.
            // point2.Deconstruct(out int longiValue, out int latiValue);
            (int longiValue, int latiValue) = point2;
            WriteLine($"x: {longiValue} y: {latiValue}");


            int circleAmount = Circle.GetCircleAmount();
            WriteLine($"Amount of circle: {circleAmount}");


            double value = Sqrt(4);

            ReadKey();
        }
    }

   
}
