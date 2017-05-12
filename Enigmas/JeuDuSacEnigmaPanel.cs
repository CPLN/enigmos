using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas
{
    class JeuDuSacEnigmaPanel : EnigmaPanel
    {

        PictureBox[] aPBMurs = new PictureBox[9]; //ce tableau contient les murs
        PictureBox[] aPBEnnemis = new PictureBox[5]; //celui ci les ennemis
        PictureBox[] aPBPapier = new PictureBox[7];//et celui là les papiers à récupérer
        PictureBox pbJoueur = new PictureBox();

        List<List<string>> listCoordMur = new List<List<string>>();//et toutes les informations individuelles des murs sont stocké ici
        List<List<string>> listCoordEnnemis = new List<List<string>>();
        List<List<string>> listCoordPapier = new List<List<string>>();
        //ne pas oublier de rajouter le joueur

        String[,] ADirectioEnnemis = new string[5, 2] { { "avancer", "X" }, { "avancer", "Y" }, { "avancer", "Y" }, { "avancer", "X" }, { "avancer", "X" } };//tableau qui contient les directives de déplacement
        //Je l'ai mis ici, car si il est dans le "tick" il se réinitialise à chaque fois
        int iPapier = 0;//compteur qui permet de determiner l'avancement du joueur dans la découverte du mot de passe
        string[] AStrCodeSecret = new string[7] { "si", "c'est", "un", "oeuf", "c'est", "un", "vin" };
        Timer timer1 = new Timer();

        public JeuDuSacEnigmaPanel()
        {
        }

        public override void Load()
        {           
            listCoordMur = RemplissageDeCord(Properties.Resources.Murcoord, listCoordMur);
            listCoordEnnemis = RemplissageDeCord(Properties.Resources.EnnemisCoord, listCoordEnnemis);
            listCoordPapier = RemplissageDeCord(Properties.Resources.papierCoord, listCoordPapier);

            //auomatiser tout ça par la suite
            aPBMurs = RemplissageProprietePictureBox(aPBMurs, listCoordMur);
            foreach (PictureBox mur in aPBMurs)
            { Controls.Add(mur); }

            aPBEnnemis = RemplissageProprietePictureBox(aPBEnnemis, listCoordEnnemis);
            foreach (PictureBox ennemi in aPBEnnemis)
            { Controls.Add(ennemi); }

            aPBPapier = RemplissageProprietePictureBox(aPBPapier, listCoordPapier);
            foreach (PictureBox papier in aPBPapier)
            { Controls.Add(papier); }

            aPBPapier[6].Enabled = false;
            aPBPapier[6].Visible = false;

            pbJoueur.Size = new System.Drawing.Size(33, 40);
            pbJoueur.Location = new System.Drawing.Point(91, 217);
            pbJoueur.BackColor = System.Drawing.Color.Crimson;

            foreach (PictureBox ennemi in aPBEnnemis)
            {
                //test image
                ennemi.Image = Properties.Resources.Fantome1Avance1;
            }
            //int iJaaj = 2; //si on a besoin d'un point d'arrêt pour contrôler
        }

        private void GameOverParColision()
        {
            timer1.Stop();
            MessageBox.Show("touché!");
        }

        private void GameOverParVision()
        {
            timer1.Stop();
            MessageBox.Show("Vous avez été vu!\n G a m e  O v e r!");
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {

            //PictureBox[] aPBMurs = new PictureBox[9] { pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10 };
           // PictureBox[] aPBEnnemis = new PictureBox[5] { pbEnnemi1X, pbEnnemi2Y, pbEnnemi3X, pbEnnemi4Y, pbEnnemi5X };

            Point[,] APositionPoint = new Point[4, 2] {//ici on va mettre le déplacement à effectuer selon la direction, ainsi que sa "corection" en cas de colision
               /*pour se déplacer en haut*/            { new Point(pbJoueur.Location.X, pbJoueur.Location.Y - 3),new Point(pbJoueur.Location.X, pbJoueur.Location.Y + 3) },
               /*pour se déplacer en bas*/             { new Point(pbJoueur.Location.X, pbJoueur.Location.Y + 3),new Point(pbJoueur.Location.X, pbJoueur.Location.Y - 3) },
               /*pour se déplacer à gauche*/           { new Point(pbJoueur.Location.X - 3, pbJoueur.Location.Y),new Point(pbJoueur.Location.X + 3, pbJoueur.Location.Y) },
               /*pour se déplacer à droite*/           { new Point(pbJoueur.Location.X + 3, pbJoueur.Location.Y),new Point(pbJoueur.Location.X - 3, pbJoueur.Location.Y) }
                                                     };
            Int32 iIndexDeDéplacement;
            switch (e.KeyCode)//ce swith détermine la touche préssée et donc, l'index à utiliser
            {
                case Keys.W:
                    iIndexDeDéplacement = 0;
                    break;
                case Keys.S:
                    iIndexDeDéplacement = 1;
                    break;
                case Keys.A:
                    iIndexDeDéplacement = 2;
                    break;
                case Keys.D:
                    iIndexDeDéplacement = 3;
                    break;
                default:
                    iIndexDeDéplacement = 5;
                    break;
            }
            //ici on fait avancer le panel quoi qu'il arive et on corrige après coup la position,
            //si on la corrige avant il peut rentrer dans la hit box d'un autre panel
            if (iIndexDeDéplacement == 5)
            {/*on ne fait rien car 5 indique une erreur, donc on l'ignore*/ }
            else
            {
                pbJoueur.Location = APositionPoint[iIndexDeDéplacement, 0]; // on va à l'index indiqué pour savoir quel déplacement éffectuer
                if (ColisionDetect(aPBMurs, pbJoueur)) // si la méthode retourne true, ça veut dire qu'il y a eu une colision
                { pbJoueur.Location = APositionPoint[iIndexDeDéplacement, 1]; }//de facto, on "annule" le déplacement en effectuant le mouvement inverse
            }
            if (ColisionDetect(aPBEnnemis, pbJoueur)) //ici on vérifie le joueur n'entre pas en colision avec un ennemi en se déplaçant
            { GameOverParColision(); }
            DetectPapier(aPBPapier);//et là on determine si il rammasse un papier
        }

        private void DetectPapier(PictureBox[] LesPapiers)
        {
            int iRecherche = 0;
            foreach (PictureBox lePapier in LesPapiers)
            {   //on va vérifier que le joueur ne ramasse pas un papier qu'il a déjà rammasé
                if (pbJoueur.Bounds.IntersectsWith(lePapier.Bounds) && lePapier.Enabled == true)
                {
                    foreach (PictureBox papier in aPBPapier)
                    {
                        if (lePapier.Name == papier.Name) //ici on cherche quel papier a été ramassé et on le désactive
                        {
                            aPBPapier[iRecherche].Enabled = false;
                            aPBPapier[iRecherche].Visible = false;
                        }
                        else { iRecherche++; }
                    } //on affiche le morceau de mot passe correspondant
                    MessageBox.Show(AStrCodeSecret[iPapier], "11037");
                    iPapier++;
                }
                if (iPapier == 3)
                { // et après 3 papier récupéré on lui débloque le sac
                    aPBPapier[6].Enabled = true;
                    aPBPapier[6].Visible = true;
                }
            }
        }

        public bool ColisionDetect(PictureBox[] LesMurs, PictureBox leJoueur) //cette méthode detecte les colision entre le joueur et les murs ou les ennemis
        {
            foreach (PictureBox leMur in LesMurs) //on utilise une méthode et on test tout les murs en boucle car
            {                                     //si on effectue la boucle plus haut, le déplacement aussi est bouclé
                if (leJoueur.Bounds.IntersectsWith(leMur.Bounds)) //si jammais on détecte une collision, on indique true
                { return true; }
            }
            return false; //dans le cas contraire on indique false
        }


        #region RemplirLesCoordonneDesControles
        public List<List<string>> RemplissageDeCord(string coord, List<List<string>> listeARemplir)
        {
            //ici on va fournir le fichier xml duquel on aura retiré tout les "\n"
            string[] coordAMettre = coord.Replace('\n', ' ').Split(';');
            int iCpt = 0;
            foreach (string ligne in coordAMettre)
            {   //et ici on va remplir la liste en convertissant en liste le tableau duquel on aura enlevé tout les espace blanc
                listeARemplir.Add((ligne.Trim()).Split(',').ToList());
                iCpt++;
            }
            //étant donné que le dernier élément de la liste est systématiquemen un vide, on le supprime.
            listeARemplir.RemoveAt(listeARemplir.Count()-1);
            return listeARemplir;
        }

        public PictureBox[] RemplissageProprietePictureBox(PictureBox[] aPbElement, List<List<string>> listePropriete)
        {
            int iCpt = 0;

            for (int itaille = 0; itaille < aPbElement.Count(); itaille++)
            {//on initialise toutes les picturebox du tableau
                aPbElement[itaille] = new PictureBox();
            }
            foreach (PictureBox Entite in aPbElement)
            {   //et on leur asigne les propriété stocké dans la liste
                Entite.Width = Convert.ToInt32(listePropriete[iCpt][0]);
                Entite.Height = Convert.ToInt32(listePropriete[iCpt][1]);
                Entite.Location = new System.Drawing.Point(Convert.ToInt32(listePropriete[iCpt][2]), Convert.ToInt32(listePropriete[iCpt][3]));
                Entite.BackColor =  System.Drawing.Color.FromName(listePropriete[iCpt][4]);
                iCpt++;
            }
            return aPbElement;
        }
        #endregion
    }


}
