using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_19_Testy
{
    internal class MojaLista<T> : IEnumerable<T>
    {
        Queue kolejka;

        internal MojaLista()
        {
            kolejka = new Queue();
        }

        internal void DodajElement(object element)
        {
            kolejka.Enqueue(element);
        }

        public IEnumerator GetEnumerator()
        {
            return new MojEnumerator(kolejka);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class MojEnumerator : IEnumerator
    {
        private Queue _kolejka;
        private Queue _kolejkaDoIterowania;

        internal MojEnumerator(Queue kolejka)
        {
            _kolejka = kolejka;
        }

        public object Current => _current;

        private object _current;

        public bool MoveNext()
        {
            if(_kolejkaDoIterowania == null || _kolejkaDoIterowania.Count == 0)
            {
                _kolejkaDoIterowania = _kolejka;
            }

            if (_kolejkaDoIterowania.Count > 0)
            {
                _current = _kolejkaDoIterowania.Dequeue();
                return true;
            }

            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
