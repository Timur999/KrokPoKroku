using System;

/* 
 * Język C# posiada 2 rodzaje wartościowych typów danych: Wyliczeniowy (enum) i Strukture (Struct)
 * Struktyry również przechowuja wartośći na stosie. Gdy klasa jet mała lepiej jest uzyć struktury, gdyż zarządzanie pamięcią na stercie jest dodatkowym narzutem operacji do wykonania.
 * Podobnie jak klasy, struktury mogą mieć Pola, Metody, Konstruktory (z jednym wyjątkiem omowionym ponizej w metodzie RoznicePomiedzyKlasaAStruktura()).
 * Typy liczbowe takie jak np. int, long, float to są Struktury. Dokładniej są aliasami do następujących struktur: System.Int32, System.Int64, System.Single.
 * Wszystkie te struktury posiadają swoje metody i pola np. ToString(), którą można użyć na zmiennych i literałach tych typów/struktur. (przykłady w metodzie MetodaInstancjiToString())
*/

namespace Chapter_9_Enums_and_Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            KiedyUzywacStruktur();
            PolaIMetodyStruktury();
            DeklaracjaWlasnejStruktury();
            KopiowanieZmiennychStrukturalnych();
            StrukturyAKompatybilnoscZWindowsRuntime();

            Console.ReadKey();
        }


        public static void KiedyUzywacStruktur()
        {
            /*
             * Ponieważ zmienne strukturalne są przechowywane na stosie to gdy ich rozmiar nie jest przesadnie duży, dodatkowy narzut związany z zarządzaniem danych na stercie zostanie zredukowany.
             * Podstawowe typy danychL bool, byte, short int, long, float, double, decimal ... Są to odpowiednio aliasami do następujących struktur:
             * System.Boolean, System.Byte, System.Int16, System.Int32, System.Int64, System.Single, System.Double, System.Decimal.
             * Należy pamiętać, że string (System.String) oraz object (System.Object) nie są strukturami tylko klasami i utwoerzenie ich zmiennej wiąze się z zarządzaniem tej zmiennej na stercie itd.
             */

            /* Note: Podsumowując, struktur należy uzywać do tworzenia danych które są na tyle niewielkie, że kopiowanie ich wartości bedzie tak samo efektywna co kopiowanie referencji.
            * Struktyry należy używać do reprezentacji prostych typów, których główną cechą ma być ich wartość a nie funkcjionalność.
            */
        }

        public static void PolaIMetodyStruktury()
        {
            MetodaInstancjiToString();
            StatyczneMetodyIWlasciwosci();
        }

        public static new void MetodaInstancjiToString()
        {
            // Na wszystkich zmiennych jak i na literałach numerycznych (np. 9) możemy użyć metody 'ToString()'. 
            string result;
            int i = 99;
            result = i.ToString();
            result = 102.ToString();
            float f = 19.56F;
            result = f.ToString();
            result = 10.12F.ToString();

            // Strutury posiadają ronież innej przydatne metody np.
            Console.WriteLine(i.Equals(12)); //false
            Console.WriteLine(i.CompareTo(13)); // 1
            Console.WriteLine(i.CompareTo(130)); // -1
            Console.WriteLine(i.CompareTo(99)); // 0

            //Note: metode ToString jest z dziedziczona z klasy object. Wszystkie typy ref i wartosciowe oraz jak widac literały mogą jej użyć. 
        }

        public static void StatyczneMetodyIWlasciwosci()
        {
            // Int32.Parse(value); Int32 to nazwa struktury, int jest aliasem.
            int number = int.Parse("1239");
            int.TryParse("123", out int intNumber);
            int.Equals(number, intNumber);
            int.ReferenceEquals(number, intNumber);

            // Struktura posiada 2 pola
            number = int.MaxValue;
            number = int.MinValue;
        }

        public static void DeklaracjaWlasnejStruktury()
        {
            /* Ponieważ struktura jest typem wartościowym nie trzeba jej inicjalizować podczas deklaracji. Próba uzycia skonczy się błędem kompilacji. */

            Czas teraz;
            int a;
            int b = a; // blad kompilacji

            Czas czas = new Czas(12, 9, 59); // Inicjiowanie struktur przedstawione obrazkowo w resorcach 'IMG_Inicjiowanie_zmiennej_strukturalnej_za_pomoca_konstruktora_i_bez_1.jpg i 2.jpg'

            /* Domyślnie dla zdefiniowanych przez uzytkownika/programiste struktur nie można uzywąć większości operatorów m.in. operatora równości "==" i "!=".
             * Można je przeciążyć lub użyc metody Equals().
             */

            /* Note: Podsumowując. Struktur należy uzywać do tworzenia danych które są na tyle niewielkie, że kopiowanie ich wartości bedzie tak samo efektywna co kopiowanie referencji.
             * Struktyry należy używać do reprezentacji prostych typów, których główną cechą ma być ich wartość a nie funkcjionalność.
             */
        }

        public static void KopiowanieZmiennychStrukturalnych()
        {
            /*
             * Kopiując zmienna strukturalną otrzymamy 2 kopie wartości tej zmiennej, Dla porownania kopiując zmienną typu ref. otrzymamy 2 takie same referencje. 
             * Kopiowanie i przypisanie wartość zmiennej strukturalnej jest możliwy tylko gdy wszystkie pola są wypenione. 
             * Obrazek w resoucach IMG_Kopiowanie_zniennych_strukturalnych.jpg
             */
            Time time = new Time(12, 9, 59); 
            Time timeInChina = time;

            Time teraz;
            // timeInChina = teraz  Błąd kompilacji

            timeInChina.SetHour(time.GetHour() + 6);
            Console.WriteLine(time); // 12:09:59
            Console.WriteLine(timeInChina); // 18:09:59
        }


        public static void RoznicePomiedzyKlasaAStruktura()
        {
            /*
             * 1. W strukturze nie można definiować własnego konstruktora domyślnego. Kompilator zawsze go generuje automatycznie.
             * 2. Po utworzeniu własnego konstruktora (niedomyślnego) w strukturze musimy jawnie zainicjować wszystkie pola.
             * W klasie nie musimy, kompilator wypełni takie pole wartością domyślną.
             * 3. Po zdefiniowaniu własnego konstruktora kompilator nadal bedzie generował konstruktor domyślny dla Struktury.
             * Dla klasy nie.
             * 4. Nie możliwe jest inicjiowanie pola w strukturze na poziomie deklaracji. W klasie jest możliwe.
             * 
             * Istnieją także różnice które są związane z dziedziczeniem. Zostaną omowione w rozdziale 12 "Dziedziczenie".
             */

            Czas czas = new Czas(); // Struktura, zawiera wlasny konstruktor oraz domyślny wygenerowany automatycznie przez kompilator
            Uzytkownik timurelos = new Uzytkownik(); // Klasa, zawiera tylko wlasny konstruktor. Błąd kąpilacji. 

            /* Kompilatory domyślne zawsze inicjalizują wszystkie pola struktur i klass wartościami domyślnymi, 0, false, null */
        }


        struct Czas
        {
            // Różnice miedzy struktya a klasą:
            // 1. Konstruktor Domyślny. W strukturze nie mozna zdefiniować wlasnego konstruktora domyślnego, w klasie możemy.
            // 1.1. W strukturze konstruktor domyślny jest generowany zawsze przez kompilator w klasie tylko wtedy gdy sami go nie zdefiniujemy i działa tak samo, czyli inicjalizuje wszystkie 
            // pola wartościami domyślnymi.
            // 1.2. Gdy zdefiniujemy wlasny konstruktor niedomyślny to wszystkie pola muszą zostać zainicjowane chociażby wartościamy domyslnymi: 0, false, null.
            // 2. Inicjiowanie pól. Gdy zdefiniowaliśmy własny konstruktor to musimy w nim przypisać wartość wszystkich pól struktury. W klasie gdy któreś pole niezainicjujemy zostanie nadana jej wartość domyślna.
            // 2.1. W strukturze nie można przypisać wartość polu na poziome deklaracji. W klasie możemy 
            
            private int sec, minute, hour;
            //private int miliSec = 0; // Błąd kompilacji. 2.1.

            public Czas(int _hour, int _minute, int _sec)
            {
                // Musimy jawnie przypisać wartości do WSZYSTKICH pól w strukturze!
                hour = _hour % 24;
                minute = _minute % 60;
                sec = _sec % 60;
            }

            /*public Time(int _hour, int _minute) 
            {
                hour = _hour % 23;
                minute = _minute % 59;
                  // Błąd kompilacji, nie przypisaliśmy wartości do zmiennej sec.
                  // w strukturze gdy zdefiniujemy konstruktor musi on inicjiować każde pole w strukturze. 
                  // w klasie kompilator przypisze wartość domyślną gdy sami tego nie zrobimy.
            }*/

            public int GetHour() => hour;
            public void SetHour(int _hour) => this.hour = _hour % 23;

            public override string ToString()
            {
                return $"{hour}:{minute}:{sec}";
            }
        }

        class Uzytkownik
        {
            public string Imie;
            public byte Wiek;
            private string Rola = "User"; // inicjacja na poziomie deklaracji.

            public Uzytkownik(string imie)
            {
                Imie = imie;
            }
        }

        public static void StrukturyAKompatybilnoscZWindowsRuntime()
        {
            // Wskazówki odnośnie przenoszenia/integracji aplikacji C# (kod zarządzany) do aplikacji napisanej w C++ (kod natywny)

            /*
            * Podstawowym przeznaczeniem środowiska WinRT jest uproszczenie współpracy pomiedzy kodem napisanym w różnych językach programowania, pozwalając na łatwiejszą integracje
            * aplikacji z różnymi kładnikami (bibliotekami) napisami w różnych językach. np. Aplikacja w jezyku C++ biblioteka w jezyku C#.
            * Ma to jednak swoją cene gdyż języki posiadają pewne różnice:
            * np. w C++ struktury nie posiadają metod instancji. Jeśli wiec bede pisał biblioteke w C#, która zostanie umieszczona w C++ koniecznie bedzię usuniecie metod lub przerobienie jej na klase.
            * To samo tyczy sie pól statycznych oraz identyfikatora dostepności, wszystkie pola nie mogą byc prywatne a pola publiczne muszą używać wartościowych typów danych. Zgodnich z C++ lub stringa.
            * Srodowisko WinRT nakłada jeszcze kilka innych restrykcji co to klas i struktur tworzonych w jezyku C# aby mogły zostać bezpiecznie użyte w kodzie natywnym. Wiecej o tym w rozdziale 12.
            */
        }

        private static void CommonLanguageRuntime_CLR_AND_CommonIntermediateLanguage_CIL()
        {
            // Wszystkie apliakcje C#, Visual Basic, F# uruchamiane są za pośrednictwem CLR platformy .Net Framework (CLR Common Language Runtime - Wspólne środowisko uruchomieniowe) 
            // CLR odpowiada za utworzenie virtual maszyny na której wykonywany bedzie kod.
            // Podczas kompilacji aplikacji w jezyku C#, F#, itp kompilator przekształca kod zródłowy na pseudo-maszynowy kod nazywany Wspólnym Językiem Pośredniczącym (Common Intermediate Language - CIL)
            // Po kompilacji taki zbiór instrukcji pseudo maszynowego (CIL) zostanie zapisany do pliku wykonywalnego .exe
            // Podczas uruchomienia programu napisanej w jezyku C#, środowisko CLR odpowiedzialne jest za konwersje instrukcji jezyka CLI na rzeczywiste instrukcje maszynowe. 
            // Cały ten proces konwersji kodu do CLI i w CLR do postaci maszynowej nazywany jest "zarządzalnym środowiskiem uruchomieniowym", a programy napisany w tym standarcie "kodem zarządzanym".
            // W Windows 7 i wcześniejszych windowsach możliwe było również tworzenie niezarządzanech aplikacji nazywane "kodem natywnym".
        }

        private static void WinRT_AND_APIWin32()
        {
            // Niezarządzane aplikacje (z kodem natywnym) oparte są o wykorzystywanie fukcji oferowanych przez API podsystemy 'Win32'.
            // (W aplikacjach zarządzanych CLR również może korzystac z API Win32 jednak jest to całkowicie przezroczyste dla tworzonego kodu przez programiste. (Chyba trzeba poprostu dodać odpowiednią bibliotekę))

            // Systemach nowszych od Windows 7 zaimplementowano alternatywne rozwiązane w postaci Windows Runtime ('WinRT') (środowisko uruchomieniowe systemu Windows)
            // WinRT oferuje warstę opartą o API podsystemu Win32 a także o kilka innych interfejsach API systemu Windows, która zapewnia spójną funkcjionalność na różnego typu użądzeniach.
            // WinRT zapewnia wieloplatformowość od telefony po serwery.
            // Tworząc aplikacje Universal Windows Platform (UWP), program bedzie korzystał z funkcji oferowanych przez API WinRT a nie z API podsystemu Win32
            // Analogicznie środowisko CLR w systemie Windows 10 również bedzie korzystać z środowiska WinRT zamiast Win32. W trakcie wykonywania kodu zarządzanego środowisko CLR bedzie przekształcać
            // wykonywany kod na wywołania funkcji API WinRT zamiast API Win32. Środowiska CLR i WinRT wspólnie odpowiadają za bezpieczne zarządzanie i uruchamianie kody w systemie Windows 10.
            // Głownym zadaniem WinRT jest uproszczenie z integrowania w jedną aplikacje składników (bibliotek) napisanych w różnych jezykach programowania.

            // Info: Dzięki specjalnych technologii pośredniczących możliwe jest umieszczanie kodu zarządzanego w aplikacjach niezarządzanych
        }



        public static void StringStaticMethods()
        {
            // WAZNE: string nie jest struktura tylko klasą. Dlatego posiada więcej metod.

            string[] fruits = new string[] { "apple", "peach", "banana", "currants", "apricot", "tangerine" };
            string fruit = "strawberry";
            string vege = "cucumber";

            string.IsNullOrEmpty(vege);
            string.Format("I like so much {0}", fruit); // zapis stringa
            // zapis stringa. Można zpisać w różnych formatach np. liczba ile miejsc po przecinku czy po kropce. Date oraz format daty w zelżności od podanego providera np. System.Globalization.CultureInfo(cultureName);
            string.Format("In the grocery you can buy: {0}, {1}, {2}, {3}, {4}, {5}", fruits[0], fruits[1], fruits[2], fruits[3], fruits[4], fruits[5]);
            string.Compare("string", "STRING"); // Jesli takie same zwraca 0, jesli roznią się tylko wielkością liter zwraca 1, jesli sa róznie -1
            string.CompareOrdinal("TEXT", "text"); // Uwzglednia wielkosc liter, jesli są identyczne zwróci zero inaczej wartość ujemna.
            string temp = string.Concat("a", "g", "r");
            string.Concat<int>(new int[] { 123, 44 });
            string.Copy("ooo");
            string.Equals(vege, fruit);
            fruit.Equals(vege);
            string.IsNullOrEmpty(fruit);
            string.IsNullOrWhiteSpace(fruit);
            string.Join(",", new string[] { "A", "B" }); // A,B
            string theSameFruit = string.Intern(fruit); //przekazuje referencje. string jest troche inny niż obiektów referencyjnych i wartościowych dlatego aby przekazac ref nalezy uzyc string.Intern
            Console.WriteLine($"{(object)theSameFruit == (object)fruit}");
            Console.WriteLine(string.IsInterned("raspberry"));


            // Więcej tutaj: https://docs.microsoft.com/pl-pl/dotnet/api/system.string.clone?view=netcore-3.1

            // Note: zrobić osobny projekt w którym pokaze jak formatowac liczby daty w zależności od podanej kultury. 
            // Te klasy dziedziczą po IFormatProvider:
            //System.Globalization.CultureInfo
            //System.Globalization.DateTimeFormatInfo
            //System.Globalization.NumberFormatInfo
        }
    }
}
