using Chapter_10_TabliceArrays.Cards;
using System;

namespace Chapter_10_TabliceArrays
{
    // Tablice (klasa System.Array) zawieraja zbiór elementów tego samego typu. Tablica jest typem referencyjny a elementy są przechowywane obok siebie w pamięci. Dostep do nich odbywa się za pomocą indexu.
    class Program
    {
        // Parametr w metodzie Main. Funckja Main jest to punkt wejscia do programu. Uruchamiając aplikacje z poziomu cmd możemy zdefiniować dodatkowe argumenty które zostaną przekazane do tej funkcji.
        // System Windows przekazuje argumenty do CLR który następnie uruchamia aplikacje. Możemy w ten sposób dostarczyc pewnych danych bez konieczności pobierania ich bezpośrednio w kodzie. Ma to zastosowanie w skryptach
        // Aby uruchomić aplikacje w cmd należy dodac zmienna srodowiskową Path "C:\Windows\Microsoft.NET\Framework\v4.0.30319", przejsc do folderu z programem, wpisac nazwe programu i podac parametry po spacji
        // Program d:\folder\plik.rozszerzenie np. d:\fotki\fota.jpg
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }


            // Zakres rozdziału:
            //Declaration();
            //Initalization();
            //TableWithAnonymousObject();
            //string[] animals = new string[] { "cat", "dog" };
            //IterationThroughoutArray(animals);
            //TableAsAParameter(new int[] { 1, 2, 3, 4 });
            //string[] newTable = CopyTable(animals);
            //MultiMatrixTable();
            //UnregularTable();
            //GetValueFromTable();

            int[] tab = new int[] { 1, 2, 3, 4 };
            TableAsAParameter(tab);

            foreach(int i in tab){
                Console.WriteLine(i);
            }
        }

        public static void Declaration()
        {
            //Deklaracja. Alokowana jest nie wielka ilosc pamięci na stosie aby przechowywać referencje
            string[] names;
            string[,] table;
            string[][] elements;
        }

        public static void Initalization()
        {
            string[] names;

            //Inicjalizacja. Alokowana jest pamieć na stercie i przypisujemy referencje
            names = new string[3];
            //Ponieważ pamięć jest alokowana dynamicznie w trakcie działania programu, rozmiar tabeli nie musi byc wartością const/stałą.
            names = new string[int.Parse(Console.ReadLine())];
            //Dopuszczalna jest rozmiar tablicy zero. W tedy nie jest to null ale jest to tablica o zerowej ilości elementów 

            //Wypełnianie tablic. Po inicjalizacji jeśli nie przypiszemy wartości to zostanie przypisana wartośc domyślna. (Dla typów wartościowych - zero, referencyjnych - null, daty - 01/01/0001 00:00:00
            names = new[] { "Tom", "John", "Rob" };
            //Ponieważ pamięć jest alokowana dynamicznie w trakcie działania programu, elementy tablicy nie musi byc wartością const/stałą.
            names = new[] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };

            //Ilość elementów musi byc identyczna z rozmiarem tablicy
            int[] luckyNumbers = new int[6] { 1, 2, 4, 88, 12, 54 };
            // luckyNumbers = new int[6] { 1, 2, 4}; bład kompulacji

            // Inicjalizacja bez new
            int[] salaryRange = { 999999, 99999999 };

            // Note: Tablica to instancja klasy System.Array
            System.Array array = new string[1];
        }

        public static void TableWithAnonymousObject()
        {
            //Tablice o niejawnie okreslonym typie.
            var cars = new[] { "Fiat", "Ford" };
            //var wrongTable = new[] { 1, 2, "A", "B" };  Muszą byc tego samego typu
            var doubleElements = new[] { 1, 2, 3.5, 9.99999 }; //domyslna konwersja na double
            var students = new[] { new { Name = "Tom", ID = 991112 }, new { Name = "Rob", ID = 092134 } };
            // Pola klas anonimowych musza byc takie same inaczej byłaby to inna klasa i nastąpiłby błąd kompilacji.
            //var studentsAndCats = new[] { new { Name = "Tom", ID = 991112 }, new { Name = "Rob", ID = 092134 }, new { Name = "Minia", Age = 3 } };

            //Note: Przydaje się do pracy z anonimowanymi typami danych. Są opisane w rozdziale 7 "Tworzenie i zarządzanie klasami oraz obiektami"
        }

        public static void IterationThroughoutArray(string[] names)
        {
            // Każde pobieranie elementu z tablicy podlega kontroli czy index nie jest mniejszy niz 0 i nie jest większy niż ilości elementów w tablicy.
            var me = names[0]; 

            // iteracja
            foreach (string name in names)
            {
                if (name.Equals("Rob"))
                {
                    names[2] = "Bob"; // nie ma indeksu, w takiej sytuacji lepsza becie petla for
                }
            }

            // Próba iteracji tablicy która nie posiada żadnych elementów za pomocą pętli foreach jest całkowicie poprawa nie powoduje żadnych błędów
            string[] motors = new string[0];
            foreach (string motor in motors)
            { }

             Console.ReadKey();
        }

        public static int[] TableAsAParameter(int[] numbers)
        {
            // Należy zwrócić uwage, że tablica jest zmienną referencyjną a więc zmiany na utworzonej kopii będą widoczne we wszystkich innych zmiennych zawierających referencje do tej tablicy.
            numbers[0] = 10;
            // Modyfikacja wartości na stosie kopii zmiennej 'numbers' utworzonej przez funkcje. Nie spowoduje to zmiany wartości zmiennej przekazanej w parametrze metody.
            numbers = new int[2];

            return new int[1];
        }

        public static string[] CopyTable(string[] names)
        {
            // Kopiujemy tylko referencje
            string[] copyRef = names;

            // Kopiowanie tablicy (płytkie)
            string[] copyTable = new string[names.Length];
            for (int index = 0; index < names.Length; index++)
            {
                copyTable[index] = names[index];
            }

            // Kopiowanie jest bardzo powszeche w programowaniu dlatego tablice posiadają "metody instancji" 'CopyTo' i 'Clone' oraz statyczną metode 'Copy'.

            // Metoda CopyTo. 
            // dDugi param określa od którego indexu rozpocząc kopiowanie
            names.CopyTo(copyTable, 10);

            // Copy - Metoda statyczna klasy Array.
            Array.Copy(names, copyTable, 0);

            //Clone - metoda instacji. Funkcja ta zwraca nową instancje tabeli w postaci object
            string[] copy = (string[])names.Clone();

            return copy;

            //Note: wszystkie te metody tworzą płytką kopie (gdy element np obiekt Car zawiera zmienna referencyjna np. Owner to zostanie skopiowania tylko referencja do tego obiektu. Gdy tworzona jest kopia do tego obiektu mowimy o kopi głębokiej)  
            // Gdy chcemy wykonac kopie głęboką nalezy uzyc petli for
        }

        public static void MultiMatrixTable()
        {
            int[,] elemnts = new int[4, 5];
            elemnts[1, 4] = 99;
            elemnts[4, 4] = elemnts[1, 4];
            elemnts[1, 4]++; // 100

            int[,,] cube = new int[5, 5, 5]; //Zaweira 125 elementow

            //Note: Wielowymiarowe tablice zawierają wiele elementów i zajmują duzo pamięci
        }

        public static void UnregularTable()
        {
            //Tablica tablic
            int[][] elements = new int[4][];
            elements[0] = new int[9]; 
            elements[1] = new int[3]; 
            elements[2] = new int[1];
            elements[3] = new int[4];

            int numb = elements.Length;// Liczba elementów w pierwszym wymiarze. 4
            numb = elements[1].Length; // Liczba elementów w drugim wymiarze. 3
        }

        public static void GetValueFromTable()
        {
            Player[] players = new Player[3];
            Player player = players[2]; // przekazuje na stos kopie referencji do obiektu. Pracujemy na oryginale
            int[] intTab = new int[] { 1, 2, 3 };
            int number = intTab[1]; // przekazuje na stos kopie wartości. Pracujemy na kopii

            // 
            foreach (int i in intTab)
            {
                Console.Write($"{i}, "); // 1, 2, 3,
            }

            ref int first = ref GetFirstElement(intTab);
            first = 99;
            foreach (int i in intTab)
            {
                Console.Write($"{i}, "); // 99, 2, 3,
            }
        }

        private static ref int GetFirstElement(int[] intTab)
        {
            return ref intTab[0];
        }

        //Uwaga. Ten kod sie nie skompiluje.
        // Problem wiszącego wskaźnika. Czesto spotykany bład w jezyku C. Nie można zwrócic referencji do obiektu z metody w której obiekt został stworzony.
        //private static ref int DanglingReference(int[] intTab) //tłumaczeniu wiszacy wskażnik
        //{
        //    int i;

        //     return ref i;
        //    // po zakonczeniu metody srodowisko zwalnia pamięc zajmowaną przez zmienne lokalne utworzone w trakcie działania metody.
        //}

        public static void PlayCards()
        {
            int index = 0;
            int[] cards = new int[52] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int[,] playersCards = new int[4, 13];

            HushCards(cards);

            for (int i = 0; i < 13; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    playersCards[j, i] = cards[index++]; 
                }
            }

            ShowYourCards(playersCards);
        }

        private static void HushCards(int[] cards)
        {
            int randomIndex;
            int cardValue;
            Random random = new Random();
            for(int i = 0; i < cards.Length; i++)
            {
                randomIndex = random.Next(0, 52);
                cardValue = cards[randomIndex];
                cards[randomIndex] = cards[i];
                cards[i] = cardValue;
            }
        }

        private static void ShowYourCards(int[,] cardsPlayers)
        {
            for(int i = 0; i < cardsPlayers.GetLength(0); i++)
            {
                Console.WriteLine($"Card's player {i}:");
                for (int j = 0; j < cardsPlayers.GetLength(1); j++)
                {
                    Console.Write($"{cardsPlayers[i, j]} ");
                }
                Console.WriteLine();
            }
        }


        public static void PlayRealCards()
        {
            int index = 0;
            var cards = new PlayingCard[52];
            PlayingCard[,] cardsPerPlayers;
 
            Pack packCard = new Pack();
            cards = packCard.GetPackCard();

            HushCards(cards);
            GiveAwayCards(cards, out cardsPerPlayers);
            ShowYourCards(cardsPerPlayers);
        }

        private static void HushCards(PlayingCard[] cards)
        {
            int numOfCardInBox = cards.Length;
            int randomIndex;
            PlayingCard card;
            Random random = new Random();
            for (int i = 0; i < numOfCardInBox; i++)
            {
                randomIndex = random.Next(0, numOfCardInBox);
                card = cards[randomIndex];
                cards[randomIndex] = cards[i];
                cards[i] = card;
            }
        }

        private static void GiveAwayCards(PlayingCard[] cards, out PlayingCard[,] cardsPerPlayers)
        {
            const int numOfPlayers = 4;
            int numOfCardsPerPlayer = cards.Length / numOfPlayers;
            cardsPerPlayers = new PlayingCard[numOfPlayers, numOfCardsPerPlayer];

            int index = 0;
            for (int i = 0; i < numOfCardsPerPlayer; i++)
            {
                for(int j = 0; j < numOfPlayers; j++)
                {
                    cardsPerPlayers[j, i] = cards[index++];
                }
            }
        }

        private static void ShowYourCards(PlayingCard[,] cardsPlayers)
        {
            for (int i = 0; i < cardsPlayers.GetLength(0); i++)
            {
                Console.WriteLine($"Card's player {i}:");
                for (int j = 0; j < cardsPlayers.GetLength(1); j++)
                {
                    Console.Write($"{cardsPlayers[i, j].ToString()}; ");
                    // kompilator podpowiada, że ToString() jest nie potrzebny. Nie tylko ze Console.Write domyslnie uzyje ToString na obiekcie ale wyrazenie $"{obiekt}" równiez
                    // string card = $"{cardsPlayers[i, j]}";   
                }
                Console.WriteLine();
            }
        }


        public static void ProfesionalCardGame()
        {
            const int NumPlayers = 4;
            Pack packCard = new Pack();
            Player[] players = new Player[NumPlayers];

            try
            {
                for (int i = 0; i < NumPlayers; i++)
                {
                    players[i] = new Player();
                }

                for (int i = 0; i < NumPlayers; i++)
                {
                    for (int j = 0; j < Player.MaxCardInHand; j++)
                    {
                        players[i].AddPlayerCard(packCard.DealCardFromPack());
                    }
                }

                for (int i = 0; i < NumPlayers; i++)
                {
                    players[i].Check();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
