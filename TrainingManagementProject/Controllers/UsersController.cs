using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainingManagementProject.Models;

namespace TrainingManagementProject.Controllers
{
    public class UsersController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: Users
        void InitilazieRoles()
        {

            Role role1 = new Role { id = 1, RoleName = "User" };
            Role role2 = new Role { id = 2, RoleName = "Manager" };
            Role role3 = new Role() { id = 3,RoleName = "Admin" };
            db.roles.Add(role1); db.roles.Add(role2); db.roles.Add(role3);
            db.SaveChanges();

        }
        public UsersController()
        {
            if (db.roles.Count() == 0)
            {
                InitilazieRoles();
            }

        }
        List<SelectListItem> GetManagers()
        {
           
            var query = from p in db.users
            where p.RoleId == 2
            select new { p.ManagerId, p.UserFirstName, p.UserLastName };
            List<SelectListItem> managersList = new List<SelectListItem>();
            foreach (var element in query)
            {
                managersList.Add(new SelectListItem
                            {
                    Value = element.ManagerId.ToString(),
                    Text = element.UserFirstName.ToString() + " " + element.UserLastName.ToString()
                });
            }
            return managersList;
        }

        List<SelectListItem> FillRoles()
        {
            List<SelectListItem> roleList = new List<SelectListItem>() {
            new SelectListItem
            {
                Text = "User",
                Value = "1"
            },
        new SelectListItem
        {
            Text = "Manager",
            Value = "2"
        },
        };
            return roleList;
        }
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.roles = FillRoles();
            ViewBag.managerList = GetManagers();
            return View();
        }
       
        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UserName,UserPassword,UserFirstName,UserLastName,UserDateOfJoining,UserEmailId,RoleId,ManagerId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserName,UserPassword,UserFirstName,UserLastName,UserDateOfJoining,UserEmailId,RoleId,ManagerId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
