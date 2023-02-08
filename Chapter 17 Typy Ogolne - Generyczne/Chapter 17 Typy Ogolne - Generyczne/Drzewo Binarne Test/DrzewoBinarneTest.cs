using Drzewo_Binarne;
using System;

namespace Drzewo_Binarne_Test
{
    /* ppm na projekt Set as Startup Project - ustawymy w ten sposób że ten projekt bedzie sie uruchamiał po nacisnięciu Start */
    internal class DrzewoBinarneTest
    {
        static void Main(string[] args)
        {
            TestujDrzewoBinarneWypelnioneLiczbami();
            TestujDrzewoBinarneWypelnioneTekstami();
        }

        private static void TestujDrzewoBinarneWypelnioneLiczbami()
        {
            DrzewoBinarne<int> drzewoBinarne = new DrzewoBinarne<int>(10);
            drzewoBinarne.Insert(5);
            drzewoBinarne.Insert(15);
            drzewoBinarne.Insert(2);
            drzewoBinarne.Insert(-12);
            drzewoBinarne.Insert(3);
            drzewoBinarne.Insert(0);
            drzewoBinarne.Insert(14);
            drzewoBinarne.Insert(-9);
            drzewoBinarne.Insert(-1);
            drzewoBinarne.Insert(8);
            drzewoBinarne.Insert(8);

            var result = drzewoBinarne.WalkTree();

            Console.WriteLine(result);

            Console.ReadKey();
        }


        private static void TestujDrzewoBinarneWypelnioneTekstami()
        {
            //Sortowanie alfabetycznie
            DrzewoBinarne<string> drzewoBinarne = new DrzewoBinarne<string>("Hello");
            drzewoBinarne.Insert("How");
            drzewoBinarne.Insert("are");
            drzewoBinarne.Insert("you?");
            drzewoBinarne.Insert("I");
            drzewoBinarne.Insert("Hope");
            drzewoBinarne.Insert("you");
            drzewoBinarne.Insert("are");
            drzewoBinarne.Insert("feeling");
            drzewoBinarne.Insert("well");
            drzewoBinarne.Insert("and");
            drzewoBinarne.Insert("HAPPY");
            drzewoBinarne.Insert("NEW");
            drzewoBinarne.Insert("YEAR");
            drzewoBinarne.Insert("2023");
            drzewoBinarne.Insert(":)");


            var result = drzewoBinarne.WalkTree();

            Console.WriteLine(result);

            Console.ReadKey();
        }

    }
}
