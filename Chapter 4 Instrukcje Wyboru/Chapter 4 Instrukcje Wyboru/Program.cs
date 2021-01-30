using Chapter_4_Instrukcje_Wyboru.Model;
using System;

namespace Chapter_4_Instrukcje_Wyboru
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void InstrukcjaWarunkowaIfElse()
        {
            bool wynik;
            int zmienna1, zmienna2, zmienna3 = 10;
            zmienna1 = zmienna2 = zmienna3;

            // Wskazówka: zaleca się aby w instrukcji warunkowej uzywać nawiasy np.
            wynik = zmienna1 < 11 && zmienna2 < 12 && zmienna3 < 13; // Nie zalecane
            wynik = (zmienna1 < 11) && (zmienna2 < 12) && (zmienna3 < 13); // Zalecane

            // Do porównywania dat. Klasa DateTime posiada metode statyczną Compare
            DateTime dt1 = new DateTime(1999, 8, 1);
            DateTime dt2 = new DateTime(1999, 9, 10);
            DateTime.Compare(dt1, dt2);
        }

        static void SkracanieDzialania()
        {
            bool warunek1 = false;
            bool warunek2 = true;
            // Jeśli instrukcja warunkowa która składa się z 2 warunków i && to gdy pierwszy warunek jest false, drugi warunek nie jest sprawdzany.
            if (warunek1 && warunek2)
                Console.WriteLine("Nie sprawdzi drugiego warunku");

            // Jeśli instrukcja warunkowa która składa się z 2 warunków i || to gdy pierwszy warunek jest true, drugi warunek nie jest sprawdzany.
            if (warunek2 || warunek1)
                Console.WriteLine("Nie sprawdzi drugiego warunku");
        }

        static void InstrukcjaSwitch()
        {
            /* Zasady które musi spełnić instrukcja switch: 
             * - Używana jest tylko do porstych typów danych.
             * - Etykiety case muszą być wyrażeniami stałymi. Wartość case nie może być zwrócona przez np. metode.
             * - Etykiety case nie mogą być takie same. Inaczej mówiąć wartość casa musi być unikatowa.
             * - Możliwe jest określenie, że dla różnych wartości sterującej (wartość w switchu) uruchomi się ten sam case. W tym celu należy podać
             * listę etykiet jedna pod drugą bez żadnych instrukcji pomiędzy.
             */
            Napoje napoje = Napoje.Herbata;
            switch (napoje)
            {
                case Napoje.WodaZcytryna:
                case Napoje.WodaPoOgorkach:
                    Console.WriteLine("Zdrowa i pic trzeba");
                    break;
                case Napoje.Kawa:
                    Console.WriteLine("Kawa chuj");
                    throw new Exception("Zbyt duze stezenie kofeiny we krwy. Zawał serca ioioioioio.");
                case Napoje.Herbata:
                    Console.WriteLine("Tylko zielona");
                    break;
                default:
                    Console.WriteLine("Jestem woda");
                    return;
            }

            //Note: W C# kompilator wymaga aby instrukcje case zakończyc dodając break lub return lub throw.
        }

        static void InstrukcjaSwitchTypDanych()
        {
            Okrag c = new Okrag(11);
            Kwadrat s = new Kwadrat(14);
            Trojkat t = new Trojkat(17);

            object o = t;
            if (o is Kwadrat mojKwadrat) // Zasieg zmiennej 'mojKwadrat' nie wykracza poza ifa ani case.
            {
                Console.WriteLine(mojKwadrat.DlugoscBoku);
            }
            else if (o is Okrag mojOkrag)
            {
                Console.WriteLine(mojOkrag.Promien);
            }

            switch (o) // Selectory 'case' sprawdzają typ danych obiektu o. Działanie takie same jak za pomocą powyższej instruckji if.
            {
                case Okrag circle:
                    Console.WriteLine("o is circle {0}", circle.ToString());
                    break;
                case Kwadrat square:
                    Console.WriteLine("o is square {0}", square.ToString());
                    break;
                case Trojkat triangle when triangle.DlugoscBoku > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.DlugoscBoku);
                    break;
                case Trojkat triangle:
                    Console.WriteLine("o is triangle");
                    break;
            }

            switch (o) // Selectory 'case' obsługują również wyrażenie 'when'
            {
                case Trojkat triangle when triangle.DlugoscBoku > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.DlugoscBoku);
                    break;
                case Trojkat triangle when triangle.DlugoscBoku > 10:
                    Console.WriteLine("Small triangle {0}", triangle.DlugoscBoku);
                    break;
            }
        }
    }

    enum Napoje
    {
        Kawa,
        Herbata,
        WodaZcytryna,
        WodaPoOgorkach
    }

}
