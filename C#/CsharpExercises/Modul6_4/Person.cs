using System;
using System.Collections.Generic;
using System.Text;

namespace Modul6_4
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Sport FavoriteSport { get; set; }
    }

    enum Sport
    {
        Tennis, Rugby, Soccer, Hurling, Squash
    }

    enum Gender
    {
        Female, Male, Other
    }


}
