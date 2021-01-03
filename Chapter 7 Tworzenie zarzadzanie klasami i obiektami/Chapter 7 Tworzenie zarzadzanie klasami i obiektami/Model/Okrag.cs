using System;
namespace Classies.Model
{
    class Okrag
    {
        /* Warto pamiętać, że pola w klasach mają wartość domyślną 0, false lub null, zależy od ich typu.
         * Dobrą praktyką jest jawnie inicjowanie wartości tych pól.
         */
        private float promien = 0f;
        private bool poprawneDaneWejsciowe = false;

        public Okrag(float _promien)
        {
            poprawneDaneWejsciowe = sprawdzPoprawnoscWartosc(_promien);
            if (poprawneDaneWejsciowe)
            {
                promien = _promien;
            }
            else
            {
                throw new ArithmeticException("Nie prawidłowa wartość pola 'Promień'");
            }
        }

        public double ObliczObwod()
        {
            return promien * 3.14f;
        }

        private Okrag()
        {
            Console.WriteLine("Tworzę okrag");
        }

        private bool sprawdzPoprawnoscWartosc(float wartoscPola)
        {
            return !(wartoscPola < 0);
        }
    }
}
