using System;

// Metoda to sekwencja instrukcji. Posiada Ciało, Parametry i Typ zwracanej wartości.
// Nazwa metody powinna jasno określać zastosowanie metody, np. ZnajdzNajwiekszaLiczbe() 
// Wskazowka: Jeśli sekwencja instrukcji nie mieści się na ekranie warto pomyślec o podzieleniu jej na kilka metod.

// Ważne: Podczas kompilacji programu kompilator zapisuje sobie wszystkie metody, ich sygnatury. (Na sygnature sklada się: nazwa, typ oraz parametry metody)
// Kompilator na podstawie przekazaych parametrów decyduje która przeciążoną metodę wykonać.
// Natomiast w przypadku parametrow domyslnych nalezy je zainicjować wartościami 'const' inaczej kompilator nie bedzie wstanie zapisac sobie sygnatury.

namespace Chapter_3_Metody_i_Zakres_Zmiennych
{
    class Program
    {
        static void Main(string[] args)
        {
            ZagniezdzanieMetody();
            Console.ReadKey();
        }

        // Metoda Wcielajaca Wyrażenia. Zostały stworzone z myślą o bardzo maŁych metodach bez rozbudowanej logiki.
        // Nie posiadają return. Jeśli wyrażenie nie zwraca wartości to metoda jest typu void.
        static public int DodajLiczby(int a, int b) => a + b;
        static public void PokazWynik(int result) => Console.WriteLine(result);

        // Więcej niż jedna wartość z funkcji.
        // Krotka (tuple) mała kolekcja wartości. Aby użyc krotki nalezy zainstalować pakiet 'ValueTuple'. 
        public static void Krotka()
        {
            float devidedResult, remainder;
            (devidedResult, remainder) = MojKalkulator.PodzielLiczby(11, 2);
        }

        //Przeciązanie Metody. Nazwa taka sama, różne parametry  
        public static void PrzeciazanieMetody()
        {
            MojKalkulator.PomnozLiczby(1.4f, 4.3f);
            MojKalkulator.PomnozLiczby(1, 4);
        }

        // Zagnieżdżenie Metody 
        public static void ZagniezdzanieMetody()
        {
            Console.WriteLine(MojKalkulator.ObliczSilnie(5));
        }

        //ParametryOpjionalne
        public static void ParametryOpjionalne()
        {
            MojKalkulator.ParametryOpcjionalne(21);
            MojKalkulator.ParametryOpcjionalne(21, 19.00f);
            MojKalkulator.ParametryOpcjionalne(21, 19.00f, "wlasny");
            
            // Mozliwe jest podanie parametrów w innej kolejności oraz pominięcie parametrów domyślnych, np. param2 omijamy1
            MojKalkulator.ParametryOpcjionalne(param3: "wlasny", param1: 21);
        }

        // Rozwiazywanie niejasnosci z parametrami opjionalnymi w przypadku 
        //        1. static public string Play(string name, int hp = 100, int dungeonsLevel=1),
        //        2. static public string Play(string name, int hp = 100, int dungeonsLevel=1, int heroLevel=7)
        //  w takim przypadku wygrywa metoda najbardziej dopoasowana
        //  Play( "Hero", 100, 1) ---- 1 metoda
        //  Play( "Hero", 100, 1, 7) ---- 2 metoda
        //  Play( "Hero", heroLevel: 7)---- 2 metoda
        //  Play( "Hero", 100) ---- blad i w kazdym innym przypadku.

    }

    class MojKalkulator
    {
        // Zakres Zmiennych (Scope)
        // Zmienna ma zakres klasy. Moze zostac uzyta w wszystkich metodach tej klasy.
        private static float _wynik; 

        public static float DodajLiczby(float a, float b)
        {
            _wynik = a + b;
            return _wynik;
        }

        public static (float, int) PodzielLiczby(int a, int b)
        {
            // Zmienna ma zakresie lokalny. Nie jest widoczna poza metodą.
            int reszta = a % b;
            _wynik = a / b;
            return (_wynik, reszta);
        }

        // Przeciążenie Metody 
        // Nie można przeciązyc metody która różni się tylko zwracanym typem np. public static int PomnozLiczby(float a, float b)
        // public static void PomnozLiczby(float a, float b) {} Błąd na etapie kompilacji.
        public static float PomnozLiczby(float a, float b)
        {
            _wynik = a + b;
            return _wynik;
        }

        public static float PomnozLiczby(int a, int b)
        {
            _wynik = a + b;
            return _wynik;
        }


        // Zagnieżdżenie Metody 
        // Metoda w metodzie. Stosuje się je gdy piszemy metode pomocniczą (helper) dla jakieś większej metody 
        // i nie chcemy aby została uzyta w innej części programu, np. przez przypadek. 
        // Taka praktyka zwiększa bezpieczeństwo. Przykład zastosowania metoda int Silnia(int wartosc)
        public static int ObliczSilnie(int liczba)
        {
            if (liczba < 1) { return 1; }
            
            int Silnia(int wartosc)
            {
                if (wartosc == 1) { return 1; }

                return wartosc * Silnia(wartosc - 1);
            }

            return Silnia(liczba);
        }


        /* Parametry Opcjionalne
         * Wiele starszych usług, aplikacji, bibliotek windowsowych nie korzysta z technologi .Net Framwork. 
         * Wykorzystują zato starszą technologie tzw. Model COM (Component Object Model - Obiektowy Model Składników)
         * Model COM nie wpiera metod przeciążonych ale wspiera Parametry Opcjionalne.
         * Język C# umożliwa integracja starszych usług, bibliotek itp z aplikacją. Dlatego wpiera również Parametry Opcjionalne.
         * Parametry Opcjionalne muszą znajdować się na koncu za parametrami obowiązkowymi. 
         */
        public static void ParametryOpcjionalne(int param1, float param2 = 12.5f , string param3 = "domyslny")
        {
            Console.Write($"param1:{param1}, param2:{param2}, param3:{param3}");
        }

        // Możliwe jest zmiana kolejności przekazywanych parametrów np. ParametryOpcjionalne(param3 : "wlasny", param1 : 21);

        //Note: .Net Framework i WinRT są silnie zależne od Modelu COM. (WinRT nie jest częścią .Net Frameworku)
        /* Wszystkie apliakcje C#, Visual Basic, F# uruchamiane są za pośrednictwem CLR platformy .Net Framework (CLR Common Language Runtime - Wspólne środowisko uruchomieniowe)
         * (Czyli .Net Framework jest odpowiedzialny za uruchamianie kodu zarządzanego).
         * .Net Frameworku sklada się z
         * Bibliotek,
         * CIL wspólnym językiem pośredniczącym (Common Intermediate Language),
         * CLR odpowiedzialny jest za dostarczenie/utworzenie wirualnego srodowiska dla uruchomionego programu (kodu),
         * Konwertuje instrukcje w formacie CIL na język zrozumiały dla maszyny,
         * Kompilator wysokiego poziomu standardowo C++/CLI, C#, Visual Basic .NET, J#,
         * Kompilator just-in-time kodu zarządzanego wraz z debuggerem,
         * I pewnie jeszcze z czegoś
         */
        /* WinRT jest to poprostu API który oferuje różne funkcje. Można też sobie to tłumaczyc jako zestaw biblioteki.
         * WinRT zapewnia wieloplatformowość. Aplikacje Uniwersal Windows Platform (UWP) wykorzystuje WinRT do działania.
         * WinRT głownym zadaniem jest uproszczenie zintegrowania w jedną aplikacje składników (bibliotek) napisanych w różnych jezykach programowania.
         * (Z WinRT mogą korzystać nie tylko aplikacje zarządzane ale takze natiwne, które są kompilowane bezpośrednio do kodu maszynowego.)
         * Lista funkcji oferowane przez WinRT znajdziemy tutaj: https://docs.microsoft.com/en-us/uwp/api/?redirectedfrom=MSDN
         */
    }
}
