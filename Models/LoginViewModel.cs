using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.Models
{
    public class LoginViewModel
    {
        public List<Login> users { get; set; }
        public Login User { get; set; }
    }
}
