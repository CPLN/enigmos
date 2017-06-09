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
        PictureBox[] aPBMurs = new PictureBox[14]; //ce tableau contient les murs
        PictureBox[] aPBEnnemis = new PictureBox[5]; //celui ci les ennemis
        PictureBox[] aPBGhostEnnemi = new PictureBox[5];//la on stock l'image des ennemis
        PictureBox[] aPBPapier = new PictureBox[7];//et celui là les papiers à récupérer
        PictureBox pbJoueur = new PictureBox();
        PictureBox pbGhostJoueur = new PictureBox();    
        List<List<string>> listCoordMur = new List<List<string>>();//et toutes les informations individuelles des murs sont stockées ici
        List<List<string>> listCoordEnnemis = new List<List<string>>();
        List<List<string>> listCoordPapier = new List<List<string>>();

        String[,] ADirectioEnnemis = new string[5, 2] { { "avancer", "X" }, { "avancer", "Y" }, { "avancer", "Y" }, { "avancer", "X" }, { "avancer", "X" } };//tableau qui contient les directives de déplacement
        //Je l'ai mis ici, car si il est dans le "tick" il se réinitialise à chaque fois
        int iPapier = 0;//compteur qui permet de determiner l'avancement du joueur dans la découverte du mot de passe
        string[] AStrCodeSecret = new string[7] { "si", "c'est", "un", "oeuf", "c'est", "un", "vin" };//tableau qui contient les "morceaux" du mot de passe
        Timer timer1 = new Timer();
        Timer timerSpriteEnnemi = new Timer();
        Timer timerSpriteJoueur = new Timer();

        bool[] aBetatTouche = new bool[4] { false, false, false, false };//stock l'état des touches "W,A,S,D" false indiquant qu'elles sont relâchées
        Keys[] aKey = new Keys[4] { Keys.W, Keys.A, Keys.S, Keys.D };

        int iTimerSpriteEnnemiState=0;
        int[] aEtatSpriteEnnemi = new int[5] { 2, 0, 0, 2, 2 };//ici on va stocker quel rangée de sprites l'ennemi utilise
        int EtatSpriteJoueur = 0;
        int iTimerSpriteJoueur = 0;
        //ici on stock tout les sprites ennemis.
        Image[,] aSpriteEnnemiType1 = new Image[4, 3] { {Properties.Resources.Fantome1Avance1,Properties.Resources.Fantome1Avance2,Properties.Resources.Fantome1Avance3 },
                                                        {Properties.Resources.Fantome1Recul1,Properties.Resources.Fantome1Recul2,Properties.Resources.Fantome1Recul3 },                                                           
                                                        {Properties.Resources.Fantome1Droite1,Properties.Resources.Fantome1Droite2,Properties.Resources.Fantome1Droite3 },
                                                        {Properties.Resources.Fantome1Gauche1,Properties.Resources.Fantome1Gauche2,Properties.Resources.Fantome1Gauche3 }};

        Image[,] aSpriteEnnemiType2 = new Image[4, 3] { {Properties.Resources.Fantome2Avance1,Properties.Resources.Fantome2Avance2,Properties.Resources.Fantome2Avance3 },
                                                        {Properties.Resources.Fantome2Recul1,Properties.Resources.Fantome2Recul2,Properties.Resources.Fantome2Recul3 },
                                                        {Properties.Resources.Fantome2Droite1,Properties.Resources.Fantome2Droite2,Properties.Resources.Fantome2Droite3 },
                                                        {Properties.Resources.Fantome2Gauche1,Properties.Resources.Fantome2Gauche2,Properties.Resources.Fantome2Gauche3 }};
        //là les sprites des sacs
        Image[] aSpriteSac = new Image[7] {Properties.Resources.SacAsauce1,Properties.Resources.SacAsauce2, Properties.Resources.SacAsauce3, Properties.Resources.SacAsauce4, Properties.Resources.SacAsauce5, Properties.Resources.SacAsauce6, Properties.Resources.SacAsauce7};
        //ici on stock les sprites du joueur
        Image[,] aSpriteJoueur = new Image[4, 3] { {Properties.Resources.LorieAvance1,Properties.Resources.LorieAvance2,Properties.Resources.LorieAvance3 },
                                                        {Properties.Resources.LorieRecul1,Properties.Resources.LorieRecul2,Properties.Resources.LorieRecul3 },
                                                        {Properties.Resources.LorieDroite1,Properties.Resources.LorieDroite2,Properties.Resources.LorieDroite3 },
                                                        {Properties.Resources.LorieGauche1,Properties.Resources.LorieGauche2,Properties.Resources.LorieGauche3 }};
        public JeuDuSacEnigmaPanel()
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            DoubleBuffered = true; //permet d'éviter l'effet saccadé des animation et des déplacements
            timerSpriteEnnemi.Interval = 300;
            timerSpriteEnnemi.Tick += new EventHandler(timerSpriteEnnemi_Tick);

            timerSpriteJoueur.Interval = 200;
            timerSpriteJoueur.Tick += new EventHandler(timerSpriteJoueur_Tick);
            this.BackgroundImage = Properties.Resources.SolParquetReworkGrisBrunSmol;//on a besoin d'assigner l'image de fond au sol ET a la forme, ou le transparent des entité apparait.                                                                        
        }

        public override void Load()
        {         
            listCoordMur = RemplissageDeCord(Properties.Resources.Murcoord, listCoordMur);
            listCoordEnnemis = RemplissageDeCord(Properties.Resources.EnnemisCoord, listCoordEnnemis);
            listCoordPapier = RemplissageDeCord(Properties.Resources.papierCoord, listCoordPapier);
            string[] aStrNomPapier = new string[7] { "pbPapier1", "pbPapier2", "pbPapier3", "pbPapier4", "pbPapier5", "pbPapier6", "pbSac" };

            //pour le joueur et les ennemi j'utilise un système de "ghost"
            //normalement la hitbox serait légèrement plus grande que l'image affichée
            //car cette dernière ne remplis pas toute la box.
            //alors je réduis la taille du joueur/ennemi , c'est ce qui sera sa hitbox effective
            //et j'affiche l'image dans une autre picturebox qui la suivra, son "ghost"

            //ici on initialise le joueur avec son "Ghost"
            pbJoueur.Size = new System.Drawing.Size(23, 26);
            pbJoueur.Location = new System.Drawing.Point(98, 231);

            pbGhostJoueur.Size = new System.Drawing.Size(29, 32);
            pbGhostJoueur.Location = new System.Drawing.Point(95, 228);
           //pbJoueur.BackColor = Color.Crimson; //utile pour afficher la hitbox pour le débuggage
            pbJoueur.Visible = false;
            pbGhostJoueur.Image = aSpriteJoueur[EtatSpriteJoueur, 1];
            pbGhostJoueur.BackColor = Color.Transparent;
            Controls.Add(pbJoueur);
            Controls.Add(pbGhostJoueur);

            //on va donc assigner toute les coordonnées contenues dans le fichier XML grâce à cette méthode
            aPBMurs = RemplissageProprietePictureBox(aPBMurs, listCoordMur);
            foreach (PictureBox mur in aPBMurs)
            { Controls.Add(mur); }
           
            //ici on initialise les ennemis et on lie leurs "ghost"
            aPBEnnemis = RemplissageProprietePictureBox(aPBEnnemis, listCoordEnnemis);
            connexionSpriteHitboxEnnemi();
            int iEnnemis = 0;
            foreach (PictureBox ennemi in aPBEnnemis)
            {
                Image[,] aSpriteEnnemi = SelectionSet(iEnnemis);
                aPBGhostEnnemi[iEnnemis].Image = aSpriteEnnemi[aEtatSpriteEnnemi[iEnnemis], 1];               
                Controls.Add(ennemi);
                Controls.Add(aPBGhostEnnemi[iEnnemis]);
                iEnnemis++;
            }

            //ici on initialise les papiers
            aPBPapier = RemplissageProprietePictureBox(aPBPapier, listCoordPapier);
            int iNomPapier = 0;
            foreach (PictureBox papier in aPBPapier)
            {
                aPBPapier[iNomPapier].Name = aStrNomPapier[iNomPapier];
                aPBPapier[iNomPapier].Image = aSpriteSac[iNomPapier];
                iNomPapier++;
                Controls.Add(papier);
            }

            //ici on modifie le dernier sac pour le faire disparaître momentanéement
            aPBPapier[6].Enabled = false;
            aPBPapier[6].Visible = false;
            aPBPapier[6].BackColor = Color.Transparent;

            timer1.Start();
            timerSpriteEnnemi.Start();
            //on demarre le timer d'animation du joueur sur un keypress
        }

#region Animation_Et_Sprite
        /// <summary>
        /// permet de determiner quel set de sprite l'ennemi va utiliser dans ses animations
        /// </summary>
        /// <param name="iEnnemis">le numero de l'ennemi permetant de l'identifier</param>
        /// <returns>retourne un tableau contenant un set de sprites</returns>
        private Image[,] SelectionSet(int iEnnemis)
        {
            Image[,] aSpriteEnnemi; // par défaut on utilise le set de sprite numéro 1
            if (iEnnemis == 2 || iEnnemis == 4)
            { aSpriteEnnemi = aSpriteEnnemiType2; } //ou le numéro 2 si on indique quels ennemis l'utilisent. ici l'ennemi 3 et 5.
            else
            { aSpriteEnnemi = aSpriteEnnemiType1; }
            return aSpriteEnnemi;
        }
        /// <summary>
        /// Timer servant exclusivement à l'animation des sprites des ennemis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSpriteEnnemi_Tick(object sender, EventArgs e)
        {
            int iEnnemis = 0;           
            //on va parcourir tous les ennemis et leurs assigner la rangée de sprites indiquée par le tableau "aEtatSpriteEnnemi"
            //le ItimerSprite va nous servir à savoir quelle séquence afficher, 0,1 ou 2        
            foreach (PictureBox ennemi in aPBEnnemis)
            {
                Image[,] aSpriteEnnemi = SelectionSet(iEnnemis);
                aPBGhostEnnemi[iEnnemis].Image = aSpriteEnnemi[aEtatSpriteEnnemi[iEnnemis], iTimerSpriteEnnemiState];
                iEnnemis++;
            }
            iTimerSpriteEnnemiState= AnimationFlow(iTimerSpriteEnnemiState);
        }
        /// <summary>
        /// indique quel séquence d'animation afficher. l'ordre des séquences est 0,1,2 
        /// </summary>
        /// <param name="iTimer">un entier indiquant à quelle séquence on l'en est</param>
        /// <returns>retourne la nouvelle valeur de l'entier</returns>
        private int AnimationFlow(int iTimer)
        {
            if (iTimer >= 2)//une fois à deux, le compteur retombe à zéro
            { iTimer = 0; }
            else
            { iTimer++; }
            return iTimer;
        }
        /// <summary>
        /// timer servant exclusivement à l'animation des sprites du joueur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerSpriteJoueur_Tick(object sender, EventArgs e)
        {
            int iNbToucheDown = 0;
            pbGhostJoueur.Image = aSpriteJoueur[EtatSpriteJoueur, iTimerSpriteJoueur];
            iTimerSpriteJoueur = AnimationFlow(iTimerSpriteJoueur);
            foreach (bool betat in aBetatTouche)
            {
                if(betat)
                { iNbToucheDown++; }
            }
            if (iNbToucheDown == 0)
            {
                pbGhostJoueur.Image = aSpriteJoueur[EtatSpriteJoueur, 1];//on régle le sprite sur la position normal
                timerSpriteJoueur.Stop();//et on arrête le timer d'animation si aucune touche n'est préssée
            }       
        }
        public override void ReleaseKey(object sender, KeyEventArgs e)
        {
            int iChercheTouche = 0;
            foreach (Keys touche in aKey)
            {
                if (touche == aKey[iChercheTouche])
                { aBetatTouche[iChercheTouche] = false; }
                iChercheTouche++;
            }
        }
#endregion
        private void timer1_Tick(object sender, EventArgs e)
        {          
            Int32[,] aIlimitesEnnemis = new Int32[5, 2] { { 65, 185 }, { 100, 390 }, { 128, 305 }, { 124, 270 },  { 283, 380 } };//tableau qui contient les coordonées des limites des routines de déplacement des ennemis 
            Point[,] AdDeplacementEnnemis = new Point[5, 2] {
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
                        { // dans ce cas, l'ennemis a atteint la limite de sa route, on le fait donc se retourner
                            ADirectioEnnemis[iCptEnnemis, 0] = "reculer"; // en partant du principe que l'ennemi a un index de sprite paire quand il avance
                            aEtatSpriteEnnemi[iCptEnnemis] += 1; //si l'ennemis recul on augmente de 1 car les rangées impaires sont pour les reculs
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
                            aEtatSpriteEnnemi[iCptEnnemis] -= 1;//si l'ennemis avance on diminue de 1 car les rangées paires sont pour avancer
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
                //on déplace l'image en même temps que l'ennemi
                aPBGhostEnnemi[iCptEnnemis].Location = new Point(Ennemi.Location.X - 3, Ennemi.Location.Y - 3);
            }
        }

        /// <summary>
        /// Determine sur quel axe l'ennemi se déplace et si il ne dépasse pas les limites de sa routine de déplacement
        /// </summary>
        /// <param name="TabXY">Tableau contenant quel ennemi se déplace sur quel axe</param>
        /// <param name="TabLimites">
        ///     Tableau contenant les limites minimales et maximales des routines de déplacement de chaque ennemi, valeurs sous forme de coordonées X,Y
        /// </param>
        /// <param name="pbEnnemis">l'ennemi qui va être assujetis au test</param>
        /// <param name="iIndexEnnemis">index indiquant la place dans les tableau des infos concernant l'ennemi testé</param>
        /// <returns>retourne un booléen indiquant si la limite a été dépassée, true indiquant un dépassement, et false indiquant qu'elle n'est pas dépassée.</returns>
        public bool DetectXY(string[,] TabXY, Int32[,] TabLimites, PictureBox pbEnnemis, int iIndexEnnemis)
        {
            int iPositionXYEnnemi = 0;
            if (TabXY[iIndexEnnemis, 1] == "X") //Selon l'axe de déplacement de l'ennemi(X ou Y) on utilise la position corespondante
            { iPositionXYEnnemi = pbEnnemis.Location.X; }
            if (TabXY[iIndexEnnemis, 1] == "Y")
            { iPositionXYEnnemi = pbEnnemis.Location.Y; }

            switch (TabXY[iIndexEnnemis, 0]) // là on teste que l'ennemi ne dépasse pas les limittes.
            {
                case "avancer":
                    return ((iPositionXYEnnemi + 2 > TabLimites[iIndexEnnemis, 1])); //quand il avance c'est sa limite maximum qui est testée
                    break;

                case "reculer":
                    return ((iPositionXYEnnemi - 2 < TabLimites[iIndexEnnemis, 0])); // quand il recule c'est sa limite minimum qui est testée
                    break;
            }
            return false;
        }

        /// <summary>
        /// message s'affichant lorsque le jeu détecte qu'il y a eu collision entre un ennemi et le joueur
        /// </summary>
        private void GameOverParColision()
        {
            timer1.Stop();
            DialogResult DlgGameOver = MessageBox.Show("touché!","G a m e  O v e r!",MessageBoxButtons.OK);
            if (DlgGameOver == DialogResult.OK)
            {
                pbGhostJoueur.Location = new System.Drawing.Point(95, 228);
                timer1.Start();
            }
          
        }
        /// <summary>
        ///  message s'affichant lorsque le jeu détecte qu'un ennemi a vu le joueur
        /// </summary>
        private void GameOverParVision()
        {
            timer1.Stop();
            DialogResult DlgGameOver = MessageBox.Show("Vous avez été vu!!", "G a m e  O v e r!", MessageBoxButtons.OK);
            if (DlgGameOver == DialogResult.OK)
            {
                pbGhostJoueur.Location = new System.Drawing.Point(95, 228);
                timer1.Start();
            }
        }

        public override void PressKey(object sender, KeyEventArgs e)
        {
            timerSpriteJoueur.Start();
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
                    EtatSpriteJoueur = 1;
                    aBetatTouche[0] = true;
                    break;
                case Keys.S:
                    iIndexDeDéplacement = 1;
                    EtatSpriteJoueur = 0;
                    aBetatTouche[1] = true;
                    break;
                case Keys.A:
                    iIndexDeDéplacement = 2;
                    EtatSpriteJoueur = 3;
                    aBetatTouche[2] = true;
                    break;
                case Keys.D:
                    iIndexDeDéplacement = 3;
                    EtatSpriteJoueur = 2;
                    aBetatTouche[3] = true;
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
            if (ColisionDetect(aPBEnnemis, pbJoueur)) //ici on vérifie que le joueur n'entre pas en colision avec un ennemi en se déplaçant
            { GameOverParColision(); }
            DetectPapier(aPBPapier);//et là on determine si il rammasse un papier
            pbGhostJoueur.Location = new Point(pbJoueur.Location.X - 3, pbJoueur.Location.Y - 3);
        }

        #region detectionDeColisionEtVision
        /// <summary>
        /// Detecte si le joueur ramasse un papier et determine quel morceau du mot de passe il doit afficher selon
        /// les papiers déjà ramassés. gère aussi l'apparition du dernier papier
        /// </summary>
        /// <param name="LesPapiers">tableau de picturebox contenant les papiers</param>
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
                { // et après 3 papier récupérés on lui débloque le sac
                    aPBPapier[6].Enabled = true;
                    aPBPapier[6].Visible = true;
                }
            }
        }

        /// <summary>
        /// cette méthode detecte les colision entre le joueur et les murs ou les ennemis
        /// </summary>
        /// <param name="LesEntites">Tableau contenant soit des ennemis, soit des murs</param>
        /// <param name="leJoueur">la picturebox representant la hitbox du joueur</param>
        /// <returns>retourne un booléen indiquant si il y a eu collision</returns>
        public bool ColisionDetect(PictureBox[] LesEntites, PictureBox leJoueur)
        {
            foreach (PictureBox Entite in LesEntites) //on utilise une méthode et on test tout les murs en boucle car
            {                                     //si on effectue la boucle plus haut, le déplacement aussi est bouclé
                if (leJoueur.Bounds.IntersectsWith(Entite.Bounds)) //si jammais on détecte une collision, on indique true
                { return true; }
            }
            return false; //dans le cas contraire on indique false
        }

        /// <summary>
        /// Methode servant à vérifier si un ennemi peut voir un joueur
        /// </summary>
        /// <param name="Ennemi">L'ennemi dont on va tester la ligne de vue</param>
        /// <param name="TabXY">le tableau indiquant son orientation</param>
        /// <param name="iIndexEnnemis">l'index indiquant à quelle place se situe les infos relatives à l'ennemi</param>
        /// <returns>retourne sous forme d'un test, si oui ou non le joueur a été vu par l'ennemi</returns>
        private bool DetectVision(PictureBox Ennemi, string[,] TabXY, int iIndexEnnemis)
        {
            int iAxeEnnmi = 0;
            int iAxeJoueur = 0;
            int iAxeJoueurrecul = 0;
            bool bAxeInverse = false;
            if (TabXY[iIndexEnnemis, 1] == "X") //Selon l'axe de déplacement de l'ennemi(X ou Y) on utilise la position corespondante
            { //on va donc assigner ici tout les renseignement nécéssaires au calcul de la ligne de vue de l'ennemi
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
                    { return ((iAxeEnnmi + 50 > iAxeJoueur && iAxeJoueur > iAxeEnnmi)); } //on vérifie si le regard de l'ennemi atteint le joueur et que le joueur ne soit pas dérière l'ennemi
                    break;

                case "reculer":
                    if (bAxeInverse)
                    { return ((iAxeEnnmi - 75 < iAxeJoueurrecul && iAxeJoueurrecul < iAxeEnnmi)); } // ici la vison est plus grande car on soustrait la largeur/hauteur de l'ennemi
                    break;
            }
            return false; //et si le switch ne donne aucun résultat on considère comme false.
        }
        /// <summary>
        /// methode utilisé par "detectvision" pour tester l'axe voulu du joueur
        /// </summary>
        /// <param name="iAxeEnnemiInverse">l'axe sur lequel l'ennemi ne se déplace pas</param>
        /// <param name="iAxeInverseJoueur">l'axe sur lequel le joueur ne se déplace pas</param>
        /// <param name="LargeurHauteurEnnemi">la largeur OU hauteur de l'ennemi, permet de considérer la ligne de vue comme une barre plutôt qu'une ligne</param>
        /// <param name="LargeurhauteurJoueur">La largeur OU hauteur de la hitbox du joueur, idem que plus haut</param>
        /// <returns>Retourne le resultat inverse du test. si le test est faux, on renvoi donc true. indiquant que le joueur est dans la ligne de vue</returns>
        private bool TestAlignement(int iAxeEnnemiInverse, int iAxeInverseJoueur, int LargeurHauteurEnnemi, int LargeurhauteurJoueur)
        {
            return (!(iAxeInverseJoueur + (LargeurhauteurJoueur / 2) < iAxeEnnemiInverse || iAxeInverseJoueur > iAxeEnnemiInverse + (LargeurHauteurEnnemi / 2)));
            //ici on teste si le joueur est au même niveau que l'ennemi sur l'axe ou il ne se déplace pas
            // par exemple si l'ennemi se déplace sur l'axe X, on va tester les position en Y des deux entités.         
        }
        #endregion

        #region RemplirLesCoordonneDesControles
        /// <summary>
        /// On fournit un fichier texte avec différentes valeurs à l'intérieur, qui vont être stocker dans une liste pour un usage futur.
        /// </summary>
        /// <param name="coord">le fichier texte à utiliser</param>
        /// <param name="listeARemplir">indique quelle liste de liste il faut utiliser. </param>
        /// <returns>retourne la valeur du parametre "listeARemplir"</returns>
        public List<List<string>> RemplissageDeCord(string coord, List<List<string>> listeARemplir)
        {
            //ici on va fournir le fichier xml duquel on aura retiré tout les "\n"
            string[] coordAMettre = coord.Replace('\n', ' ').Split(';');
            int iCpt = 0;
            foreach (string ligne in coordAMettre)
            {   //et ici on va remplir la liste en convertissant en liste le tableau duquel on aura enlevé tout les espaces blanc
                listeARemplir.Add((ligne.Trim()).Split(',').ToList());
                iCpt++;
            }
            return listeARemplir;
        }
        /// <summary>
        /// Va se servir des différentes listes remplies de coordonées pour les assigner aux bons objets (murs, ennemis,sacs)
        /// </summary>
        /// <param name="aPbElement">le tableau d'éléments auxquels on va assigner les valeurs</param>
        /// <param name="listePropriete">la liste qui va fournir les valeurs</param>
        /// <returns>retourne le tableau d'éléments auxquels on a assigné les valeurs</returns>
        public PictureBox[] RemplissageProprietePictureBox(PictureBox[] aPbElement, List<List<string>> listePropriete)
        {
            int iCpt = 0;

            for (int itaille = 0; itaille < aPbElement.Count(); itaille++)
            {//on initialise toutes les picturebox du tableau
                aPbElement[itaille] = new PictureBox();
            }
            foreach (PictureBox Entite in aPbElement)
            {   //et on leurs asigne les propriétées stockées dans la liste
                Entite.Width = Convert.ToInt32(listePropriete[iCpt][0]);
                Entite.Height = Convert.ToInt32(listePropriete[iCpt][1]);
                Entite.Location = new System.Drawing.Point(Convert.ToInt32(listePropriete[iCpt][2]), Convert.ToInt32(listePropriete[iCpt][3]));
                if (listePropriete[iCpt][4] == "Black" || listePropriete[iCpt][4]== "Transparent") //à gauche couleur des murs et à droite les ennemis
                { Entite.BackColor = System.Drawing.Color.FromName(listePropriete[iCpt][4]); }
                iCpt++;
            }
            return aPbElement;
        }

        /// <summary>
        /// fait le lien entre un ennemi et sa hitbox
        /// </summary>
        public void connexionSpriteHitboxEnnemi()
        {
            int iIndexHitbox = 0;
            foreach (PictureBox ennemi in aPBEnnemis)
            {//ici on va faire le lien entre la hitbox de l'ennemi et l'image de ce dernier
                //les deux ont été dissociés pour que la hitbox soit légèrement plus petite et que les colisions soit moins hasardeuses et plus ajustable
                aPBGhostEnnemi[iIndexHitbox] = new PictureBox();
                aPBGhostEnnemi[iIndexHitbox].Location = new Point(ennemi.Location.X - 3, ennemi.Location.Y - 3);
                aPBGhostEnnemi[iIndexHitbox].Width = ennemi.Width + 7;
                aPBGhostEnnemi[iIndexHitbox].Height = ennemi.Height + 7;
                aPBGhostEnnemi[iIndexHitbox].BackColor = Color.Transparent;
                ennemi.Visible = false;
                //ennemi.BackColor = Color.Aquamarine;//cette ligne sert à rendre la hitbox visible. utile pour le debugage.
                iIndexHitbox++;
            }
        }
        #endregion
    }
}
