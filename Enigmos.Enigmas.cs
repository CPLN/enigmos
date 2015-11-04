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

        private Enigma NextEnigma()
        {
            #if DEBUG
            // Pour tester, retournez votre énigme ici

            // return new Enigma("Un titre", new PanelAAfficher(), "reponse");

            // ---
            #endif

            enigmas = ShuffleEnigmas(enigmas);
            foreach (Enigma enigma in enigmas)
            {
                if (enigma.IsPlayable(solved))
                {
                    lblId.Text = enigma.Id;

                    mainLayout.Controls.Remove(active);
                    enigma.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    enigma.AutoSize = true;
                    enigma.BackColor = Color.White;
                    mainLayout.Controls.Add(enigma, 0, 0);
                    return enigma;
                }
            }
            throw new Exception("Vous avez terminé le jeu !");
        }
    }
}
