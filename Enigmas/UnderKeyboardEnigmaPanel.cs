﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpln.Enigmos.Enigmas.Components;
using System.Drawing;
using Cpln.Enigmos.Utils;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    
    class UnderKeyboardEnigmaPanel : EnigmaPanel
    {
        //4 18 22 26
        private ShuffleList<Touche> touches;
        private int iWidth = 60;
        private int iHeight = 60;
        private int iLocalisationX = 190;
        private int iLocalisationY = 150;
        private int iLocY;
        private int iLocX;

        public void CreerClavier (List<Touche>touches)
        {
            iLocX = iLocalisationX;
            iLocY = iLocalisationY;
            for (int i = 0; i < 26; i++)
            {
                iLocX += iWidth;
                if (i % 7 == 0)
                {
                    iLocX = iLocalisationX;
                    iLocY += iHeight;
                }
                if (i == 21)
                {
                    iLocX += iWidth;
                }

                Touche touche = touches[i];
                touche.Location = new Point(iLocX, iLocY);

            }
        }

        public UnderKeyboardEnigmaPanel()
        {
            touches = new ShuffleList<Touche>();

            Button reset = new Button();
            Controls.Add(reset);
            reset.Text = "Réinitialiser le clavier";
            reset.Size = new Size(140, 30);
            reset.Click += new EventHandler(Reset);

            for (char i = 'a'; i <= 'z'; i++)
            {
                    Label label = new Label();
                    label.Text = Convert.ToString(i);
                    label.Font = new Font(FontFamily.GenericMonospace, 10);
                    label.AutoSize = true;
                    label.BackColor = Color.Transparent;
                    label.ForeColor = Color.White;

                    Touche touche = new Touche("", iLocX, iLocY, iWidth, iHeight);

                    touche.BackColor = Color.Black;
                    touche.BorderStyle = BorderStyle.Fixed3D;
                    touches.Add(touche);
                    Controls.Add(touche);
                    touche.Controls.Add(label);
            }

            touches.Shuffle();
            CreerClavier(touches);
    }
        private void Reset(object sender, EventArgs e)
        {
            CreerClavier(touches);
        }
    }
}