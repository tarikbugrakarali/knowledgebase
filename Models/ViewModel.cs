using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.Models
{
    public class ViewModel
    {
        public List<Article> Articles { get; set; }
        public List<Faq > Faqs { get; set; }
        public List<Text> Texts  { get; set; }
    }
}
