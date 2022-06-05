using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace knowledgeBase.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Tag { get; set; }
        public string Department { get; set; }
        public string FilePath { get; set; }
       
        [NotMapped]
        public IFormFile file { get; set; }
    }
}
