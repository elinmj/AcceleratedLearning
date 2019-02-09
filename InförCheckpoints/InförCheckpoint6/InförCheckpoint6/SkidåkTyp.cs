using System;
using System.Collections.Generic;
using System.Text;

namespace InförCheckpoint6
{
    public class SkidåkTyp
    {
        public int Id { get; set; }
        public string typ { get; set; }

        public Skidåkare Skidåkare { get; set; }
        public int SkidåkareId { get; set; }
    }
}
