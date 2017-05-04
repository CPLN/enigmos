﻿using System;
using System.Drawing;
using System.Windows.Forms;
namespace Cpln.Enigmos.Enigmas
{
    public class SingesEnigmaPanel : EnigmaPanel
    {
        //Déclarations des variables
        bool bEtatSinge1 = false;
        bool bEtatSinge2 = false;
        bool bEtatSinge3 = false;
        Label Reponse = new Label();
        Label lblEnigme = new Label();
        Timer tSinge = new Timer();
        private Button[] btnReponse = new Button[5];
        private PictureBox[] tblPbx = new PictureBox[3];
        string strMot = "BANANAS"; //Réponse de l'énigme.
        public SingesEnigmaPanel()
        {
            //Initialisation des PituresBox
            for (int i = 0; i < tblPbx.Length; i++)
            {
                tblPbx[i] = new PictureBox();
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

            //Formatages des pictures box et insertions de l'image du singe
            foreach (PictureBox pbx in tblPbx)
            {
                pbx.Image = Properties.Resources.SingeBleuCymbalesOuvertes;
                pbx.Size = Properties.Resources.SingeBleuCymbalesOuvertes.Size;
                pbx.BackColor = Color.Transparent;
                Controls.Add(pbx);
            }
            //Placement des PictureBox
            tblPbx[0].Location = new Point(200, 500);
            tblPbx[1].Location = new Point(600, 500);
            tblPbx[2].Location = new Point(1000, 500);

            //Création des boutons
            Button bouton = new Button();
            bouton.Size = new Size(50, 80);
            bouton.Click += new EventHandler(bouton_Click);
            for (int i = 0; i < 5; i++)
            {
                Controls.Remove(btnReponse[i]);
                btnReponse[i] = new Button();
            }
            //Placement des boutons
            btnReponse[0].Location = new Point(450, 800);
            btnReponse[1].Location = new Point(600, 850);
            btnReponse[2].Location = new Point(750, 800);
            btnReponse[3].Location = new Point(900, 850);
            btnReponse[4].Location = new Point(1050, 800);

            //Attribution d'une taille pour les boutons
            for (int i = 0; i < 5; i++)
            {
                btnReponse[i].Width = 50;
                btnReponse[i].Height = 30;
                //btnReponse[i].Font = new Font(FontFamily.GenericSansSerif, 24, FontStyle.Bold);
                btnReponse[i].FlatStyle = FlatStyle.System;
                Controls.Add(btnReponse[i]);
            }
        }
        //Evènement sur le clic sur un bouton.
        private void bouton_Click(object sender, EventArgs e)
        {
   
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            tblPbx[1].Image = Properties.Resources.SingeBleuCymbaleFermees;
        }
        private void Initialiser()
        {
            tSinge.Tick += new EventHandler(TimerEventProcessor);
            tSinge.Interval = 500;
            tSinge.Start();
        }
        public override void Load()
        {
            Initialiser();
        }
        public override void Unload()
        {
            tSinge.Stop();
        }
    }
}
