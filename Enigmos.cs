using Cpln.Utils.Enigmos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    public partial class Enigmos : Form
    {
        private ShuffleList<Enigma> enigmas = new ShuffleList<Enigma>();
        private List<string> solved = new List<string>();
        private Enigma active = null;
        public Enigmos()
        {
            InitializeComponent();

            #if DEBUG
            TopMost = false;
            #endif

            Init();
        }

        private void Init()
        {
            try
            {
                SuspendLayout();

                enigmas = new ShuffleList<Enigma>();
                ReferenceEnigmas();
                enigmas.Shuffle();

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
            catch
            {
                MessageBox.Show("Aucune énigme n'a été trouvée", "Erreur");
                Environment.Exit(1);
            }
        }

        private void Validate(object sender, EventArgs e)
        {
            if (active.CheckAnswer(tbxAnswer.Text))
            {
                solved.Add(active.Title);
                enigmas.Remove(active);
                try {
                    NextEnigma();
                }
                catch (Exception exception)
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
        }

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

        private void Hint(object sender, EventArgs e)
        {
            MessageBox.Show(active.Hint, "Indice");
        }

        private void CheckIntegrity()
        {
            List<string> ids = new List<string>();
            foreach (Enigma enigma in enigmas)
            {
                if (ids.Contains(enigma.Title.ToLower()))
                {
                    throw new IntegrityException(enigma.Title);
                }
                ids.Add(enigma.Title.ToLower());
            }
        }

        private void NextEnigma()
        {
            #if DEBUG
            Enigma debug = DebugEnigma();
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
                throw new Exception("Vous avez terminé le jeu !");
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

        private void SetActive(Enigma enigma)
        {
            mainLayout.Controls.Remove(active);
            active = enigma;
            active.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            active.AutoSize = true;
            mainLayout.Controls.Add(active, 0, 0);

            lblId.Text = active.Title;
        }
    }
}
