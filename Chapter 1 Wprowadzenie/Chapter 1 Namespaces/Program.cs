/* Przestrzenie nazw powstały dlatego aby zmniejszyć problem z nazewnictwem, konfliktem nazw klas itd.
 Im wieksza liczba klas tym większy problem z nazewnictwem.
 Dzięki przestrzeni nazw, klasy mogą mieć taką samą nazwę, podwarunkiem, że istnieją w różnych przestrzeniach.
 Zaleca się aby w najwyższej hierarchi pliku projektu, używać nazwy projektu jako nazwy przestrzeni nazw (namespace Chapter_1_Namespaces).
*/

/* Załóżmy, że przestrzeń nazw to Pokój, projekt to Mieszkanie a solucja to Blok. Dyrektywa using to drzwi do pokoju.
 * W Pokoju mogą znajdować się różne obiekty jak Tapczan Lampa itp. - to nasze klasy.
 * W Mieszkaniu musi sie znajdować przynajmniej jeden pokój, który posiada metode Main (wejscie do programu).
 * Może się znajdować wiecej pokoi a także referencje do innych mieszkań (folder References - książka adresowa do innych projektów (bibliotek)).
 * Chcąc skorzystać z innych klas których nie zdefinowaliśmy w naszym projekcie musimy dodać referencje do tego projektu.
 * Inaczej mowiąc dodać adres mieszkania do ksiązki adresowej projektu.
 */

/* W środowisku .Net Framework istnieje mnóstwo takich projetów (inaczej też mówi się na nie assemblace). Każda z nich dostarcza różne funkcjonalności
 * z których możemy skorzystać w naszych aplikacjach. Istnieje taka główną asemblacja (zestaw ten nosi nazwie mscorlib.dll). Zawiera powszechnie używane
 * klasy, takie jak System.Console, inne assemblacje zawierający klasy służace do pracy z bazą danych, korzystające z usług webowych, tworzenia interface
 * graficznego, itd.
 * Assemblacja może mieć wiele przestrzni nazw (mieszkanie może mieć wiele pokoi)
 * Uwaga: Ta sama przestrzeń nazw może się zawierać w wielu assemblacjach, np. Klasy i elementy z przestrzeni nazw System zostały faktycznie zaimplementowane
 * w kilku różnych assemblacjach, miedzy innymi w mscorlib.dll, System.dll, System.Core.dll.
 */

/* Podczas tworzenia projektu, VS automatycznie doda odpowiednie odwołania do bibliotek w zależności od wybranego szablonu np. Console application.
 * Jednak w żadnym z projektów nie znajdziemy asemblacji mscorlib.dll. Wynika to z faktu, że ta asemblacja zawiera podstawowe funkconalności czasu wykonywania 
 * i musi być używana przez wszystkie aplikacje korzystające z platformy .NET Framework.
 */

// Przestrzenie nazw to poprostu kontenery dla identyfikatorów np. nazwy klas.
namespace Chapter_1_Namespaces
{
    /* Dyrektywa using pozwala korzystac z klas i elementów zawartych w przestrzeni nazw bez wpisywania pełnej nazwy.
     np. pełna nazwa klasy Console zawartej w przestrzeni nazw System to System.Console.
     Dyrektywa using dodaje wskazaną przestrzeń nazw do zasięgu (ang. scope).*/
using System;

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello");
            Console.Read();
        }
    }
}

