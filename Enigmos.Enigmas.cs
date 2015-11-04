using System;
using System.Collections.Generic;
using System.Drawing;
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
            // Pour ajouter votre énigme aux autres, ajoutez une ligne à la fin de la liste.
            enigmas.Add(new Enigma("Démo", new Panel(), "1234"));
            enigmas.Add(new Enigma("Démo 2", new Panel(), "1234", new string[] { "Démo" }));
        }

        private Enigma DebugEnigma(){
            // Pour tester, retournez votre énigme ici. La valeur null lancera le jeu normalement.

            return null;

            // ---
        }
    }
}
