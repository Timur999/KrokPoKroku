using System;
using iterator = Chapter_19_Iterator;
using modulWyliczeniowy = Chapter_19_Wyliczane_Kolekcje;

namespace Chapter_19_Testy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestyWyliczanejKolekcji();
            TestyProstegoIteratora();
            TestyRekurencyjnegoIteratora();
        }

        private static void TestyWyliczanejKolekcji()
        {
            modulWyliczeniowy.Tree<int> drzewoBinarne = new modulWyliczeniowy.Tree<int>(10);
            drzewoBinarne.Insert(1);
            drzewoBinarne.Insert(8);
            drzewoBinarne.Insert(11);
            drzewoBinarne.Insert(5);
            drzewoBinarne.Insert(-5);


            foreach (int item in drzewoBinarne)
            {
                Console.WriteLine(item);
            }

            foreach (int item in drzewoBinarne)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static void TestyProstegoIteratora()
        {
            iterator.ProstaKolekcja<string> musicBands = new iterator.ProstaKolekcja<string>("TangerineDream", "Prodigy", "AC/DC");

            foreach (var band in musicBands)
            {
                Console.WriteLine(band);
            }

            foreach (var band in musicBands.Reverse)
            {
                Console.WriteLine(band);
            }

            Console.ReadKey();
        }

        private static void TestyRekurencyjnegoIteratora()
        {
            iterator.Tree<int> tree = new iterator.Tree<int>(10);
            tree.Insert(9);
            tree.Insert(-3);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(11);
            tree.Insert(5);

            foreach (var item in tree)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
