namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces
{
    // Interfejs Kontrawariantny -  z przestrzeni nazw System.Collections.Generic w .NET Framework jest identyczny
    public interface IComparer<in T>
    {
        int Compare(T x, T y);
    }
}
