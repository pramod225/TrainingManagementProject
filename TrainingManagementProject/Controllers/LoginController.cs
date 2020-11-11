using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using TrainingManagementProject.Models;

namespace TrainingManagementProject.Controllers
{
    public class LoginController : Controller
    {
         UserDbContext db = new UserDbContext();
        // GET: Login
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtUserName, string txtPassword)
        {

            User user = db.users.Where(x => x.UserName == txtUserName && x.UserPassword == txtPassword).FirstOrDefault();
            if (user!=null)
            {
                return RedirectToAction("Index","Users");
            }
            else{
                return View();

            }


        }
    }
}