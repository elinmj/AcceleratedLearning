using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndLists.Core
{
    public class StringListToString
    {
        public string Frame(string[] v)
        {
            if (v == null)
            {
                throw new ArgumentException();
            }

            string frame = "";

            if (v.Length > 0)
            {
                int length = 7;

                frame += "*********\n";


                foreach (var item in v)
                {
                    char[] x = item.ToCharArray();
                    int lengthLeft = (length-1) - x.Length;
                    string fillString = new string(' ', lengthLeft);
                    frame += $"* {item}{fillString}*\n";
                    
                }

                //foreach (var item in v)
                //{
                //    frame += $"* {item} *\n";
                //}

                frame += "*********";
            }


            return frame;
        }
    }
}
