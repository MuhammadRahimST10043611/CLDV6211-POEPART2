using Microsoft.AspNetCore.Mvc;
using POEPART1.Models;

namespace POEPART1.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();

        [HttpPost]
        public ActionResult MyWork(productTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("MyProduct", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
