using System;
using System.Collections.Generic;

namespace Cpln.Utils.Enigmos
{
    class ShuffleList<T> : List<T>
    {
        public void Shuffle()
        {
            Random random = new Random();
            for (int count = Count; count > 0; count--)
            {
                int i = random.Next(count - 1);
                Add(this[i]);
                RemoveAt(i);
            }
        }
    }
}
