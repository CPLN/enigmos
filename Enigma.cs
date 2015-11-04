using Cpln.Enigmos.Enigmas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    class Enigma : Panel
    {
        private string id;
        private EnigmaPanel enigmaPanel;
        private string strAnswer;
        private List<string> prerequisites = new List<string>();

        public string Id{
            get
            {
                return id;
            }
        }

        public Enigma(string id, EnigmaPanel enigmaPanel, string answer)
        {
            this.id = id;
            this.enigmaPanel = enigmaPanel;
            this.strAnswer = answer;
            Controls.Add(enigmaPanel);

            Dock = DockStyle.Fill;
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        public Enigma(string id, EnigmaPanel enigmaPanel, string answer, string[] prerequisites)
            : this(id, enigmaPanel, answer)
        {
            foreach (string prerequisite in prerequisites)
            {
                this.prerequisites.Add(prerequisite);
            }
        }

        public bool CheckAnswer(string answer)
        {
            return answer == strAnswer;
        }

        public void AddPrerequisite(Enigma prerequisite)
        {
            prerequisites.Add(prerequisite.Id);
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
