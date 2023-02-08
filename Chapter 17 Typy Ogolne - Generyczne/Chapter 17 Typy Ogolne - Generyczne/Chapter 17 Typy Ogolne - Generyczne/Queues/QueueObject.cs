using System;

namespace Chapter_17_Typy_Ogolne___Generyczne.Queues
{

    class QueueObject
    {
        private int DEFAULT_QUEUE_SIZE = 100;
        private object[] data;
        private int head, tail = 0;
        private int numElements = 0;

        public QueueObject()
        {
            this.data = new object[DEFAULT_QUEUE_SIZE];
        }

        public QueueObject(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Must be greater than 0.");
            }
            else
            {
                this.data = new object[size];
            }
        }

        public void Enqueue(object item)
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

        public object Dequeue()
        {
            if (this.numElements == 0)
            {
                throw new Exception("Queue is empty");
            }

            object item = this.data[tail];
            this.tail++;
            this.tail %= this.data.Length;
            this.numElements--;
            return item;
        }
    }
}


