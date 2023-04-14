using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milli_park
{
    internal class Kuyruk
    {
        private int maxSize;
        private MilliPark[] queArray;
        private int front;
        private int rear;
        private int nItems;
        public int NItems
        {
            get { return nItems; }
        }
        public Kuyruk(int s) // constructor
        {
            maxSize = s;
            queArray = new MilliPark[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }
        public void insert(MilliPark j) // put item at rear of queue
        {
            if (rear == maxSize - 1) // deal with wraparound
                rear = -1;
            queArray[++rear] = j; // increment rear and insert
            nItems++; // one more item
        }
        public MilliPark remove() // take item from front of queue
        {
            MilliPark temp = queArray[front++]; // get value and incr front
            if (front == maxSize) // deal with wraparound
                front = 0;
            nItems--; // one less item
            return temp;
        }
        public MilliPark peekFront() // peek at front of queue
        {
            return queArray[front];
        }
        public bool isEmpty() // true if queue is empty
        {
            return (nItems == 0);
        }
        public bool isFull() // true if queue is full
        {
            return (nItems == maxSize);
        }
        public int size() // number of items in queue
        {
            return nItems;
        }
    }
}
