using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valuesAndReferences.Model
{
    class Pass
    {
        public WrappedInt OtherObject;

        public Pass()
        {
            OtherObject = null;
        }

        // Do funkcji przekazujemy kopie wartości. Nie operujemy na orginalnej watośći. W tym przypadku na kopii referencji która wskazuje na ten sam obiekt
        public static void Reference(WrappedInt objectReference)
        {
            objectReference.Value = 12;
        }

        public int ReturnNumber()
        {
            return 1;
        }

        public bool ReturnBool()
        {
            return true;
        }

        public WrappedInt ReturnObject()
        {
            return new WrappedInt();
        }
    }

    class WrappedInt
    {
        public int Value;

        public WrappedInt(int value)
        {
            Value = value;
        }
        public WrappedInt() {}

        public int GetIntegerValue()
        {
            return Value;
        }
    }
}
