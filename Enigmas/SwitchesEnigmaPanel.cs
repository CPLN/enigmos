using Cpln.Enigmos.Enigmas;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Cette énigme demande au joueur d'allumer toutes les cases, sachant qu'un clic sur une case bascule la couleur de toutes les cases adjascentes.
    /// </summary>
    class SwitchesEnigmaPanel : EnigmaPanel
    {
        private List<Panel> panels;
    }
}