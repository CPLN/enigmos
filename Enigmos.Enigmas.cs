using Cpln.Enigmos.Enigmas;

namespace Cpln.Enigmos
{
    partial class Enigmos
    {
        private Enigma DebugEnigma()
        {
            // Pour tester, retournez votre énigme ici. La valeur null lancera le jeu normalement.

            //return new Enigma(new SimpleEnigmaPanel(), "C'est simple", "Pas d'indice, la solution est simple !");
            return null;

            // ---
        }

        private void ReferenceEnigmas()
        {
            // Pour ajouter votre énigme aux autres, ajoutez une ligne à la fin de la liste.
            enigmas.Add(new Enigma(new SimpleEnigmaPanel(), "C'est simple", "Pas d'indice, la solution est simple !"));
            enigmas.Add(new Enigma(new SimplePuzzleEnigmaPanel(), "Puzzle", "Remetez les pièces à leur place"));
        }
    }
}
