using System;

namespace Chapter_14_Zarzadzanie_pamiecia.Model
{
    class Przyklad :IDisposable
    {
        private string[][] cennyZasób;  // cenny zasób, który chcemy zarządzać.
        private bool zwolniony = false; // czy interesujacy nas zasób został już zwolniony.

        ~Przyklad()
        {
            // zwalnia tylko zasoby niezarządzane, ponieważ zasoby zarządzane zostaną lub zostały już zwolnione przez GC i należy zwolnić jedynie zasobby niezarządzane tak jak np. uchwyt pliku.
            Dispose(false); 
        }

        public void Dispose() // Może zostać wywołana w każdej chwili działania programu
        {
            Dispose(true); // zwalnia zasoby zarządzane i nie zarządzane.
            GC.SuppressFinalize(this); // po wykonaniu tej metody destruktor tego obiektu już się nie wykona.
        }

        protected void Dispose(bool zwalnianie)
        {
            if (!this.zwolniony)
            {
                if (zwalnianie)
                {
                    // zwalnianie dużych zasobów zarządzanych
                }
                // zwalnianie zasobów niezarządzanych

                this.zwolniony = true;
            }
        }

        public void PewnaMetoda()
        {
            SprawdzCzyZostalZwolniony();
            //...
        }

        private void SprawdzCzyZostalZwolniony()
        {
            if (this.zwolniony)
            {
                throw new ObjectDisposedException("Przykład: obiekt został już zwolniony");
            }
        }
    }
}
