using System;
using System.Collections.Generic;
using System.Text;

namespace InförCheckpoint6
{


    public class Skidåkare
    {

        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

        public List<SkidåkTyp> SkidåkTyps { get; set; }

    }
}
