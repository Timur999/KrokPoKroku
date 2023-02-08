using Chapter_17_Typy_Ogolne___Generyczne.Model.Enums;
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model
{
    internal class Kon : IAnimal
    {
        public string Name;

        public Gatunek Gatunek { get; }

        public Kon(string name)
        {
            Name = name;
            Gatunek = Gatunek.Ssaki;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
