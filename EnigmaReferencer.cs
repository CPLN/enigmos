using Cpln.Enigmos.Enigmas;
using Cpln.Enigmos.Utils;
using System.Collections.Generic;

namespace Cpln.Enigmos
{
    class EnigmaReferencer
    {
        public static Enigma DebugEnigma()
        {
            // Pour tester, retournez votre énigme ici. La valeur null lancera le jeu normalement.

            //return new Enigma(new SimpleEnigmaPanel(), "C'est simple", "Pas d'indice, la solution est simple !");
            return null;

            // ---
        }

        public static List<Enigma> ReferenceEnigmas()
        {
            ShuffleList<Enigma> enigmas = new ShuffleList<Enigma>();

            // Pour ajouter votre énigme aux autres, ajoutez une ligne à la fin de la liste.
            enigmas.Add(new Enigma(new SimpleEnigmaPanel(), "C'est simple"));
            enigmas.Add(new Enigma(new SimplePuzzleEnigmaPanel(), "Puzzle"));

            enigmas.Shuffle();
            return enigmas;
        }
    }
}
