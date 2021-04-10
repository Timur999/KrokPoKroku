using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_14_Zarzadzanie_pamiecia.Model
{
    class InnyPrzyklad : IDisposable
    {
        private bool zwolniony = false;

        /* Nie wiemy kiedy GC wywoła 'destruktor' może się więc tak zdarzyć, że 'Kolektor Śmieci' proces finalizacji zostanie uruchomionyw osobnym wątku w chwili gdy inny wątek wykonywć bedzie metodę 'Dispose()'
         * Aby się zabezpieczyć przez zwalnianiem tych samych zasobów przez 2 różne wątki możemy użyć instrukcji 'lock'
         */
        ~InnyPrzyklad() 
        {
            Dispose();
        }

        public void Dispose()
        {
            /* 'lock' uniemożliwi wykonywanie tego samego bloku kodu przez 2 różne wątki równocześnie. 
             * Argumentem do instrukcji 'lock' jest referencja do obiektu. Jeśli w chwilą napotkania instrukcji 'lock' obiekt podany jako argument został już zablokowany to wątek żadający nałożenia blokady 
             * sam zostanie zablokowany aż do momentu wyjscią z instrukcji 'lock' przez blokujący wątek.
             */
            
            lock (this) 
            {
                if (!zwolniony)
                {
                    Console.WriteLine("Zwalnianie zasobów zarządzanych i niezarządzanych");
                    this.zwolniony = true;
                    GC.SuppressFinalize(this);
                }
            }

            /* ALternatywnym sposobem na rozwiązanie tego problemu jest opisany w klasie Przykład, który uniemożliwia zwalnianie więcej niż raz zasobó zarządzanych. */
        }
    }
}
