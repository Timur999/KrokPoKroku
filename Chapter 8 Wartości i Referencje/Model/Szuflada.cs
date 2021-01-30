using System;

namespace valuesAndReferences.Model
{
    class Szuflada
    {
        public Olowek OtherObject;

        public Szuflada()
        {
            OtherObject = null;
        }

        // Do funkcji przekazujemy kopie wartości. Nie operujemy na orginalnej watośći. W tym przypadku na kopii referencji która wskazuje na ten sam obiekt
        public static void PrzekazReferencje(Olowek objectReference)
        {
            objectReference.Grubosc = 12;
        }

        public void PokazCoMaszWSrodku()
        {
            Console.WriteLine("Rękawiczki", "Czapki", "Marchewki");
        }

        public int ReturnNumber()
        {
            return 1;
        }

        public bool ReturnBool()
        {
            return true;
        }

        public Olowek ReturnObject()
        {
            return new Olowek();
        }
    }

    class Olowek
    {
        public int Grubosc;

        public Olowek(int grubosc)
        {
            Grubosc = grubosc;
        }
        public Olowek() {}

        public int PobiezGruboscOlowka()
        {
            return Grubosc;
        }
    }
}
