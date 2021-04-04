using System;
using System.Linq;

/* Kiedy używać parametrów param.
 * Gdy zachodzi potrzeba przekazania do metody zmienną liczbę parametrów które mogą być różnego typu.
 * Przeciążenie nadaje się gdy chcemy wykonać te same zadanie na różnych typach danych.
 */

namespace Chapter_11_Tablica_parametrów_params
{
    class Program
    {
        static void Main(string[] args)
        {
            RoznaIloscParametrowTegoSamegoTypu();
            RoznaIloscParametrowRoznegoTypu();
            ParametryOpcjionalneAParametrParam();

            Console.ReadKey();
        }

        static void RoznaIloscParametrowTegoSamegoTypu()
        {
            // Parametrem metody jest tablica int[]
            int[] numbers = new int[] { 1, 2, 4, 6 };
            Min(numbers); // Musimy utworzyc ręcznie własną tablice. 
            Min(new int[4] { 1, 4, 8, 4 });

            // Parametrem metody jest tablica parametrów 'params' o typie int.
            // Nie musimy tworzyc własnej tablicy. Kompilator zrobi to za nas.
            Max(1, 4, 8, 4); // Max(new int[4] {1, 4, 8, 4}); 
            Max(); // Max(new int[0]);
            Max(null);
            Max(numbers);
        }

        // Należy zdefionwać wlasną tablice
        static int Min(int[] numbers)
        {
            if(numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Nie prawidłowa wartość parametrów metody.");
            }

            int min = numbers[0];
            foreach(int numb in numbers)
            {
                if(min > numb)
                {
                    min = numb;
                }
            }

            return min;
        }

        // Nie trzeba recznie tworzyc tablicy, kompilator sam zrobi tablice o odpowiednim rozmiarze oraz typie danych. 
        static int Max(params int[] numbers)
        {
            //DOTO: znajdz maxa
            return 1;
        }

        // Kwestie warte uwagi związene z tablica parametrów typu 'params':

        //1. Nie mozna używac 'params' dla tablic wielowymiarowych ale możemy podać taką tablice jak argument metody. przykład 'Drawer4'
        // błąd kompilacji
        // static int Max(params int[,] numbers)

        //2. Nie można przeciążyż metody wyłącznie dodając słowo kluczowe 'params'. Słowo 'params' nie jest częścią sygnatury metody.
        // błąd kompilacji
        // static int Max(int[] numbers)
        // static int Max(params int[] numbers) // dla kompilatora jest to to samo.

        //3. Nie moga być używane z modyfikatorami ref i out.

        //4. Tablica parametrów typu 'params' muszą być ostatnim parametrem metody.
        // błąd kompilacji
        // static int Max(params int[] numbers, int index)

        //5. Metody, które nie używają 'params' w parametrze mają wyższy priorytet od tych które używają 'params'.
        // static int Max(int pierwsza, int druga, int trzecia)
        // static int Max(params int[] numbers)
        // Druga metoda wykona się w każdym innym przypadku gdy ilość parametrów bedzie różna od trzech.


        static void RoznaIloscParametrowRoznegoTypu()
        {
            // Dobrym przykładem takiej metody jest Console.WriteLine();
            // Console.WriteLine(string format, params object[] arg);
            Console.WriteLine("{0} dziennie {1} dostarcza duzo wit. {2}.", 1, "cytryna", 'C');

            Drawer("skarpetki", 1, 'T');
            Drawer(new int[] { 1, 2, 5 }, new string[] { "Pen", "Pencil" },
                new []{ new { Name = "gloves", price = 10}, new { Name = "scarf", price = 20 } });

            Drawer(new int[1] { 4 });
            Drawer2(new object[1] { 4 });
            Drawer3(4);
            Drawer4(new int[2, 3]);

            //Note: Tablica parametrów 'params' zapisze argumenty do tablicy, aby pobrać wartość należy uzyć indexu, things[0], things[1], itd.
        }

        // Różna ilość parametrów o różnych typach - "params object[]"
        // Wszystkie parametry zostaną rzutowane do typu object.
        static void Drawer(params object[] things)
        {
            Console.WriteLine(things.ToString()); // wynik: object[];
            foreach (object ob in things)
            {
                Console.WriteLine(ob.GetType()); // wynik: System.Int32[], System.String[], <>f__AnonymousType0`2[System.String,System.Int32][]
                switch (ob)
                {
                    case int[] tabInt:
                        foreach(var a in tabInt)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    case string[] tabStr:
                        foreach (var a in tabStr)
                        {
                            Console.WriteLine(a);
                        }
                        break;
                    
                }
            }
        }

        static void Drawer2(object[] things)
        {
            Console.WriteLine(things.ToString()); // wynik: int[];
            foreach (int ob in things)
            {
                Console.WriteLine(ob); // wynik: 4
            }
        }

        static void Drawer3(object things)
        {
            Console.WriteLine(things); // wynik: 4
        }

        static void Drawer4(params object[] things)
        {
            Console.WriteLine(things[0]);  //  wynik: int[,];  Console.WriteLine wykona metode 'ToSting()' na obiekcie.
            int[,] multiTab = things[0] as int[,];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(multiTab[i, j]); // wynik: 0
                }
            }
        }

        static void ParametryOpcjionalneAParametrParam()
        {
            // Wykona się metoda z parametrami opcjionalnymi
            Sum();
            Sum(1);
            Sum(1,2,3,4);
            // Wykona się metoda z tablicą parametrów typu 'params'
            Sum(1, 2, 3, 4, 5);
        }

        static int Sum(int a = 0, int b = 0, int c = 0, int d = 0)
        {
            return a + b + c + d;
        }

        static int Sum(params int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
