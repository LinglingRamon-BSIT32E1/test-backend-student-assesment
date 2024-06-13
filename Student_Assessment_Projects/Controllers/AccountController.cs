using Microsoft.AspNetCore.Mvc;
using Student_Assessment_Projects.Models;
using Student_Assessment_Projects.Storage;

namespace Student_Assessment_Projects.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                InMemoryUserStore.Users.Add(user);
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Logon() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var loggedInUser = InMemoryUserStore.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (loggedInUser != null) 
            {
                Session["Username"] = loggedInUser.Username;
                Session["Role"] = loggedInUser.Role;

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
