using Classies.Model;
using System;
using Chapter_7_Tworzenie_zarzadzanie_klasami_i_obiektami.Model;

/* Klasy umożliwiają wygodny sposob tworzenia Encji na podstawie zdefiniowanego szablonu.
 * Encją może być np. 'klient' lub cos bardziej abstakcyjnego 'tranzakcja'.
 * Podczas tworzenia projektu powinniśmy zastanowić się z jakich Encji nasza aplikacja bedzie korzystać
 * oraz jakie informacje powinna zawierać, przechowywać i jakie operacje wykonywać.
 */

/* Klasyfikacja. 
 * Pisząc programy powinniśmy starać się implementować tak klasy jak faktycznie jest w rzeczywistości.
 * Np. Klasa Samochód nie powinna zawierać metody latanie czy smarzenie frytek.
 */

/* Hermetyzacja (ang. encapsulation)
 * Polega na zasłonięciu zasady działania metody/klasy, ważne aby realizowała swoję zadanie.
 * np. Samochód musi dojechać do celu, nie jest ważne jak działa silnik itp.
 * Hermetyzacja ma 2 cele:
 * Łączenie ze sobą metod i danych wewnątrz klasy; inaczej mówiąc, umożliwienie przeprowadzenia klasyfikacji.
 * Kontrolowanie dostępności metod i danych; inaczej mówiąc kontrolowanie sposoby wykorzystywania klasy.
 */

namespace Chapter_7_Tworzenie_zarzadzanie_klasami_i_obiektami
{
    class Program
    {
        static void Main(string[] args)
        {
            DefiniowanieIUzywanieKlas();
            KontrolowanieDostepnosci();
            KonwencjeNazewnicze();
            Konstruktory();
            KlasyCzesciowe();
            KomentarzTODO();
            SłowoKluczoweThis();
            MetodaInstancji();
            DekonstrukcjaObiektu();
            MetodyPolaStatyczne();
            PolaConst();
            KlasyStatyczne();
            StatyczneInstrukcjeUsing();
            KlasyAnonimowe();

            Console.ReadKey();
        }

        static void DefiniowanieIUzywanieKlas()
        {
            /* Klasa Okrąg.
             * Klasy zawierają zmienne i metody (omowione w roz. 2 i 3). Zmienne w klasie nazywane są 'polami'.
             */

            // Więcej na temat słowa kluczowego 'new' oraz przydzielania pamięci w rozdziale 8.
            Okrag okrag = new Okrag(4.2f);
            Console.WriteLine(okrag.ObliczObwod());
        }

        static void KontrolowanieDostepnosci()
        {
            /* Klasa Okrąg.
             * Domyślnie pola i metody są prywatne. Prywatne elementy mają zakres klasy. (poza klasą są niewidoczne)
             * Warto pamiętać, że pola w klasach mają wartości domyślne 0, false lub null, zależnie od ich typu.
             * Dobrą praktyką jest jawnie inicjowanie tych pól. 
             * np. private float promien = 0f;
             *     public string Imie = null;
             */
        }

        static void KonwencjeNazewnicze()
        {
            /* Klasa Okrąg
             * Nazwy identyfikatorów publicznych powinny zaczynać się od Wielkiej litery. Konwencja Pascalowa (PascalCase)
             * Identyfikatory nie publiczne (nazwy pól i metod, zaliczają się do nich także zmienne lokalne)
             * powinny zaczynajać się od małej litery (camelCase).
             * Wszystkie przykłady w książce stosują się do tych regół.
             * Identyfikatory nie publiczne mogą również zaczynać się od podkęślnika '_'.
             * Istnieje jednak wyjątek, gdybyśmy chcieli zdefiniować prywatny konstruktor nazwa musi rozpoczynac Dużą literą. 
             */

            /* Uwaga! 
             * Nie należy deklarować 2 publicznych pól, których nazwa różni się tylko rozmiarem liter.
             * Taka sytuacja doprowadzi do tego, że ta klasa nie bedzie mogła być integrowana z rozwiązaniami tworzonymi
             * przy użyciu języków programowania, które nie rozróżniają wielkości liter np. Visual Basic
             */
        }

        static void Konstruktory()
        {
            /* Klasa Okrąg
             * Użycie słowa kluczowego 'new' powoduję utworzenie obiektu na podstawie szablonu klasy, aby to zrobić wymagane jest
             * zarezerwowanie pewnej ilości pamięci z zasobów komputera, wypełniania jej polami zdefiniowanymi przez klasę, a następnie
             * wywołanie konstruktora klasy, który wykona odpowiednie działanie inicjujące.
             */

            Okrag obiektOkrąg = new Okrag();

            /* Klasa Kwadrat
             * Istnieje możliwość zdefiniowania konstrukotra prywatnego, nie można z niego skorzystać poza klasą, co uniemożliwia
             * tworzenie obiektów tej klasy z poziomu metod nie bedących częścią tej klasy.
             */

            Kwadrat obiektK = new Kwadrat(11.9f);
            Kwadrat klon = obiektK.KlonujKwadrat();

            /* Metoda KlonujKwadrat() wywołuje w swoim ciele konstruktor prywatny.
             * Jeśli napiszemy własny konstruktor to kompilator nie wygeneruje już konstrukotora domyślnego.
             */
        }

        static void KlasyCzesciowe()
        {
            /* Aby zrobić klasy częściowe dodajemy slowo kluczowe 'partial'. 
             * Umożliwia to podzielenie kodu źródłowego takiej klasy na kilka osobnych plików. 
             * Kompilując klasę częściową musimy posiadać wszystkie te pliki źródłowe.
             */
        }

        static void KomentarzTODO()
        {
            //TODO: W zakładce Task Lists możemy znaleść wszystkie komentarze TODO, znajduje się ona poniżej okna edytora i tekstu.
            // Jeśli jest nie widoczna klikamy View -> Task List
        }

        static void SłowoKluczoweThis()
        {
            /* Słowo kluczowe 'this' odnosi się do instancji tego obektu.
             * Gdybyśmy nie użyli 'this' a parametry nazywałyby się tak samo jak pola, spowodowałoby to przesłonięcie pól klasy przez 
             * parametry metody. W rzeczywistości nie zainicjowalibyśmy pól w konstruktorze, tylko wartość parametru swoją własną wartością.
             * public Okrag(float r) { r = r; }   
             * Kompilator nie wie! że pierwszy 'r' to pole klasy, a drugi 'r' to parametr.
             * public Okrag(float r) { this.r = r; }   
             */

            /* Note: Stosowanie 'this' należy do dobrej praktyki programowania, nie ma konieczności zawsze go stosować np. gdy parametry 
             * nazywają się inaczej od pól klasy.
             */
        }

        static void MetodaInstancji()
        {
            /* Metody w klasie które operują na danych należącej do konkretnej instancji tej klasy nazywamy 'metodami instancji'.
             * Mogą one również przyjmować różne parametry i operować również na nich. np. metoda OdlegloscDo(Punkt punktB);
             * (Istnieją także inne rodzaje metod. Zostaną one omówione w dalszej części tego rozdziału).
             */

            Punkt punktA = new Punkt(14, 9);
            punktA.OdlegloscDo(new Punkt(18, 4));

            /* Uwaga! 
             * private int x = 0;
             * public OdlegloscDo(Punkt param){
             *    int roznica = this.x - param.x; 
             *    ...}
             * Prywatne pola mają zakres klasy. Oznacza to, że obiety tej samej klasy mają dostęp do swoich danych prywatnych. 
             * Instancje różnych klas takiego dostęou nie mają.
             */

            // Note: W metodzie instancji obiekty tych samych klas mają dostęp do swoich prywatnych danych (pola, metody, itp.)
        }

        static void DekonstrukcjaObiektu()
        {
            /* Klasa Punkt
             * Konstruktor inicjalizuje obiekt a Dekonstruktor służy do zbadania obiektu i wydobycia wartości wszystkich pól instancji.
             * Musi się nazywać 'Deconstruct' nie zwracać wartości 'void' i przyjmować przynajniej jeden outowy parametr. np.
             * public void Deconstruct(out int x, out int y){ x = this.x; y = this.y; }
             */

            Punkt p = new Punkt(1, 2);
            p.Deconstruct(out int a, out int b);
            (int x, int y) = p;

            /* Wywoływanie Doconstructora. 
             * Można także użyć ktorki. Kompilator automatycznie użyje metody Deconstruct zdefinowanej w klasie Point.
             * Nalezy pamietac żeby zainstalowac nuget System.ValueType. Więcej na temat krotki w roz. 3.
             */
        }

        static void MetodyPolaStatyczne()
        {
            /* Wszystkie obiekty tej klasy współdzielą jedną kopię tych elementów składowych.
             * Gdy jakaś metoda lub pole dotyczy klasy a nie bezpośrednio instancji to powinna być statyczna.
             * Taką metode nazywamy 'metodą użytkową lub klasy' oferuje ona pewną funkcjonalność, która nie zależy 
             * od żadnej konkretnej instacji klasy.
             */
            Math.Sqrt(12.3);

            /* Zdefiniowanie pola statycznego tworzy pojedyńczą instancje tego pola, która bedzie współnidzilona przez wszystki obiekty.
             * np. Samochod.LiczbaKol;
             */
        }

        static void PolaConst()
        {
            /* Słowo kluczowe const (ang. constant) oznacza stały.
             * Pola const również są polami static. Musi być zainicjowana podczas deklaracji,
             * polami const mogą być tylko pola o typie wartościowym.
             * np. public const int LiczbaKol = 4;
             */
        }

        static void KlasyStatyczne()
        {
            /* Klasa Mapa
             * Klasa statyczna służy wyłącznie jako kontener użytecznych metod i pól. Nie może zawierać żadnych metod i pól instancji.
             * Nie można utworzyć obiektu tej klasy. Klasa statyczna może zawierać tylko domyślny konstruktor statyczny.
             * Konstruktor statyczny jest wykonywany tylko raz przed pierwszym odwołaniem się do klasy w programie, a Klasa statyczna
             * pozostaje w pamięci przez cały okres życia aplikacji.
             */

            Mapa.DodajPunktNaMapie(new Punkt(10, 99));
            foreach(Punkt p in Mapa.PobierzPunkty())
            {
                Console.WriteLine(p);
            }
        }

        static void StatyczneInstrukcjeUsing()
        {
            /* Umożliwia korzystanie z elementów statycznych klas bez wpisywania nazwy klasy.
             * Statyczne isntrukcje using działają jak zwykłe. Dodają klasę do zasięgu.
             * using static System.Math;
             * Zalaca się nie stosować satycznych isntrukcje using.
             * Obniża czytelność kodu, utrudnia wyszukanie błędów.
             * Np. 'WriteLine("Wypisz na consoli");' 
             *     'Console.WriteLine("Wypisz na consoli");'
             */
        }

        static void KlasyAnonimowe()
        {
            /* Bywają przydatne w zapytanich do obiektu LINQ. 
             * Klasa anonimowa zawiera wyłącznie pola publiczne, nie może posiadać metod ani pól statycznych.
             * Typ pól jest określany na podstawie wartości, która zastała użyta do inicjiacji tego pola.
             * Do stwierdzenia czy dwie instancje klasy anonimowej są tego samego typu, kompilator bierze pod uwagę:
             * nazwy pola, typ oraz kolejność pól. 
             * Dla klasy anonimowej kompilator generuje wlasną nazwę.
             */

            var obiektAnonimowy = new { Imie = "Ela", Wiek = 111 };
            var innyObiektAnonimowy = new { Imie = "Mirek", Wiek = 88 };
            var kotel = new { Name = "Mija", Color = "Black" };

            if (obiektAnonimowy.GetType() == innyObiektAnonimowy.GetType())
            {
                Console.WriteLine(obiektAnonimowy.Imie);
                Console.WriteLine(innyObiektAnonimowy.Imie);
            }

            Console.WriteLine(kotel.GetType()); //np. <>f__AnonymousType1`2[System.String,System.String]
        }

    }

   
}
