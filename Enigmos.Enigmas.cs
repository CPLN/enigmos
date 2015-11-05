using Cpln.Enigmos.Enigmas;

namespace Cpln.Enigmos
{
    partial class Enigmos
    {
        private Enigma DebugEnigma()
        {
            // Pour tester, retournez votre énigme ici. La valeur null lancera le jeu normalement.

            return new Enigma(new SimpleEnigmaPanel(), "C'est simple", "Je vous donne la solution : c'est simple", "simple");

            // ---
        }

        private void ReferenceEnigmas()
        {
            // Pour ajouter votre énigme aux autres, ajoutez une ligne à la fin de la liste.
            enigmas.Add(new Enigma(new SimpleEnigmaPanel(), "C'est simple", "Je vous donne la solution : c'est simple", "simple"));
        }
    }
}
