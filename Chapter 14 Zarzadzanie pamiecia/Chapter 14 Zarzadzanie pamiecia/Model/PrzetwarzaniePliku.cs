using System;
using System.IO;

/* Jest to tylko przykład i nie jest zalecaną formą otwierania i zamykania pliku */

namespace Chapter_14_Zarzadzanie_pamiecia.Model
{
    class PrzetwarzaniePliku : IDisposable
    {
        FileStream file = null;

        public PrzetwarzaniePliku(string sciezka)
        {
            //file = new FileStream(sciezka, FileMode.Open);
        }

        /* 'Destruktor' jest podobny do konstruktora z tym, że jest on wywoływany przez CLR gdy zniknie ostatnia referencja do obiektu */
        ~PrzetwarzaniePliku()
        {
            //file.Close();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }
}
