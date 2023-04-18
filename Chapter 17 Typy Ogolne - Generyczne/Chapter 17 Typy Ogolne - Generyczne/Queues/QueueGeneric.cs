using System;

namespace Chapter_17_Typy_Ogolne___Generyczne.Queues
{
    // Parametr 'T' może być dowolnym, poprawnym identyfikatorem C# ale najczęściej jest pojedynczy znak 'T'.
    class QueueGeneric<T>
    {
        private int DEFAULT_QUEUE_SIZE = 100;
        private T[] data; //Tablicajest typem 'T' a 'T' jest parametrem typu
        private int head, tail = 0;
        private int numElements = 0;

        public QueueGeneric()
        {
            this.data = new T[DEFAULT_QUEUE_SIZE];
        }

        public QueueGeneric(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Must be greater than 0.");
            }
            else
            {
                this.data = new T[size];
            }
        }

        public void Enqueue(T item)
        {
            if (this.numElements >= this.data.Length)
            {
                throw new Exception("Queue is full");
            }

            this.data[head] = item;
            this.head++;
            this.head %= this.data.Length;
            this.numElements++;
        }

        public T Dequeue()
        {
            if (this.numElements == 0)
            {
                throw new Exception("Queue is empty");
            }

            T item = this.data[tail];
            this.tail++;
            this.tail %= this.data.Length;
            this.numElements--;
            return item;
        }
    }
}
