using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model;
using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne
{
    class Program
    {
        static void Main(string[] args)
        {
            ExplicitlyImplementingInterface(); //JawnieImplementowanieInterfajsu
            Console.ReadKey();
        }

        static void ExplicitlyImplementingInterface() 
        {
            // Głownie dotyczy przypadku, gdy klasa dziedziczy po dwóch lub wiecej interfejsów i nazwa któreś metody się powtarza.
            // Należy jawnie zaimplementowac ten interface w definicji metody np. ICalculate.CalculateVolume(), przykład w klasie Square.

            // Wywołanie takiej metody:
            // Jawnie zaimplementowany interfajs oznacza, że gdy utworzymy obiekt klasy i przypiszemy go do zmiennej o typie danego interfacjsu,
            // umożliwi to wywołanie funkcji danego interfejsu.
            ICalculate Square = new Square(1.3, 2f, 5f);
            Console.WriteLine(Square.CalculateDistance(new Sphere())); // Wykona się metoda ineterfejsu ICalculate

            IMove square2 = new Square(2, 4, 6);
            Console.WriteLine(square2.CalculateDistance(new Sphere())); // Wykona się metoda ineterfejsu IMove

            // Dla obiektu klasy Square, który implementuje jawnie interfejs, metody te mają prywatny poziom dostępności.
            // Jeśli w klasie są 2 lub wiecej metod które nazywają się tak samo to nie wiadomo, która metoda ma się wykonać.
            Square kwadrat = new Square(1, 4, 6);
            Console.WriteLine(kwadrat.CalculateVolume()); // 'Square' does not contain a definition for 'CaclulateVolume'

            // Note: Zaleca się aby zawsze gdy to jest możliwe, implementować interfejsy w sposób jawny.
        }
    }
}
