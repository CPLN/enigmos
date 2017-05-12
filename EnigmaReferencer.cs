﻿using Cpln.Enigmos.Enigmas;
using Cpln.Enigmos.Utils;
using System.Collections.Generic;

namespace Cpln.Enigmos
{
    /// <summary>
    /// Cette classe permet de référencer toutes les énigmes, ainsi que de tester une énigme lors du débugging.
    /// </summary>
    public abstract class EnigmaReferencer
    {
        /// <summary>
        /// Cette méthode permet de n'afficher que l'énigme qu'on souhaite tester. Si null est renvoyé, alors l'application démarre normalement.
        /// </summary>
        /// 
        /// <remarks>Lorsque le programme est en mode RELEASE, cette méthode n'est pas appelée.</remarks>
        /// <returns>L'énigme à afficher</returns>
        public static Enigma DebugEnigma()
        {
            return null;
        }

        /// <summary>
        /// Cette méthode crée une liste contenant les différentes énigmes et la mélange avant de la retourner.
        /// </summary>
        /// <returns>Une liste d'énigme mélangées</returns>
        public static List<Enigma> ReferenceEnigmas()
        {
            ShuffleList<Enigma> enigmas = new ShuffleList<Enigma>();

            enigmas.Add(new Enigma(new AppuieReponseEnigmaPanel(), "Appuie sur la réponse"));
            enigmas.Add(new Enigma(new BeatThemAllEnigmaPanel(), "Beat them all"));
            enigmas.Add(new Enigma(new BusEnigmaPanel(), "Sens du bus"));
            enigmas.Add(new Enigma(new CaseVideEnigmaPanel(), "Et ben non"));
            enigmas.Add(new Enigma(new CharadeEnigmaPanel(), "Charade"));
            enigmas.Add(new Enigma(new ClicRapideEnigmaPanel(), "Clic-rapide"));
            enigmas.Add(new Enigma(new CodeBarreEnigmaPanel(), "Le code barre"));
            enigmas.Add(new Enigma(new DingbatEnigmaPanel(), "Jeu de mot"));
            enigmas.Add(new Enigma(new FruitsEnigmaPanel(), "Calcul"));
            enigmas.Add(new Enigma(new HazardEnigmaPanel(), "Hazard"));
            enigmas.Add(new Enigma(new HiddenCharacterEnigmalPanel(), "Caractère caché"));
            enigmas.Add(new Enigma(new InvisibleAnwerEnigmaPanel(), "Invisible Answer"));
            enigmas.Add(new Enigma(new LettreHaute(), "Quelle est la plus haute ?"));
            enigmas.Add(new Enigma(new MemoireDesChiffresEnigmaPanel(), "Souviens toi"));
            enigmas.Add(new Enigma(new MorpionEnigmaPanel(), "Morpion"));
            enigmas.Add(new Enigma(new NbrCarresEnigmaPanel(), "Nombre de carrés"));
            enigmas.Add(new Enigma(new NfsEnigmaPanel(), "Need For Speed"));
            enigmas.Add(new Enigma(new NinePointsEnigmaPanel(), "9 Points"));
            enigmas.Add(new Enigma(new OiseauxEnigmaPanel(), "Le plus long mot"));
            enigmas.Add(new Enigma(new OpenDoorEnigmaPanel(), "Ouvrez la porte !"));
            enigmas.Add(new Enigma(new OuEstLaReponseEnigmaPanel(), "Où est la réponse ?"));
            enigmas.Add(new Enigma(new PenduEnigmaPanel(), "Le jeu du pendu"));
            enigmas.Add(new Enigma(new PhoqueEnigmaPanel(), "Chop' les poissons"));
            enigmas.Add(new Enigma(new RebusEnigmaPanel(), "Rébus"));
            enigmas.Add(new Enigma(new RectangleEnigmaPanel(), "Trouve le rectangle"));
            enigmas.Add(new Enigma(new ReflexeEnigmaPanel(), "Reflexe"));
            enigmas.Add(new Enigma(new SeptDifferencesEnigmaPanel(), "Le jeu des 7 différences"));
            enigmas.Add(new Enigma(new SimpleEnigmaPanel(), "C'est simple"));
            enigmas.Add(new Enigma(new SimplePuzzleEnigmaPanel(), "Puzzle"));
            enigmas.Add(new Enigma(new TapeTaupeEnigmaPanel(), "Tape-taupe"));
            enigmas.Add(new Enigma(new TrouverEnigmaPanel(), "Trouver Cristiano"));
            enigmas.Add(new Enigma(new ZombieInvasionEnigmaPanel(), "ZombieInvasion"));

            Enigma runEnigma = new Enigma(new RunEnigmaPanel(), "Roux run");
            enigmas.Add(runEnigma);
            Enigma runEnigmaInverse = new Enigma(new RunEnigmaPanel(true), "Roux run encore");
            runEnigmaInverse.AddPrerequisite(runEnigma);
            enigmas.Add(runEnigmaInverse);

            enigmas.Shuffle();
            return enigmas;
        }
        
    }
}
