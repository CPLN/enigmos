using System;
using System.Collections.Generic;

namespace Cpln.Enigmos.Utils
{
    class ShuffleList<T> : List<T>
    {
        public void Shuffle()
        {
            Random random = new Random();
            for (int count = Count; count > 0; count--)
            {
                int i = random.Next(count);
                Add(this[i]);
                RemoveAt(i);
            }
        }
    }
}
