﻿using System;

namespace Chapter_9_Enums_and_Structs
{
    class Program
    {
        // Język C# posiada 2 rodzaje 'Wartościowych' typów danych: Wyliczeniowy (enum) i Strukture (Struct)
        // Enum (typ wyliczeniowy) jest wartościowym typem danych, zawiera wartość na stosie.
        // Struktyry również przechowuja wartośći na stosie. Gdy klasa jet mała lepiej jest uzyć strukture, gdyż zarządzanie pamięcią na stercie jest to dodatkowy narzutem operacji do wykonania
        public enum Seasons
        {
            // Wartości enuma nazywamy 'literałami' wyliczeniowymi.
            // Literały są reprezentowane przez liczby całkowite domyślnie zaczynając od zera. Może być reprezentowany przez każdy typ danych całkowitoliczbowego. Należy określic typ po ':'
            Spring, Summer, Autumn, Winter
        }

        // Dwa Literały reprezentowane przez tą samą liczbę. RepresentationOfTheEnumsValue - przykład
        public enum AmericanSeasons
        {
            Spring, Summer, Fall, Autum = Fall, Winter
        }

        // Tylko typy całkowitoliczbowe mogą zostać do tego uzyte. Takie jak: 'byte', 'sbyte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong'.
        // short czy byte zajmuje mniej miejsca w pamięci niż int. 
        //  Nie można zdefiniować więcej literałów niż zakres danego typu na to zezwala np. dla byte zakres wartości jest od '0 do 255'
        public enum Color : short
        {
            green, lawngreen = green, limegreen = green, red, blue
        }

        static void Main(string[] args)
        {
            AboutEnum();
            AboutStructs();
            MyStruct();

            Console.ReadKey();
        }

        public static void AboutEnum()
        {
            Seasons hotSeason = Seasons.Summer;

            // Przekształcenie wartości typu wyliczeniowego na string
            string winter = Seasons.Winter.ToString();
            //string winter = (string)Seasons.Winter; Nie zadziała. 
            int representativeOfEnumValue = (int)Seasons.Autumn; //Zadziała

            // Operacje arytmetyczne na enumach. Dostępne są wszystkie tak jak na pozostałych typach wartościowych oprócz bitwise i shift (zostaną omówione w rozdziale 16 "Indeksatory")
            AritmeticOperationOnEnum();
        }

        public static void AritmeticOperationOnEnum()
        {
            Seasons season = Seasons.Spring;
            season++;
            Console.WriteLine(season);
            --season;
            season += 2;
            season += 100;
            Console.WriteLine(season); // zostanie wyswielona liczba, gdyż nie ma takiej pory roku
            bool isSummer = season == Seasons.Summer;
            if (isSummer)
            {
                Console.WriteLine("Ide na plaże");
            }

            // season += Seasons.Spring; // BAD
            // season += (int)Seasons.Spring; // GOOD
        }

        public static void AboutStructs()
        {
            // Struktury to wartościowy typ danych, przechowuje wartość na stosie. Gdy klasa jest mała lepiej uzyć struktury, gdyż obiekty klas wymagają pewnych dodatkowych operacji takich jak alkowanie pamięci na stercie (konstruktory) i dekonstruktory
            // Struktura moze posiadać pola, metody, konstruktory. Wiecej o tym w metodzie MyStruct()
            // Numeryczne typy danych np. bool, byte, short int, long, float, double, decimal ... są to struktury. String jest klasą
            // Są to odpowiednio aliasami do następujących struktur: System.Boolean, System.Byte, System.Int16, System.Int32, System.Int64, System.Single, System.Double, System.Decimal
            StructsStaticMethodes();
            MyStruct();


            // Wskazówki odnośnie przenoszenia/integracji aplikacji C# (kod zarządzany) z/do aplikacji napisanej w C++ (kod natywny)

            // Note: Wszystkie apliakcje C#, Visual Basic, F# uruchamiane są za pośrednictwem CLR platformy .Net Framework (CLR Common Language Runtime - Wspólne środowisko uruchomieniowe) 
            // CIL kompilator podczas kompilacji przekształca kod C# na pseudo-maszynowy kod nazywany wspólnym językiem pośredniczącym (Common Intermediate Language)
            // CLR odpowiedzialny jest za dostarczenie/utworzenie wirualnego srodowiska dla uruchomionego programu (kodu). Konwertuje instrukcje w formacie CIL na język zrozumiały dla maszyny.
            // Całe te środowisko nazywane jest 'zarządzanym środowiskiem uruchomieniowym' a programy ktore wykorzystuja ten mechanizm określane są mianem kodu zarządzanego.
            // W Windows 7 możliwe było tworzenie niezarządzalnych aplikacji określane są mianem kodu natywnego. Owe aplikacje do działania wykorzystywały interfejs API z podsystemy Win32 (API udostępnia bezposrednio rózne funkcje systemu Windows).
            // .Net Framework zezwala na umieszczenie kodu natywnego w aplikacji zarządzanych i odwrotnie lecz nie jest to podobno proste. Kod natywny to: Fortran, C, C++
            // W późniejszych systemach Windows zaimplementowano alternatywe do Win32. Windows Runtime (środowisko uruchomieniowe systemu Windows) w skrócie WinRT, który korzysta z API Win32 oraz innych interfejsów API systemu Windows.
            // WinRT zapewnia wieloplatformowość. Aplikacje Uniwersal Windows Platform (UWP) wykorzystuje WinRT do działania. W Windows 10 kod zarządzany (aplikacje zarządzane. nazwa własna) beda korzystac z API WinRT.
            // WinRT głownym zadaniem jest uproszczenie zintegrowania w jedną aplikacje składników (bibliotek) napisanych w różnych jezykach programowania.
            // To ma swoją cene gdyż języki posiadają pewne różnice np. w C++ struktury nie zawierają metod. Jeśli wiec bede pisał biblioteke, która zostanie umieszczona w C++ koniecznie bedzię usuniecie metod lub przerobienie jej na klase.
            // To samo tyczy sie pol statycznych oraz identyfikatora dostepności, wszystkie pola musza nie mogą byc prywatne w strukturze. Wszystkie pola muszą zawierać wartościowych (podstawowych/prymitywnych) typów danych lub stringa.
            // Srodowisko WinRT nakłada jeszcze kilka innych restrykcji co to klas i struktur tworzonych w jezyku C# aby mogły zostać bezpiecznie użyte w kodzie natywnym. Wiecej o tym w rozdziale 12.
        }

        private static void CommonLanguageRuntime_CLR_AND_CommonIntermediateLanguage_CIL()
        {
            // Wszystkie apliakcje C#, Visual Basic, F# uruchamiane są za pośrednictwem CLR platformy .Net Framework (CLR Common Language Runtime - Wspólne środowisko uruchomieniowe) 
            // CLR (Wspólne środowisko uruchomieniowe) odpowiada za utworzenie virtual maszyny na której wykonywany bedzie kod.
            // CIL (Common Intermediate Language - wspólny język pośredni) podczas kompilacji, kompilator przekształca kod napisany w C#, Visual Basic itp. do postaci CIL (nazywany również kodem/zbiorem instrukcji pseudo-maszynowym) 
            // Po kompilacji taki zbiór instrukcji pseudo maszynowego zostanie zapisany do pliku wykonywalnego .exe
            // Podczas uruchomienia programu, CLR przekonwertuje kod CLI na rzeczywiste instrukcje maszynowe. 
            // Cały ten proces konwersji kodu do CLI i w CLR do postaci maszynowej nazywany jest "zarządzalnym środowiskiem uruchomieniowym", a programy napisany w tym standarcie "kodem zarządzanym"
            // W Windows 7 i wcześniejszych windowsach możliwe było również tworzenie niezarządzanech aplikacji nazywane "kodem natywnym".
        }

        private static void WinRT_AND_APIWin32()
        {
            // Niezarządzane aplikacje oparte są o wykorzystywanie fukcji oferowanych przez API podsystemy Win32.(w aplikacjach zarządzanych CLR również może korzystac z API Win32 jednak jest to całkowicie pernamętne dla programisty. 
                                                                                                                                                                                // (Chyba trzeba poprostu dodać odpowiednią bibliotekę))
            // Systemach nowszych od Windows 7 zaimplementowano Windows Runtime (środowisko uruchomieniowe systemu Windows) w skrócie WinRT oferującą warstę opartą o API podsystemu Win32 a także o kilku innych interfejsach API systemu Windows.
            // WinRT zapewnia wieloplatformowość od telefony po serwery.
            // W Win10 CLR bedzie korzystać z srodowiska WinRT zamiast Win32.
            // Tworząc aplikacje Universal Windows Platform (UWP), program bedzie korzystał z funkcji oferowanych przez API WinRT
            // Głownym zadaniem WinRT jest uproszczenie zintegrowania w jedną aplikacje składników (bibliotek) napisanych w różnych jezykach programowania.

            // Info: Dzięki specjalnych technologii pośredniczących możliwe jest umieszczanie kodu zarządzanego w aplikacjach niezarządzanych
        }

        public static void StructsStaticMethodes()
        {
            ToString();
            StructMethodsAndProperties();
        }

        public static new void ToString()
        {
            // Na wszystkich zmiennych jak i na literałach numerycznych typów danych (np. 99) możemy użyć metody 'ToString()'. 
            string result;
            int i = 99;
            result = i.ToString();
            result = 102.ToString();
            float f = 19.56F;
            result = f.ToString();
            result = 10.12F.ToString();

            //Note: metode ToString jest z dziedziczona z klasy object. Wszystkie typy ref i wartosciowe oraz jak widac literały mogą jej użyć. 
        }

        public static void StructMethodsAndProperties()
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

        public static void MyStruct()
        {
            // Moja struktura
            // Na wlasnych strukturach nie działąją operatory równości '==' '!=' można je przeciążyć.
            Time time = new Time(12, 9, 59); // różnice miedzy struktura a klasą zostały opisane w strukturze Time. 

            // Ponieważ struktura jest typem wartościowym nie trzeba jej inicjalizować podczas deklaracji. Próba uzycia skonczy się błędem kompilacji.
            Date Holiday;
            int a;
            //int b = a; // blad kompilacji

            // Kopiowanie i przypisanie wartość zmiennej strukturalnej.
            Date date = new Date(1991, Month.July, 6);
            Console.WriteLine(date);  // Console.Write automatycznie uzyje metody ToString();
            Date Birthday = date;
            Console.WriteLine(Birthday);

            // Note: Podsumowując, struktur należy uzywać do tworzenia danych które są na tyle niewielkie, że kopiowanie ich wartości bedzie tak samo efektywna co kopiowanie referencji.
            //       Główną cechą instancji struktury ma być jej wartość a nie oferowana funkcjionalność 
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
