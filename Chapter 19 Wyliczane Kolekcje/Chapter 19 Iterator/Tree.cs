using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_19_Iterator
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
            // Note: konstruktor nie zawiera parametru typu. Tree, a nie Tree<TItem>
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

        // Zwraca moduł wyliczeniowy umożliwiający iteracja po elementach kolekcji 
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
                foreach (var item in this.LeftTree)
                {
                    yield return item;
                }
            }

            yield return this.NodeData;

            if (this.RightTree != null)
            {
                foreach (var item in this.RightTree)
                {
                    yield return item;
                }
            }
        }

        // Analogicznie jak IEnumerator, generyczny IEnumerable<T> dziedziczy po swoim starszym bracie IEnumerable dlatego nalezy dodac implementacje obydwuch interfejsow. 
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
