using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace milli_park
{
    internal class Yigit
    {
        private int maxSize;
        private MilliPark[] stackArray;
        private int top;
        public int Top
        {
            get { return top; }
        }

        public Yigit(int N)
        {
            maxSize = N;
            stackArray = new MilliPark[maxSize];
            top=-1;

        }
        public void push(MilliPark mp)
        {
            stackArray[++top] = mp;
        }
        public MilliPark pop()
        {
            return stackArray[top--];
        }
        public MilliPark peek() // peek at top of stack
        {
            return stackArray[top];
        }
        public bool isEmpty() // true if stack is empty
        {
            return (top == -1);
        }
        //--------------------------------------------------------------
        public bool isFull() // true if stack is full
        {
            return (top == maxSize - 1);
        }


    }
    }


