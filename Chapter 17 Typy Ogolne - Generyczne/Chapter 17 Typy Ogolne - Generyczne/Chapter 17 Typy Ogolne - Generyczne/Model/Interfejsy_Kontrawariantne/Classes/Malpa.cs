using Chapter_17_Typy_Ogolne___Generyczne.Model.Enums;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model
{
    internal class Malpa : IAnimal
    {
        public string Name;

        public Gatunek Gatunek { get; }

        public Malpa(string name)
        {
            Gatunek = Gatunek.Ssaki;
        }
    }
}
