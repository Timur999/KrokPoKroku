using Chapter_17_Typy_Ogolne___Generyczne.Model.Interfaces;

namespace Chapter_17_Typy_Ogolne___Generyczne.Model
{
    internal class PrintableCollection<T> where T : IPrintable, IScaleable
    {
    }
}
