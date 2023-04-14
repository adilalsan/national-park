using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace milli_park
{
    internal class OncelikliKuyruk
    {
        public List<MilliPark> list;
        public int Count { get { return list.Count; } }

        public OncelikliKuyruk()
        {
            list = new List<MilliPark>();
        }

        public OncelikliKuyruk(int count)
        {
            list = new List<MilliPark>(count);
        }


        public void Enqueue(MilliPark x)
        {
            list.Add(x);
            int i = Count - 1;

            while (i > 0)
            {
                int p = (i - 1) / 2;
                if (list[p].Yuzolcumu <= x.Yuzolcumu) break;

                list[i] = list[p];
                i = p;
            }

            if (Count > 0) list[i] = x;
        }

        public MilliPark Dequeue()
        {
            MilliPark min = Peek();
            MilliPark root = list[Count - 1];
            list.RemoveAt(Count - 1);

            int i = 0;
            while (i * 2 + 1 < Count)
            {
                int a = i * 2 + 1;
                int b = i * 2 + 2;
                int c = b < Count && list[b].Yuzolcumu < list[a].Yuzolcumu ? b : a;

                if (list[c].Yuzolcumu >= root.Yuzolcumu) break;
                list[i] = list[c];
                i = c;
            }

            if (Count > 0) list[i] = root;
            return min;
        }

        public MilliPark Peek()
        {
            if (Count == 0) throw new InvalidOperationException("Queue is empty.");
            return list[0];
        }

        public void Clear()
        {
            list.Clear();
        }
    
}
}
