using System;
using System.Collections.Generic;
using System.Text;

namespace Blogg.Domain
{
    public class Blogpost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Tag { get; set; }
        public string Comment { get; set; }
    }
}
