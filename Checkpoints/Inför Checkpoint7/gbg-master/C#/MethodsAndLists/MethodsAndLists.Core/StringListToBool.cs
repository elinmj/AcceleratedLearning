using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToBool
    {
        // Demo: Returerna "true" om längen på alla ord tillsammans är större än 10

        public bool AllWordsAreFiveLettersOrLonger(IEnumerable<string> list)
        {
            if (list == null)
                return false;

            if (list.Count() == 0)
                return false;

            bool result = true;

            foreach (var item in list)
            {
                if (item.Length < 5)
                    result = false;
            }

            return result;
        }

        public bool AllWordsAreFiveLettersOrLonger_Linq(IEnumerable<string> list)
        {
            return list != null && !list.Any(x => x.Count() < 5);
        }
    }
}
