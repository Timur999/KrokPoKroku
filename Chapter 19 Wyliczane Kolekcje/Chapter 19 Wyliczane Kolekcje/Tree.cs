using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_19_Wyliczane_Kolekcje
{
    public class Tree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public TItem NodeData { get; set; }
        public Tree<TItem> LeftTree { get; set; }
        public Tree<TItem> RightTree { get; set; }

        private TItem tempCurrentNodeValue;

        public Tree(TItem nodeValue)
        {
            this.NodeData = nodeValue;
            LeftTree = null;
            RightTree = null;
            /* Note: konstruktor nie zawiera parametru typu. np mie wyglada tak 'Tree<TItem>'
             * pomimo ze podczas inicjalizacji podajemy typ
             * Tree<int> drzewoBinarne = new Tree<int>(10);
             */
        }

        public void Insert(TItem newItem)
        {
            tempCurrentNodeValue = this.NodeData;

            if (tempCurrentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<TItem>(newItem);
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
                    this.RightTree = new Tree<TItem>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        // Zwraca moduł wyliczeniowy umożliwiający iteracje po elementach kolekcji 
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return new TreeEnumerator<TItem>(this);
        }

        /* Analogicznie jak IEnumerator<T> (zaimplementowany w klasie TreeEnumerator),
         * generyczny IEnumerable<T> dziedziczy po swoim starszym bracie IEnumerable dlatego nalezy dodac implementacje obydwu interfejsow. 
         */
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
