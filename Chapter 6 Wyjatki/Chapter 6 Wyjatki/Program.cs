using System;
using System.IO;
using System.Text;

/* Każda aplikacja musi być przygotowana na obsługę wyjątków korygujac działanie aplikacji lub jeśli to nie możliwe,
 * informując użytkownika o przyczynie problemu w czytelny sposób.
 */

/* try - catch (ang. pułapka) Jeśli jakaś instrukcaja w bloku try spowoduje błąd, środowisko uruchomieniowe runtime wygeneruje 
 * i złgłosi wyjątek. Następnie sprawdzi bloki obsługi wyjątków i sterowanie zostanie przekazane do pierwszego! pasującego bloku.
 * Wyjątki dziedzicza po klasie bazowej 'Exception' przez to posiadają wiele wspólnych właściwosci i metod, np. Message.
 * Nie powinniśmy jednak ograniczac się do stosowania tylko jednej pułapki typu Exception. Im bardziej precyzyjnie będą obsłuzone
 * wyjątki tym łatwiejsze bedzie utrzymanie kodu i lokalizowanie powstałych i powtarzających się błędów.
 */

/* Uwaga - Bardzo ważna wskazówka!!
 * Klasa Exception posiada własciwość InnerException (Wyjątek wewnętrzny) gdy wartość jest null oznacza, że najprawdopodobniej
 * jesteśmy u źródła problemu i po jego naprawie wszystko powinno działać jak w zegarku.
 */

/* Wskazowka. Natychmiastowe przechwytywanie wyjątków.
 * Podczas uruchomienia programu w trypie debug możemy przechwycic wyjątek bez koniecznosci ustawiania breakPointa.
 * Aby to zrobic należy zaznaczyc w opcjach Exception Settings które wyjątki chcemy przechwycić i przedebagować.
 * Debug -> Windows -> Exception Settings -> Common Language Runtime Exceptions  
 */

namespace Chapter_6_Wyjatki
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int liczba = PodajLiczbe();
                OperacjeNaLiczbie(liczba);
                BlokFinally();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }

        static int PodajLiczbe()
        {
            string userInput;
            while (true)
            {
                userInput = Console.ReadLine();
                try
                {
                    return int.Parse(userInput);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Nieprawidlowy format. Spróbuj ponownie. {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nieoczekiwany wyjatek. Spróbuj ponownie {ex.Message}");
                }
            }
        }

        static void OperacjeNaLiczbie(int liczba)
        {
            /* Nie Obsłużony Wyjatek. 
             * Gdy środowisko wykonawcze runtime złgosi wyjątek i nie znajdzie odpowiedniego bloku obsługi błędu lub blok instrukcji 
             * try catch w ogole nie bedzie to sterowanie programu zostanie przekazane do metody która wywołała daną metodę.
             * Należy podkreślić, że wykonywanie programu zostanie wznowione w metodzie która wyjątek obsłuzyła. Jeżeli zgłoszony wyjątek nie
             * zostanie obsłużony przez żaden blok obsługi wyjątków catch to działanie program zostanie przerwane z błędem sygnalizującym
             * nieobsłużony wyjątek (ang. unhandled exception)
             */
            try
            {
                DzieleniePrzezZero(liczba);
                Przepelnij(liczba);
                FiltrWyjatkow(liczba);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"Wyjatek podczas operacji arytmetycznej. Spróbuj ponownie {ex.Message}");
                DzieleniePrzezZero(liczba);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany wyjatek. Spróbuj ponownie {ex.Message}");
            }
        }

        static double DzieleniePrzezZero(int liczba)
        {
            int zero = 0;
            return liczba / zero;
        }

        static int Przepelnij(int liczba)
        {
            //Note: aby nastąpiło przepełnienie musi zostać użyty blok instrukcji 'checked'.
            checked
            {
                try
                {
                    int max = int.MaxValue;
                    int wiecejOdMax = int.MaxValue + max + liczba;
                    return wiecejOdMax;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Przepełnienie zmiennej. Spróbuj ponownie. {ex.Message}");
                }
            }

            /* Kompilator C# dopuszca przepełnienie, uzasadnieniem takiego stanu rzeczy jest wydajność.
             * Operacje arytmetyczne w programach są bardzo częstą praktyką dlatego narzucająć dodatkowej logiki sprawdzającej
             * czy nie doszło do przepełnienia spowodowałoby to obniżeniem wydajności programu.
             * W wielu przypadkach ryzyko z brakiem takiej kontroli jest akceptowalne ponieważ programista powinien wiedzieć!
             * , że zbliża się do maksymalnej wartości typu. 
             */

            // Przykład przepełnienia bez kontroli:
            byte b = 255;
            b += 1;
            Console.WriteLine($"Powinno być {b + 1} a jest {b}"); // Powinno być 256 a jest 0 

            /* Włączenie/Wyłączenie kontroli przepenienia
             * Mozna to zrobic selektywnie dodajac blok kodu 'checked' lub 'unchecked'
             * lub w ustawieniach programu. Klikamy prawym na nazwe projektu -> properties -> Build -> Advanced -> 
             * Check for arithmetic overflow
             */

            int nieZglosiWyjatek = unchecked(int.MaxValue + 1);
            int zglosiWyjatek = checked(int.MaxValue + 1);

            /* Slowa kluczowe 'checked' 'unchecked' mają zastosowanie wyłącznie dla zmiennych całkowitych!
             * Zmienne zmiennoprzecinkowe nigdy nie zgłoszą wyjątku overflowException gdyż posiadają specjalną własciwość Infinity!
             */

            return -1;
        }

        static float FiltrWyjatkow(int liczba)
        {
            bool jestZero = false;
            try
            {
                jestZero = liczba == 0;
                return 100 / liczba;
            }
            catch (Exception ex) when (jestZero)
            {
                Console.WriteLine($"Dzielenie przez zero. Spróbuj ponownie {ex.Message}");
            }
            catch (Exception ex) when (!jestZero)
            {
                Console.WriteLine($"Nieoczekiwany wyjatek. Spróbuj ponownie {ex.Message}");
            }

            return -1F;
        }

        static void ZglaszanieWyjatkow(int liczba)
        {
            PobierzNazweMiesiaca(liczba);
        }

        static string PobierzNazweMiesiaca(int liczba)
        {
            switch (liczba)
            {
                case 1:
                    return "Styczen";
                case 2:
                    return "Luty";
                case 12:
                    return "Grudzien";
                default:
                    throw new ArgumentOutOfRangeException("Nie ma takiego miesiaca");
            }
        }

        static void BlokFinally()
        {
            /* Bardzo ważne jest to aby pamiętać, że zgłoszenie wyjątku spowoduje zmianę głównej linii wykonywania się programu.
             * Czasami fakt, że pewna instrukcja nie zostanie wykonana nie stanowi problemu ale w wielu przypadkach może to oznaczać
             * poważny błąd. Jeśli ta pominięta instrukcja zwalniałaby przydzielone zasoby to jej niewykonanie spowodowałby zachowanie
             * stanu zajętości dla tych zasobów.
             * np. Operacja otwarcia pliku wymaga przydzieleniu pewnych zasobów (uchwytu pliku) i programista musi zadbać o to aby
             * ten zasób został zwolnony po skonczeniu pracy z tym plikiem, za pomocą instrukcji reader.Dispose(). Jeśli tego nie zrobi
             * to prędzej czy później dojdzie do wyczerpania tych zasobów i otwarcie kolejnego pliku bedzie niemożliwe!
             * Blok 'finally' zawsze! zostanie wykonany bez względu na to czy doszło do zgłoszenia wyjątku czy nie.
             */

            string path = @"D:\Mircosoft krok po kroku\mojeProjekty\Chapter 6 Wyjatki\Chapter 6 Wyjatki\resources\plik.txt";
            string badPath = @"Dupa:\plik1.txt";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            OdczytajPlik(path, encoding);
        }

        static void OdczytajPlik(string path, Encoding encoding)
        {
            /* Note: wiecej o TextReader: https://docs.microsoft.com/pl-pl/dotnet/api/system.io.textreader?view=net-5.0
             * TextReader jest to klasa abstrakcyjna a pochodne to: StringReader i StreamReader.
             * StreamReader posiada wiele konstruktorów, m.in. może okreslić typ kodowania pliku StreamReader(Stream, Encoding).
             */
            Console.OutputEncoding = encoding;
            TextReader textReader = null;
            try
            {
                textReader = new StreamReader(path, encoding);
                string text = textReader.ReadLine();
                while (text != null)
                {
                    Console.WriteLine(text);
                    text = textReader.ReadLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Przechwycenie wyjatku: FileNotFoundException. {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Przechwycenie wyjatku: IOException. {ex.Message}");
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Dispose();
                }
            }

            /* Note: Gdy wyjątek zostanie obsłużony w tej metodzie to najpierw wykona się blok pułapki catch a potem finally.
             * Natomiast gdy wyjątek zostanie obsłużony w metodzie wyżej to jako pierwszy wykona się blok finally.
            */
        }
    }
}
