namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfaces
{
    // Interfejs Inwariantny
    internal interface IWrapper<T>
    {
        void SetData(T text);
        T GetData();
    }
}
