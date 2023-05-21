namespace Chapter_19_Iterator
{
    /* W tym rozdziale zostanią omowiony iterator.
     * Co to jest iterator i jak działa na przykładzie ProstaKolekcja oraz Rekurencyjnego podejścia w klasie Tree.
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Iterator();
        }

        static void Iterator()
        {
            /* Iterator jest opisem wyliczanej sekwencji który zostanie wykorzystany przez Kompilator C# do utworzenia własnego modyłu wyliczającego.
             * Innymi słowy jest to blok kodu który dostarcza uporządkowaną sekwencje.
             * Takim blokiem jest metoda GetEnumerator().
             * Kompilator na jej podstawie wygeneruje właściowść Current oraz metody MoveNext() i Reset().
             * (Cały proces wygenerowania moduły wyliczającego przez kompilator zostanie wykonany w tle
             * i tylko dekompilujac zestaw bedziemy mogli podejrzec implementacje.)
             * 
             * Przyklad:
             * IEnumerator<T> GetEnumerator()
             * {
             *      for(...)
             *      {
             *          yield return ...
             *      }
             * }
             * 
             * instrukcja yield wskazuje który elemnent ma zostać zwrócony
             */
        }
    }
}
