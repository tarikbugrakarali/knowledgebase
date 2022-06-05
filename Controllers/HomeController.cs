using knowledgeBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace knowledgeBase.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<Login> users = new List<Login>();
        public knowledgeBaseContext context = new knowledgeBaseContext();
        private readonly IWebHostEnvironment hostEnvironment;

       public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            hostEnvironment = webHostEnvironment;
        }

        //public PartialViewResult _Layout()
        //{
        //    var model = new ViewModel();
        //    model.Faqs = context.Faqs.OrderByDescending(u => u.Id).ToList();
        //    model.Articles = context.Articles.OrderByDescending(u => u.Id ).ToList();
        //    model.Texts = context.Texts.OrderByDescending(u => u.Id).ToList();
        //    return PartialView(model);
        //}
        public IActionResult Index()
        {
            ArticlesViewModel model = new ArticlesViewModel();
            model.articles = context.Articles.ToList();
            return View(model);
        }

        public IActionResult ArticleDetail(int Id)
        {
            TextViewModel model = new TextViewModel();
            model.paper   = context.Texts .Where(d=> d.Id == Id).SingleOrDefault();
            return View(model.paper);
        }

        public IActionResult DepartmentDetail(string id)
        {
            ArticlesViewModel model = new ArticlesViewModel();
            model.articles  = context.Articles.Where(d => d.Department.Equals(id)).ToList();
            ViewBag.part = id;
            TempData["part"] = id;
            return View(model);
        }



        public IActionResult KnowledgeBase()
        {
            ArticlesViewModel model = new ArticlesViewModel();
            model.articles = context.Articles.ToList();
            return View(model);
        }

        public IActionResult Articles()
        {

            TextViewModel texts = new TextViewModel();
            texts.txt = context.Texts.ToList();
            return View(texts);
        }

        public IActionResult SSS()
        {
            FaqViewModel model = new FaqViewModel();
            model.questions = context.Faqs.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult SSS(string departman)
        {
            FaqViewModel model = new FaqViewModel();
            model.questions = context.Faqs.ToList();
            if (!departman.Equals(""))
                model.questions = context.Faqs.Where(d => d.Department.Equals(departman)).ToList();
          
            return View(model);
        }
       
       
        public IActionResult Result(string findThis)
        {
            
           
            ViewModel model = new ViewModel();

            model.Faqs = context.Faqs.Where(d => d.Question.Contains (findThis) || d.Answer.Contains(findThis)).ToList();
            model.Articles = context.Articles.Where(d => d.FileName.Contains(findThis) || d.Tag.Contains(findThis)).ToList();
            model.Texts = context.Texts.Where(d => d.Header.Contains(findThis) || d.Tag.Contains(findThis)).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            var person = new Login();
            return View(person);
        }
       
        [HttpPost]
        public IActionResult Login(Login person)
        {
            var username = person.Username;
            var password = person.Password;
            
            //int exist = 0;

            var check = context.Logins.FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));

          //  var admin = context.Logins.FirstOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password) && a.Admin == true);

            if (check != null && check.Admin == true)
            {
                return RedirectToAction("AdminPanel");
            }

            else if(check != null && check.Admin == false)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return RedirectToAction("Login");
            }
            
        }

        public IActionResult Register()
        {
            var model = new Login();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(Login model)
        {
            var username = model.Username;
            var password = model.Password;
            model.Admin = false;

            context.Logins.Add(model);
            users.Add(model);
            context.SaveChanges();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Users()
        {
            LoginViewModel users = new LoginViewModel();
            users.users = context.Logins.ToList();

            return View(users);
        }

        public IActionResult MakeAdmin()
        {
            LoginViewModel users = new LoginViewModel();
            users.users = context.Logins.ToList();
        
            return View(users);
        }
      
        [HttpPost]
        public IActionResult MakeAdmin(LoginViewModel model)
        {

            //var listOfId = context.Logins .Select(r => r.Id);
            //var roles = context.Logins.Where(r => listOfId.Contains(r.Id));

            Login updatedUser = (from c in context.Logins
                                 where c.Id == model.User.Id
                                 select c).FirstOrDefault();
            int id = updatedUser.Id;

            if (updatedUser != null)
            {
                updatedUser.Admin = true;
            }

            context.SaveChanges();
            return RedirectToAction("MakeAdmin"); 
        }


        public ActionResult FileUpload()
        {
            var model = new Article();
            return View(model);
        }

        [HttpPost]
        public IActionResult FileUpload(Article model)
        {
            string path = Path.Combine(hostEnvironment.WebRootPath,"uploads");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); // wwwroot un içine uploads klasörü oluşturur.
            }

            var completePath = Path.Combine(path, model.file.FileName);

            using(var stream = new FileStream(completePath,FileMode.Create))
            {
                 model.file.CopyToAsync(stream);
            }

            model.FileName = model.file.FileName;
            model.FilePath = model.file.FileName;

            context.Articles.Add(model);
            context.SaveChanges();
            return RedirectToAction("MakeAdmin");
        }

        public IActionResult WriteArticle()
        {
            var model = new Text();
            return View(model);
            //LoginViewModel users = new LoginViewModel();
            //users.users = context.Logins.ToList();

            //return View(users);
        }

        [HttpPost]
        public IActionResult WriteArticle(Text model)
        {

            // TextViewModel texts = new TextViewModel();
            // texts.txt = context.Texts.ToList();
            context.Texts.Add(model);
            context.SaveChanges();
            return RedirectToAction("MakeAdmin");
        }
        

        public IActionResult FAQMaker()
        {

            var model = new Faq();
            return View(model);
        }

        [HttpPost]
        public IActionResult FAQMaker(Faq model)
        {
            context.Faqs.Add(model);
            context.SaveChanges();
            return RedirectToAction("MakeAdmin");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
