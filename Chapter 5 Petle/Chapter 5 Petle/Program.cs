using System;
using System.IO;

namespace Chapter_5_Petle
{
    class Program
    {
        static void Main(string[] args)
        {
            //WyswietlZawartoscPliku();
            ZnajdzKlucz();
            Console.ReadKey();
        }

        static void PetlaWhile()
        {
            int i = 10; 
            while(i > 0) 
            {
                Console.WriteLine(i);
                i--;
            }

            Console.WriteLine("Rakieta leci na Saturna");

            /* Note: zmienna która służy tylko do kontroli wykonanych iteracji nazywamy zmienna sterującą lub pomocniczą.
             * Tak jak w instrukcji if zaleca się stosować blok kodu (nawisów { }) gdy petla while zawiera jedną instrukcje.
            */
            while (i < 10)
                Console.WriteLine("nieskończonośc");
            i++;
        }

        static void WyswietlZawartoscPliku()
        {
            CzytajPlik(PobierzPlik());
        }

        static TextReader PobierzPlik()
        {
            string path = @"d:/Mircosoft krok po kroku/mojeProjekty/Chapter 5 Petle/Chapter 5 Petle/Resources/Tekst.txt";
            return new StreamReader(path);
        }

        static void CzytajPlik(TextReader stream)
        {
            string line = stream.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = stream.ReadLine();
            }
            stream.Dispose();
        }

        static void PetlaFor(TextReader stream)
        {
            // Możliwe jst pominięcie dowolnej części w instrukcji for
            for (int i = 0; ; i++)
            {
                Console.Write("czy może mnie ktoś zatrzymać!");
            }
            for (int i = 0, j = 10; i < j; i++, j--)
            {
                Console.Write("Instrukcja logiczna może być tylko jedna");
            }
            for (string line = stream.ReadLine(); line != null; line = stream.ReadLine())
            {
                Console.WriteLine(line);
            }
            stream.Dispose();

            //Note: Zakres zmiennych ograniczony jest do ciała pętli i przestaje istnieć po.
        }

        static void ZnajdzKlucz()
        {
            bool parseSucceed = int.TryParse(Console.ReadLine(), out int secretNumber);
           
            if (parseSucceed)
            {
                for (int i = 0; ; i++)
                {
                    if(i != secretNumber)
                    {
                        continue;
                    }
                    Console.WriteLine($"Znalazłem klucz! {i}");
                    break;
                }
            }
        }

        static char KonwertujLiczbeDoZnaku(int liczba)
        {
            /* Note. Każdy znak jest reprezentowany przez liczbę całkowitą. Język C# umożliwia traktowanie znaku jako liczby 
             * i wykonywanie na niej operacji arytmetycznych. Znak '0' jest reprezentowany przez liczbę 48, '1' = 49, ... '9' = 57.      
             * Jest to tak zwany system kodowania znaków, w zależności zestawu znaków uzywany przez systemu operacyjnego niekture
             * znaki bedą reprezentowane przez inne liczby. 
             * http://kursdlaopornych.pl/iso-ascii-unicode-kodowanie-znakow/
            */
            int liczbaAscii = '0' + liczba;
            char znak = Convert.ToChar(liczbaAscii);
            return znak;
        }
    }
}
