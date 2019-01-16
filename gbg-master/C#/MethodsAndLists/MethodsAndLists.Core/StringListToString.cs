using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToString
    {
        public string Frame(string[] rows)
        {
            /*
             
            *********
            * Hello *
            * World *
            * in    *
            * a     *
            * frame *
            *********
             
             */

            if (rows == null)
                throw new ArgumentException();

            if (!rows.Any())
                return "";

            int width = rows.Max(x => x.Length) + 4;

            List<string> result = new List<string>();
            result.Add(new string('*', width));

            foreach (var row in rows)
            {
                string spaces = new string(' ', width - row.Length - 3);
                result.Add("* " + row + spaces + "*");
            }
            result.Add(new string('*', width));

            return string.Join('\n', result);
        }

    }
}
