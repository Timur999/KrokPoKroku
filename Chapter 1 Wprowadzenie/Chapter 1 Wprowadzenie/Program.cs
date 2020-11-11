
/* Tworząc projekt w technologii .Net możemy wybrać z którego frameworka nasz projekt bedzie korzystać.
 .Net Core przeznaczony jest do aplikacji przenośnych, które działają na wielu systemach operacyjnych np. Linux. 
 .Net Framework zawiera inne biblioteki niż .Net Core. Przeznaczona jest do aplikacji uruchamianych na Windowsie.
 .Net Standard zawiera tylko te biblioteki które występują tylko w .Net Core i .Net Frameworku.
*/
// Note: Framework zawiera środowisko uruchomieniowe języka wspólnego CLR oraz biblioteki. Każda nowa wersja dodaje nowe funkcjionalności i zachowuje stare.
/* 
    Aplikacje C# składają się z:
    1. Solucja(Rozwiązanie) jest to plik, który w hierarchi plików aplikacji leży najwyżej. Jest tworzony aby ułatwić prace z projektami.
Solucja może posiadać jeden projekt lub kilka.
    2. Project (Chapter 1 Wprowadzenie jest plikiem projektu) Każdy plik projektu zawiera odwołanie przynajmniej do jednego pliku zawierającego kod źródłowy,
pliku graficznego itp. Całość kodu źródłowego w danym projekcie musi zostać napisana w tym samym języku.
    3. Properties jest to folder należący do projektu. Zawiera klase AssemblyInfo.cs, jest to plik który umożliwia dodanie specjalnych atrybutów do programu
takich jak nazwa autora, data utworzenia programu itp. Możliwe jest dodanie takiego atrybutu który zmienia działanie programu. Wykracza to poza ramy książki.
    4. References (Odwołania) ten folder zawiera odwołania do bibliotek, ktore mogą być używane przez tworzoną aplikacje. 
Podczas kompilacji kod źródłowy jest przekształcany na bibliotekę. W środowisku .NET Framework biblioteki te nazywane są asemblacjami.
    4. App.config jest to plik konfiguracyjny, umożliwia dodanie daych konfiguracyjnych takich jak np. wersja środowiska .NET Frameworku używana
do uruchomienia tej aplikacji. 
    5. Program.cs plik źródłowy zawiera kod tworzonej aplikacji. (Plik źródłowy to plik od którego komputer zaczyna działanie).
*/
namespace Chapter_1_Wprowadzenie
{
    class Program
    {
        // Ta funkcjia rozpoczyna działanie programu. Jest nazywana punktem wejścia do programu. Metoda musi być static i zaczynać się od Wielkiej litery.
        static void Main(string[] args)
        {
        }
        // W folderze projektu znajduje się folder bin w tym folderze znajduje się wykonywalna wersja programu.
    }
}
