using System;

namespace Chapter_16_Indeksory.Model
{
    struct IntBits
    {
        private int _bits;

        public IntBits (int wartosc) => _bits = wartosc;

        public bool this[int index]
        {
            get => (_bits & (1 << index)) != 0;
          
            set
            {
                if (value == true)
                {
                    _bits |= 1 << index;
                }
                else
                {
                    _bits &= ~(1 << index);
                }
            }
        }

        public override string ToString()
        {
            return Convert.ToString(_bits, 2);
        }
    }
}
