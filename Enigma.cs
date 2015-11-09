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
    class Enigma : Panel
    {
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

        /// <summary>
        /// Constructeur permettant de créer une nouvelle énigme.
        /// </summary>
        /// <param name="enigmaPanel">Le Panel contenant l'énigme</param>
        /// <param name="title">Le titre de l'énigme</param>
        public Enigma(EnigmaPanel enigmaPanel, string title)
        {
            XmlParser.Parse(this);

            TableLayoutPanel centerLayout = new TableLayoutPanel();
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

        /// <summary>
        /// Cette classe fille permet d'obtenir des informations relatives à cette énigme dans le fichier enigmas.xml.
        /// </summary>
        private abstract class XmlParser
        {
            /// <summary>
            /// Cette méthode cherche dans le fichier enigmas.xml les données relatives à l'énigme et hydrate l'objet Enigme en accord.
            /// </summary>
            /// <param name="enigma">L'énigme à hydrater</param>
            public static void Parse(Enigma enigma)
            {
                using (XmlReader reader = XmlReader.Create(new StringReader(Properties.Resources.enigmas)))
                {
                    while (reader.ReadToFollowing("enigma"))
                    {
                        if (reader.GetAttribute("title") == enigma.strTitle)
                        {
                            reader.ReadToDescendant("answer");
                            enigma.strAnswer = reader.ReadElementContentAsString();
                            reader.ReadToFollowing("hint");
                            enigma.strHint = reader.ReadElementContentAsString();
                            return;
                        }
                    }
                    throw new NoAnswerException(strTitle);
                }
            }
        }
    }
}
