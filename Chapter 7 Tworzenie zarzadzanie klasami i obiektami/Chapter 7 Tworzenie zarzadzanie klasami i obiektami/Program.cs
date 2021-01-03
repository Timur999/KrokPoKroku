using Classies.Model;
using System;
/* Klasy umożliwiają wygodny sposob tworzenia Encji na podstawie zdefiniowanego szablonu.
 * Encją może być np. 'klient' lub cos bardziej abstakcyjnego 'tranzakcja'.
 * Podczas tworzenia projektu musimy zastanowić się z jakich Encji nasza aplikacja bedzie korzystać oraz jakie informacje
 * powinna zawierać i przechowywac i jakie operacje powinna ona wykonywać.
 */

/* Klasyfikacja. 
 * Pisząc programy powinniśmy starać się implementować tak klasy jak faktycznie jest w rzeczywistości.
 * Np. Klasa Samochód nie powinna zawierać metody odpowiedzialnej za latanie czy smarzenie frytek.
 */

/* Hermetyzacja (ang. encapsulation)
 * Polega na zasłonięciu zasady działania metody/klasy, ważne aby realizowała swoję zadanie. np. Samochód musi dojechać na miejsce
 * nie jest ważne jak działa silnik itp.
 * Hermetyzacja ma 2 cele:
 * Łączenie ze sobą metod i danych wewnątrz klasy; inaczej mówiąc, umożliwienie przeprowadzenia klasyfikacji.
 * Kontrolowanie dostępności metod i danych; inaczej mówiąc kontrolowanie sposoby wykorzystywania klasy.
 */

namespace Chapter_7_Tworzenie_zarzadzanie_klasami_i_obiektami
{
    /* Statyczne instrukcje using.
     * Te klasy statyczne są dodane do zasięgu i można z ich korzystać bez wpisywania nazwy klasy.
     * Nie zalaca się stosować, zmniejsza czytelność kodu. Np. 'WriteLine("Wypisz na consoli");' zamiast 'Console.WriteLine("...");'
     */
    using static System.Math;
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            DefiniowanieIUzywanieKlas();

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
            //int circleAmount = Okrag.PobierzLiczbeOkregow();
            //WriteLine($"Amount of circle: {circleAmount}");
                      
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

        static void DefiniowanieIUzywanieKlas()
        {
            /* Klasa Okrąg.
             * Klasy zawierają zmienne i metody (omowione w roz. 2 i 3). Zmienne w klasie nazywane są 'polami'.
             */

            // Więcej na temat słowa kluczowego 'new' oraz przydzielania pamięci w rozdziale 8.
            Okrag okrag = new Okrag(4.2f);
            Console.WriteLine(okrag.ObliczObwod());
        }

        static void KontrolowanieDostepnosci()
        {
            /* Klasa Okrąg.
             * Domyślnie pola i metody są prywatne. Pola prywatne mają zakres klasy, poza klasą są niewidoczne.
             * Warto pamiętać, że pola w klasach mają wartość domyślną 0, false lub null, zależy od ich typu.
             * Dobrą praktyką jest jawnie inicjowanie wartości tych pól. 
             * np. private float promien = 0f;
             */
        }

        static void KonwencjeNazewnicze()
        {
            /* Klasa Okrąg
             * Identyfikatory publiczbe powinny nazywać się zaczynając od Wielkiej litery. Konwencja Pascalowa (PascalCase)
             * Identyfikatory nie publiczne (zaliczają się do nich także zmienne lokalne oraz metody) powinny nazywać się zaczynając
             * od małej litery. (camelCase). Wszystkie przykłady w książce stosują się do tych regół.
             * Istnieje jednak wyjątek, gdybyśmy chcieli zdefiniować prywatny konstruktor nazwa musi rozpoczynac Dużą literą. 
             */
        }

        static void Konstruktory()
        {

        }
    }

   
}
