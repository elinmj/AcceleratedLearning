using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToNumber
    {
        // Demo: räkna antalet tecken i alla strängar tillsammans

        public int ElevatorGoUpAndDown(IEnumerable<string> list)
        {
            if (list == null)
                return 0;

            int floorNumber = 0;
            foreach (string command in list)
            {
                if (command == "UPP")
                    floorNumber++;
                if (command == "NER")
                    floorNumber--;
            }

            return floorNumber;
        }

        public int ElevatorGoUpAndDown_Linq(IEnumerable<string> list)
        {
            if (list == null)
                return 0;

            return list.Count(x => x == "UPP") - list.Count(x => x == "NER");
        }

        public int ElevatorGoUpAndDown_Linq_OneLiner(IEnumerable<string> list)

        {
            if (list == null)
                return 0;

            return list.Sum(x => x == "UPP" ? 1 : x == "NER" ? -1 : 0);
        }
    }
}
