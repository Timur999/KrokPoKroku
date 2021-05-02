using Chapter_16_Indeksory.Model;
using System;

/* Właściwości przydają się gdy chcemy operować na polu zawierającą jedną wartość. Natomiast do operacji na elementach pola zawierającego wiele wartości mozemy uzyć indexora. 
 * Składnia korzystania z elementów pola za pomocą indexora jest identyczna jak korzystanie z tablicy elementow.
 * mojObiekt[index];
 * index nie musi być liczba całkowitą tak jak w przypadku korzystania ze zwyklej tablicy.
 */
namespace Chapter_16_Indeksory
{
    class Program
    {
        static void Main(string[] args)
        {
            PrzechowywanieDanychBinarnie();
            ManipulowanieWartosciamiDwojkowymi();
            RoznicaPomiedzyIndexoremATablica();

            Console.ReadKey();
        }

        static void PrzechowywanieDanychBinarnie()
        {
            // Kompilator sam skonwertuje typ zmiennej na uint 
            int binarnie = 0b0111;
            uint binarnie_duza = 0b0_1111_1001_1110_0000; // separator '_' mozna użyc w dowolnym momencie.
            uint hexa_duza = 0x0_0F_A9_99_0C;

            //Wysietalnie danych.
            Console.WriteLine(binarnie); // 7
            Console.WriteLine(Convert.ToString(binarnie, 2)); // 111
            Console.WriteLine(Convert.ToString(hexa_duza, 16));
        }

        static void ManipulowanieWartosciamiDwojkowymi()
        {
            //Negacja
            byte zmienna = 0b0_00011101;
            byte negacja = (byte)~zmienna;

            Console.WriteLine(Convert.ToString(zmienna, 2)); // 00011101
            Console.WriteLine(Convert.ToString(negacja, 2)); // 11100010
            Console.WriteLine(zmienna); // 29
            Console.WriteLine(negacja); // 226

            //Operator przesuniecia w lewo <<
            zmienna = 0b0_11011101;
            var przesunieta = zmienna << 2;
            // 2 pierwsze pozycje od lewej zostaja usiniete a na koniec dodane 2 zera
            Console.WriteLine(Convert.ToString(zmienna, 2)); // 11011101
            Console.WriteLine(Convert.ToString(przesunieta, 2)); // 01110100

            //Operator OR |
            var zmiennaOR = zmienna | 3;  // zmienna = 11011101; 3 = 0b0_011
            Console.WriteLine(Convert.ToString(zmiennaOR, 2)); // 11011111

            //Operator AND &
            var zmiennaAND = zmienna & 9;  // zmienna = 11011101; 9 = 0b0_1001
            Console.WriteLine(Convert.ToString(zmiennaAND, 2)); // 1001

            // Operator XOR ^
            var zmiennaXOR = zmienna ^ 9;  // zmienna = 11011101; 9 = 00001001
            Console.WriteLine(Convert.ToString(zmiennaXOR, 2)); // 11010100

            // Mortal Combat
            int dobre_bity = 0b0_10101010;
            if((dobre_bity & (1 << 5)) != 0)
            {
                Console.WriteLine("Szosty bit jest 1");
            }

            Console.WriteLine(Convert.ToString(dobre_bity, 2)); // 11010100

            dobre_bity &= ~(1 << 5); // ustawienie 0 na 6 bicie
            Console.WriteLine(Convert.ToString(dobre_bity, 2)); // 11010100

            dobre_bity |= (1 << 5); // ustawienie 1 na 6 bicie
            Console.WriteLine(Convert.ToString(dobre_bity, 2)); // 11010100

            // To samo mozemy osiagnac za pomoca Indexorow.
            IntBits bits = new IntBits(11); // 01011
            bits[2] = true; // 01111
            bits[3] = false; // 00111

            Console.WriteLine(bits);

        }

        static void RoznicaPomiedzyIndexoremATablica()
        {
            /* Tablice moga miec tylko index calkowitoliczbowy, Indexory nie np. 
             * public int this[string name]
             * 
             * Indexory moga byc przeciazone, tablice nie np,
             * public Osoba this[NumerTelefonu numer]
             * public NumerTelefonu this[Osoba osoba]
             * 
             * Idexory nie moga byc uzywane jako parametry ref, out, tablice tak. 
             * Indexory są podobne do własiwości dlatego nie mogą byc uzywane jako ref i out poniewaz wskazują tak naprawde na metode a nie pole.
            */
        } 
    }
}
