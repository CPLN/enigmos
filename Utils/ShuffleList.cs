using System;
using System.Collections.Generic;

namespace Cpln.Utils.Enigmos
{
    class ShuffleList<T> : List<T>
    {
        public void Shuffle()
        {
            List<T> shuffled = new List<T>();
            Random random = new Random();
            while (Count > 0)
            {
                int i = random.Next(Count);
                shuffled.Add(this[i]);
                RemoveAt(i);
            }
            foreach (T item in shuffled)
            {
                Add(item);
            }
        }
    }
}
