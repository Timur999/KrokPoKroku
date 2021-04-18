using Chapter_15_Wlasciwosci.Model;
using System;

/* Właściwości (ang. properties) stosuje się je aby zachować 'złotą' zasadę hermetyzacji pól oraz aby zachować możliwość korzystania z nich jak za pomocą zwykłych pól publicznych.
 * W poprzednich rozdziałach tworzyliśmy prywatne pola i publiczne metody, które operowały na tych polach. Właściwości to skrzyżowanie pól i metody, dostęp do niej odbywa się jak do pola.
 * Natomiast kompilator zmienia to odwołanie na wywołanie metody 'akcesora' (nazwyany getterem lub setterem).
*/
namespace Chapter_15_Wlasciwosci
{
    class Program
    {
        static void Main(string[] args)
        {
            Właściwości();
            Właściwości_i_Nazwy_Pól();
            Właściwości_Tylko_Do_Odczytu_Zapisu();
            Dostępność_Właściwości();
            Ograniczenia_Właściwości();
            Prawidłowe_Korzystanie_z_Właściwości();
            Deklarowanie_Właściwości_Interfejsu();
            Generowanie_Automatycznych_Właściwości();
            Inicjiowanie_Obiektów_Przy_Użyciu_Właściwości();

            Console.ReadKey();
        }

        static void Właściwości()
        {
            /* Załóżmy, że chcemy zaimplementować klase 'Punkt', który bedzie przyjmował wartości tylko z jakiegoś określonego przedziału. Dla X max zakres to 1920 dla Y 1080. 
             * 'Punkt' to struktura i zawiera 2 właściwości.
             */

            Punkt punkt = new Punkt();
            punkt.X = 1209; // używamy akcesora 'set', wartość 1209 zostanie przekazana do ukrytego parametru 'value'. 
            punkt.Y = 150;

            int x = punkt.X; // używamy akcesora 'get'
            punkt.Y += 12; //  używamy akcesora 'get' i 'set'

            punkt.X = 99999; // zostanie zgłoszony wyjątek ArgumentException z metodzy akcesora 'set'.
        }

        static void Właściwości_i_Nazwy_Pól()
        {
            /* Pola publiczne nazywamy z dużych liter, prywatne z małych. 
             * Nazwa pola prywatnego które bedzie modyfikowane przez właściwość powinna rozpoczynać się od podkreślnika '_' aby wyraźnie zaznaczyć co jest co.
             * Jeśli przez przypadek np. aksesor 'get' odwoływałby się do 'Właściwości' zamiast do pola, doprowadziłoby to do nieskączonej rekurencji i wyjątku StackOverflowException.
             * np.
             * Źle
             * Class Employee
              {
                   private int employeID;
                   public int EmployeID { get { return this.EmployeID } } // Błąd
              }

             Dobrze
             Class Employee
              {
                   private int _employeID; 
                   public int EmployeID { get { return this._employeID } }
              }
             */
        }

        static void Właściwości_Tylko_Do_Odczytu_Zapisu()
        {
            /* Pomijamy poprostu ten akcesor. Nie można pominąć akcesora 'get' w przypadku gdy generujemy automatyczną właściwość. 
             * (Nie można utworzyć 'automatycznej właściwości' tylko do zapisu. Można utworzyć 'automatyczna właściwości' tylko do odczytu).
             * 
             * Można również stworzyć właściwość statyczną.
             */
        }

        static void Dostępność_Właściwości()
        {
            /* W deklaracji określamy dostępność właściwości i jego akcesorów (public, private, protected). Możemy nadpisac dostępność dla wybranego akcesora. 
             * Definiując akcesory o różnej dostępności musimy przestrzegać kilka zasad:
             * 1. Możemy zmienić tylko 1. (zdefiniowanie właściości publicznej aby potem zmienić 2 akcesory na private lub private i protected było by bezsensowne!)
             * 2. Modyfikator akcesora nie może rozszerzać dostępności samej właściwości. Np. jeśli właściwość jest prywatna to akcesor nie może być publiczny lub protected.
             * 
             *  public int EmployeID { get; set; } (get i set publiczny)
             *  protected int EmployeID { get; set; } (get i set protected)
             *  public int EmployeID { get; protected set; } (get publiczny, set protected)
             *  public int EmployeID { protected get; set; } (get protected, set publiczny)
             * 
             * źle
             *  public int EmployeID { protected get; private set; } 
             *  protected int EmployeID { public get; set; } 
             */
        }

        static void Ograniczenia_Właściwości()
        {
            /* 1. Nie można używać właściwości jako parametry 'ref' lub 'out'. Właściwość nie wskazuje na referencje do pola tylko do metody.
             * 2. Właściwość może zawierać tylko jeden akcesor 'get' i jeden 'set', nie może zawierać żadnych innych metod, poł ani właściwośći.
             * 3. Nie może mieć parametrów. Przypisywana wartość trafia do zmiennej 'value'.
             * 4. Nie można zrobić właściwości const.
             * 5. Nie można przypisać wartości do 'właściwości' przed zainicjiowaniem obiektu. (do pola możemy tak zrobić) np.
             */

            Punkt p;
            p.X = 10; // błąd na etapie kompilacji. Gdyby 'X' był polem to taka operacja byłaby prawidłowa.
        }
         
        static void Prawidłowe_Korzystanie_z_Właściwości()
        {
            /* Rozważmy przykład konta bankowego który przechowuje informacje o saldzie. Utworzenie właściwości która bedzie tylko zwracać wartość stanu konta i ustawiać nową kwote
             * może nie być najlepszym rozwiązaniem, ponieważ nie oferuje to funkcjionalności deponowania i wypłacania pieniędzy (takie operacje wiążą się z fizycznym transferem pieniedzy)
             * Podczas programowania musimy zwracać uwagę na problem do rozwiązania i nie pogubić się się w plątaninie składni niskiego poziomu.
             * Lepiej bedzie użyć metod Deponuj i Wypłać zamiast akcesorów 'get' i 'set'.
             */

            /*class KontoBankowe
            {
                 private decimal _saldo;
                 public decimal Saldo
                 {
                    get { return this._saldo; }
                    set { this._saldo = value; }
                 }
            }*/

            /*class KontoBankowe
            {
                 private decimal _saldo;
                 public decimal Saldo { get { return this._saldo; } }
                 public void Deponuj(decimal wartość) { ... }
                 public bool Wypłać(decimal wartość) { ... }
            }*/

        }

        static void Deklarowanie_Właściwości_Interfejsu()
        {
            /* Iterfejsy mogą definiować zarówno metody i właściwości, nie mogą posiadać ciała. Przykłady w klasie Figury. Klasy implementują właściwość interfejsu 'Kolor'. */

            Kwadrat kwadrat = new Kwadrat();
            kwadrat.Kolor = Kolor.Czerwony;
            
            Prosokat prosokat = new Prosokat();
            prosokat.Kolor = Kolor.Czerwony;

            Trójkat trójkat = new Trójkat();
            trójkat.Kolor = Kolor.Czerwony; // Możemy jawnie zaimplementowana właściwość ale jak wiadomo z rozdziału 13 bedzie ona dostępna tylko dla obiektu o typie interfejsu.

            if(trójkat is IKolor)
            {
                ((IKolor)trójkat).Kolor = Kolor.Niebieski;
            }
        }

        static void Generowanie_Automatycznych_Właściwości()
        {
            /* Składnia jest bardzo podobna do składni właściwości interfejsu z tą różnicą, że musimy określić modyfikator dostępności.
             * Czasami tworzenie właściwości która bedzie tylko do odczytu lub zapisu może wydawać się niepotrzebna i można to zaimplementować w inny sposób. 
             * Są jednak przynajmniej 2 powodu dla których lepiej zaimplementować właściwość zamiast pól publicznych:
             * 
             * 1. 'Kompatybilność aplikacji' - Pola i metody są eksponowane za pomocą metadanych w asemblach. Właściwości są przerabiane na wywołanie metody akcesora. Pomimo tego, że 
             * korzystanie z Pól i Właściwości z poziomu kodu się nie róźni to w plikach matadanych już tak. Jeśli tworząc klase która bedzie używać Pól publicznych to dowolna aplikacja która bedzie 
             * używać tej klasy bedzie mogła używać tych elemntów jako Pola. Po zamianie ich na Właściwości (aby dodać nową funkcjonalność) konieczne bedzie przekompilowanie tej aplikacji aby mogła
             * skorzystać z nowej wersji tej klasy. Co może być szczególnie niewygodne, gdy aplikacje są już wdrożone na wielu użądzeniach.
             * Istnieją sposoby ominięcia tego problemu ale z reguły lepiej jest unikać tego typu sytuacji za wczasu.
             * 
             * 2. 'Kompatybilność z interfejsami' - Jeśli interfejs posiada definicje właściwości to klasa implementująca interfejs musi zdefiniować własną właściwość. Nie można tylko zdefiniować
             * publicznego pola o takiej samej nazwie. W takim przypadku można wygenerować 'Automatyczną Właściwość'. 
             * Np. public int X { get; set; } (więcej na temat ograniczeń 'Automatycznej Właściwośći' w klasie 'Przyklad').
             */
        }

        static void Inicjiowanie_Obiektów_Przy_Użyciu_Właściwości()
        {
            /* Ta składnia wywołuje najpierw konstruktor domyślny a następnie akcesory set. */
            Kolo kolo = new Kolo { Promien = 10, X = 190, Y = 200 };
            kolo = new Kolo { Promien = 10, Y = 200 };
            kolo = new Kolo { X = 200 };

            /* Możemy użyć konstruktora innego niż domylny. Kolejność wykonywania inicjalizacji taka sama. */
            Kolo kolo2 = new Kolo(Kolor.Zielony) { Promien = 10, X = 190, Y = 200 };

            /* Ważne jest aby pamiętać, że najpierw wywoływany jest konstruktor a potem ustawiane są właściwości. */
        }
    }
}

