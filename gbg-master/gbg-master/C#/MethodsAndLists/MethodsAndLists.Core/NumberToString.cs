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
            throw new NotImplementedException();
        }

        public string TriangleReversed(int height)
        {
            throw new NotImplementedException();
        }
    }
}