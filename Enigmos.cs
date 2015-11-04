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
            Init();
        }

        private void Init()
        {
            try
            {
                SuspendLayout();

                enigmas = new List<Enigma>();
                ReferenceEnigmas();
                solved = new List<string>();

                CheckIntegrity();

                active = NextEnigma();

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
                    throw new IntegrityException(enigma.Id);
                }
                ids.Add(enigma.Id.ToLower());
            }
        }

        private List<Enigma> ShuffleEnigmas(List<Enigma> input)
        {
            List<Enigma> shuffled = new List<Enigma>();
            Random random = new Random();
            while (input.Count > 0)
            {
                int i = random.Next(input.Count);
                shuffled.Add(enigmas[i]);
                input.RemoveAt(i);
            }
            return shuffled;
        }
    }
}
