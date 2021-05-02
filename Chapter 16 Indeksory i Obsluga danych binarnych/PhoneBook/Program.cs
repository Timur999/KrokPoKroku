using PhoneBook.Model;
using System;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            KsiazkaTelefoniczna ksiazka = new KsiazkaTelefoniczna()
            {
                Numery = new[] { new NumerTelefonu(000000005), new NumerTelefonu(121121212), new NumerTelefonu(323323232), new NumerTelefonu(5654565), new NumerTelefonu(0700555) },
                Osoby = new Osoba[] { new Osoba("Siara"), new Osoba("Stasiu"), new Osoba("Wojtek"), new Osoba("Romek"), new Osoba("Ryszarda") }
            };

            NumerTelefonu memoryFive = new NumerTelefonu(000000005);
            Osoba osoba = ksiazka[memoryFive];

            Console.WriteLine(osoba.Imie);

            NumerTelefonu sexTelefon = new NumerTelefonu(0700555);
            osoba = ksiazka[sexTelefon];

            Console.WriteLine(osoba.Imie);

            Osoba stasiu = new Osoba("Stasiu");
            NumerTelefonu numerDoStasia = ksiazka[stasiu];
            Console.WriteLine(numerDoStasia);

            Console.ReadLine();
        }
    }
}
