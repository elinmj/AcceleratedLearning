using System;
using System.Collections.Generic;

namespace MethodsAndLists.Core
{
    public class NumberToString
    {

        public string Triangle(int height, char symbol = '*')
        {
            if (height < 0)
                throw new ArgumentException();

            List<string> starList = new List<string>();

            for (int i = 1; i <= height; i++)
                starList.Add(new string(symbol, i));

            return string.Join('\n', starList);
        }

        public string TriangleReversed(int height, char symbol = '*')
        {
            if (height < 0)
                throw new ArgumentException();

            List<string> starList = new List<string>();

            for (int i = height; i >= 1; i--)
                starList.Add(new string(symbol, i));

            return string.Join('\n', starList);
        }

    }
}
