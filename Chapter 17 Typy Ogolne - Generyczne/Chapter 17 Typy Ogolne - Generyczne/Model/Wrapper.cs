using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfaces;
using System;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model
{
    internal class Wrapper<T> : IWrapper<T>
    {
        private readonly T text;
        T IWrapper<T>.GetData() // Jawna implementacja interfejsu. Gdy przypiszemy obiekt do interfersu (IWrapper) bedzie można uzyć tej metody.
        {
            throw new NotImplementedException();
        }

        void IWrapper<T>.SetData(T data)
        {
            throw new NotImplementedException();
        }
    }
}
