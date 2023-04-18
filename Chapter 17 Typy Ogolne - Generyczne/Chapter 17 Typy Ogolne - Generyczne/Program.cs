using Chapter_17_Typy_Ogolne___Generyczne.Model;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfaces;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne.Interfaces;
using Chapter_17_Typy_Ogolne___Generyczne.Queues;
using System;

namespace Chapter_17_Typy_Ogolne___Generyczne
{
    /* Wstęp: 
     * W tym rozdziale zostanie omówiony typ ogólny - generics,
     * który został zaprojektowany aby uniknąć potrzeby rzutowania i zapamiętania prawdziwego typu obiektu który znajduje się 'wewnatąrz' obiektu (object)
     * oraz aby zapobiec błędów wynikających z nieprawidłowym rzutowaniem
     * i dodatkowgo narzutu pamięci oraz czasu procesora.
     * 
     * Kiedy Stosować?
     * Gdy zachowanie obiektu, metody jest takie same ale działa na innych typach.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            ZaletyTypuOgólnego_i_WadyObject();
            CoToJestParametrTypu();
            JakDziałaKlasaOgólna_Generyczna();
            KlasaUogólniona();
            TypyOgolne_A_KlasyUogolnine();
            TypyOgolne_I_NakladanieOgraniczen();
            MetodyOgólne();
            Interfacy_i_StrukturyOgolne();
            InterfaceOgólny_i_NieZgodnosciTypów();
            InterfaceKowariantny();
            InterfaceKontrawariantny();
            PodsumowanieInterfejsów_I_Przykład();


            //Przykłady
            KolejkaFIFOTypuObject(); // Wady typu object w praktyce
            KolejkaFIFOTypuOgolnego_Generycznego(); //Zalety typu ogolnego w praktyce

            KlasyOgolne_PrzykladDrzewnoBinarne();
            MetodyOgolne_PrzykladDrzewnoBinarne();


            Console.ReadKey();
        }

        static void ZaletyTypuOgólnego_i_WadyObject()
        {
            /* W rozdziale 8 "Wartości i referencje" poznaliśmy sposób odwoływania się do Dowolnej klasy/biektu za pomocą typu Object. */

            /* Opis problemy zastasowania object zamiast typu ogólnego.
             * 
             * Za pomocą typu Object można zapisać wartość DOWOLNEJ klasy, przekazać do i zwrócić z metody dowolny typ obiektu.
             * void object Swap(object a, object b) 
             * 
             * Chociaż daje to dużą swobodę to może prowadzić do błędów podczas rzutowania na oczekiwany obiekt.
             * Wymaga od programisty pamiętania jakiego typu jest dany obiekt. (Kon, Okrąg)
             */

            /* Wady object:
             * 1. Kompilator nie wykonuje automatycznej konwersji typu podczas budowania programu (kompilacji) dlatego,
             * wymagane jest jawne RZUTOWANIE wartość na odpowiedni typ!.
             * 2. Inną wadą jest wysokie zużycie pamięci i czasu procesora w przypadku konwersji wartości z typu object (referencyjnej) do typu wartościowego.
             * W takim przypadku zachodzi proces pakowania typu wartościowego do referencyjnego i odwrotnie. Więcej o tym zagadnieniu w rozdziale 8.      
             */

            /* Zalety typów ogólnych:
             * 1. Zwalniają z potrzeby rzutowania,
             * 2. Zwiększają bezpieczeństwo posługiwania sie typami,
             * 3. Zmniejszają ilość wymaganego opakowywania (Chyba tylko podczas deklaracji pod warunkiem, ze naszym typem bedzie typ wartosciowy).
            */
        }

        static void CoToJestParametrTypu()
        {
            /* Klasy i metody generyczne wykorzystują Parametr Typu(<T>), określający typ obiektu/ów na których pracują. np. class Queue<T>
             *
             * Parametr Typ T pełni role typu zastępczego i podczas kompilacji zostanie on zastąpionia na prawdziwy typ.
             * Parametrem typu mogą być:
             *  typ prosty,
             *  wartościowy,
             *  lista / kolekcja,
             *  lub inna kolekcja z paramterem typu.
             *  
             * Queue<int> intQueue = new Queue<int>();
             * Queue<Queue<string>> queueOfStringQueue = new Queue<Queue<string>>();
             */
        }

        static void JakDziałaKlasaOgólna_Generyczna()
        {
            /* Klasę ogólną możemy traktować jak SZABLON który zostanie użyty przez kompilator do generowania klas zdefiniowanego typu.
             * (Kompilator podczas budowania programu (kompilaci) wygeneruje całkowicie nową klasę dla typu int i inną dla typu Kon.)
             * Wersje klasy ogólnej(generycznej) o ustalonym typie(Queue<int>, Queue<Kon>) są nazywane 'obiektami typów skonstruowanych'.
             * Należy je traktować jako OSOBNE typy.
             */
        }

        static void KlasaUogólniona()
        {
            /* Klasą Uogólnioną jest np. kolejka oparta na typie 'object'. QueueObject queue
             * Jest ona zaprojektowana z myślą o parametrach, które mogą być rzutowane na różne typy.
             * Kompilator podczas budowania programu (kompilaci) wygeneruje zawsze taką samą klasę.
             * Jest tylko JEDNA implmentacja tej klasy, a jej metody przyjmują parametr typu 'object' i zwracają wartości typu 'object'.
             * Można używać tej klasy z wartościami typu int, string, Kon ale za każdym razem tworzona jest instancja TEGO SAMEGO typu i trzeba rzutować dane.
             */
        }

        static void TypyOgolne_A_KlasyUogolnine()
        {
            /* Jak należy rozumieć generyczną metode, a metode która zwraca object. */

            /* Metoda Generyczna:
             * Nie polega to na zwykłej podmianie tektowej, zamiast tego kompilator dokonuje pełnego semantycznego zastąpienia, dzięki temu możemy podać dowolny
             * poprawy typ w miejsce Parametru Typu (<T>)
             * np.
             * QueueGeneric<int> intQueue = new QueueGeneric<int>(); 
             * metoda 'Enqueue' dla obiektu intQueue wygląda Enqueue(int item)
             * QueueGeneric<Kon> konQueue = new QueueGeneric<Kon>();
             * a dla konQueue wygląda Enqueue(Kon item)
            */

            /* Metoda działająca na typie object
             * Metoda zawsze bedzie wygladac tak samo nie zależnie od podanego typu obiektu podanego w parametrze.
             * Kon kon = new Kon("Łysek");
             * Kon kon2 = new Kon("Śiwek");
             * np. Swap(kon,kon2) 
             * Kompilator wygeneruje metode Swap(object ob, object ob2)
             */

        }

        static void TypyOgolne_I_NakladanieOgraniczen()
        {
            /* Ograniczenia nakładamy kiedy chcemy mieć pewność że podany typ posiada jakąś metode. 
             * np definując klasę PrintableCollection możemy dopilnować, aby wszystkie obiekty zapisane w tej klasie miały metodę Print().
             * Ograniczenie pozwala zawęzić dozwolone typu klasy ogólnej do klas/typów które implmentują konkretny zbiór interfejsów.
             * 
             * class PrintableCollection<T> where T : IPrintable, IScaleable
             * 
             * Podczas kompilacji klasy PrintableCollection<T>, kompilator upewni się czy podany typ zawiera implementacje IPrintable i IScaleable.
             * Jeśli podana klasa nie implementuje okreslony interfejs, kompilacja zakonczy się błędem.
             */

            PrintableCollection<Okrag> printableCollection = new PrintableCollection<Okrag>(); // Błąd kompilacji - Okrąg nie dziedziczy po IScaleable
        }

        static void MetodyOgólne()
        {
            /* Możemy okreslic typ parametrów oraz zwracanej wartości.
             * Można rówież nadać ograniczenia.
             * 
             * Tak samo jak klasy ogólne kompilator utworzy zupełnie inna metode dla Swap<int> i Swap<string>. 
             */

            int a = 1;
            int b = 2;
            int w = Swap<int>(ref a, ref b);

            T Swap<T>(ref T first, ref T second)
            {
                T temp = first;
                first = second;
                second = temp;

                return temp;
            }
        }

        static void Interfacy_i_StrukturyOgolne()
        {
            /* Można również tworzyc struktury ogólne (generyczna) oraz interfejsy ogólne
            * interface IRysuj<T> 
            * struct MyStruct<T>
            */
        }

        static void InterfaceOgólny_i_NieZgodnosciTypów()
        {
            /* Przedstawienie problemu na podstawie próby zapisania stringa do zmiennej typu object.
             * Zgodnie z zasadami dziedziczenia wszystkie Stringi dziedziczą po klasie Object, tak więc wszyszytkie stringi są obiektami
             * i przyspisanie stringa do object jest jak najbardziej poprawne.
             * string dupa = "dupaRomana";
             * object obj = dupa;
             * 
             * To przypisanie obiektu typu Interface<string> do obiektu typu Interface<object> jest nie możliwe.
             */

            Wrapper<string> stringWrapper = new Wrapper<string>();

            IWrapper<string> storedStringWrapper = stringWrapper; // Klasa implementuje interfejs jawnie zatem obiekt trzeba przypisać do typu IWrapper aby uzyc metody interfejsu.
            storedStringWrapper.SetData("Zawin stringa");         // Więcej o tym w rozdziale 13. Dopisac tę zasade do notatek

            IWrapper<object> storedObjectWrapper = stringWrapper; // bład podczas kompilacji "Nie można w sposób niejawny konwertować typu  Wrapper<string> do IWrapper<object>"

            IWrapper<object> storedObjectWrapper2 = (IWrapper<object>)stringWrapper; // skompiluje się ale podczas wykonywania programu wystąpi błąd 'InvalidCastException'.

            /* O interfejsie 'Inwariantnym', mówimy gdy nie dozwolone jest przypisanie obiektu typu IWrapper<B> do referencje typu IWrapper<A>,
             * nawet jeżeli typ B pochodzi od typu A lub istnieje poprawna konwersja typu B na typ A, np string na object.
             * C# standarowo implementuje takie ograniczenie aby zapewnić BEZPIECZEŃŚTWO typów! 
             */

            /* Gdyby nie było takiego zabezpieczenia to za pomocą metody SetData do zmiennej stringWrappera która jest typu string
             * (określona podczas deklaracji 'new Wrapper<string>()') można by bylo przypisac jakikolwiek obiekt np Koń. */
            storedObjectWrapper2.SetData(new Kon());
        }

        static void InterfaceKowariantny()
        {
            /* O interfejsie 'Kowariantnym', mówimy gdy dozwolone jest przypisanie obiektu typu IWrapper<B> do referencje typu IWrapper<A>,
             * pod warunkiem, że typ B pochodzi od typu A lub istnieje poprawna konwersja typu B na typ A, np string na object.
             */

            /*  Interface Kowariantny stosujemy pod jednym warunkiem:
             *  Gdy metoda bedzie tylko zczytywała wartość zmiennej i w żaden sposób nie bedzie jej modyfikowała.
             *  (np. metoda w klasie Wrapper<T> SetData(T data) nie nadaje się jako interfejs kowariatny, poniważ zapisuje dane do zmiennej)
             *  Interfejs IRetrieveWrapper<T> pozwala tylko zczytac dane z obiektu IRetrieveWrapper<T> za pomocą metody T GetData(),
             *  co nie prowadzi w żaden sposób do zmiany tych danych.
             *  
             *  Dodanie słowa kluczowe 'out' w delaracji interfejsu z 'Parametrem Typu' (T), np IRetrieveWrapper<out T>
             *  oznacza, że niejawne konwersje są bezpieczne i nie trzeba wymuszać ścisłego bezpieczeństwa typów.
             */

            SafeWrapper<string> safeStringWrapper = new SafeWrapper<string>();
            IStoreWrapper<string> storeWrapper = safeStringWrapper;
            storeWrapper.SetData("HELLO");

            SafeWrapper<Kon> safeKonWrapper = new SafeWrapper<Kon>();
            IStoreWrapper<Kon> storeKonWrapper = safeKonWrapper;
            storeKonWrapper.SetData(new Kon("Łysek"));

            /* IRetrieveWrapper<object> retrieveWrapper = safeStringWrapper; // bez out w parametrze typu, kompilator zgłosi wyjatek
             * 
             * IRetrieveWrapper<object> retrieveWrapper = (IRetrieveWrapper<object>)safeStringWrapper; // bez 'out' interpreter zgłosi wyjątek 'InvalidCastException' 
             */

            IRetrieveWrapper<object> retrieveWrapper = safeStringWrapper;
            Console.WriteLine(retrieveWrapper.GetData()); // HELLO

            retrieveWrapper = safeKonWrapper;
            Console.WriteLine(retrieveWrapper.GetData()); // Łysek. klasa Kon ma overidowana metode ToString()

            /* Kilka ograniczeń: 
             * 1. Działa tylko na wartościach referencyjnych. Typy wartościowe nie mogą tworzyć hierarchi dzedzienia.
             * 2. Kwalifikator 'out' z parametrem typu moze byc tylko stosowany, gdy metoda bedzie zwracac 'Parametr Typu',
             * dla metod z parametrem typu jako parametr metody zostanie zgłoszony wyjątek.
             * 3. Tylko interfejsy i delegaty mogą być deklarowane jako 'Kowariantne', klasy generalne nie mogą!
             */

            /* Kowariancja występuje w kilku interfejsach zdefiniowanych przez .NET Framework, np w IEnumerable<T> opisana w roz. 19 "Wyliczanie Kolekcji". */
        }

        static void InterfaceKontrawariantny()
        {
            /* Interfejs Kontrawariantnyjest podobny do kowariantnego tylko w odwrotnym kierunku,
             * umożliwia odwołanie się do obiektu za pośrednictwem interfejsu ogólnego opartego na typie tego obiektu lub na typie pochodnym od tego obiektu.
             * Jeżeli klasa bazowa A implementuje pewne metody, właściwości itp. to klasa pochodna B również musi je posiadać.
             * Dlatego podstawienie obiektu typu B zamiast A w pewnych warunkach jest bezpieczne:
             * 1. W Implementacji interfejsu na przekazywanym obiekcie nie może wykonywać żadnych metod których nie zawiera klasa bazowa,
             * 2. Należy dodac kwalifikator 'in' do Parametru typu.
             */

            object ob1 = new object();
            object ob2 = new object();
            string s1 = "dupa";
            string s2 = "dupa";
            ObjectComparer comparer = new ObjectComparer();

            IComparer<object> objectComparator = comparer;
            objectComparator.Compare(ob1, ob2);

            IComparer<string> stringComparator = comparer;
            stringComparator.Compare(s1, s2);


            /* Intercejs IComparer<in T> z przestrzeni nazw System.Collections.Generic w .NET Framework to przykład ineterfejsu kontrawariantnego. 
             * public interface IComparer<in T>
             * {
             *      int Compare(T x, T y);
             * }
             */
        }

        static void PodsumowanieInterfejsów_I_Przykład()
        {
            Malpa malpa = new Malpa("Julian");
            Malpa malpa2 = new Malpa("Julian2");
            AnimalComaparer comaparer = new AnimalComaparer();
            comaparer.Compare(malpa, malpa2);

            Czlowiek czlowiek = new Czlowiek("Człowień");
            Czlowiek czlowiek2 = new Czlowiek("Człowień2");
            comaparer.Compare(czlowiek, czlowiek2);

            comaparer.Compare(malpa, czlowiek2);

            /* Przykład Interfejsu Kowariantnego - jesli metody w interfejsie ogólnym mogą zwracać stringa to mogą tez zwracac obiekty. */
            /* Przykład Interfejsu Kontrawariantnego - jesli metody w interfejsie ogólnym mogą przyjmować jako parametr obiektu to przyjmowac rowniez stringa. */
            /* Poniewaz wszystkie stringi są obiektami */
        }


        static void KolejkaFIFOTypuObject()
        {
            QueueObject queue = new QueueObject();
            queue.Enqueue(new Kon()); // Dodajemy Konia
            Okrag mojOkrag = (Okrag)queue.Dequeue(); // Rzutujemy na Okrag. BŁĄD podczas wykonywania (System.InvalidCastException)
            // UWAGA: Błąd jest dlatego, że kompilator nie wykonuje konwersji typów podczas budowania programu.

            QueueObject queue2 = new QueueObject();
            queue.Enqueue(1); // Pakowanie (int do object) - wymaga dynamicznej alokacji pamięci na stercie.  
            int mojInt = (int)queue2.Dequeue(); // rozpakowywanie (object do int) - zajmowany czas procesora.
        }

        static void KolejkaFIFOTypuOgolnego_Generycznego()
        {
            QueueGeneric<int> intQueue = new QueueGeneric<int>();
            intQueue.Enqueue(1);
            //...

            int number = intQueue.Dequeue(); // NIE RZUTUJEMY
                                             //           Kon kon = intQueue.Dequeue(); // Cannot implicitly convert type 'int' to 'Chapter_17_Typy_Ogolne___Generyczne.Model.Kon'
                                             // Kompilator posiada juz wystarczającą ilość informacji aby wykonać kontrole typów podczas kompilacji i zgłosi błąd niezgodności typu.

            QueueGeneric<Kon> konQueue = new QueueGeneric<Kon>();
            konQueue.Enqueue(new Kon());

            /* Parametrem typu NIE musi być typem prostym lub wartościowym.
             * Można np utworzyc kolejke kolejek liczb całkowitych (Jeżeli jest taka potrzeba)
             * Queue<Queue<int>> queueQueue = new Queue<Queue<int>>();
             * 
             * Klasa ogólna(generyczna) może mieć wiele parametrów typów.Przykład klasa Dictionary, która oczekuje typu dla klucza i typu dla wartości.
             * Dictionary bardziej szegółowo w roz. 18.
             * 
             * Przestrzeń nazw System.Collections.Generic w bibliotece.Net udostępnia imlementacje klasy Queue dziłającą podobnie do opisanej przed chwilą.
             * W tej samej przestrzeni jest też kilka innych klas kolekcji, opisanych bardziej szczegółowo w rozdzile 18. "Kolekcje".
             */
        }


        static void KlasyOgolne_PrzykladDrzewnoBinarne()
        {
            // Implementacja klasy znajduje się w projekcie Drzewo Binarne a przykład uzycia w Drzewo Binarne Test
        }

        static void MetodyOgolne_PrzykladDrzewnoBinarne() { }
    }
}
