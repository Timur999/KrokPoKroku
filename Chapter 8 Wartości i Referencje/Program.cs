using System;
using valuesAndReferences.Model;

namespace valuesAndReferences
{
    /* Typy wartościowe mają stały rozmiar.
     * Gdy deklarujemy zmienną typu wartościowego to kopilator generuje kod, który rezerwuje na stosie odpowiedni rozmiar pamięci aby pomieścic wartość danego typu.
     * np. int zajmuje 4 bajty (32bity) więc kompilator alokuje 4 bajty pamięci. (Cały ten proces ma miejsce na etapie Kompilacji)
     * Typy referencyjne
     * Gdy deklarujemy zmienna typu referencyjnego to kopilator rezerwuje na 'stosie' (ang. stack) niewielką ilość pamięci aby móc pomieścić adres do obiektu (inaczej mówiąc referencje, odwołanie do)
     * (Adres określa właściwe położenia obiektu w pamięci)
     * Faktyczny przydział pamięci nastąpi na stercie (ang. heap) dopiero podczas tworzenia obiektu za pomocą słowa kluczowego 'new', a następnie zostanie przypisana referencja od zmiennej na stosie. (Inicjalizacja)
     * Stos - System przydziela każdej aplikacji własny stos.
     * Podczas wykonywania metody pamieć potrzebna do przechowywania parametrów funkcji oraz lokalnych zmiennych funkcji jest rezerwowana na stosie.
     * Po zakończeniu metody lub przy zgłoszeniu wyjątku ta pamięć jest zwalniana.
    */

    class Program
    {
        static void Main(string[] args)
        {

            KopiowanieInicjalizowanieZmiennych();   // Kopiowanie/Inicjalizowanie zmiennych referencyjnych oraz wartościowych. 
            PrzekazywanieZmiennychhDoFunkcji();     // Do funkcji trawia wartość ze stosu. 
            GarbageCollection();
            OperatorWarunkowyNull();
            ZmienneNullowalne();
            ParametryRefOut();                      // Funkcja nie tworzy kopii zmiennych tylko pracuje na oryginale. 
            ZarzadzaniePamieciaKomputera();
            KorzystanieZeStosuIsterty();
            KlasaSystemObject();                    // Zmienna referencyjna typu object może przechowywać referencje do wszystkich typów ref. 
            BoxingOpakowywanie();                   // Przekopiowanie wartości ze zmiennej wartościowej do zmiennej referencyjnej.
            UnBoxingRozpakowywanie();
            Rzutowanie();
            BezpieczneRzutowanieDanych();           // Operatory 'is' oraz 'as'
            InstrukcjaSwitch();
            WskaznikiOrazKodNiezabezpieczony();


            Console.ReadKey();
        }

        static void KopiowanieInicjalizowanieZmiennych()
        {
            /* Kopiowanie/Inicjalizowanie zmiennych referencyjnych oraz wartościowych. */

            int a; // Rezerwowana jest pamięć na stosie aby pomieścić wartość typu int (4 bajty).
            Okrag o; // Rezerwowana jest pamięć na stosie aby pomieścić referencje do obiektu.

            a = 13; // Instrukcja przypisania powoduje skopiowanie tej wartości do zaalokowanego wcześniej bloku pamięci.
            o = new Okrag(); // Tworzy obiekt na stercie i przypisuje referencje na stosie do zmiennej o.
        }

        static void PrzekazywanieZmiennychhDoFunkcji()
        {
            Olowek olowek = new Olowek();
            // Do zmiennej PrzekazReferencje trafia referencja do okiektu ołówek, a nie cały obiekt. Następnie funkcja stworzy kopie obiektu na podstawie przekazanego argumentu. (wiecej niżej w ParametryRefOut())
            Szuflada.PrzekazReferencje(olowek);

            // Note: Do funkcji zawsze trawia wartość ze stosu.
        }

        static void GarbageCollection()
        {
            //Garbage collection 
            Olowek olowek = new Olowek();
            Olowek grubyOlowek = new Olowek();  // Kompilator rezerwuje pamiec i przekzuje referencje do zmiennej
            grubyOlowek = olowek; // Nadpisujemy referencje, do poprzedniego miejsca w pamięci, żadna zmienna już się nie odwołuje więc Garbage collection odzyskuje zaalokowaną pamięc.
                                  // Ten proces jest kosztowny czasowo-sprzętowo.


            // Dobrą praktyką jest aby przypisywać/kopiować referencje do zmiennej gdy nie zawiera jeszcze żadnej referencji. 
            Olowek cienkiOlowek = null; // null jest to referencja, która nie wskazuje na żaden konkretny obiekt.
            if (cienkiOlowek == null)
            {
                cienkiOlowek = olowek;
            }
        }
        static void OperatorWarunkowyNull()
        {
            /* Operatory warunkowe wartości null '?'. 
             * Umożliwia sprawdzenie czy wartość zmiennej == null przed użyciem metody instancji. Gdy obiekt jest nullem to metoda nie zostanie wykonana.
             * Nie zostanie również zgłoszony wyjątek 'NullReferenceException'. Poprostu bedzie nullem. (bool true = p?.ToString() == null;)
            */
            Szuflada szuflada = null;
            szuflada?.PokazCoMaszWSrodku();
            Console.WriteLine($"p value is: {szuflada.ToString()}");  // Wyswietli się "p value is:" |  Console.WriteLine($"p value is: {null}");
            string wartoscTekstowa = szuflada?.ToString(); // Nie zostanie zgłoszony wyjątek. Do zmiennej wartoscTekstowa przypisze nulla         
        }

        static void ZmienneNullowalne()
        {
            /* Typy danych dopuszczające zapis wartości null.
             * Wartość null jest przydatna ponieważ pozwala inicjiować zmienne referencyjne wartością domyślną, ale wartość null sama jest referencją i dlatego nie można jej
             * przypisać do zmiennej wartościowej. C# umożliwia jednak przypisanie null do zmiennej nullowalnej. Zmienna nullowalna (ang. nullalbe value type) najprościej mówiąc
             * jest to zmienna która była typu wartościowego i umożliwia przypisanie do niej wartości null. 
             * np. int ? nullowalna;
             * Zmienne Nullowalne są typu referencyjnego posiadają 2 właściwości: 
             * bool b = nullowalna.HasValue; - Sprawdza czy zmienna 'nullowalna' posiada wartość różną od null.
             * int v = nullowalna.Value; - Zwraca wartość typu prostego jeśli istnieje.
            */

            int? i = null;
            int j = 99;
            i = 100;
            i = j;

            /* Nie można jednak przypisać wartość zmiennej nullowalnej do zmiennej typu wartościowego.
             * j = i; instrukcja nieprawidłowa.
             * Oznacza to, że nie można przekazywać zmiennej nullowalnej jako parametr fukncji która przyjmuje zwykły typ wartościowy.
             * Nie można zrobić zmiennej nullowalenj ze zmiennej referencyjnej. Zmienne referencyjne nie posiadają także tych 2 własciwości, które zawierają zmienne nullowalne.
             * Szuflada? objSzuflada = null; instrukcja nieprawidłowa.
             */ 
        }

        static void ParametryRefOut()
        {
            /* Normalnie metoda tworzy kopie przekazanych argumentów bez różnicy czy argumentami są zmienne typu wartościowego czy referencyjnego. 
             * Z modyfikatorami 'out' 'ref' parametry funkcji stają się aliasem/przedłużeniem jej argumentu. (Metoda nie tworzy kopii zmiennych tylko pracuje na oryginale)
             */

            /* Modyfikator 'ref' 
             */
            Olowek olowek = new Olowek(10);
            int liczba = 4;
            ZmianaWartosci(olowek, liczba); // zmienna która została przekazana do metody nazywamy argumentem.
            Console.WriteLine($"{olowek.Grubosc}, {liczba}"); // 14, 4
            ZmianaWartosci(ref olowek, ref liczba);
            Console.WriteLine($"{olowek.Grubosc}, {liczba}"); // 1, 9

            /* Modyfikator 'out' 
             * Umożliwia przekazywanie zmiennych (wartosciowych i referencycjnych) do funkcji przed ich zainicjowaniem. W takiej funkcji musimy przypisać wartość do tego argumentu.
             */
            int arg;
            DoIncrement(out arg);
        }

        static void ZmianaWartosci(Olowek olowek, int liczba)
        {
            // Do funkcji trafia wartość ze stosu, następnie funkcja tworzy zmienną tego samgo typu i o tej samej wartości (kopie).
            olowek.Grubosc = 14;
            liczba = 9;

            //Note: W tym przypadku metoda utworzy 2 kopie.
        }

        static void ZmianaWartosci(ref Olowek olowek, ref int liczba) 
        {
            // Funkcja nie tworzy kopii.

            olowek.Grubosc = 99;

            // Zmieniamy wartość na stosie.
            olowek = new Olowek(1);
            liczba = 9;

            //Note: Funkcja nie tworzy kopii zmiennych tylko pracuje na oryginale.
        }

        static void DoIncrement(out int param)
        {
            // param++; Błąd kompilacji.
            // 'param' jest aliasem i nie posiada wartośći. Przed wykonaniem incrementacji, należy ją zainicjować.

            param = 0;
            param++;
        }

        static void ZarzadzaniePamieciaKomputera()
        {
            /* W pamięci komputera są przechowywane uruchomione aplikacje oraz ich dane z któch korzystają (zmienne).
             * Pamięć jest podzielona na 2 części: Stos (ang. stock) i Sterta (ang. heap).
             * Na stosie zapisujemy zmienne wartościowe oraz referencje do zmiennych referencyjnych.
             * Na stercie przechowywane są zmienne referencyjne.
             */

            /* Podczas wywoływania meody, parametry oraz zmienne lokalne tej metody (wart. oraz ref.) są zawsze zapisywane na stosie. Po zakonczeniu metody (z powodu poprawnego zwrotu lub w wyniku wystąpienia wyjątku) 
             * pamięć przydzielona na stosie dla zmiennych wartościowych jest zwalniana i bedzie mogła zostać użyta odrazu.
             * Cykl życia zmiennych konczy się pod koniec metody a zaczyna na początku. Taki sam cykl życia dotyczy wszystkich zmiennych zdefiniowanych w nawiasach klamrowych {}.
             */
            int a = 9;
            while(a == 10){
                int i = 0; // w tym miejscu zmienna i zostanie utworzona na stosie.
            }
            /* W tym miejscu zmienna 'i' zostanie usunięta ze stosie. */

           /* Zmiennych referencyjne, do utworzenia instancji używanmy słowa kluczowego new, pamięć potrzebna do przechowywania odpowiednie dużego obiektu jest rezerwowana na stercie.
            * Następnie uruchomi się konstruktor, który wypełni surowy blok pamięci wartościami.
            * Pamięć zwalniana jest, gdy w programie zniknie ostatnie odwołania (referencja) do tego bloku pamięci (obiektu). (Choć nie koniecznie może to nastąpić od razu.)
            * Sposób odzyskiwania pamięci ze sterty jest omówiony w rozdziale 14.
            * Obiekty, które 'żyją' na stercie mają bardziej nieokreślony czas życia.
            */

            /* Wszystkie zmienne wart. są przechowywane na stosie, wszystkie zmienne ref. są przechowywane na stercie a ich referencje zapisujemy na stosie. Zmienne nullowalne są typu referencynego. */

            /* Stos jest uporządkowana jak stos pudełek. Gdy wywołujemy metode dokładmay pudełka na szczyt, a pod koniec metody zdejmujemy pudełka.
             * Sterta przypomina rozrzucone pudełka po całym pokoju. Kazde pudełko ma swoją etykietę, która informuje czy pudełko jest zajęte/używane. 
             * Podczas twoarzenia obiektu środowisko uruchomieniowe zapisuje obiekt do odpowiedniego pudełka. Odwołanie do obiektu (referencja) zostanie zapisana na stosie.
             * Gdy zniknie ostatnie odwołanie do obiektu, to srodowisko uruchomieniowe oznaczy te pudełko jako wolne po pewnym czasie bedzie można zapisać nowy obiekt.
             */

            /* Note: gdy zmienna ref. posiada zmienne wart. to po utworzeniu takiego obiektu zmienne te nie są zapisywane na stosie tylko jest to część obiektu i jest zapisana na stercie. */
        }

        static void KorzystanieZeStosuIsterty()
        {
            Metoda(42);
            void Metoda(int parameter)
            {
                /* Rezerwujemy pamięć na stosie, aby pomieścić zmienną typu int. (parametr metody)*/

                /* Rezerwujemu pamięć na stosice, aby pomieścić referencje. */
                Okrag o;

                /* Rezerwujemy pamięć na stercie, aby pomieścić obiekt klasy Okrąg. Wywoływany jest konstruktor, który przekształca surowy blok pamięci w obiekt klasy Okrąg. Zapisujemy ref na stos. */
                o = new Okrag(parameter);

               /* Po zakończeniu metody, zmienne o oraz parametr wychodzą poza zakres i pamięć przydzielona do nich zostanie zwrócona na stos. Środowisko uruchomieniowe odnotuje fakt, że żadna zmienna nie wskazuje 
                * na blok pamięci przechowujący obiekt o i po pewnym czasie pamięć zostanie zwrócona na stertę. (więcej w rozdziale 14)
                */
            }

            /* Note: Ilość dostępnej pamięci na stercie jest ograniczona. Gdy dojdzie do wyczerpania zostanie zgłoszony wyjątek OutOfMemoryException. */
        }

        static void KlasaSystemObject()
        {
            // Zmienna typu 'object' moze przechowywać referencje do dowolnego obiektu.

            object obiekt;
            Olowek olowek = new Olowek();
            obiekt = olowek;

            Okrag okrag = new Okrag();
            obiekt = okrag;

            //Note: Rekomedowanie jest uzywanie aliasu 'object' zamiast System.Object tak samo jak 'string' zamiast System.String
        }

        static void BoxingOpakowywanie()
        {
            /* Chodzi o przekazywanie wartości zmiennej wartościowej do zmiennej referencyjnej. 
             * Zmienne ref mogą przechowywać wyłącznie odwołania do obiektów na stercie. Dlatego w poniższym przykładzie zostanie utworzony obiekt klasy object i zostanie przekazana wartość ze zmiennej value.
             * Takie automatycznie kopiowanie wartości ze stosu na sterte nosi nazwę: Opakowywanie ang. Boxing
             */

            int value = 13;
            object ob = value;

            /*Modyfikacja zmiennej wartościowej nie zmieni wartości na stercie. Są to 2 różne wartośći */
            value++; //14
            ob.ToString(); //13

            //Note: Tworzenie zmiennej referencyjnej na podstawie zmiennej wartościowej. Taka operacja nazywa sie opakowywaniem (ang. Boxing)            
        }
        static void UnBoxingRozpakowywanie()
        {
            /* Pobieranie wartości z opakowanej zmiennej wartościowej wymaga użycia rzutowania (ang. cast). 
             * Operacja rzutowania przeprowadza konwersje elementu jednego typu na element drugiego typu, ale wcześniej sprawdza, czy taka konwersja może zostać przeprowadzona w sposób bezpieczny.
             * W nawiasch okrągłych przed zmienną referencyjną należy podać typ wartościowy do którego chcemy rzutować.
             * Kompilator generuje kod, który podczas wykonywania programu sprawdza zgodność typów pomiędzy typem zdefinowanym w () a rzeczywistym typem przechowywanym w obiekcie (na stercie).
             * Jeśli typy się zgadzają to mamy do czynienia ze zgodnośćią typów danych i operacja zakonczy się sukseem.
             * Natomiast jeśli mamy do czynienia z z niezgodnością typów danych to operacja zgłosi wyjątek InvalidCastException
             */


            /* Zgodność typów danych */
            int i = 100;
            object ob = i; // opakowywanie
            i = (int)ob; // rozpakowywanie


            /* Niezgodność typów danych */
            /* Zostanie skompilowany bez błedu ale w czasie wykonywania zostanie zgloszony wyjątek InvalidCastException */
            float f = 100.0f;
            ob = f; // opakowywanie
            i = (int)ob; // rozpakowywanie. Wyjątek InvalidCastException


            /* Note: Operacje Pakowania i Rozpakowania ze względu na alokowanie dodatkowej pamięci na stercie i dodatkowe instrukcje sprawdzające poprawność typu są bardzo kosztowne sprzętowo.
             * Opakowywanie ma swoje zastosowanie ale nierozważne jego stosowanie może wpłynąć negatywnie na wydajność. W rozdziale 18 "Klasy ogólne", poznamy alternatywę dla opakowywania.  
             */
        }

        static void Rzutowanie()
        {
            /* Rzutowanie zmiennych o większej precyzji do zmiennych o mniejszej precyzji musi odbywać się w sposób jawny. */

            int i = 100;
            long l = i; // rzutowanie niejawne 

            i = (int)l; // rzutowanie jawne 
        }

        static void BezpieczneRzutowanieDanych()  //Save casting - operator 'is' i 'as'. 
        {
            /* Kompilator nie sprawdza czy typy zmiennych są ze sobą zgodne lecz srodowisko uruchomieniowe (.Net).
             * W przypadku gdy zostanie zgłoszony wyjątek 'InvalidCastException' należy taki wyjątek przechwycic i obsłużyć,
             * język C# oferuje dwa przydatne operatory 'is' oraz 'as' do wykonywania operacji rzutowania.
             */


            /* Operator 'is'
             * Sprawdza czy typ jest zgodny z oczekiwanym.
             * Operator 'is' posiada 2 argumenty: z lewej strony referencje do obiektu, z prawej strony typ danych.
             * Jeśli typ danych który jest wskazywany przez referencje jest zgodny z typem przekazanym w argumecie po prawej stonie, operator 'is' zwróci true.
             */
            Okrag okrag = new Okrag();
            object ob = okrag;

            if(ob is Okrag)
            {
                Okrag okrag1 = (Okrag)ob;       // bezpieczna operacja rzutowania (SAVE CASTING)
                Console.WriteLine(ob is Okrag); // wynik true;
            }


            /* Operator 'as'
             * Pełni taką samą role co operacja SAVE CASTING. Równiez posiada 2 arg. po lewej referencje do obiektu na stercie po prawej typ danych.
             * Środowisko uruchomieniowe w czasie wykonywania programu podejmie próbę rzutowania, gdy sie powiedzie zwróci wartość w przciwnym razie NULL`a.
             */
            Okrag okrag2 = ob as Okrag;

            if (okrag2 != null)
            {
                // Operacja rzutowania zakonczyła sie sukcesem
            }

            /* Note: Więcej na temast 'is' oraz 'as' w rozdziale 12 (Dziedziczenie). */
        }

        static void InstrukcjaSwitch()
        {
            Okrag c = new Okrag(11);
            Kwadrat s = new Kwadrat(14);
            Trojkat t = new Trojkat(17);

            object o = t;
            if(o is Kwadrat mojKwadrat) // Zasieg zmiennej 'mojKwadrat' nie wykracza poza ifa ani case.
            {
                Console.WriteLine(mojKwadrat.DlugoscBoku);
            }else if(o is Okrag mojOkrag) 
            {
                Console.WriteLine(mojOkrag.Promien);
            }

            switch (o) // Selectory 'case' sprawdzają typ danych obiektu o. Działanie takie same jak za pomocą powyższej instruckji if.
            {
                case Okrag circle:
                    Console.WriteLine("o is circle {0}", circle.ToString());
                    break;
                case Kwadrat square:
                    Console.WriteLine("o is square {0}", square.ToString());
                    break;
                case Trojkat triangle when triangle.DlugoscBoku > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.DlugoscBoku);
                    break;
                case Trojkat triangle:
                    Console.WriteLine("o is triangle");
                    break;
            }

            switch (o) // Selectory 'case' obsługują również wyrażenie 'when'
            {
                case Trojkat triangle when triangle.DlugoscBoku > 1000:
                    Console.WriteLine("Big triangle {0}", triangle.DlugoscBoku);
                    break;
                case Trojkat triangle when triangle.DlugoscBoku > 10:
                    Console.WriteLine("Small triangle {0}", triangle.DlugoscBoku);
                    break;
            }
        }

        static unsafe void WskaznikiOrazKodNiezabezpieczony()
        {
            /* Wskaźniki (ang. pointer) to zmienna która przechowuje referencje do pewnego elementu w pamięci znajdującego się na stercie lub na stosie (do zmiennych referencyjnych lub wartościowych)
             * Aby zadeklarowac wskanik potrzebna jest specjalna konstrukcja. 
             */

            int i = 10;
            int *w;
            w = &i;

            /* Modyfikowanie wartości 'i' */
            *w = 99;
            Console.WriteLine(i); // wynik 99


            /* Niektóre systemy operacyjne (choć nie Windows) nie stosują obowiązkowej kontroli, czy dany wskaźnik nie wskazuje obszaru pamięci nalężącej do innego procesu,
             * co stwarza potencjalną możliwość podejrzenia poufnych danych. 
             * W języku C# stworzono zmienne referencyjne zmyślą aby właśnie uniknąć tego rodzaju zagrożenia. 
             * Jeżeli nadal chcemy korzystać ze wskaźników należy użyć słowa kluczowego 'unsafe'. (oznacza: kod jest potencjalnie niebezpieczny)
             */

            /* Słowo kluczowe 'unsafe'
             * Słowem kluczowym 'unsafe' można oznaczyć część kodu lub całą metode.
             */
            int x = 9, y = 10;
            Console.WriteLine($"x: {x}, y: {y}");
            unsafe
            {
                Zaamien(&x, &y); // takie same działanie gdyby argumenty były oznaczone słowem kluczowym ref
                Zaamien(ref x, ref y);
            }
            Console.WriteLine($"x: {x}, y: {y}");

            /* Note: Kompilacja programu z kodem potencjalnie niebezpiecznym oznaczony słowem kluczowym 'usafe' wymaga aby operacja budowania programu wykonana była z włączoną opcją "Allow Unsafe Code".
             * W Solution Explorer klikamy prawym na projekt i wybieramy propierties, w zakładce Build zaznaczmy dany checkbox.
             */
        }
        private static unsafe void Zaamien(int* a, int* b)
        {
            int temp = *a;
            *a = *b;
            *b = temp;
        }

        private static void Zaamien(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
