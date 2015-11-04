using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos
{
    class Enigma : Panel
    {
        private string id;
        private Panel pnlContent;
        private string strAnswer;
        private List<string> prerequisites = new List<string>();

        public string Id{
            get
            {
                return id;
            }
        }

        public Enigma(string id, Panel content, string answer)
        {
            this.id = id;
            this.pnlContent = content;
            this.strAnswer = answer;
            Controls.Add(pnlContent);
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
