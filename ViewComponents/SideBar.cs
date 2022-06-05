using knowledgeBase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.ViewComponents
{
    public class SideBar : ViewComponent
    {
        public knowledgeBaseContext context = new knowledgeBaseContext();
        public IViewComponentResult Invoke()
        {
            var model = new ViewModel();
            model.Faqs = context.Faqs.OrderByDescending(u => u.Id).ToList();
            model.Articles = context.Articles.OrderByDescending(u => u.Id).ToList();
            model.Texts = context.Texts.OrderByDescending(u => u.Id).ToList();
            return View(model);
        }
    }
}
