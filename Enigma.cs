using Cpln.Enigmos.Enigmas;
using Cpln.Enigmos.Exceptions;
using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    class Enigma : Panel
    {
        private string strTitle;
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

        public Enigma(EnigmaPanel enigmaPanel, string title, string hint)
        {
            if (Reponses.ResourceManager.GetString(StringUtils.PascalCase(title)) == null)
            {
                throw new NoAnswerException(title);
            }
            this.strTitle = title;
            this.strHint = hint;

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
            : this(enigmaPanel, title, hint)
        {
            foreach (string prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
        }

        public bool CheckAnswer(string answer)
        {
            string responseName = StringUtils.PascalCase(strTitle);
            string goodAnswer = Reponses.ResourceManager.GetString(responseName);
            return IsCaseSensitive ? answer == goodAnswer : answer.ToLower() == goodAnswer.ToLower();
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
    }
}
