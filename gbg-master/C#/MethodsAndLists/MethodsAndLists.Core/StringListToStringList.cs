using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToStringList
    {
        public IEnumerable<string> GetEverySecondElement(string[] strings)
        {
            if (strings == null)
                throw new ArgumentNullException();

            var result = new List<string>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i % 2 == 1)
                    result.Add(strings[i]);
            }
            return result;
        }

        public IEnumerable<string> GetEverySecondElement_WithYield(string[] strings)
        {
            if (strings == null)
                throw new ArgumentNullException();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i % 2 == 1)
                    yield return strings[i];
            }
        }

        public IEnumerable<string> GetEverySecondElement_OneLiner(string[] strings)
        {
            if (strings == null)
                throw new ArgumentNullException();

            return strings.Where((x, index) => index % 2 == 1);

        }

        // Lösning med hjälpmetod:

        public IEnumerable<string> GetEverySecondElement_OneLiner_WithHelpMethod(string[] strings)
        {
            if (strings == null)
                throw new ArgumentNullException();

            return OddNumbersTo(strings.Length).Select(index => strings[index]);

        }

        public IEnumerable<int> OddNumbersTo(int lastvalue)
        {
            return Enumerable.Range(0, lastvalue).Where(index => index % 2 == 1);
        }

    }
}
