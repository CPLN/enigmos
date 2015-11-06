using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cpln.Enigmos.Utils
{
    class StringUtils
    {
        public static string PascalCase(string input)
        {
            string pattern = "[^a-zA-Z]";
            string[] words = Regex.Split(input, pattern);
            string output = "";
            foreach (string word in words)
            {
                if(word.Length > 0)
                {
                    output += char.ToUpper(word[0]) + word.Substring(1).ToLower();
                }
            }
            return output;
        }
    }
}
