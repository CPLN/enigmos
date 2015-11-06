using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpln.Enigmos
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
