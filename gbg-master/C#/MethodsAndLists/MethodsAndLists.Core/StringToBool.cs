using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MethodsAndLists.Core
{
    public class StringToBool
    {
        public bool IsPalindrome(string word)
        {
            if (word == null)
                throw new ArgumentException();

            if (!Regex.IsMatch(word, "^[a-zåäö]*$", RegexOptions.IgnoreCase))
                throw new ArgumentException();

            string reversedWord = new string(word.Reverse().ToArray());
            return word == reversedWord;
        }

        public bool IsPalindrome_ForLoop(string word)
        {
            if (word == null)
                throw new ArgumentException();

            if (!Regex.IsMatch(word, "^[a-zåäö]*$", RegexOptions.IgnoreCase))
                throw new ArgumentException();

            // 012345678
            // abcdedcba

            for (int i = 0; i < word.Length / 2; i++)
                if (word[i] != word[word.Length - i - 1])
                    return false;

            return true;
        }

        public bool IsZipCode(string text)
        {
            return Regex.IsMatch(text ?? "", @"^[1-9]\d\d [1-9]\d$");
        }
    }
}
