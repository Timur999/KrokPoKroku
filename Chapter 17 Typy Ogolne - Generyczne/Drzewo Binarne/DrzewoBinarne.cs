using System;

namespace Drzewo_Binarne
{
    /* Project został utworzony jako Biblioteka Klas (Class Library) 
     * Raz utworzony i skompilowany projekt w postaci bilioteki klas bedziemy mogli dodac do dowlnego projektu i uzywac wielokrotnie.
     * Biblioteka Klas jest zbiorem skompilowanych klas (i innych typów, takich jak struktury i delegaty) zapisanych w zestawie (assembly).
     * Zestaw to plik mający zwykle rozszerzenie .dll.
     * 
     * Projekty i aplikacje mogą korzystac z zawartości biblioteki klas dodając u siebie ODWOŁANIE do zestawu,
     * a następnie włączając jej przestrzeń nazw do swojego zasięgu za pomocą dyrektywy using.
     * (Należy najpierw skopiować assemblie zawierający skompilowany kod na komputer (o ile sami jej nie zrobilismy) a nastepnie dodac referencje/odwołanie.
     * 
     * np. po skompilowaniu tego projektu 
     * w projekcie Chapter 17 Typy Ogolne dodając using Drzewo_Binarne
     * oraz zakładce References dodając zestaw DrzewoBinarne.dll (Zestaw kompiluje sie do folderu /bin/Debug lub Release)
     * 
     * Jeżeli Biblioteka klas znajduje się W TEJ SAMEJ solucji to wystarczy dodac odwołanie do projektu zamiast do zestawu.
     * Odwołanie do projektu dodajemy w ten sam sposób - ppm na projekt -> add -> references -> zamiast Assemblies wybieramy Projects -> zaznaczmy i OK)
     */

    public class DrzewoBinarne<TItem> where TItem : IComparable<TItem>
    {
        public TItem NodeData { get; set; }
        public DrzewoBinarne<TItem> LeftTree { get; set; }
        public DrzewoBinarne<TItem> RightTree { get; set; }

        private TItem currentNodeValue;

        public DrzewoBinarne(TItem nodeValue)
        {
            this.NodeData = nodeValue;
            LeftTree = RightTree = null;
            // UWAGA: Zauważmy, że konstruktor nie zawiera parametru typu: ma postać DrzewoBinarne, a nie DrzewoBinarne<TItem>
        }

        public void Insert(TItem newItem)
        {
            currentNodeValue = this.NodeData;

            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new DrzewoBinarne<TItem>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new DrzewoBinarne<TItem>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        public string WalkTree()
        {
            string result = "";

            if (this.LeftTree != null)
            {
                result = this.LeftTree.WalkTree();
            }
            result += $" {this.NodeData} ";

            if (this.RightTree != null)
            {
                result += this.RightTree.WalkTree();
            }

            return result;
        }
    }
}
