using Microsoft.AspNetCore.Mvc;
using MySurvey.Models;
using System.Diagnostics;


namespace MySurvey.Controllers
{
    

    public class HomeController : Controller
    {
        private bool loggedIn = false;
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = loggedIn;
            
            return View();
            
        }
        public IActionResult Index2(String email, String pwd)
        {
            ViewBag.IsLoggedIn = loggedIn;
            if (email == null)
            {
                email = "";
            }
            if (pwd == null)
            {
                pwd = "";
            }
            if (email.Equals("odahuber@gmail.com") && pwd.Equals("1234"))
            {
                loggedIn = true;

            }
            ViewBag.IsLoggedIn = loggedIn;
            return View();

        }


        public IActionResult Privacy()
        {
            ViewBag.IsLoggedIn = loggedIn;
            return View();
        }
        public IActionResult Login()
        {
            ViewBag.IsLoggedIn = loggedIn;
            return View();
        }

        public IActionResult Catalogo()
        {
            ViewBag.IsLoggedIn = true;
            return View();
        }
        public IActionResult Encuesta()
        {
            ViewBag.IsLoggedIn = true;
            return View();
        }

        /*public  void Validate(String email, String pwd)
        {
            
            if (email == null)
            {
                email = "";
            }
            if (pwd == null)
            {
                pwd = "";
            }
            if (email.Equals("odahuber@gmail.com") && pwd.Equals("1234"))
            {
                loggedIn = true;
                
            }
            else
            {
              
            }
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}