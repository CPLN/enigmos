﻿using Cpln.Enigmos.Enigmas;
using Cpln.Enigmos.Enigmas.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    /// <summary>
    /// Cette énigme demande au joueur d'allumer toutes les cases, sachant qu'un clic sur une case bascule la couleur de toutes les cases adjascentes.
    /// </summary>
    class SwitchesEnigmaPanel : EnigmaPanel, LightController
    {
        private int size;
        private Light[][] lights;
        private Label answer;

        public SwitchesEnigmaPanel(int size, string textAnswer)
        {
            this.size = size;
            lights = new Light[size][];
            for (int x = 0; x < size; x++)
            {
                lights[x] = new Light[size];
                for (int y = 0; y < size; y++)
                {
                    lights[x][y] = new Light(this);
                }
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Light light = lights[x][y];

                    if (x > 0)
                    {
                        light.AjouterVoisin(lights[x - 1][y]);
                    }

                    if (y > 0)
                    {
                        light.AjouterVoisin(lights[x][y - 1]);
                    }

                    if (x < size - 1)
                    {
                        light.AjouterVoisin(lights[x + 1][y]);
                    }

                    if (y < size - 1)
                    {
                        light.AjouterVoisin(lights[x][y + 1]);
                    }

                    light.Location = new Point(110 * x+50, 110 * y+50);
                    Controls.Add(light);
                }
            }

            Width = 110 * size + 100;
            Height = 110 * size + 100;

            Font font = new Font("Arial", 30);
            this.answer = new Label() { Text = textAnswer, Visible = false, Font = font, Left = 0, Top = 0, Width = Width, Height = 50, TextAlign = ContentAlignment.MiddleCenter };
            this.answer.BringToFront();
            Controls.Add(this.answer);
        }

        public override void Load()
        {
            Random rand = new Random();
            for (int i = 0; i < size*size; i++)
            {
                Light light = lights[rand.Next(size)][rand.Next(size)];
                light.CliquerVoisins();
            }
        }

        public void Check()
        {
            bool finished = true;
            foreach(Light[] row in lights)
            {
                foreach(Light light in row)
                {
                    if (!light.Allume)
                    {
                        finished = false;
                        break;
                    }
                }
                if (!finished)
                {
                    break;
                }
            }
            answer.Visible = finished;
        }
    }
}