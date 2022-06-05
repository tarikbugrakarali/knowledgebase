using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.Models
{
    public class FaqViewModel
    {
        public List<Faq> questions { get; set; }
        public Faq question { get; set; }

        public List<SelectListItem> birimler;
    }
}
