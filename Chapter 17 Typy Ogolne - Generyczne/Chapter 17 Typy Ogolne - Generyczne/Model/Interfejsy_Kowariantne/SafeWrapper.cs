using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne
{
    public class SafeWrapper<T> : IStoreWrapper<T>, IRetrieveWrapper<T>
    {
        private T data;

        T IRetrieveWrapper<T>.GetData()
        {
            return data;
        }

        void IStoreWrapper<T>.SetData(T data)
        {
            this.data = data;
        }
    }
}
