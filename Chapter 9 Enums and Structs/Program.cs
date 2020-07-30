using System;

namespace Chapter_9_Enums_and_Structs
{
    class Program
    {
        // Język C# posiada 2 rodzaje 'Wartościowych' typów danych: Wyliczeniowy (enum) i Strukture (Struct)
        // Jeśli enum (typ wyliczeniowy) jest wartościowym typem danych to zawiera wartość na stosie.
        // Struktyry również przechowuja wartośći na stercie. Gdy klasa jet mała lepiej jest uzyć strukture, gdyż zarządzanie pamięcią na stercie jest to dodatkowy narzut operacji
        public enum Seasons
        {
            // Domyślnie wartości zmiennej wyliczeniowej są ponumerowane zaczynajac od zera '0'. Wartości enuma nazywamy 'literałami'
            // Literały są reprezentowane przez liczby
            Spring, Summer, Autumn, Winter
        }

        // Dwa Literały reprezentowane przez tą samą liczbę. RepresentationOfTheEnumsValue - przykład
        public enum AmericanSeasons
        {
            Spring, Summer, Fall, Autum = Fall, Winter
        }

        // Wybór typu danych reprezentujący wartośc enuma (Literał).
        // Tylko typy całkowitoliczbowe mogą zostać do tego uzyte. Takie jak: 'byte', 'sbyte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong'.
        // short czy byte zajmuje mniej miejsca w pamięci niż int. 
        // Literały będą reprezentowane przez wartości danego typu danych więc nie mogą przekraczać dopuszczalnego zakresu typu. np. dla byte od '0 do 255'
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

            // Można zrobić zmienną wyliczeniową nullowalną. Jak dla wszystkich pozostałych wartościowych typów danych.
            Seasons? season = null;
            // season.HasValue; season.Value;

            // Można przekazac referencje zmiennej jak np. int czy zmienna referencyjną
            ChangeSeason(ref hotSeason);
            Console.WriteLine(hotSeason); //Summer

            // Przekształcenie wartości typu wyliczeniowego na string
            string winter = Seasons.Winter.ToString();
            //string winter = (string)Seasons.Winter; Nie zadziała. 

            // Jakich operatorów można uzywać na enumach? Takich samych jak na pozostalych wartościowych typach jak np. int oprócz bitwise i shift (zostaną omówione w rozdziale 16 "Indeksatory")
            AritmeticOperationOnEnum();

            // Jak odczytać wartość reprezentującą dany literał zmiennej wyliczeniowej
            RepresentationOfTheEnumsValue();
        }

        public static void ChangeSeason(ref Seasons season)
        {
            season = Seasons.Autumn;
        }

        public static void AritmeticOperationOnEnum()
        {
            Seasons season = Seasons.Spring;
            season++;
            Console.WriteLine(season);
            // season += Seasons.Spring; // BAD
            // season += (int)Seasons.Spring; // GOOD
            --season;
            season += 2;
            season += 100;
            Console.WriteLine(season); // zostanie wyswielona poprostu liczba, gdyż nie ma takiej pory roku
            bool isSummer = season == Seasons.Summer;
            Console.WriteLine(isSummer);
        }

        public static void RepresentationOfTheEnumsValue()
        {
            int springNumber = (int)AmericanSeasons.Spring; // Spring = 0
            int autumnNumber = (int)AmericanSeasons.Autum; // autumnNumber = 2
            autumnNumber = (int)AmericanSeasons.Fall; // autumnNumber = 2
        }

        public static void AboutStructs()
        {
            // Struktury to wartościowy typ danych, przechowuje wartość na stosie. Gdy klasa jest mała lepiej uzyć struktury, gdyż obiekty klas wymagają pewnych dodatkowych operacji takich jak alkowanie pamięci na stercie (konstruktory) i dekonstruktory
            // Struktura moze posiadać pola, metody, konstruktor. Wiecej o tym w metodzie MyStruct()
            // Numeryczne typy danych np. bool, byte, short int, long, float, double, decimal ... to są struktury.
            // Są to odpowiednio aliasami do następujących struktur: System.Boolean, System.Byte, System.Int16, System.Int32, System.Int64, System.Single, System.Double, System.Decimal
            StructsStaticMethodes();
            MyStruct();


            // Note: Wszystkie apliakcje C#, Visual Basic, F# uruchamiane są za pośrednictwem CLR platformy .Net Framework (CLR Common Language Runtime - Wspólne środowisko uruchomieniowe) 
            // CIL kompilator podczas kompilacji przekształca kod C# na pseudo-maszynowy nazywany wspólnym językiem pośredniczącym (Common Intermediate Language)
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

        public static void StructsStaticMethodes()
        {
            // typy danych numerycznychc tylko 2 Parse i TryParse oraz 2 wlasciwości
            StructToString();
            StructMethodsAndProperties();
        }

        public static void StructToString()
        {
            // Na wszystkich zmiennych i literałach numerycznych typów danych można użyć metode 'ToString()'
            string result;
            int i = 99;
            result = i.ToString();
            result = 102.ToString();
            float f = 19.56F;
            result = f.ToString();
            result = 10.12F.ToString();
        }

        public static void StructMethodsAndProperties()
        {
            // Int32.Parse(value); Int32 to nazwa struktury, int jest aliasem.
            int number = int.Parse("1239");  
            int.TryParse("123", out int intNumber);
            int.Equals(number, intNumber);
            int.ReferenceEquals(number, intNumber);

            // Struktua posiada 2 pola
            number = int.MaxValue;
            number = int.MinValue;
        }

        public static void MyStruct()
        {
            // wlasna struktura
            // Na wlasnych strukturach nie działąją operatory równości '==' '!=' można je przeciążyć.
            Time time = new Time(12, 9, 59); // różnice miedzy struktura a klasą zostały opisane w strukturze Time. 

            // Ponieważ struktura jest zmienna wartościową nie trzeba jej inicjalizować podczas deklaracji. Próba uzycie skonczy się błędem kompilacji.
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
            // WAZNE: string nie jest struktura tylko klasą

            string[] fruits = new string[] { "apple", "peach", "banana", "currants", "apricot", "tangerine" };
            string fruit = "strawberry";
            string vege = "cucumber";

            string.IsNullOrEmpty(vege);
            string.Format("I like so much {0}", fruit); // zapis stringa
            // zapis stringa. Można zpisać w różnych formatach np. liczba ile miejsc po przecinku czy po kropce. Date oraz format daty w zelżności od podanego providera np. System.Globalization.CultureInfo(cultureName);
            string.Format("In the grocery you can buy: {0}, {1}, {2}, {3}, {4}, {5}", fruits[0], fruits[1], fruits[2], fruits[3], fruits[4], fruits[5]); 
            string.Compare("A", "B"); // Jesli takie same zwraca 0, jesli roznią się tylko wielkością liter zwraca 1, jesli sa róznie -1
            string.CompareOrdinal("A", "a"); // Uwzglednia wielkosc liter, jesli są identyczne zwróci 0 inaczej jakis minus.
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
