using Cpln.Enigmos.Exceptions;
using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    /// <summary>
    /// Cette classe est la classe contenant toute la vue de l'application.
    /// </summary>
    public partial class Enigmos : Form
    {
        /// <summary>
        /// La liste des énigmes qui n'ont pas encore été résolues.
        /// </summary>
        private List<Enigma> enigmas = new List<Enigma>();
        /// <summary>
        /// La liste des titres des énigmes déjà résolues.
        /// </summary>
        private List<string> solved = new List<string>();
        /// <summary>
        /// L'énigme que l'utilisateur est en train de résoudre.
        /// </summary>
        private Enigma active = null;

        /// <summary>
        /// Constructeur par défaut, instancie une nouvelle série d'énigme et affiche la première.
        /// </summary>
        public Enigmos()
        {
            InitializeComponent();

            #if DEBUG
            #endif
            TopMost = false;

            Init();
        }

        /// <summary>
        /// Méthode d'initialisation ou de réinitialisation, appelée au début et au redémarrage de l'application.
        /// </summary>
        private void Init()
        {
            try
            {
                SuspendLayout();

                enigmas = EnigmaReferencer.ReferenceEnigmas();

                solved = new List<string>();

                CheckIntegrity();

                NextEnigma();

                ResumeLayout();
            }
            catch (IntegrityException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }
            catch (NoAnswerException e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(1);
            }
            catch (EndGameException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Cette méthode teste si le contenu de la TextBox de réponse coïncide avec la réponse attendue. Si c'est le cas, l'énigme suivante est affichée.
        /// </summary>
        /// <param name="sender">Le bouton "Valider"</param>
        /// <param name="e">Les évènements liés au clic</param>
        private void Validate(object sender, EventArgs e)
        {
            if (active.CheckAnswer(tbxAnswer.Text))
            {
                solved.Add(active.Title);
                enigmas.Remove(active);
                try
                {
                    NextEnigma();
                }
                catch (EndGameException exception)
                {
                    if (MessageBox.Show(exception.Message, "Bravo !", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    {
                        Init();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            tbxAnswer.Text = "";
            active.Focus();
        }

        /// <summary>
        /// Cette méthode laisse momentanément de côté l'énigme courante pour afficher la suivante.
        /// </summary>
        /// <param name="sender">Le bouton "Passer"</param>
        /// <param name="e">Les évènements liés au clic</param>
        private void Skip(object sender, EventArgs e)
        {
            try
            {
                NextEnigma();
            }
            catch
            {
                MessageBox.Show("Aucune énigme n'a été trouvée", "Erreur");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Cette méthode affiche un MessageBox contenant l'indice relatif à l'énigme.
        /// </summary>
        /// <param name="sender">Le bouton "?"</param>
        /// <param name="e">Les évènements liés au clic</param>
        private void Hint(object sender, EventArgs e)
        {
            MessageBox.Show(active.Hint, "Indice");
        }

        /// <summary>
        /// Cette méthode vérifie l'intégrité de l'application : deux énigmes ne peuvent avoir le même nom.
        /// </summary>
        private void CheckIntegrity()
        {
            List<string> titles = new List<string>();
            foreach (Enigma enigma in enigmas)
            {
                if (titles.Contains(enigma.Title))
                {
                    throw new IntegrityException(enigma.Title);
                }
                titles.Add(enigma.Title);
            }
        }

        /// <summary>
        /// Cette méthode trouve et affiche l'énigme suivante celle qui se trouve actuellement à l'écran et effectue le remplacement.
        /// </summary>
        private void NextEnigma()
        {
            tbxAnswer.Text = "";

            #if DEBUG
            Enigma debug = EnigmaReferencer.DebugEnigma();
            if (debug != null)
            {
                if (active != null)
                {
                    Environment.Exit(0);
                }
                SetActive(debug);
                return;
            }
            #endif

            if (enigmas.Count == 0)
            {
                throw new EndGameException();
            }

            if (active == null)
            {
                SetActive(enigmas[enigmas.Count - 1]);
            }
            Enigma next = enigmas[(enigmas.IndexOf(active) + 1) % enigmas.Count];
            while (next != active)
            {
                if (next.IsPlayable(solved))
                {
                    lblId.Text = next.Title;

                    SetActive(next);
                    return;
                }
                next = enigmas[(enigmas.IndexOf(next) + 1) % enigmas.Count];
            }
            MessageBox.Show("C'est la dernière énigme disponible.", "Bientôt fini !");
        }

        /// <summary>
        /// Cette méthode effectue concrètement le changement d'énigme à l'écran.
        /// </summary>
        /// <param name="enigma">La nouvelle énigme</param>
        private void SetActive(Enigma enigma)
        {
            if (active != null)
            {
                active.Unload();
            }
            mainLayout.Controls.Remove(active);
            active = enigma;
            active.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            active.AutoSize = true;
            mainLayout.Controls.Add(active, 0, 0);

            ActiveControl = enigma;
            enigma.Load();

            lblId.Text = active.Title;
        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
