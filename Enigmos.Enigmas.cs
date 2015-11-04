using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    partial class Enigmos
    {
        private void ReferenceEnigmas()
        {
        }

        private Enigma NextEnigma()
        {
            #if DEBUG
            // Retournez votre enigme ici

            #endif
            Random random = new Random();
            enigmas.OrderBy(item => random.Next());
            foreach (Enigma enigma in enigmas)
            {
                if (enigma.IsPlayable(solved))
                {
                    return enigma;
                }
            }
            throw new Exception("Vous avez terminé le jeu !");
        }
    }
}
