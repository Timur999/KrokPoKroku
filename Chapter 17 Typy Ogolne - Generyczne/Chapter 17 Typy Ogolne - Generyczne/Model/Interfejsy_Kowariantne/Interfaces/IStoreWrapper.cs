
namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne.Interfaces
{
    // To nie jest interfejs Konwariantny
    // interfejs Konwariantny musi zawierac kwalifikator out w parametrze typu i być użyty jako wartość zwracana przez metode
    public interface IStoreWrapper<T>
    {
        void SetData(T data);
    }
}
