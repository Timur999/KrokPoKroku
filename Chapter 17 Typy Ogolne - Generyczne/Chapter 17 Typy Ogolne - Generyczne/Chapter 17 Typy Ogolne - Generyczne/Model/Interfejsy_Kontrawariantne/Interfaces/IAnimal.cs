using Chapter_17_Typy_Ogolne___Generyczne.Model.Enums;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces
{
    interface IAnimalComparer<in T>
    {
        int Compare(T x, T y);
    }

    interface IAnimal
    {
        Gatunek Gatunek { get; }
    }
}
