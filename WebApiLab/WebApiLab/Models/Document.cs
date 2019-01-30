using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLab.Models
{
    public class Document
    {
        public string Title { get; set; }
        public int? Pages { get; set; }
        public bool? Summary { get; set; }
        public DateTime? Published { get; set; }
        public decimal? Price { get; set; }
        public DocumentType Type { get; set; }
        public List<string> TagList { get; set; }
        public int? Rating { get; set; }
    }

    public enum DocumentType
    {
        PDF, HTML, TXT
    }
}
