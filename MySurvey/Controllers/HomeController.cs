using Microsoft.AspNetCore.Mvc;
using MySurvey.Models;
using System.Diagnostics;


namespace MySurvey.Controllers
{
    

    public class HomeController : Controller
    {
        private bool loggedIn = false;
        private bool admin=false;
        private bool directivo = false;
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
            
        }

        public IActionResult Index()
        {
            // Obtiene el valor de la sesión "IsLoggedIn" y lo establece en ViewBag.IsLoggedIn.
            ViewBag.IsLoggedIn = Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"];
            ViewBag.IsAdmin = Session["IsAdmin"] != null && (bool)Session["IsAdmin"];
            ViewBag.IsDirectivo = Session["IsDirectivo"] != null && (bool)Session["IsDirectivo"];

            return View();
        }

        public IActionResult Verificar(string email, string pwd)
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
                Session["IsLoggedIn"] = true;
                Session["IsAdmin"] = true;
                Session["IsDirectivo"] = true;
                ViewBag.Name = "Oscar Huber";
            }
            else if (email.Equals("oda@gmail.com") && pwd.Equals("1234"))
            {
                Session["IsLoggedIn"] = true;
                Session["IsAdmin"] = false;
                Session["IsDirectivo"] = true;
                ViewBag.Name = "Daniel Ortega";
            }
            else if (email.Equals("a@a.a") && pwd.Equals("1234"))
            {
                Session["IsLoggedIn"] = true;
                Session["IsAdmin"] = false;
                Session["IsDirectivo"] = false;
                ViewBag.Name = "Oscar Ortega";
            }
            else
            {
                Session["IsLoggedIn"] = false;
                ViewBag.Message = "Usuario o contraseña incorrectos";
                return View("Login");
            }

            // Después de actualizar las sesiones, redirecciona a la acción "Index".
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            ViewBag.IsLoggedIn = loggedIn;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
            return View();
        }
        public IActionResult Login()
        {
            ViewBag.IsLoggedIn = loggedIn;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
            return View();
        }

        public IActionResult Catalogo()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
            return View();
        }
        public IActionResult Encuesta()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
            return View();
        }
        public IActionResult AdministrarCatalogo()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
            return View();
        }
        public IActionResult Resultados ()
        {
            ViewBag.IsLoggedIn = true;
            ViewBag.IsAdmin = admin;
            ViewBag.IsDirectivo = directivo;
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