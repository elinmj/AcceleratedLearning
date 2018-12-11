using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodsAndLists.Core
{
    public class StringListToNumber
    {
        public int ElevatorGoUpAndDown(string[] input)
        {
            if (input == null)
            {
                return 0;
            }

            int floor = 0;

            foreach (var item in input)
            {
                if ( item =="UPP")
                {
                    floor++;
                }
                else
                {
                    floor--;
                }
            }

            return floor;
        }

        public int ElevatorGoUpAndDown_Linq(string[] input)
        {
            //int y = 0;
            //input.Sum(x => x == "UPP" ? y++ : y--);
            //return y;

            return input.Sum(x => x == "UPP" ? 1 : -1);
        }
    }
}
