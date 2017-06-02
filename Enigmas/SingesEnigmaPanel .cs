using System;
using System.Drawing;
using System.Windows.Forms;
using Cpln.Enigmos.Enigmas.Components;
using System.Collections.Generic;

namespace Cpln.Enigmos.Enigmas

{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        //Déclarations des variables
        Label Reponse = new Label();
        Label lblEnigme = new Label();
        Timer tChrono = new Timer();
        private PictureBox[] pbxReponse = new PictureBox[6];
        private List<PictureBox> Tpbx = new List<PictureBox>();
        List<Singe> Tsinge = new List<Singe>();
        private Interaction[][] interactions = new Interaction[6][];


        public SingesEnigmaPanel()
        {
            //Initialisation des singes + placement
            Tsinge.Add(new Singe(200, Properties.Resources.SingeDjembeD, Properties.Resources.SingeDjembeG));
            Tsinge.Add(new Singe(600, Properties.Resources.SingeBleuCymbalesOuvertes, Properties.Resources.SingeBleuCymbalesFermees));
            Tsinge.Add(new Singe(1000, Properties.Resources.SingeBleuCymbalesOuvertes, Properties.Resources.SingeBleuCymbalesFermees));

            //PictureBox
            foreach (Singe S in Tsinge)
            {
                Controls.Add(S);
            }

            //Génération du titre.
            lblEnigme.Text = "Jeu des 3 Singes";
            lblEnigme.Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
            lblEnigme.Dock = DockStyle.Top;
            lblEnigme.TextAlign = ContentAlignment.TopCenter;
            Controls.Add(lblEnigme);
            //Image de base.
            BackgroundImage = Properties.Resources.jungle;
            Size = Properties.Resources.jungle.Size;

            //Création des boutons
            PictureBox pbx = new PictureBox();
            pbx.Size = new Size(50, 80);
            for (int i = 0; i < pbxReponse.Length; i++)
            {
                pbxReponse[i] = new PictureBox();
                pbxReponse[i].Click += new EventHandler(pbxReponse_Click);
            }
            //Placement des boutons
            TableLayoutPanel centrage = new TableLayoutPanel();

            centrage.ColumnCount = 3;
            centrage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            centrage.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centrage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            centrage.Location = new Point(0, 800);
            centrage.Size = new Size(Width, 130);
            centrage.BackColor = Color.Transparent;

            TableLayoutPanel table = new TableLayoutPanel();

            //Attribution d'une taille pour les boutons
            for (int i = 0; i < 6; i++)
            {
                pbxReponse[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pbxReponse[i].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                pbxReponse[i].BackgroundImage = Properties.Resources.troisBananes;
                //pbxReponse[i].BackColor = Color.Transparent;
                pbxReponse[5].BackgroundImage = Properties.Resources.reset;
            }

            

            table.ColumnCount = 5;
            table.RowCount = 3;

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            table.BackColor = Color.Transparent;
            table.Width = 650;
            table.Height = 130;
            table.Padding = new Padding(0);
            table.Margin = new Padding(0);

            table.Controls.Add(pbxReponse[0], 0, 0);
            table.Controls.Add(pbxReponse[1], 2, 0);
            table.Controls.Add(pbxReponse[2], 4, 0);
            table.Controls.Add(pbxReponse[3], 1, 1);
            table.Controls.Add(pbxReponse[4], 3, 1);
            table.Controls.Add(pbxReponse[5], 2, 2);
            table.Location = new Point(450, 800);

            centrage.Controls.Add(table, 1, 0);
            Controls.Add(centrage);

            for (int i = 0; i < interactions.Length; i++)
            {
                interactions[i] = new Interaction[3];
            }

            interactions[0][0] = Interaction.ACTIVER;
            interactions[0][1] = Interaction.DESACTIVER;
            interactions[0][2] = Interaction.RIEN;

            interactions[1][0] = Interaction.RIEN;
            interactions[1][1] = Interaction.ACTIVER;
            interactions[1][2] = Interaction.RIEN;

            interactions[2][0] = Interaction.DESACTIVER;
            interactions[2][1] = Interaction.RIEN;
            interactions[2][2] = Interaction.ACTIVER;

            interactions[3][0] = Interaction.DESACTIVER;
            interactions[3][1] = Interaction.ACTIVER;
            interactions[3][2] = Interaction.RIEN;

            interactions[4][0] = Interaction.RIEN;
            interactions[4][1] = Interaction.ACTIVER;
            interactions[4][2] = Interaction.DESACTIVER;

            interactions[5][0] = Interaction.DESACTIVER;
            interactions[5][1] = Interaction.DESACTIVER;
            interactions[5][2] = Interaction.DESACTIVER;
        }

        //Evènement sur click des pbx.
        private void pbxReponse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pbxReponse.Length; i++)
            {
                if (pbxReponse[i] == sender)
                {
                    ChangerSinges(interactions[i]);
                    break;
                }
            }

            //Réponse de l'énigme            
            if (Tsinge[0].bEtat && Tsinge[1].bEtat && Tsinge[2].bEtat)
            {
                tChrono.Stop();
                Tsinge[0].Image = Properties.Resources.SingeDeDosBA;
                Tsinge[1].Image = Properties.Resources.SingeDeDosNA;
                Tsinge[2].Image = Properties.Resources.SingeDeDosNA;
            }
        }

        private void ChangerSinges(Interaction[] interaction)
        {
            for (int i = 0; i < interaction.Length; i++)
            {
                switch (interaction[i])
                {
                    case Interaction.ACTIVER:
                        Tsinge[i].Activer();
                        break;

                    case Interaction.DESACTIVER:
                        Tsinge[i].Desactiver();
                        break;

                    case Interaction.INVERSER:
                        Tsinge[i].Inverser();
                        break;

                    default:
                        break;
                }
            }
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            foreach (Singe S in Tsinge)
            {
                S.Alterner();
            }
        }

        /// <summary>
        /// Initialise le timer, créer une intervalle d'une demi-seconde, et le démarre
        /// </summary>
        public override void Load()
        {
            tChrono.Tick += new EventHandler(TimerEventProcessor);
            tChrono.Interval = 500;
            tChrono.Start();
        }
        public override void Unload()
        {
            tChrono.Stop();
        }
    }
}

