using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndLists.Core
{
    public class StringListToStringList
    {
        public IEnumerable<string> GetEverySecondElement(string[] strings)
        {
            if (strings == null)
            {
                throw new ArgumentNullException();
            }

            //List<string> newList = new List<string>();

            //int counter = 1;

            //foreach (var item in strings)
            //{

            //    if (counter % 2 == 0)
            //    {
            //        newList.Add(item);
            //    }

            //    counter++;

            //}

            //return newList;

            return strings.Where((a,x) => x % 2 != 0).ToList();

            
        }

    }
}