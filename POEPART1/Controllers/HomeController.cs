using Microsoft.AspNetCore.Mvc;
using POEPART1.Models;
using System.Diagnostics;

namespace POEPART1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult MyProduct()
        {

            //Retrteive all products from the database
            List<productTable> products = productTable.GetAllProducts();

            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");



            //Pass products and UserID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
