using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_9_Enums_and_Structs
{

    // Różnice miedzy struktya a klasą:
    // 1. Konstruktor Domyślny. W strukturze nie mozna zdefiniować wlasnego konstruktora domyślnego, w klasie możemy. (konstruktora domyślnego bez parametrów)
    // 2. Inicjiowanie properties. Gdy zdefiniowaliśmy własny konstruktor to musimy w nim przypisać wartość wszystkich pól struktury. W klasie gdy któreś pole niezainicjujemy zostanie przypisjana jej wartość domyślna.
    // 2.1. W strukturze nie można przypisać wartość polu na poziome deklaracji. W klasie możemy 
    struct Time
    {
        private int sec, minute, hour;
        //private int miliSec = 0; // Błąd kompilacji. 2.1.

        public Time(int _hour, int _minute, int _sec)
        {
            hour = _hour % 23;
            minute = _minute % 59;
            sec = _sec % 59;
        }

        //public Time(int _hour, int _minute) 
        //{
        //    hour = _hour % 23;
        //    minute = _minute % 59;
        //    // Błąd kompilacji w strukturze gdy zdefiniujemy konstruktor musi on inicjiować każdą zmienną zawartą w strukturze. W klasie zainicjuje ta zmienna wartości domyślną
        //}

        public int GetHour() => hour;
        public void SetHour(int _hour) => this.hour = _hour % 23;

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", hour, minute, sec);
        }
    }
}
