using System;
using System.Collections.Generic;

#nullable disable

namespace knowledgeBase.Models
{
    public partial class Text
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Tag { get; set; }
        public string Date { get; set; }
        public string Department { get; set; }
        public string Article { get; set; }
    }
}
