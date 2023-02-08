using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne
{
    internal class AnimalComaparer : IAnimalComparer<IAnimal>
    {
        public int Compare(IAnimal x, IAnimal y)
        {
            if (x.Gatunek == y.Gatunek)
            {
                return 0;
            }

            return -1;
        }
    }
}
