using System;

namespace Chapter_17_Typy_Ogolne___Generyczne.Queues
{
    class QueueInt
    {
        private int DEFAULT_QUEUE_SIZE = 100;
        private int[] data;
        private int head, tail = 0;
        private int numElements = 0;

        public QueueInt()
        {
            this.data = new int[DEFAULT_QUEUE_SIZE];
        }

        public QueueInt(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Must be greater than 0.");
            }
            else
            {
                this.data = new int[size];
            }
        }

        public void Enqueue(int item)
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

        public int Dequeue()
        {
            if (this.numElements == 0)
            {
                throw new Exception("Queue is empty");
            }

            int item = this.data[tail];
            this.tail++;
            this.tail %= this.data.Length;
            this.numElements--;
            return item;
        }
    }
}
