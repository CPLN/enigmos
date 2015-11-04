using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    public partial class Enigmos : Form
    {
        private List<Enigma> enigmas = new List<Enigma>();
        private List<string> solved = new List<string>();
        private Enigma active = null;
        public Enigmos()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                SuspendLayout();

                enigmas = new List<Enigma>();
                ReferenceEnigmas();
                ShuffleEnigmas();
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
                solved.Add(active.Id);
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

        private void CheckIntegrity()
        {
            List<string> ids = new List<string>();
            foreach (Enigma enigma in enigmas)
            {
                if (ids.Contains(enigma.Id.ToLower()))
                {
                    throw new IntegrityException(enigma.Id);
                }
                ids.Add(enigma.Id.ToLower());
            }
        }

        private void ShuffleEnigmas()
        {
            List<Enigma> shuffled = new List<Enigma>();
            Random random = new Random();
            while (enigmas.Count > 0)
            {
                int i = random.Next(enigmas.Count);
                shuffled.Add(enigmas[i]);
                enigmas.RemoveAt(i);
            }
            enigmas = shuffled;
        }

        private void NextEnigma()
        {
            #if DEBUG
            Enigma debug = DebugEnigma();
            if (debug != null)
            {
                SetActive(debug);
                return;
            }
            #endif

            if (active == null)
            {
                SetActive(enigmas[enigmas.Count - 1]);
            }
            Enigma next = enigmas[(enigmas.IndexOf(active) + 1) % enigmas.Count];
            while (next != active)
            {
                next = enigmas[(enigmas.IndexOf(next) + 1) % enigmas.Count];
                if (next.IsPlayable(solved))
                {
                    lblId.Text = next.Id;

                    SetActive(next);
                    return;
                }
            }
            throw new Exception("Vous avez terminé le jeu !");
        }

        private void SetActive(Enigma enigma)
        {
            mainLayout.Controls.Remove(active);
            active = enigma;
            active.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            active.AutoSize = true;
            active.BackColor = Color.White;
            mainLayout.Controls.Add(active, 0, 0);

            lblId.Text = active.Id;
        }
    }
}
