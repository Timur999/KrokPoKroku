namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kowariantne.Interfaces
{
    // Interfejs Konwariantny
    // Kowiariantny parameter typu zawiera kwalifikator out i jest użyty jako wartość zwracana.
    public interface IRetrieveWrapper<out T>
    {
        T GetData();
    }
}
