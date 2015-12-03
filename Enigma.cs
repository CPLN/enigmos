using Cpln.Enigmos.Enigmas;
using Cpln.Enigmos.Exceptions;
using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Cpln.Enigmos
{
    /// <summary>
    /// Cette classe contient les informations relatives à une énigme ainsi que l'énigme en tant que telle.
    /// </summary>
    public class Enigma : Panel
    {
        /// <summary>
        /// Le Panel contenant l'énigme.
        /// </summary>
        private EnigmaPanel enigmaPanel;

        /// <summary>
        /// Layout d'alignement de l'énigme.
        /// </summary>
        TableLayoutPanel centerLayout = new TableLayoutPanel();

        /// <summary>
        /// Le titre de l'énigme.
        /// </summary>
        private string strTitle;

        /// <summary>
        /// La réponse à l'énigme.
        /// </summary>
        private string strAnswer;

        /// <summary>
        /// L'indice relatif à l'énigme.
        /// </summary>
        private string strHint;

        /// <summary>
        /// Si la réponse est sensible à la casse.
        /// </summary>
        private bool bCaseSensitive = false;

        /// <summary>
        /// Une liste de noms d'énigmes qui doivent avoir été résolues afin de pouvoir afficher cette énigme.
        /// </summary>
        private List<string> prerequisites = new List<string>();

        /// <summary>
        /// Est-ce que l'énigme doit prendre le focus ?
        /// </summary>
        private bool bTakeFocus = false;

        /// <summary>
        /// Permet d'afficher le titre de l'énigme.
        /// </summary>
        public string Title
        {
            get
            {
                return strTitle;
            }
        }

        /// <summary>
        /// Permet d'afficher l'indice relatif à l'énigme.
        /// </summary>
        public string Hint
        {
            get
            {
                return strHint;
            }
        }

        /// <summary>
        /// Permet de savoir si la réponse à l'énigme est sensible à la casse.
        /// </summary>
        public bool IsCaseSensitive
        {
            get
            {
                return bCaseSensitive;
            }
            set
            {
                bCaseSensitive = value;
            }
        }

        [Obsolete("Cette option est activée par défaut et est donc inutile.")]
        public bool TakeFocus
        {
            get
            {
                return bTakeFocus;
            }
            set
            {
                bTakeFocus = value;
            }
        }

        /// <summary>
        /// Constructeur permettant de créer une nouvelle énigme.
        /// </summary>
        /// <param name="enigmaPanel">Le Panel contenant l'énigme</param>
        /// <param name="title">Le titre de l'énigme</param>
        public Enigma(EnigmaPanel enigmaPanel, string title)
        {
            this.enigmaPanel = enigmaPanel;
            this.strTitle = title;
            Parse();
            SetSelectable();

            centerLayout.ColumnCount = 3;
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            centerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5f));
            centerLayout.RowCount = 3;
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            centerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 0.5f));
            centerLayout.Dock = DockStyle.Fill;

            Controls.Add(centerLayout);
            centerLayout.Controls.Add(enigmaPanel, 1, 1);

            Dock = DockStyle.Fill;
        }

        public void Load()
        {
            KeyDown += new KeyEventHandler(PressKey);
            KeyUp += new KeyEventHandler(ReleaseKey);
            MouseDown += new MouseEventHandler(PressMouse);
            MouseClick += new MouseEventHandler(PressMouse);
            centerLayout.MouseClick += new MouseEventHandler(PressMouse);
            enigmaPanel.MouseClick += new MouseEventHandler(PressMouse);

            enigmaPanel.Load();
        }

        public void Unload()
        {
            enigmaPanel.Unload();
        }

        /// <summary>
        /// Détecte les touches appuyées et les transmets au Panel.
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">L'évènement</param>
        private void PressKey(object sender, KeyEventArgs e)
        {
            enigmaPanel.PressKey(sender, e);
        }

        /// <summary>
        /// Détecte les touches relâchées et les transmets au Panel.
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">L'évènement</param>
        private void ReleaseKey(object sender, KeyEventArgs e)
        {
            enigmaPanel.ReleaseKey(sender, e);
        }

        /// <summary>
        /// Constructeur permettant de créer une nouvelle énigme.
        /// </summary>
        /// <param name="enigmaPanel">Le Panel contenant l'énigme</param>
        /// <param name="title">Le titre de l'énigme</param>
        /// <param name="prerequisites">Les énigmes prérequises à la résolution de celle-ci</param>
        public Enigma(EnigmaPanel enigmaPanel, string title, string[] prerequisites)
            : this(enigmaPanel, title)
        {
            foreach (string prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
        }

        /// <summary>
        /// Cette méthode vérifie la réponse donnée par l'utilisateur.
        /// </summary>
        /// <param name="answer">La réponse soumise</param>
        /// <returns>Si la réponse soumise correspond à la réponse attendue</returns>
        public bool CheckAnswer(string answer)
        {
            return IsCaseSensitive ? answer == strAnswer : answer.ToLower() == strAnswer.ToLower();
        }

        /// <summary>
        /// Permet d'ajouter un prérequis.
        /// </summary>
        /// <param name="prerequisite">L'énigme prérequise</param>
        public void AddPrerequisite(Enigma prerequisite)
        {
            prerequisites.Add(prerequisite.Title);
        }

        /// <summary>
        /// Permet d'ajouter un prérequis.
        /// </summary>
        /// <param name="prerequisite">Le titre de l'énigme prérequise</param>
        public void AddPrerequisite(string title)
        {
            prerequisites.Add(title);
        }

        /// <summary>
        /// Vérifie si cette énigme peut être jouée, d'après la liste des énigmes déjà résolues.
        /// </summary>
        /// <param name="solved">La liste des énigmes résolues</param>
        /// <returns></returns>
        public bool IsPlayable(List<string> solved)
        {
            foreach (string prerequisite in prerequisites)
            {
                if (!solved.Contains(prerequisite))
                {
                    return false;
                }
            }
            return true;
        }

        private void PressMouse(object sender, MouseEventArgs e)
        {
            this.Focus();
        }

        /// <summary>
        /// Cette méthode cherche dans le fichier enigmas.xml les données relatives à l'énigme et hydrate l'objet Enigme en accord.
        /// </summary>
        /// <param name="enigma">L'énigme à hydrater</param>
        private void Parse()
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(Properties.Resources.enigmas)))
            {
                while (reader.ReadToFollowing("enigma"))
                {
                    if (reader.GetAttribute("title") == strTitle)
                    {
                        reader.ReadToDescendant("answer");
                        strAnswer = reader.ReadElementContentAsString();
                        reader.ReadToFollowing("hint");
                        strHint = reader.ReadElementContentAsString();
                        return;
                    }
                }
                throw new NoAnswerException(strTitle);
            }
        }

        /// <summary>
        /// Rend l'énigme sélectionnable et accessible lors de l'appui sur <code>tab</code>.
        /// </summary>
        private void SetSelectable()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
    }
}
