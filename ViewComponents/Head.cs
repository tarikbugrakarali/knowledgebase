﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace knowledgeBase.ViewComponents
{
    public class Head: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
