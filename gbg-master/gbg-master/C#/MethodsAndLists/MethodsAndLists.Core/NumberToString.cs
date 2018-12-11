using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndLists.Core
{
    public class NumberToString
    {
        public string Triangle(int height)
        {
            if (height < 0)
            {
                throw new ArgumentException();
            }

            string triangle = "";

            for (int j = 1; j <= height; j++)
            {
                if (j > 1)
                {
                    triangle += "\n";
                }


                triangle += new string('*', j);
            }


            return triangle;
        }

        

        public string Triangle(int height, char symbol)
        {
            if (height < 0)
            {
                throw new ArgumentException();
            }

            string triangle = "";

            for (int j = 1; j <= height; j++)
            {
                if (j > 1)
                {
                    triangle += "\n";
                }


                triangle += new string(symbol, j);
            }

            return triangle;
        }

        public string TriangleReversed(int height)
        {
            if (height < 0)
            {
                throw new ArgumentException();
            }

            string triangle = "";

            for (int j = 1; j <= height; height--)
            {
                triangle += new string('*', height);

                if (height > 1)
                {
                    triangle += "\n";
                }
            }

            return triangle;
        }
    }
}