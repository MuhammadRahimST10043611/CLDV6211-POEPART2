using Microsoft.AspNetCore.Mvc;
using POEPART1.Models;

namespace POEPART1.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var products = ProductDisplayModel.SelectProducts();
            return View(products);
        }
    }
}
