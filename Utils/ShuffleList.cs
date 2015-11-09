using System;
using System.Collections.Generic;

namespace Cpln.Enigmos.Utils
{
    /// <summary>
    /// Cette classe permet de créer une liste qu'il sera possible de mélanger.
    /// </summary>
    /// <typeparam name="T">Le type des éléments contenus dans la liste</typeparam>
    class ShuffleList<T> : List<T>
    {
        /// <summary>
        /// Permet de mélanger la liste.
        /// </summary>
        public void Shuffle()
        {
            Shuffle(new Random());
        }

        /// <summary>
        /// Permet de mélanger la liste grâce à un objet Random fourni en paramètre.
        /// </summary>
        /// <param name="random">Un objet aléatoire spécifique</param>
        public void Shuffle(Random random)
        {
            for (int count = Count; count > 0; count--)
            {
                int i = random.Next(count);
                Add(this[i]);
                RemoveAt(i);
            }
        }
    }
}
