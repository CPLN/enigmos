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
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        public override void Load()
        {           
            listCoordMur = RemplissageDeCord(Properties.Resources.Murcoord, listCoordMur);
            listCoordEnnemis = RemplissageDeCord(Properties.Resources.EnnemisCoord, listCoordEnnemis);
            listCoordPapier = RemplissageDeCord(Properties.Resources.papierCoord, listCoordPapier);
            string[] aStrNomPapier = new string[7] { "pbPapier1", "pbPapier2", "pbPapier3", "pbPapier4", "pbPapier5", "pbPapier6", "pbSac" };

            //auomatiser tout ça par la suite
            aPBMurs = RemplissageProprietePictureBox(aPBMurs, listCoordMur);
            foreach (PictureBox mur in aPBMurs)
            { Controls.Add(mur); }

            aPBEnnemis = RemplissageProprietePictureBox(aPBEnnemis, listCoordEnnemis);
            foreach (PictureBox ennemi in aPBEnnemis)
            { Controls.Add(ennemi); }

            aPBPapier = RemplissageProprietePictureBox(aPBPapier, listCoordPapier);
            int iNomPapier = 0;
            foreach (PictureBox papier in aPBPapier)
            {
                aPBPapier[iNomPapier].Name = aStrNomPapier[iNomPapier];
                iNomPapier++;
                Controls.Add(papier);
            }



            //ici on initialise le sac
            aPBPapier[6].Enabled = false;
            aPBPapier[6].Visible = false;

            //ici on initialise le joueur
            pbJoueur.Size = new System.Drawing.Size(33, 40);
            pbJoueur.Location = new System.Drawing.Point(91, 217);
            pbJoueur.BackColor = System.Drawing.Color.Crimson;
            Controls.Add(pbJoueur);

            foreach (PictureBox ennemi in aPBEnnemis)
            {
                //test image
                ennemi.Image = Properties.Resources.Fantome1Avance1;
            }
            timer1.Start();
            //int iJaaj = 2; //si on a besoin d'un point d'arrêt pour contrôler
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //PictureBox[] aPbEnnemis = new PictureBox[5] { pbEnnemi1X, pbEnnemi4Y, pbEnnemi2Y, pbEnnemi3X, pbEnnemi5X };//Contient les picture box de tout les ennemis
            //Int32[,] aIlimitesEnnemis = new Int32[5, 2] { { 65, 185 }, { 124, 270 }, { 100, 390 }, { 128, 305 }, { 283, 380 } };//tableau qui contient les coordonées limites ou les ennemis se déplacent 
            Int32[,] aIlimitesEnnemis = new Int32[5, 2] { { 65, 185 }, { 100, 390 }, { 128, 305 }, { 124, 270 },  { 283, 380 } };
            Point[,] AdDeplacementEnnemis = new Point[5, 2] { // on va simplifier le tableau des déplacement, si possible
                                                             {new Point(aPBEnnemis[0].Location.X + 2, aPBEnnemis[0].Location.Y), new Point(aPBEnnemis[0].Location.X - 2, aPBEnnemis[0].Location.Y) },
                                                             {new Point(aPBEnnemis[1].Location.X, aPBEnnemis[1].Location.Y+2), new Point(aPBEnnemis[1].Location.X, aPBEnnemis[1].Location.Y-2) },
                                                             {new Point(aPBEnnemis[2].Location.X, aPBEnnemis[2].Location.Y+2), new Point(aPBEnnemis[2].Location.X, aPBEnnemis[2].Location.Y-2) },
                                                             {new Point(aPBEnnemis[3].Location.X + 2, aPBEnnemis[3].Location.Y), new Point(aPBEnnemis[3].Location.X - 2, aPBEnnemis[3].Location.Y)},
                                                             {new Point(aPBEnnemis[4].Location.X + 2, aPBEnnemis[4].Location.Y), new Point(aPBEnnemis[4].Location.X - 2, aPBEnnemis[4].Location.Y)}
                                                            };
            int iCptEnnemis = -1;
            foreach (PictureBox Ennemi in aPBEnnemis)
            {
                iCptEnnemis++;
                switch (ADirectioEnnemis[iCptEnnemis, 0])
                {
                    case "avancer":
                        if (DetectXY(ADirectioEnnemis, aIlimitesEnnemis, Ennemi, iCptEnnemis))
                        { // dans ce cas, l'ennemis à atteint la limite de sa route, on le fais se retourner
                            ADirectioEnnemis[iCptEnnemis, 0] = "reculer";
                        }
                        else
                        {  //dans ce cas là, l'ennemi peut avancer normalement
                            Ennemi.Location = AdDeplacementEnnemis[iCptEnnemis, 0];
                        }
                        break;
                    case "reculer"://idem que plus haut, mais dans le cas ou l'ennemi fait le chemin retour.
                        if (DetectXY(ADirectioEnnemis, aIlimitesEnnemis, Ennemi, iCptEnnemis))
                        {
                            ADirectioEnnemis[iCptEnnemis, 0] = "avancer";
                        }
                        else
                        { Ennemi.Location = AdDeplacementEnnemis[iCptEnnemis, 1]; }

                        break;
                }
                //Vérifie si l'ennemi peut voir le joueur
                if (DetectVision(Ennemi, ADirectioEnnemis, iCptEnnemis))
                {
                    aPBEnnemis[iCptEnnemis].BackColor = Color.Crimson; //on change la couleur de l'ennemi qui l'a touché
                    GameOverParVision();//game over
                }
                //Vérifie si l'ennemi n'entre pas en collision avec le joueur
                if (Ennemi.Bounds.IntersectsWith(pbJoueur.Bounds))
                {
                    aPBEnnemis[iCptEnnemis].BackColor = Color.Crimson;
                    GameOverParColision();//game over
                }
            }
        }

        public bool DetectXY(string[,] TabXY, Int32[,] TabLimites, PictureBox pbEnnemis, int iIndexEnnemis)
        {
            //faire un switch, et assigner la location à une variable
            int iPositionXYEnnemi = 0;

            if (TabXY[iIndexEnnemis, 1] == "X") //Selon l'axe de déplacement de l'ennemi(X ou Y) on utilise la position corespondante
            { iPositionXYEnnemi = pbEnnemis.Location.X; }
            if (TabXY[iIndexEnnemis, 1] == "Y")
            { iPositionXYEnnemi = pbEnnemis.Location.Y; }

            switch (TabXY[iIndexEnnemis, 0]) // là on teste que l'ennemi ne dépasse pas les limittes.
            {
                case "avancer":
                    return ((iPositionXYEnnemi + 2 > TabLimites[iIndexEnnemis, 1])); //quand il avance c'est sa limite maximum qui est testé
                    break;

                case "reculer":
                    return ((iPositionXYEnnemi - 2 < TabLimites[iIndexEnnemis, 0])); // quand il recule c'est sa limite minimum qui est testé
                    break;
            }
            return false;
        }

        private bool DetectVision(PictureBox Ennemi, string[,] TabXY, int iIndexEnnemis)
        {
            int iAxeEnnmi = 0;
            int iAxeJoueur = 0;
            int iAxeJoueurrecul = 0;
            bool bAxeInverse = false;
            if (TabXY[iIndexEnnemis, 1] == "X") //Selon l'axe de déplacement de l'ennemi(X ou Y) on utilise la position corespondante
            { //on va donc assigner ici tout les renseignement nécéssaire au calcul de la ligne de vue de l'ennemi
                iAxeEnnmi = Ennemi.Location.X + Ennemi.Width;
                iAxeJoueur = pbJoueur.Location.X;
                iAxeJoueurrecul = pbJoueur.Location.X + pbJoueur.Width;
                bAxeInverse = TestAlignement(Ennemi.Location.Y, pbJoueur.Location.Y, Ennemi.Height, pbJoueur.Height);
            }
            if (TabXY[iIndexEnnemis, 1] == "Y")
            {//idem que plus haut mais pour l'autre Axe
                iAxeEnnmi = Ennemi.Location.Y + Ennemi.Height;
                iAxeJoueur = pbJoueur.Location.Y;
                iAxeJoueurrecul = pbJoueur.Location.Y + pbJoueur.Height;
                bAxeInverse = TestAlignement(Ennemi.Location.X, pbJoueur.Location.X, Ennemi.Width, pbJoueur.Width);
            }

            switch (TabXY[iIndexEnnemis, 0]) // là on teste que la ligne de vue de l'ennemi n'atteigne pas le joueur
            {
                case "avancer":
                    if (bAxeInverse)
                    { return ((iAxeEnnmi + 50 > iAxeJoueur && iAxeJoueur > iAxeEnnmi)); } //on vérifie si le regard de l'ennemi atteigne le joueur est que le joueur ne sois pas dérière l'ennemi
                    break;

                case "reculer":
                    if (bAxeInverse)
                    { return ((iAxeEnnmi - 75 < iAxeJoueurrecul && iAxeJoueurrecul < iAxeEnnmi)); } // ici la vison est plus grand car on soustrait la largeur/hauteur de l'ennemi
                    break;
            }
            return false; //et si le switch ne donne aucun résultat on considère comme false.
        }

        private bool TestAlignement(int iAxeEnnemiInverse, int iAxeInverseJoueur, int LargeurHauteurEnnemi, int LargeurhauteurJoueur)
        {
            return (!(iAxeInverseJoueur + (LargeurhauteurJoueur / 2) < iAxeEnnemiInverse || iAxeInverseJoueur > iAxeEnnemiInverse + (LargeurHauteurEnnemi / 2)));
            //ici on teste si le joueur est au même niveau que l'ennemi sur l'axe ou il ne se déplace pas
            // par exemple si l'ennemi se déplace sur l'axe X, on va tester les position en Y des deux entités.         
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
