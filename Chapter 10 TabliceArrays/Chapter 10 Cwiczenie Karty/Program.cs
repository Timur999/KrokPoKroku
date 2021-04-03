using Chapter_10_Cwiczenie_Karty.Model;
using System;

namespace Chapter_10_Cwiczenie_Karty
{
    class Program
    {
        static void Main(string[] args)
        {
            TaliaKart talia = new TaliaKart();
            Karta[,] kartyGraczy = talia.RozdajKarty();

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Karty Gracza nr. {i + 1}");
                for(int j = 0; j < 13; j++)
                {
                    Console.WriteLine(kartyGraczy[i, j]);
                }
            }

            Console.ReadKey();
        }
    }
}
