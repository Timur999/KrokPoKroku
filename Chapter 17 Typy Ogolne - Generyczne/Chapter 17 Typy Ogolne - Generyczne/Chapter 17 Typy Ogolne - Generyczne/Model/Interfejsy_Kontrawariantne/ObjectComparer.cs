
using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfejsy_Kontrawariantne.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model
{
    internal class ObjectComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            int xHash = x.GetHashCode(); // zwraca inta reprezentującą dany obiekt.
            int yHash = y.GetHashCode();

            if (xHash > yHash) return 1;
            if (xHash < yHash) return -1;

            return 0;
        }
    }
}
