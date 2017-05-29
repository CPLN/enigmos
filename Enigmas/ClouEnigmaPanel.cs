using Cpln.Enigmos.Enigmas.Components.Clou;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Classe du jeu du clou
    /// </summary>
    class ClouEnigmaPanel : EnigmaPanel
    {
        //Définition/instanciation des valeurs par défaut.
        private Label status = new Label { Location = new Point(15, 15), Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Height = 50, Width=300 };
        private PictureBox table = new PictureBox { BackgroundImage = Properties.Resources.tableCorrect, Size = new Size(960, 480), Location = new Point(0, 400) };
        private EnergyBar bar = new EnergyBar { Location = new Point(700, 25) };
        private Nail nail = new Nail { Location = new Point(370, 77) };
        private IA ia = new IA();
        private Player player = new Player();

        private int round = 1;

        /// <summary>
        /// Constructeur: ajout des contrôles sur l'affichage
        /// </summary>
        public ClouEnigmaPanel()
        {
            Controls.Add(bar);
            Controls.Add(nail);
            Controls.Add(table);
            Controls.Add(status);

            //Mise à jour du label de l'interface
            UpdateStatusLabel();
        }

        #region Méthodes
        /// <summary>
        /// Met à jour les informations du label indiquant le status du jeu.
        /// </summary>
        public void UpdateStatusLabel()
        {
            if(player.IsTurn)
            {
                status.Text = "Manche(s): " + round + "/3 - Gagné(s): " + player.WinnedRound + "/3\nTour: Joueur";
            }
            else if(ia.IsTurn)
            {
                status.Text = "Manche(s): " + round + "/3 - Gagné(s): " + player.WinnedRound +"/3\nTour: IA";
            }
        }

        /// <summary>
        /// Switch les propriétés "Turns" des joueurs.
        /// </summary>
        /// <param name="isPlayerTurn">Le tour est au joueur ?</param>
        public void UpdateTurns(bool isPlayerTurn)
        {
            if(isPlayerTurn)
            {
                player.IsTurn = true;
                ia.IsTurn = false;
            }
            else
            {
                player.IsTurn = false;
                ia.IsTurn = true;
            }
        }

        /// <summary>
        /// Détermine si un joueur gagné la manche.
        /// </summary>
        /// <returns>Vrai ou faux</returns>
        public bool HasWin()
        {
            //Teste si le clou est totalement enfoncé dans la table
            if (nail.Location.Y >= 399)
            {
                //Teste quel joueur a gagné la manche
                if(player.IsTurn)
                {
                    player.WinnedRound++;
                }
                else
                {
                    ia.WinnedRound++;
                }

                //Teste si c'était la dernière manche, le joueur joue de toute façon les 3 manches même s'il a gagné
                //les deux premières, car on interrompt pas le fun !
                if(round == 3)
                {
                    //Si le joueur a gagné au moins 2 manches, il a gagné le jeu
                    if(player.WinnedRound >= 2)
                    {
                        UpdateStatusLabel();
                        MessageBox.Show("La réponse est : C'est de la frappe !", "Bravo !");
                        return true;
                    }
                    else
                    {
                        //Perdu, on restaure les valeurs de variables, l'utilisateur recommence
                        player.WinnedRound = 0;
                        ia.WinnedRound = 0;
                        round = 0;
                    }
                }

                //On augmente le nombre de tours et on update l'UI
                round++;
                UpdateStatusLabel();
                bar.StartCursor();
                nail.ResetPosition();

                return true;
            }

            return false;
        }
        #endregion

        #region Evènements
        /// <summary>
        /// Frappe le clou quand la touche espace est enfoncée, c'est ici que les manches se calculent.
        /// </summary>
        public override void PressKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                #region Tour joueur
                //Ramène l'image de la table devant le clou.
                table.BringToFront();

                //Le joueur tape le clou
                player.Blow(nail, bar.CaptureCursorPower());

                //Vérifie si le joueur a gagné
                if (HasWin())
                {
                    //Stop l'éxecution de la méthode
                    return;
                }

                //C'est au tour de l'IA de jouer
                UpdateTurns(false);
                #endregion
                #region Tour UI
                //Update l'UI
                UpdateStatusLabel();

                //Force l'interface à se refresh avant que l'IA réfléchisse.
                Application.DoEvents();

                //Simule le temps de réflexion de l'IA
                System.Threading.Thread.Sleep(2000);

                //L'IA frappe le clou                
                ia.Blow(nail, ia.CalculateBlowPower(nail, player));

                //Vérifie si l'IA a gagnée
                if (HasWin())
                {
                    //Stop l'éxecution de la méthode
                    return;
                }

                //C'est au tour du joueur de jouer
                UpdateTurns(true);
                UpdateStatusLabel();

                //Relance le curseur sur la barre d'énergie
                bar.StartCursor();
                #endregion
            }
        }

        /// <summary>
        /// Lors du chargement, on restaure avec les valeurs par défaut.
        /// </summary>
        public override void Load()
        {
            ia.WinnedRound = 0;
            player.WinnedRound = 0;
            round = 1;
            UpdateStatusLabel();
            bar.StartCursor();
            nail.ResetPosition();
        }
        #endregion
    }
}
