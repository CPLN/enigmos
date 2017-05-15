using Cpln.Enigmos.Enigmas;
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
    class SwitchesEnigmaPanel : EnigmaPanel
    {
        private int size;
        private Light[][] panels;

        public SwitchesEnigmaPanel(int size)
        {
            this.size = size;
            panels = new Light[size][];
            for (int x = 0; x < size; x++)
            {
                panels[x] = new Light[size];
                for (int y = 0; y < size; y++)
                {
                    panels[x][y] = new Light();
                }
            }

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Light light = panels[x][y];

                    if (x > 0)
                    {
                        light.AjouterVoisin(panels[x - 1][y]);
                    }

                    if (y > 0)
                    {
                        light.AjouterVoisin(panels[x][y - 1]);
                    }

                    if (x < size - 1)
                    {
                        light.AjouterVoisin(panels[x + 1][y]);
                    }

                    if (y < size - 1)
                    {
                        light.AjouterVoisin(panels[x][y + 1]);
                    }

                    light.Location = new Point(110 * x, 110 * y);
                    Controls.Add(light);
                }
            }
        }
        public override void Load()
        {
            Random rand = new Random();
            for (int i = 0; i < 5 * size; i++)
            {
                Light light = panels[rand.Next(size)][rand.Next(size)];
                light.Cliquer();
            }
        }
    }
}