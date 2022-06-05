using System;
using System.Collections.Generic;

#nullable disable

namespace knowledgeBase.Models
{
    public partial class Faq
    {
        public int Id { get; set; }
        public string Department { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
