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
    class Enigma : Panel
    {
        private string strTitle;
        private string strAnswer;
        private string strHint;
        private bool bCaseSensitive = false;
        private List<string> prerequisites = new List<string>();

        public string Title
        {
            get
            {
                return strTitle;
            }
        }

        public string Hint
        {
            get
            {
                return strHint;
            }
        }

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

        public Enigma(EnigmaPanel enigmaPanel, string title)
        {
            XmlParser xmlParser = new XmlParser(title);

            this.strTitle = title;
            this.strAnswer = xmlParser.Answer;
            this.strHint = xmlParser.Hint;

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

        public Enigma(EnigmaPanel enigmaPanel, string title, string hint, string[] prerequisites)
            : this(enigmaPanel, title)
        {
            foreach (string prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
        }

        public bool CheckAnswer(string answer)
        {
            return IsCaseSensitive ? answer == strAnswer : answer.ToLower() == strAnswer.ToLower();
        }

        public void AddPrerequisite(Enigma prerequisite)
        {
            prerequisites.Add(prerequisite.Title);
        }

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

        public class XmlParser
        {
            private string strTitle;
            private string strAnswer;
            private string strHint;

            public string Title
            {
                get
                {
                    return strTitle;
                }
                set
                {
                    strTitle = value;
                }
            }

            public string Answer
            {
                get
                {
                    return strAnswer;
                }
            }

            public string Hint
            {
                get
                {
                    return strHint;
                }
            }

            public XmlParser(string title)
            {
                this.strTitle = title;

                using (XmlReader reader = XmlReader.Create(new StringReader(Properties.Resources.enigmas)))
                {
                    while (reader.ReadToFollowing("enigma"))
                    {
                        if (reader.GetAttribute("title") == title)
                        {
                            reader.ReadToDescendant("answer");
                            this.strAnswer = reader.ReadElementContentAsString();
                            reader.ReadToFollowing("hint");
                            this.strHint = reader.ReadElementContentAsString();
                            return;
                        }
                    }
                    throw new NoAnswerException(title);
                }
            }
        }
    }
}
