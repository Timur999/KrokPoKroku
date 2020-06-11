// Asemblacja inaczej: wiele klas, biblioteka klas, binarna asemblacja. Na asemble składa się plik o rozszerzeniu .dll (choc scisle mowiac także plik wykonywalny .exe)
// W srodowisku .Net Framework główną assembla która zawiera klsay System.Console i inne jak do manipulacji z bazą danych, korzystajacych usugł webowych i innych jest "mscorlib.dll"
// Są one instalowane w raz z Visual Studio

// Note: .Net standard jest to cześć w spólna bibliotek .net framework i .net core

// Propierties znajduje się plik AssemblyInfo.cs zawiera on atrybuty m.in. nazwie autora, daty utworzenia projektu, itd. Może również posiadać atrybuty zmieniające działanie programu. (do sprawdzenia w necie)

// References znajdują się biblioteki/programy. Podczas kompilacji kodu C# następuje konwersja kodu na biblioteke zwanej także assemblą, której zostanie nadana unikatowa nazwa.

// App.config plik konfiguracynjny określający działanie prrogramu np. nr wersji .net frameworku

// bin i obj są tworzone podczas budowania programu i zawierają wykonywalne pliki programu oraz pewne pliki potrzebne do budowania aplikacji i jej debagowania. (w Solution Explorer-> Show All Files)



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
        // Metoda Main jest to tzw. "Punkt wejścia programu". Musi być statyczna bo inaczej .net framework mogłby nie rozpoznac, ze jest to "Punkt wejścia programu"
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
