using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public static class StringHelper
    {
        public static string TakeWordInFetters(string word, int countBrackets, char bracket)
        {
            string brakets = new string(bracket, countBrackets);

            string result = $"{brakets}{word}{brakets}";

            return result;
        }
    }
}
