using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MethodsAndLists.Core
{
    public class StringToBool
    {
        public bool IsPalindrome(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return false;
            }
            else
            {
                char[] charArray = word.ToCharArray();
                Array.Reverse(charArray);
                string reverseWord = new string(charArray);

                if (word == reverseWord)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }   

        public bool IsZipCode(string v)
        {
            return Regex.IsMatch(v, @"^[1-9]\d\d \d\d$");
        }


        public bool FiveLettersOrLonger_True(string[] v)
        {
            //int overFiveCounter = 0;
            //int counter = 0;

            //foreach (var item in v)
            //{
            //    if (item.ToCharArray().Length >= 5)
            //    {
            //        overFiveCounter++;
            //        counter++;
            //    }
            //    else
            //    {
            //        counter++;
            //    }
            //}

            //if (overFiveCounter == counter)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return v.Any(x => x.Count() >= 5 ? true : false);
        }


        public bool FiveLettersOrLonger_False(string[] v)
        {
            //int overFiveCounter = 0;
            //int counter = 0;

            //foreach (var item in v)
            //{
            //    if (item.ToCharArray().Length >= 5)
            //    {
            //        overFiveCounter++;
            //        counter++;
            //    }
            //    else
            //    {
            //        counter++;
            //    }
            //}

            //if (overFiveCounter == counter)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return v.Any(x => x.Count() < 5 ? true : false);
        }
    }
}


