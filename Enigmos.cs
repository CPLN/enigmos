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
        private Enigma active;
        public Enigmos()
        {
            InitializeComponent();
            AcceptButton = btnValidate;
            ReferenceEnigmas();
            try
            {
                active = NextEnigma();
                active.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                active.Location = new Point(12, 12);
                active.Size = new Size(1000, 429);
                active.BackColor = Color.White;
                Controls.Add(active);
            }
            catch
            {
                MessageBox.Show("Aucune énigme n'a été trouvée", "Erreur");
                Environment.Exit(1);
            }
        }

        private void Init()
        {
            enigmas = new List<Enigma>();
            ReferenceEnigmas();
            solved = new List<string>();
            active = NextEnigma();
        }

        private void Validate(object sender, EventArgs e)
        {
            if (active.CheckAnswer(tbxAnswer.Text))
            {
                solved.Add(active.Id);
                enigmas.Remove(active);
                try {
                    active = NextEnigma();
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
                active = NextEnigma();
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
                    throw new Exception("Erreur : deux enigmes ou plus ont le nom \"" + enigma.Id + "\".");
                }
                ids.Add(enigma.Id.ToLower());
            }
        }
    }
}
