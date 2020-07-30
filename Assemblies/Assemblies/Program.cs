// Asemblacja inaczej: wiele klas; biblioteka klas; binarna asemblacja. Na asemble składa się plik o rozszerzeniu .dll (choc scisle mowiac także plik wykonywalny .exe)
// W srodowisku .Net Framework główną assembla która zawiera klsay System.Console i inne jak do manipulacji z bazą danych, korzystajacych usług webowych i innych jest "mscorlib.dll"
// Są one instalowane w raz z Visual Studio

// Note: .Net standard jest to cześć w spólna bibliotek .net framework i .net core

// Pod projektem w zakładce 'Propierties' znajduje się plik AssemblyInfo.cs zawiera on atrybuty m.in. nazwie autora, daty utworzenia projektu, itd. Może również posiadać atrybuty zmieniające działanie programu. (wiecej w necie)
// W zakładce 'References' znajdują się biblioteki/programy. Podczas kompilacji kodu C# następuje konwersja kodu na biblioteke zwanej także assemblą, której zostanie nadana unikatowa nazwa.
// App.config plik konfiguracynjny określający działanie prrogramu np. nr wersji .net frameworku
// bin i obj są tworzone podczas budowania programu i zawierają wykonywalne pliki programu oraz pewne pliki potrzebne do budowania aplikacji i jej debagowania. (w Solution Explorer-> Show All Files)

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


// dyrektywa using dodaje (elementy z ) przestrzeni nazw do zasięgu (scope) z jednej lub z wielu assemblies
using Assemblies.Poland;
using System;

// Przestrzeń nazw 'Paying' jest zdefiniowana w assebli Shopping i Travelling (są dodane do referencji programu). Dzięki using moge korzystać z klas i elementów zdefiniowanych w tych assemblach w przestrzeni nazw 'Paying'
using Paying;

// Asseblia Travelling posiada dwie przestrzenie nazw. 'Paying' i 'Travelling'
using Travelling;


// namespace inczej mowiąc kontenery. Przestrzen nazw służy tylko do oddzielenia nazw klas obiektów od innych przestrzeni nazw. 
// Dobrą praktyką jest nazywanie przestrzeni nazw tak jak nazwa projektu lecz nie jest to wymagane, możemy nazwać jak chcemy. 
namespace Assemblies
{
    class Program
    {
        // Metoda Main jest to tzw. "Punkt wejścia programu". Musi być statyczna bo inaczej .net framework mogłby nie rozpoznac, ze jest to "Punkt wejścia programu".
        static void Main(string[] args)
        {
            // klasy Citizen są w różnych przestrzeniach nazw. Pełne nazwy tych klas to Assemblies.Poland.Citizen. Nie musimy uzywać pełnych nazw od tego słuzy nam dyrektywa using.
            Citizen pole = new Citizen();
            USA.Citizen american = new USA.Citizen();


            // Przestrzeń nazw i Assemble nie muszą być w relacji 1:1. 
            // Jedna Assembla może zawierać wiele przestrzni nazw przykład Travelling. (moze zawierac klasy zdefinowane w wielu przestrzeniach nazw)
            // Jedna Przestrzen nazw moze istnieć w kilku Assemblach przykład Shopping/Paying. (klasy, elementy z jednej przestrzeni nazw mogą być zdefiniowane w wielu assemlach)
            Shoping shoping = new Shoping();
            shoping.Pay();
            TravellingByTrain travellingByTrain = new TravellingByTrain();
            travellingByTrain.Pay();


            //klasa z przestrzeni nazw Travelling. Klasy nie mogą nazywać się jak przestrzeń nazw. Gdyby nazwać tak samo kompilator poinformuje nas 'Travelling' is a namespace but is used like a type Assemblies. 
            Travel travelling = new Travel();
            travelling.TravelOnFoot();

            // Klasy i inne elemnty z przestrzni nazw System zostały zaimplementowane w kilku assemblies tj.: mscorlib.dll, System.dll, System.Core.dll. 


            //Własna klasa w przestrzeni nazw 'System'
            SystemData systemData = new SystemData();
            systemData.GetComputerName();
            systemData.GetUserName();

            Console.ReadKey();
        }
    }
}
