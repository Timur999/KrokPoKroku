using Classies.Model;

// Statyczne instrukcje using. Te klasy statyczne są dodane do zasięgu i można z ich korzystać bez wpisywania nazwy klasy.
// Nie zalaca się stosować, zmniejsza czytelność kodu.
using static System.Math;
using static System.Console;

// Hermetyzacja polega na zasłonięciu zasady działania metody/klasy. Ważne aby realizował swoję zadanie.

namespace Classies
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            Point point2 = new Point(10, 100);
            double distance = point.DistanceTo(point2);
            WriteLine(distance);

            // wywołanie dekonstruckji. Dekonstrukcja służy do pobierania wartości pól obiektu
            point2.Deconstruct(out int longiVal, out int latiVal);
            // Można także użyć ktorki. Kompilator automatycznie użyje metody Deconstruct zdefinowanej w klasie Point. Nalezy pamietac zeby zainstalowac nuget System.ValueType.
            (int longiValue, int latiValue) = point2;
            WriteLine($"x: {longiValue} y: {latiValue}");

            // użycie metody statycznej (nazywanej również metodą klasy)
            int circleAmount = Circle.GetCircleAmount();
            WriteLine($"Amount of circle: {circleAmount}");

          
            double value = Sqrt(4);


            // klasy anonimowe czesto wykorzystywane m.in. w LINQ. Kompilator sam przydzieli nazwe tej klasy na podstawie nazwy, typu oraz ilości i kolejności zmiennych.
            // klasy anonimowe mogą zawierać wyłącznie pola publiczne i muszą byc odrazu zainicjowane. Nie może zawierać pól statycznych ani metod.
            var myAnonymousObject = new { Name = "Tomasz", Age = 28 };
            var otherAnonymousObject = new { Name = "Grarzyna", Age = 42 };

            WriteLine(myAnonymousObject.GetType() == otherAnonymousObject.GetType()); // True
            WriteLine(myAnonymousObject.Equals(otherAnonymousObject)); // False
            myAnonymousObject = otherAnonymousObject;
            WriteLine(myAnonymousObject.Equals(otherAnonymousObject)); // True          


            var myAnonymousAnimal = new { Name = "Mija", Color = "Black" };
            WriteLine(myAnonymousObject.GetType() == myAnonymousAnimal.GetType()); // False 

            ReadKey();
        }
    }

   
}
