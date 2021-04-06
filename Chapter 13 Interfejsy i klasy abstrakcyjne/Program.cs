using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model;
using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;

/* W projecie omowione są interfaces, klasy abstrakcyjne oraz slowo kluczowe sealed.
 * 
 * Interface:
 * Opisuje jedynie jaką funkcjonalność powinna posiadać klasa lub struktura, nie mowi w jaki sposób powinna ją implementować.
 * Intereface może zawierać wyłącznie sygnatury metod i właściwości nie może zawierać żadnych danych. 
 * Nie określa się modyfikatorów dostępności (public, protected, privete).
 * Zaleca się aby nazwy interfaców rozpoczynać duża literą 'I'.
 */

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne
{
    class Program
    {
        static void Main(string[] args)
        {
            ExplicitlyImplementingInterface(); //JawnieImplementowanieInterfajsu
            Console.ReadKey();
        }

        static void ImplementowanieInterfacow()
        {
            /* Gdy klasa lub struktura dziedziczy po interfejs musi spełniać następujące reguły:
             * Nazwa oraz typ implementowanej metody z interfejsu musi być taka sama.
             * Parametry metody musza być identyczne (nawet ref lub out jesli zostały użyte)
             * Implementowana metoda z interfacu w klasie lub w strukturze musi mieć identyfikator destępności publiczny,
             * chyba, że metoda jest zaimplementowana jawnie wtedy nie może być określony klasyfikator dostępności.
             * 
             * Przykład klasa Kula.
             * 
             * Klasa może dziedziczyć po innej klasie i po interfejsie (interfejsów może być wiele). Jako pierwsza podawana jest zawsze nazwa klasy bazowej następnie po przecinku nazwy interfejsów.
             * 
             * Przykład klasa Kula.
             */
        }

        static void ExplicitlyImplementingInterface() 
        {
            // Głownie dotyczy przypadku, gdy klasa dziedziczy po dwóch lub wiecej interfejsów i nazwa któreś metody się powtarza.
            // Należy jawnie zaimplementowac ten interface w definicji metody np. ICalculate.CalculateVolume(), przykład w klasie Square.

            // Wywołanie takiej metody:
            // Jawnie zaimplementowany interfajs oznacza, że gdy utworzymy obiekt klasy i przypiszemy go do zmiennej o typie danego interfacjsu,
            // umożliwi to wywołanie funkcji danego interfejsu.
            ICalculate Square = new Kostka(1.3, 2f, 5f);
            Console.WriteLine(Square.CalculateDistance(new Kula())); // Wykona się metoda ineterfejsu ICalculate

            IMove square2 = new Kostka(2, 4, 6);
            Console.WriteLine(square2.CalculateDistance(new Kula())); // Wykona się metoda ineterfejsu IMove

            // Dla obiektu klasy Square, który implementuje jawnie interfejs, metody te mają prywatny poziom dostępności.
            // Jeśli w klasie są 2 lub wiecej metod które nazywają się tak samo to nie wiadomo, która metoda ma się wykonać.
            Kostka kwadrat = new Kostka(1, 4, 6);
            Console.WriteLine(kwadrat.CalculateVolume()); // 'Square' does not contain a definition for 'CaclulateVolume'

            // Note: Zaleca się aby zawsze gdy to jest możliwe, implementować interfejsy w sposób jawny.
        }
    }
}
