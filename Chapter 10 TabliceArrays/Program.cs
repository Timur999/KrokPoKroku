using Chapter_10_TabliceArrays.Cards;
using System;

namespace Chapter_10_TabliceArrays
{
    // Tablice (klasa System.Array) zawieraja zbiór elementów tego samego typu.
    // Tablica jest typem referencyjny a elementy są przechowywane obok siebie w pamięci. Dostep do nich odbywa się za pomocą index'u.
    class Program
    {
        // Parametr 'string[] args' w metodzie Main. Funckja Main jest to punkt wejscia do programu. 
        // Uruchamiając aplikacje z poziomu cmd możemy zdefiniować dodatkowe argumenty które zostaną przekazane do tej funkcji.
        // System Windows przekazuje argumenty do CLR który następnie uruchamia aplikacje. W ten sposób możemy dostarczyć dane,
        // bez konieczności pisania kodu, który je pobierze. Ma to zastosowanie w skryptach.
        // Aby uruchomić aplikacje w cmd należy dodać zmienną srodowiskową Path "C:\Windows\Microsoft.NET\Framework\v4.0.30319", 
        // wpisac sieżkę do folderu zawierającego program, nastepnie nazwe programu i podac parametry po spacji np:
        // HelloWord d:\folder\plik.rozszerzenie np. d:\fotki\fota.jpg
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }

            //Declaration();
            //Initalization();
            //TableWithAnonymousObject();
            //IterationThroughoutArray(new string[] { "cat", "dog" });
            //TableAsAParameter(new int[] { 1, 2, 3, 4 });
            //string[] newTable = CopyTable(animals);
            //MultiMatrixTable();
            //UnregularTable();
            //GetValueFromTable();
        }

        public static void Declaration()
        {
            // Deklaracja.
            string[] names;
            string[,] table;
            string[][] elements;
        }

        public static void Initalization()
        {
            // Inicjalizacja.

            // Rozmiar tabeli nie musi byc wartością const/stałą. Ponieważ pamięć jest alokowana dynamicznie w trakcie działania programu.
            string[] names = new string[int.Parse(Console.ReadLine())];

            // Dopuszczalny jest rozmiar tablicy zero. Wtedy ta talica nie jest null, ale tablica o zerowej ilości elementów. (names != null)
            names = new string[0];

            // Wypełnianie tablic.
            names = new[] { "Tom", "John", "Rob" }; 
            names = new[] { Console.ReadLine(), Console.ReadLine(), Console.ReadLine() };
            // Jeśli nie przypiszemy wartości to zostanie przypisana wartośc domyślna.
            names = new string[3]; // (Dla typów wartościowych - zero, referencyjnych - null, daty - 01/01/0001 00:00:00)

            // Ilość elementów musi byc identyczna z rozmiarem tablicy.
            int[] luckyNumbers = new int[6] { 1, 2, 4, 88, 12, 54 };
            // luckyNumbers = new int[6] { 1, 2, 4}; bład kompilacji.

            // Inicjalizacja bez skłowa kluczowego 'new'
            int[] salaryRange = { 999999, 99999999 };

            // Note: Tablica to instancja klasy System.Array
            System.Array array = new string[1];
        }

        public static void TableWithAnonymousObject()
        {
            // Tablice o niejawnie okreslonym typie.
            var cars = new[] { "Fiat", "Ford" };

            //var wrongTable = new[] { 1, 2, "A", "B" };  Muszą byc tego samego typu
            var doubleElements = new[] { 1, 2, 3.5, 9.99999 }; //domyslna konwersja na double
            var students = new[] { new { Name = "Tom", ID = 991112 }, new { Name = "Rob", ID = 092134 } };
            // Pola klasy anonimowej muszą być takie same. W przeciwnym razie byłaby to inna klasa i nastąpiłby błąd kompilacji.
            //var studentsAndCats = new[] { new { Name = "Tom", ID = 991112 }, new { Name = "Rob", ID = 092134 }, new { Name = "Minia", Age = 3 } };

            //Note: Przydaje się do pracy z anonimowanymi typami danych. Są opisane w rozdziale 7 "Tworzenie i zarządzanie klasami oraz obiektami"
        }

        public static void IterationThroughoutArray(string[] names)
        {
            // Każde pobieranie elementu z tablicy podlega kontroli czy index nie jest mniejszy niz 0 i nie jest większy od ilości elementów w tablicy.
            var me = names[0]; 

            // iteracja
            foreach (string name in names)
            {
                if (name.Equals("Rob"))
                {
                    names[2] = "Bob"; // foreach nie ma indeksu, w takiej sytuacji lepsza bedzie petla for
                }
            }

            // Próba iteracji tablicy która nie posiada żadnych elementów za pomocą pętli foreach jest całkowicie poprawna nie powoduje żadnych błędów.
            string[] motors = new string[0];
            foreach (string motor in motors)
            { }

            // Note: Przed każdym pobraniem elementu z tablicy jest sprawdzane czy index nie przekracza wielkosci tablicy lub jest mniejsze niz zero.
        }

        public static int[] TableAsAParameter(int[] numbers)
        {
            // Należy zwrócić uwage, że tablica jest zmienną referencyjną.
            // Zmiany na utworzonej kopii będą widoczne we wszystkich innych zmiennych zawierających referencje do tej tablicy.
            numbers[0] = 10; // Zmieniamy wartość na stercie.

            return new int[4];
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

            // Kopiowanie jest bardzo powszechne w programowaniu dlatego tablice posiadają "metody instancji" 'CopyTo' i 'Clone' oraz statyczną metode 'Copy'.

            // Metoda CopyTo. 
            // Drugi param określa od którego indexu rozpocząć kopiowanie tablicy.
            names.CopyTo(copyTable, 10);

            // Copy - Metoda statyczna klasy Array.
            Array.Copy(names, copyTable, 0);

            // Clone - metoda instacji. Funkcja ta zwraca nową instancje tabeli w postaci 'object'.
            object copy = names.Clone();
  
            return (string[])names.Clone(); ;

            //Note: wszystkie te metody tworzą tzw. 'kopie płytką' (gdy elementem tablicy jest obiekt Car, który zawiera Pole typu referencyjnego np.
            // Engine to zostanie skopiowana tylko referencja do obiektu Engine nie zostanie stworzony nowy obiekt).
            // Gdy chcemy wykonac kopie głęboką nalezy uzyc petli for. Utworzyć nowy obiekt Engine i przekopiować wszystkie jego wartości. 
        }

        public static void MultiMatrixTable()
        {
            int[,] elemnts = new int[4, 5];
            elemnts[1, 4] = 99;
            elemnts[4, 4] = elemnts[1, 4];
            elemnts[1, 4]++; // 100

            int[,,] cube = new int[5, 5, 5]; //Zaweira 125 elementow

            //Note: Wielowymiarowe tablice zawierają wiele elementów i zajmują dużo pamięci.
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
            Player[] players = new Player[3]; // Tabela zawiera 3 elementy typu referencyjnego. Na stercie posiada 3 referencje do obiektów 'Player'.
            Player player = players[2]; // Przekazuje na stos kopie referencji do obiektu. (Pracujemy na oryginale)
            int[] ints = new int[] { 1, 2, 3 }; // Tabela zawiera 3 elementy typu prostego. Na stercie posiadac 3 wartości typu 'int'.
            int number = ints[1]; // przekazuje na stos kopie wartości. (Pracujemy na kopii)

            foreach (int i in ints)
            {
                Console.Write($"{i}, "); // 1, 2, 3,
            }

            // Ref Local - nowa zmienna od C# 7.0. Jest uzywana głównie w połączeniu z Ref Returns i przechowuje referencje. Jest to wskaźnik.
            ref int first = ref GetFirstElement(ints);
            first = 99;
            foreach (int i in ints)
            {
                Console.Write($"{i}, "); // 99, 2, 3,
            }

            // Wiecej o Ref Local i Ref return: https://www.c-sharpcorner.com/article/working-with-ref-returns-and-ref-local-in-c-sharp-7-0/

            // Wskaźniki wskazują na obszar pamięci na stercie lub stosie. (obrazek w resourcach)
            // int *pi; deklaracja wskaźnika do liczby całkowitej. Wskaźniki przechowuja adress/referencje do zmiennych
            // int i = 99;
            // *pi = &i; 
            // &i zwraca addres
            // *pi = 100; wskaznik *pi wskazuje na zmienna i


            // *pi = &i; 
            // *pi = 99;
            // Równoznaczne 
            // ref int first = ref GetFirstElement(ints) { return ref intTab[0]; }
            // first = 99;

            // Czy zmienne referencyjne przechowuja tylko adres do zmiennych na stercie? Na 99% tak ale sie upewnic
        }

        private static ref int GetFirstElement(int[] intTab)
        {
            // Ref Returns
            return ref intTab[0]; // &intTab[0] - pobieramy adres pierwszego elementu.
        }

        //Uwaga. Ten kod sie nie skompiluje.
        // Problem wiszącego wskaźnika. Czesto spotykany bład w jezyku C. Nie można zwrócic referencji do obiektu z metody w której obiekt został stworzony.
        //private static ref int DanglingReference(int[] intTab) //w tłumaczeniu wiszący wskaźnik
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
