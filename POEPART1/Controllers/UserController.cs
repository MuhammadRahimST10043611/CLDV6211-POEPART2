using Microsoft.AspNetCore.Mvc;
using POEPART1.Models;

namespace POEPART1.Controllers
{
    public class UserController : Controller
    {
        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult SignUp(userTable users)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = usrtbl.insert_User(users);
                    if (result == 1)
                    {
                        // Redirect on success
                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {
                        // Handle the case where insert_User returns false (e.g., an error occurred)
                        ModelState.AddModelError(string.Empty, "Failed to insert user. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (not shown in this code snippet)
                    ModelState.AddModelError(string.Empty, "An error occurred. Please try again.");
                }
            }

            // If we reach here, it means something went wrong
            return View(users); // Return the view with the user data so they can correct their input
        }


        [HttpGet]
        public ActionResult SignUp()
        {
            return View(usrtbl);
        }
    }
}


