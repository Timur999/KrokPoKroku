using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model;
using Chapter_13_Interfejsy_i_klasy_abstrakcyjne.Model.Interfaces;
using System;

/* W projecie omowione są interfaces, klasy abstrakcyjne oraz slowo kluczowe sealed.
 * 
 * Interface:
 * Opisuje jedynie jaką funkcjonalność powinna posiadać klasa lub struktura, nie mówi w jaki sposób powinna ją implementować.
 * Intereface może zawierać wyłącznie sygnatury metod i właściwości nie może zawierać żadnych danych. 
 * Nie określa się modyfikatorów dostępności (public, protected, privete). Wsystkie metody w interfejsie są z założenia publiczne.
 * Interfejs możedziedziczyć po innym interfejsie ale nie może po klasie.
 * Zaleca się aby nazwy interfaców rozpoczynać duża literą 'I'.
 * 
 * Klasa Abstrakcyjna
 * Nie można utworzyć instancji klasy abstrakcyjnej, jednak może zawierać konstruktor który zostanie użyty przy tworzeniu klasy pochodnej.
 * Jej preznaczeniem jest bycie klasą bazową dla innych klas potomnych. np. 'Bryła' czy 'Ssak' stanowią rodzaj abstrakcji dla wpólnej funkcjionalności a nie coś co może istnieć samodzielnie.
 * Motody abstrakcyjne
 * Klasy abstracyjne mogą zawierać metody abstrakcyjne są one podobne do metod wirtualnych z tą różnicą, że nie zawierają ciała metody.
 * Klasy pochodne muszą nadpisywać tą metode własną implementacją. Metody abstrakcyjne są przydatne gdy tworzenie implemenacji domyślnej nie ma sensu.
 * 
 * Klasy zamknięte (sealed)
 * Gdy wiemy, że klasa np. 'Kula' nie bedzie spełniać dobrze wymagań jako klasa bazowa możemy użyć słowa kluczowego 'sealed'.
 * Klasa zamknięta nie może zawierać żadnych metod wirtaualnych.
 * Klasa abstrakcyjna nie może być zamknięta.
 * Metody zamknięte
 * Możliwe jest oznaczenie metody jako zamknięta i oznacza to, że klasy pochodne nie beda mogły jej przesłonić.
 * Oznaczenie metody jako zamkniętej jest możliwe wyłącznie na metodzie przeszłoniętej (override)
 * 
 * Słowa kluczowe interface, virtual, override, sealed można tłumaczyć następująco:
 * 1. 'interface' dostarcza nazwę metody do stworzenia własnej implementacji.
 * 2. 'virtual' jest pierwszą implementacją danej metody.
 * 3. 'override' jest kolejna implementacją danej metody.
 * 4. 'sealed' jest ostatnią implementacją danej metody.
 */

namespace Chapter_13_Interfejsy_i_klasy_abstrakcyjne
{
    class Program
    {
        static void Main(string[] args)
        {
            Implementowanie_Interfejsów();
            Obiekty_Przypisane_Do_Typu_Interfejs(); // interefejs jako parametr metody
            Implementowanie_Interfajsu_W_Sposób_Jawny(); // Explicitly Implementing Interface
            Implementowanie_Interferjsu_W_Sposób_Niejawny();
            Ograniczenia_Interfejsów();

            Klasy_Abstrakcyjne();

            // Podsumowanie w resoursach.

            Powtorka_CLR_i_WinRT();
            Integracja_AplikacjiNatywnych_Z_AplikacjaZarzadzana_W_Zakresie_Klas();

            Console.ReadKey();
        }

        static void Implementowanie_Interfejsów()
        {
            /* Gdy klasa lub struktura dziedziczy po interfejs musi spełniać następujące reguły:
             * Nazwa oraz typ implementowanej metody z interfejsu musi być taka sama.
             * Parametry metody musza być identyczne (nawet ref lub out jesli zostały użyte)
             * Implementowana metoda z interfacu w klasie lub w strukturze musi mieć identyfikator destępności publiczny,
             * chyba, że metoda jest zaimplementowana jawnie wtedy nie może być określony klasyfikator dostępności.
             * 
             * Klasa może dziedziczyć po innej klasie i po interfejsie (interfejsów może być wiele). Jako pierwsza podawana jest zawsze nazwa klasy bazowej następnie po przecinku nazwy interfejsów.
             * 
             * Przykład klasa Kula.
             * 
             * InterfejsA może dziedziczy po innym interfejsie (nazywa się to rozszerzeniem interfejsu). Typ implementujący ten interfejs musi oferować implementacje wszystkich metod zdefiniowanych
             * w interfejsieA oraz w tym drugim.
             */
        }

        static void Obiekty_Przypisane_Do_Typu_Interfejs()
        {
            /* Można przypisać obiekt implementujący dany interfejs do typu danego interfejsu w taki sam sposób jak w rodziale 12 do typu wyżej w hierarchi dziedziczenia.
             * Tak samo możliwe jest utworzenie metody akceptującej parametry typu interfejs. np.
             */

            Kula kula = new Kula();
            IRuch ruchKuli = kula;
            RuchBryly(ruchKuli, new PozycjaNaOsi(1, 2, 2));

            IRuch ruchKostki = new Kostka(1.1,1.9,2.9, new PozycjaNaOsi(1, 1, 2)); // 1 wymiary kostki, 2 pozycja na osi 
            RuchBryly(ruchKostki, new PozycjaNaOsi(1, 2, 2));

            void RuchBryly(IRuch bryla, PozycjaNaOsi nowaPozycja)
            {
                bryla.WykonajRuch(nowaPozycja);
            }
        }

        static void Implementowanie_Interfajsu_W_Sposób_Jawny() 
        {
            /* Dotyczy przypadku, gdy klasa dziedziczy po dwóch lub wiecej interfejsów i nazwa któreś metody się powtarza.
             * Należy jawnie zaimplementowac ten interface w definicji metody np. IOblicz.ObliczDystans(), przykład w klasie 'Kostka'.
             * Jeśli tego nie zrobimy to metoda ObliczDystans() bedzie implementować oba interferjsy. (Domyślnie C# nie dokonuje rozrożnienia, który interfejs jest implementowany przez daną metode).
             * 
             * Wywołanie takiej metody:
             * Jawnie zaimplementowany interfajs oznacza, że gdy utworzymy obiekt klasy i przypiszemy go do zmiennej o typie danego interfacjsu,
             * umożliwi to wywołanie funkcji danego interfejsu.
            */

            IOblicz kostka = new Kostka();
            Console.WriteLine(kostka.ObliczDystansDo(new Kula())); // Wykona się metoda ineterfejsu IOblicz

            IRuch kostka2 = new Kostka();
            Console.WriteLine(kostka2.ObliczDystansDo(new Kula())); // Wykona się metoda ineterfejsu IMove

            /* Z poziomu obiektu klasy 'Kostka', który implementuje interfejs w sposób jawny, metody 'ObliczDystansDo()' mają prywatny poziom dostępności.
             * Oznacza to że nie można wywołać któreś z tych metod gdy obiekt przypisany jest do zmiennej typu 'Kostka'. 
             * (Jeśli w klasie są 2 lub wiecej metod które nazywają się tak samo to nie wiadomo, która metoda ma się wykonać.)
             */

            Kostka kostka3 = new Kostka();
            Console.WriteLine(kostka3.ObliczDystansDo(new Kula())); // 'Kostka' does not contain a definition for 'ObliczDystansDo'

            // Note: Zaleca się aby zawsze gdy to jest możliwe, implementować interfejsy w sposób jawny!
        }

        static void Implementowanie_Interferjsu_W_Sposób_Niejawny()
        {
            /* Jest to raczej nieprawidłowe zachowanie. Powinno się implementować w sposób jawny a w szczególności gdy nazwa metody się powtarza.  
             * Klasa 'Kula' implementuje interfejs 'IRuch' oraz 'IOblicz' w sposób niejawny, przez co zawiera jedną implementacje metody 'ObliczDystandDo()' lecz definicja tej metody 
             * znajduje się w obydwóch interfejsach. Domyślnie język C# nie dokonuje rozrożnienia, który interfejs jest implementowany przez daną metode.
             */

            Kula kula = new Kula();
            kula.ObliczDystansDo(new Kula());
            IOblicz obliczKula = kula;
            obliczKula.ObliczDystansDo(new Kula());
            IRuch ruchKuli = kula;
            ruchKuli.ObliczDystansDo(new Kula());
        }

        static void Ograniczenia_Interfejsów()
        {
            /* 1. Interfejs nie może zawierać żadnych pól, nawet pól statycznych. Pole stanowi element implementacji klasy lub struktury.
             * 2. Nie może zawierać konstruktorów ani Destrutorów.
             * 3. Żadna metoda interfejsu nie może zawierać modyfikatora dostępności. Wszystkie z założenia są publiczne.
             * 4. Wewnątrz interfejsu nie można umieszczać klasy, struktury, zmiennych wyliczeniowych czy innych interfejsów.
             * 5. Interfejs nie może dziedziczyć po klasie ale jeden interfejs może dziedziczyć po drugim interfejsie.
             */
        }

        static void Klasy_Abstrakcyjne()
        {
            /* Gdy kod się powtarza jednym z rozwiązań jest utworzenie klasy bazowej i umieszczenie w niej wspólnej implementacji. */

            Bryla bryla = new Bryla(); //Błąd kompilacji

            Bryla kula = new Kula();
            Bryla kostka = new Kostka();

            /* Należy zwrócić uwagę, że klasa abstrakcyjna nie dziedziczy żadnego interfejsu. (Implementacja interfejsów jest cechą klas takich jak 'Kula' czy 'Kostka' a nie klas abstrakcynych)
             * Mimo to klasa abstrakcyjna 'Bryla' implementuje metodę 'UstawPozycje(PozycjaNaOsi pozycja)' jako nornalną metode publiczną. (Metoda 'UstawPozycje' znajduje się w interfejsie 'IPozycja')
             * Przez co klasy pochodne klasy 'Bryla' nie muszą implementować własnej wersji tej metody, pomimo, że implementują interfejs 'IPozycja', gdyż została ona już odziedziczona. 
             */

            kula.UstawPozycje(new PozycjaNaOsi(1, 2, 4));
            kostka.UstawPozycje(new PozycjaNaOsi(4, 1, 1));
        }

        static void Powtorka_CLR_i_WinRT()
        {
            /* Aplkacje zarządzane są uruchamiane za pośrednictwem 'CLR' który wykorzystuje .Net Framework. (.Net Framework to zestaw bibliotek i funkcji.)
             * Aplikacje niezarządzane (natywne) nie są uruchamiane za pośrednictwem CLR. Do działania wykorzystują interfejs API podsystemu 'Win32'. (Natywne interfejsy API systemu Windows)
             * Od systemu Windows 8 współne środowisko uruchomieniowe 'CLR' korzysta z 'WinRT'. 'WniRT' oferuje API podsystemu 'Win32' a także kilka nowych interfejsów API systemu Windows.
             * Wcześniej 'CLR' korzystał wyłącznie z API podsystemu 'Win32'. Dlatego aplikacje zarządzane działające na systemach Windows 7 i starszych będą działać również na Widowsie 8 i nowszych.
             * 
             * W Win 10 aplikacje UWP (Universal Windows Platform) są zawsze uruchamiane przy użyciu środowiska WinRT. Ozanacza to, że środowisko 'CLR' wykorzystuje funkcje środowiska 'WinRT'
             * zamiast funkcje ze interfejsów API podsystemu 'Win32'.
             * Microsoft dostarcza warstwę pośredniczącą pomiędzy 'CLR' a 'WinRT', która w transparenty sposób tłumaczy kierowane do .Net Frameworku żądania o utworzenie obiektu lub wywołanie
             * metody na równoważne wywołania funkcji środowiska 'WinRT'. Przykładowo, tworząc inta w środowisku .Net Framework, kod tworzący tę zmienną zostanie przetłumaczony na kod używający
             * równoważnego typu danych w środowisku 'WinRT'.
             * 
             * Choć środowiska .Net Framework i 'WinRT' pokrywają się w dyżym stopniu to nie wszystkie funkcje .Net Frameworku mają swoje odpowiedniki w 'WinRT'.
             * W konsekwencji aplikacje UWP mają ograniczony dostęp do podzbioru typów i metod oferowanych przez środowisko .Net Framework.
             * 
             * Z drugiej strony środowisko 'WinRT' oferuje także pokaźny zbiór typów i funkcji, które nie mają odpowiedników lub sposób działania opdowiedników różnią się znacząco w .Net Frameworku
             * uniemożliwiając lub utrudniając przez to łatwą translacje. Dlatego 'WinRT' udostępnia tego typu funkcje środowisku 'CLR' za pośrednictwem warstwy odwzorowującej, sprawiając, że
             * funkcje te wyglądają jak typy danych i metody ze środowiska .Net Framework, które mogą być wywoływane bezpośrednio z poziomu kodu zarządzanego.
             * 
             */
        }

        static void Podstawowe_Funkcje_I_Zadania_CLR()
        {
            /* Funkcje CLR:
             * Konwertuje kod CLI do maszynowego,
             * Obsługuje wyjątki,
             * Zapewnia bezpieczeństwo typów danych,
             * Zarzadza pamięcią (Garbage Collector),
             * Bezpieczeństwo,
             * Zwieksza wydajność,
             * Niezależność w wyborze języka programowania,
             * Niezależność platform, np. deskop, serwer, telefon
             * Niezależność architektury procesora
             */

            /* Komponenty CLR:
             * Class loader - sprawdza czy klasy istnieją w .Net Frameworku i w API i wczytuje je
             * MSIL (CIL) To Native Code - Just In Time (JIT) kopilator, kompiluje do kodu maszynowego,
             * Code Manager - zarządza kodem
             * Garbage Collector
             * Thread Support - wspoiera wielowątkowość
             * Exception Handler
             * /
        }

        static void Integracja_AplikacjiNatywnych_Z_AplikacjaZarzadzana_W_Zakresie_Klas()
        {
            /* Tworząc np. aplikacje UWP w języku C++ na platformie windwsie 10 bedzie ona korzystać z 'WinRT'. Aplikacje natywne nie korzystają ze środowiska 'CLR' i .Net Framework więc kod bezpośrednio
             * bedzie tłumaczony na wywołania funkcji 'WinRT'. w rozdziale 9 zostały opisane reguły jakie należy przestrzegać w przypadku tworzenia struktur w językach zarządzanych np. C# które są przezna-
             * -czone do używania w aplikacjach natywnych korzystających ze środowiska 'WinRT" (motody instancji i metody statyczne nie są dostępne z poziomu 'WinRT' a pola prywatne są nieobsługiwane).
             * 
             *  W przypadku klas muszą one spełniać następujące warunki:
             *  
             *  1. Wszystkie pola publiczne, parametry metod i typ zwracana przez metody publiczne muszą używać typów danych środowiska 'WinRT' lub takich typów ze środowiską .Net Framework, które
             *  mogą być w sposób transparenty przetłumaczone przez środowisko Windows RunTime na typ danych 'WinRT'. Przykłady obsługiwanych typów danych ze środowiska .Net Framework to zgodne typy
             *  wartościowe (struktury i typy wyliczeniowe) oraz typy primitywne takie jak int, float, double, decimal, bool, string, itd.
             *  Pola prywatne są obsługiwane przez klasy i mogą być dowolnego typu danych dostępnych w środowisku .Net Framework, nie muszą to być typy danych zgodne z środowiskiem 'WinRT'.
             *  
             *  2. Klasy nie mogą przesłaniać innych metod z klasy 'System.Object' niż metody 'ToString()'. 
             *  
             *  3. Nie mogą deklarować konstruktrów chronionych (protected).
             *  
             *  4. Przestrzeń nazw, w której definiowana jest klasa musi nazywać się tak samo jak plik wykonywalny i nazwa nie może zaczynać się od słowa 'Windows".
             *  
             *  5. Aplikacje niezarządzane nie mogą dziedziczyć po klasie napisanej w aplikacji zarządzanej za pośrednctwem środowiska 'WinRT'. Oznacza to, że klasy publiczne muszą być zamknięte (sealed)
             *  Jeśli zachodzi potrzeba polimorfizmu można stworzyć interfejs.
             *  
             *  6. Możliwe jest zgłaszanie dowolnego typu wyjątków, należącego do podzbioru typów wyjątków środowiska .Net Framework dostępnego dla aplikacji UWP.
             *  Niemożliwe jest jednak tworzenie własnych wyjątków. Jeśli aplikacja natywna z poziomu kodu zgłosi nieobsłużony wyjątek to środowisko 'WinRT' zgłośi równoważny wyjątek.
             *  
             *  
             *  Środowisko 'WinRT' nakłada również inne wymogi i ograniczenia związane z różnymi funkcjionalnościami języka C#. Bedą one omawiane w dalszej części kursu.
             *  
             */
        }
    }
}

